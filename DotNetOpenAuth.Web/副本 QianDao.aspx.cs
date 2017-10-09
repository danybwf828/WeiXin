using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using DotNetOpenAuth.DataAccess;
using DotNetOpenAuth.SDK;

//来自：http://www.DotNetOpenAuth.com
namespace DotNetOpenAuth.Web
{//来自：http://www.DotNetOpenAuth.com
    //测试地址：http://qydev.weixin.qq.com/debug
    //文档地址：http://qydev.weixin.qq.com/wiki/index.php
    public partial class QianDao : System.Web.UI.Page
    {
        public string appId = "", timestamp = "", nonceStr = "", signature = "", secret = "", userID = "", deviceId = "", debug = "", userInfo2 = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            bool breakWrite = false;
            try
            {
                string state = Request["state"];
                if (state == "Sign")
                { //插入签到数据
                    string lat = Request["lat"], lng = Request["lng"], userID = Request["userID"], deviceId = Request["deviceId"];
                    RstArray rst = new RstArray();
                    rst.Msg = "签到失败 0";
                    rst.Ret = Sign.AddSign(userID, deviceId, lat, lng);
                    if (rst.Ret != 0)
                    {
                        rst.Msg = "签到成功";
                    }
                    Response.Clear();
                    Response.Write(rst.Msg);
                    breakWrite = true;
                }
                else
                {
                    /*
    1.参考以下文档获取access_token（有效期7200秒，开发者必须在自己的服务全局缓存access_token）：http://qydev.weixin.qq.com/wiki/index.php?title=%E4%B8%BB%E5%8A%A8%E8%B0%83%E7%94%A8 
    2.用第一步拿到的access_token 采用http GET方式请求获得jsapi_ticket（有效期7200秒，开发者必须在自己的服务全局缓存jsapi_ticket）：https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=ACCESS_TOKE 
    获得jsapi_ticket之后，就可以生成JS-SDK权限验证的签名了。                 
                     * 签名算法 
    签名生成规则如下：参与签名的字段包括noncestr（随机字符串）, 有效的jsapi_ticket, timestamp（时间戳）, url（当前网页的URL，不包含#及其后面部分） 。对所有待签名参数按照字段名的ASCII 码从小到大排序（字典序）后，使用URL键值对的格式（即key1=value1&key2=value2…）拼接成字符串string1。这里需要注意的是所有参数名均为小写字符。对string1作sha1加密，字段名和字段值都采用原始值，不进行URL 转义。 
                     */
                    appId = ConfigurationManager.AppSettings["AppID"];
                    secret = ConfigurationManager.AppSettings["Secret"];
                    string url = Request.Url.ToString();

                    Helper.WriteLog("AppID:" + appId);
                    Helper.WriteLog("secret:" + secret);
                    Helper.WriteLog("url:" + url);

                    string token = Caches.GetAccessToken(appId, secret);
                    Helper.WriteLog("token:" + token);

                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        string code = Request["code"];
                        if (string.IsNullOrWhiteSpace(code))
                        {
                            Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appId + "&redirect_uri=" + HttpUtility.HtmlEncode(url) + "&response_type=code&scope=SCOPE&state=qiandao#wechat_redirect");
                        }
                        else
                        {
                            int agentid = Convert.ToInt32(ConfigurationManager.AppSettings["AgentID"]);
                            UserInfo ui = OpenApi.GetUserInfo(token, code, agentid);
                            
                            if (ui != null)
                            {
                                userID = ui.UserId;
                                deviceId = ui.DeviceId;
                                Helper.WriteLog("userID:" + userID);
                                Helper.WriteLog("deviceId:" + deviceId);
                                UserInfo2 ui2 = OpenApi.GetUserInfo2(token, userID);
                                string userName = ui2.name;
                                string position = ui2.position;
                                string mobile = ui2.mobile;
                                string[] department = ui2.department;
                                Helper.WriteLog("department:" + department[0]);
                                int isleader = ui2.isleader;
                                string strTmpDp = "";
                                for (int i = 0; i < department.Length; i++)
                                {
                                    string txlsecret = "i_v6R_C3vdd-FJ34nwZ9aH6hTptwqTTp8U8SvKapyWQ";
                                    string txltoken = Caches.GetAccessToken(appId, txlsecret);
                                    strTmpDp = getDPstr(txltoken, department[i], strTmpDp);
                                    strTmpDp = "部门" + i.ToString() + ":" + strTmpDp + "\r\n";
                                }
                                userID = "姓名:" + userName + ";职位:" + position + ";手机号码:" + mobile + ";是否领导:" + isleader.ToString() + ";" + Environment.NewLine + strTmpDp;
                                TextBox1.Text = userID;
                                Helper.WriteLog("userInfo2:" + userID);

                                //string surl = "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token=" + token;
                                //string param = "{\"name\":\"部门测试\",\"parentid\":\"1\",\"order\":\"1\",\"id\":\"2\"}";
                                //string postCallBack = HttpHelper.Post(surl, param);
                                //Helper.WriteLog("postCallBack:" + postCallBack);

                            }
                            else
                            {
                                userID = "准备就绪！";
                            }
                            string jsapi_ticket = Caches.GetJsTicket(token);

                            timestamp = (OpenApi.GetTime() / 1000).ToString();
                            nonceStr = OpenApi.NewGuid();

                            Dictionary<string, string> paramaters = new Dictionary<string, string>();
                            paramaters.Add("noncestr", nonceStr);
                            paramaters.Add("jsapi_ticket", jsapi_ticket);
                            paramaters.Add("timestamp", timestamp);
                            paramaters.Add("url", url);
                            signature = OpenApi.MakeSig(paramaters, nonceStr);

                            debug = "noncestr=" + nonceStr + "&jsapi_ticket=" + jsapi_ticket + "&signature=" + signature + "&,timestamp=" + timestamp + "&url=" + url;

                            //Helper.WriteLog("debug:" + debug);

                        }
                    }
                    else
                    {
                        Response.Clear();
                        Response.Write("获取Token失败");
                        breakWrite = true;
                    }
                }
            }
            catch (ThreadAbortException)
            { 
            }
            catch(Exception ex)
            {
                Response.Clear();
                Response.Write("签到失败 : " + ex.Message);
                breakWrite = true;
            }
            if (breakWrite)
            {
                Response.End();
                return;
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            AspNetPager1.RecordCount = BBdv.Table.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = BBdv;

            GridView1.DataSource = pds;
            GridView1.DataBind();
        }
        public string getDPstr(string dpToken,string dpId,string TmpDp)
        {
            DepartmentList dplst = OpenApi.GetDp(dpToken, dpToken);

            string strTmpDp = TmpDp;
            string strPdpid = "";
            for (int k = 0; k < dplst.department.Count; k++)
            {
                if (dplst.department[k].id == dpId)
                {
                    strTmpDp = dplst.department[k].name + "->" + strTmpDp;
                    strPdpid = dplst.department[k].parentid;
                }
            }
            if (dpId == "1") { return strTmpDp; }
            else { strTmpDp = getDPstr(dpToken, strPdpid, strTmpDp); }
            return strTmpDp;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}