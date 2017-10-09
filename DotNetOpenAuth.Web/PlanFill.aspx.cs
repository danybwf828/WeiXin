using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using DotNetOpenAuth.DataAccess;
using DotNetOpenAuth.SDK;
using ComputerRepair.DataAccessLayer;

//来自：http://www.DotNetOpenAuth.com
namespace DotNetOpenAuth.Web
{//来自：http://www.DotNetOpenAuth.com
    //测试地址：http://qydev.weixin.qq.com/debug
    //文档地址：http://qydev.weixin.qq.com/wiki/index.php
    public partial class PlanFill : System.Web.UI.Page
    {
        public string appId = "", timestamp = "", nonceStr = "", signature = "", secret = "", userID = "", deviceId = "", debug = "", userInfo2 = "", userName = "",uMode="";

        public static Database db = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bool breakWrite = false;
                db = new Database();
                int weekNum = GetWeekNum(DateTime.Now.DayOfWeek.ToString());
                this.Date1.Value = DateTime.Now.AddDays(8 - weekNum).ToString("yyyy-MM-dd");
                this.Date2.Value = DateTime.Now.AddDays(14 - weekNum).ToString("yyyy-MM-dd");
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
                        #region
                        /*
        1.参考以下文档获取access_token（有效期7200秒，开发者必须在自己的服务全局缓存access_token）：http://qydev.weixin.qq.com/wiki/index.php?title=%E4%B8%BB%E5%8A%A8%E8%B0%83%E7%94%A8 
        2.用第一步拿到的access_token 采用http GET方式请求获得jsapi_ticket（有效期7200秒，开发者必须在自己的服务全局缓存jsapi_ticket）：https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=ACCESS_TOKE 
        获得jsapi_ticket之后，就可以生成JS-SDK权限验证的签名了。                 
                         * 签名算法 
        签名生成规则如下：参与签名的字段包括noncestr（随机字符串）, 有效的jsapi_ticket, timestamp（时间戳）, url（当前网页的URL，不包含#及其后面部分） 。对所有待签名参数按照字段名的ASCII 码从小到大排序（字典序）后，使用URL键值对的格式（即key1=value1&key2=value2…）拼接成字符串string1。这里需要注意的是所有参数名均为小写字符。对string1作sha1加密，字段名和字段值都采用原始值，不进行URL 转义。 
                         */
                        appId = ConfigurationManager.AppSettings["AppID"];
                        secret = ConfigurationManager.AppSettings["SecretPlanFill"];
                        string url = Request.Url.ToString();
                        string token = Caches.GetAccessToken(appId, secret, "PlanFQ_access_token");
                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            string code = Request["code"];
                            if (string.IsNullOrWhiteSpace(code))
                            {
                                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appId + "&redirect_uri=" + HttpUtility.HtmlEncode(url) + "&response_type=code&scope=SCOPE&state=qiandao#wechat_redirect");
                            }
                            else
                            {
                                int agentid = Convert.ToInt32(ConfigurationManager.AppSettings["AgentIDPlanFill"]);
                                UserInfo ui = OpenApi.GetUserInfo(token, code, agentid);
                                if (ui != null)
                                {
                                    userID = ui.UserId; Session["uId"] = ui.UserId;
                                    deviceId = ui.DeviceId; 
                                    UserInfo2 ui2 = OpenApi.GetUserInfo2(token, userID);
                                    userName = ui2.name; Session["uName"] = ui2.name;
                                    string position = ui2.position;
                                    string mobile = ui2.mobile;
                                    string[] department = ui2.department;
                                    int isleader = ui2.isleader;
                                    string strTmpDp = "";//部门链名称全字符串
                                    string strTmpDpId = "";//上级部门链ID全字符串
                                    for (int i = 0; i < department.Length; i++)
                                    {
                                        if (i == department.Length - 1)//如果部门大于1个，默认使用最后一个
                                        {
                                            Session["uDpId"] = department[i];
                                            string[] strMsg = FillUser(userID, userName, department[i]);
                                            strTmpDp = strMsg[0];
                                            strTmpDpId = strMsg[1];
                                        }
                                    }
                                    string[] strDptmp = strTmpDp.Split('>');
                                    string strDptmp2 = strDptmp[strDptmp.Length - 1];//最终端部门名称
                                    Session["uDp"] = strDptmp2;
                                    Session["uSDpId"] = strTmpDpId;
                                    string strTmpDp3 = strTmpDp.Replace(strDptmp2, "");
                                    string strTmpDp4 = strTmpDp;
                                    for (int i = 0; i < strDptmp.Length; i++)
                                    {
                                        if (strDptmp[i].Contains("中塔泽拉夫尚")||
                                            strDptmp[i].Contains("奥同克") ||
                                            strDptmp[i].Contains("诺顿金田") ||
                                            strDptmp[i].Contains("巴理克") ||
                                            strDptmp[i].Contains("穆索诺伊") ||
                                            strDptmp[i].Contains("卡莫阿") ||
                                            strDptmp[i].Contains("恩科维铂业") ||
                                            strDptmp[i].Contains("秘鲁白河") ||
                                            strDptmp[i].Contains("金璞国际") ||
                                            strDptmp[i].Contains("塔吉克斯坦") ||
                                            strDptmp[i].Contains("黑龙江龙兴") ||
                                            strDptmp[i].Contains("蒙特瑞科")) { strTmpDp4 = strDptmp[i]; }
                                    }
                                    this.TBupDp.Text = strTmpDp4; Session["uDp2"] = strTmpDp4; Session["uUpDp"] = strTmpDp;
                                    this.TBuserName.Text = userName;
                                    this.TBmobile.Text = mobile;
                                    Helper.WriteLog("登陆人:" + userName + "[" + userID + "]--" + strTmpDp4 + "[" + strTmpDpId + "]", "PlanFill");
                                    //string mainInfo = "姓名:" + userName + ";职位:" + position + ";手机号码:" + mobile + ";是否领导:" + isleader.ToString() + ";" + Environment.NewLine + strTmpDp2;
                                    //Helper.WriteLog("userInfo2:" + mainInfo);

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

                                timestamp = OpenApi.GetTime().ToString();
                                nonceStr = OpenApi.NewGuid();

                                Dictionary<string, string> paramaters = new Dictionary<string, string>();
                                paramaters.Add("noncestr", nonceStr);
                                paramaters.Add("jsapi_ticket", jsapi_ticket);
                                paramaters.Add("timestamp", timestamp);
                                paramaters.Add("url", url);
                                signature = OpenApi.MakeSig(paramaters, nonceStr);

                                debug = "noncestr=" + nonceStr + "&jsapi_ticket=" + jsapi_ticket + "&signature=" + signature + "&,timestamp=" + timestamp + "&url=" + url;
                            }
                        }
                        else
                        {
                            Response.Clear();
                            Response.Write("获取Token失败");
                            breakWrite = true;
                        }
                        #endregion
                    }
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception ex)
                {
                    Response.Clear();
                    Response.Write("错误 : " + ex.Message);
                    breakWrite = true;
                }
                if (breakWrite) { Response.End(); return; }
            }
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            //AspNetPager1.RecordCount = BBdv.Table.Rows.Count;
            //PagedDataSource pds = new PagedDataSource();
            //pds.AllowPaging = true;
            //pds.PageSize = AspNetPager1.PageSize;
            //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            //pds.DataSource = BBdv;

            //GridView1.DataSource = pds;
            //GridView1.DataBind();
        }

        /// <summary>
        /// 填充查询权限表
        /// </summary>
        /// <param name="txlToken"></param>
        public void FillUserList(string txlToken) 
        {
            UserList ulTmp = OpenApi.GetUserList(txlToken, "1", 1);
            string[] sqltmp = new string[ulTmp.userlist.Count];
            for (int k = 0; k < ulTmp.userlist.Count; k++)
            {
                //string strdp = getDPstr(txlToken, ulTmp.userlist[k].department.ToString(), "").Replace("紫金矿业集团>", "");
                string strSQL = "insert into wxQueryAuthority(userId,userName,userDpId,userDpName,isAllow,QueryDpId,QueryDpName,QueryUserId,QueryUserName)values('" + ulTmp.userlist[k].userid + "','" + ulTmp.userlist[k].name + "','" + ulTmp.userlist[k].department[0] + "','" + "" + "','" + "0" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "')";
                sqltmp[k] = strSQL;
            }
            db.ExecuteSQL(sqltmp);
        }

        public string[] FillUser(string strUserId,string userName,string strDpId)
        {
            DataView dv = new DataView();
            string[] strMsg = new string[2];
            string strSQl01 = "select id,userId,userName,userDpId,userSDpId,userDpName,isAllow,PushDpId,PushDpName,PushUserId,PushUserName from wxPushAuthority where userId like '%" + Session["uId"] + "%'";
            string strSQL02 = "";
            string strDpId2 = "";
            string strDpName2 = "";
            dv = db.GetDataView(strSQl01);

            if (dv.Count < 1)
            {
                string txlsecret = "i_v6R_C3vdd-FJ34nwZ9aH6hTptwqTTp8U8SvKapyWQ";
                string txltoken = Caches.GetAccessToken(appId, txlsecret, "TXL_access_token");
                strDpName2 = getDPstr(txltoken, strDpId, "").Replace("紫金矿业集团>", "");
                strDpId2 = getDPIDstr(txltoken, strDpId, "");
                strSQL02 = "insert into wxPushAuthority(userId,userName,userDpId,userSDpId,userDpName,isAllow,PushDpId,PushDpName,PushUserId,PushUserName)values('" + strUserId + "','" + userName + "','" + strDpId + "','" + strDpId2 + "','" + strDpName2 + "','" + "0" + "','" + "" + "','" + "" + "','" + strUserId + "','" + "" + "')";
                db.ExecuteSQL(strSQL02);
            }
            else 
            {
                if (string.IsNullOrEmpty(dv.Table.Rows[0]["userDpName"].ToString()) || string.IsNullOrEmpty(dv.Table.Rows[0]["userSDpId"].ToString()) || dv.Table.Rows[0]["userDpId"].ToString() != strDpId)
                {
                    string txlsecret = "i_v6R_C3vdd-FJ34nwZ9aH6hTptwqTTp8U8SvKapyWQ";
                    string txltoken = Caches.GetAccessToken(appId, txlsecret, "TXL_access_token");
                    //Helper.WriteLog("txltoken:" + txltoken);
                    strDpName2 = getDPstr(txltoken, strDpId, "").Replace("紫金矿业集团>", "");
                    strDpId2 = getDPIDstr(txltoken, strDpId, "");
                    strSQL02 = "update wxPushAuthority set userDpId = '" + strDpId + "', userSDpId = '" + strDpId2 + "', userDpName = '" + strDpName2 + "' where userId = '" + strUserId + "'";
                    db.ExecuteSQL(strSQL02);
                }
                else { strDpName2 = dv.Table.Rows[0]["userDpName"].ToString(); strDpId2 = dv.Table.Rows[0]["userSDpId"].ToString(); }
            }

            string strSQl03 = "select id,userId,userName,userDpId,userSDpId,userDpName,isAllow,QueryDpId,QueryDpName,QueryUserId,QueryUserName from wxQueryAuthority where userId like '%" + Session["uId"] + "%'";
            string strSQL04 = "";
            dv = db.GetDataView(strSQl03);
            if (dv.Count < 1)
            {
                strSQL04 = "insert into wxQueryAuthority(userId,userName,userDpId,userSDpId,userDpName,isAllow,QueryDpId,QueryDpName,QueryUserId,QueryUserName)values('" + strUserId + "','" + userName + "','" + strDpId + "','" + strDpId2 + "','" + strDpName2 + "','" + "0" + "','" + "" + "','" + "" + "','" + strUserId + "','" + "" + "')";
                db.ExecuteSQL(strSQL04);
            }
            else
            {
                if (string.IsNullOrEmpty(dv.Table.Rows[0]["userDpName"].ToString()) || string.IsNullOrEmpty(dv.Table.Rows[0]["userSDpId"].ToString()) || dv.Table.Rows[0]["userDpId"].ToString() != strDpId)
                {
                    strSQL04 = "update wxQueryAuthority set userDpId = '" + strDpId + "', userSDpId = '" + strDpId2 + "', userDpName = '" + strDpName2 + "' where userId = '" + strUserId + "'";
                    db.ExecuteSQL(strSQL04);
                }
            }
            strMsg[0] = strDpName2; strMsg[1] = strDpId2;
            return strMsg;
        }

        /// <summary>
        /// 获取星期几数字
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public int GetWeekNum(string strData)
        {
            string strDayOfWeek = strData;
            int intWeekday = -1;
            switch (strDayOfWeek)
            {
                case "Monday":
                    intWeekday = 1;
                    break;
                case "Tuesday":
                    intWeekday = 2;
                    break;
                case "Wednesday":
                    intWeekday = 3;
                    break;
                case "Thursday":
                    intWeekday = 4;
                    break;
                case "Friday":
                    intWeekday = 5;
                    break;
                case "Saturday":
                    intWeekday = 6;
                    break;
                case "Sunday":
                    intWeekday = 7;
                    break;
                default:
                    intWeekday = -1;
                    break;
            }
            return intWeekday;
        }

        /// <summary>
        /// 获取部门链字符串
        /// </summary>
        /// <param name="dpToken"></param>
        /// <param name="dpId"></param>
        /// <param name="TmpDp"></param>
        /// <returns></returns>
        public string getDPstr(string dpToken, string dpId, string TmpDp)
        {
            DepartmentList dplst = OpenApi.GetDp(dpToken, dpId);

            string strTmpDp = TmpDp;
            string strPdpid = "";
            for (int k = 0; k < dplst.department.Count; k++)
            {
                if (dplst.department[k].id == dpId)
                {
                    if (strTmpDp == "") { strTmpDp = dplst.department[k].name; } else { strTmpDp = dplst.department[k].name + ">" + strTmpDp; }
                    strPdpid = dplst.department[k].parentid;
                }
            }
            if (dpId == "1") { return strTmpDp; }
            else { strTmpDp = getDPstr(dpToken, strPdpid, strTmpDp); }
            return strTmpDp;
        }

        /// <summary>
        /// 获取部门链ID字符串
        /// </summary>
        /// <param name="dpToken"></param>
        /// <param name="dpId"></param>
        /// <param name="TmpDp"></param>
        /// <returns></returns>
        public string getDPIDstr(string dpToken, string dpId, string TmpDp)
        {
            DepartmentList dplst = OpenApi.GetDp(dpToken, dpId);

            string strTmpDp = TmpDp;
            string strPdpid = "";
            for (int k = 0; k < dplst.department.Count; k++)
            {
                if (dplst.department[k].id == dpId)
                {
                    if (strTmpDp == "") { strTmpDp = dplst.department[k].id; } else { strTmpDp = dplst.department[k].id + ">" + strTmpDp; }
                    strPdpid = dplst.department[k].parentid;
                }
            }
            if (dpId == "1") { return strTmpDp; }
            else { strTmpDp = getDPIDstr(dpToken, strPdpid, strTmpDp); }
            return strTmpDp;
        }

        /// <summary>
        /// 检查页面输入项
        /// </summary>
        /// <returns></returns>
        public bool BBcheckPage()
        {
            if (string.IsNullOrEmpty(this.Date1.Value)) { Show(this, "请输入起始时间!"); return false; }
            if (string.IsNullOrEmpty(this.Date2.Value)) { Show(this, "请输入结束时间!"); return false; }
            if (string.IsNullOrEmpty(this.TextBox2.Text)) { Show(this, "请输入计划内容!"); return false; }
            if (string.IsNullOrEmpty(this.TBplaceInfo.Text)) { Show(this, "请输入具体地点!"); return false; }
            return true;
        }

        /// <summary>
        /// 检查输入时间区间
        /// </summary>
        /// <returns></returns>
        public bool BBcheckPlanTime()
        {
            DataTable dt1 = uPlan.GetUserPlan(Session["uId"].ToString(), Session["uName"].ToString());
            foreach (DataRow dr in dt1.Rows)
            {
                if (Convert.ToDateTime(this.Date1.Value) >= Convert.ToDateTime(dr[2].ToString()) && Convert.ToDateTime(this.Date1.Value) <= Convert.ToDateTime(dr[3].ToString()))
                {
                    Show(this, "考勤区间已有计划内容!"); return false;
                }
                if (Convert.ToDateTime(this.Date2.Value) >= Convert.ToDateTime(dr[2].ToString()) && Convert.ToDateTime(this.Date2.Value) <= Convert.ToDateTime(dr[3].ToString()))
                {
                    Show(this, "考勤区间已有计划内容!"); return false;
                }
            }
            return true; 
        }

        /// <summary>
        /// 查詢push表中登錄人（session["uId"]）推送設置
        /// </summary>
        /// <returns></returns>
        public string[] BBcheckPushAuthority()
        {
            DataView dv = new DataView();
            string[] strUserNDp = new string[3];
            string strSql01 = "select id,userId,userName,userDpId,userDpName,isAllow,PushDpId,PushDpName,PushUserId,PushUserName from wxPushAuthority where userId like '%" + Session["uId"] + "%'";
            dv = db.GetDataView(strSql01);
            try
            {
                if (dv.Count < 1) { return strUserNDp; }
                else if (string.IsNullOrEmpty(dv[0][5].ToString())) { return strUserNDp; }
                else
                {
                    string strIsAllow = dv[0][5].ToString();
                    string strQueryDpId = dv[0][6].ToString();
                    string strQueryUserId = dv[0][8].ToString();
                    strUserNDp[0] = strIsAllow;
                    strUserNDp[1] = strQueryDpId;
                    strUserNDp[2] = strQueryUserId;
                    return strUserNDp;
                }
            }
            catch { return strUserNDp; } 
        }

        /// <summary>
        /// push表中isAllow=1查询（该用户全局接收推送）
        /// </summary>
        /// <returns></returns>
        public string BBcheckPushAuthority2()
        {
            DataView dv = new DataView();
            string strUserPush = "";
            string strSql01 = "select id,userId,userName,userDpId,userDpName,isAllow,PushDpId,PushDpName,PushUserId,PushUserName from wxPushAuthority where isAllow = '1'";
            dv = db.GetDataView(strSql01);
            try
            {
                if (dv.Count < 1) { return strUserPush; }
                else
                {
                    foreach (DataRow dr in dv.Table.Rows)
                    {
                        //if (dr["isAllow"].ToString() == "1") { strUserPush = strUserPush + dr["userId"].ToString() + ","; }
                        strUserPush = strUserPush + dr["userId"].ToString() + ","; 
                    }
                    return strUserPush;
                }
            }
            catch { return strUserPush; }
        }

        /// <summary>
        /// 弹窗
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public void Show(System.Web.UI.Page page, string msg)
        {
            Response.Write("<script>alert('" + msg + "')</script>");
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string bbPlace = "";
            if (BBcheckPage() && BBcheckPlanTime()) 
            {
                if (this.RadioButton1.Checked) { uMode = this.RadioButton1.Text; }
                if (this.RadioButton2.Checked) { uMode = this.RadioButton2.Text; }
                if (this.RadioButton3.Checked) { uMode = this.RadioButton3.Text; }

                if (this.RadioButton4.Checked) { bbPlace = this.RadioButton4.Text; }
                if (this.RadioButton5.Checked) { bbPlace = this.RadioButton5.Text; }

                string bbPlaceInfo = this.TBplaceInfo.Text;
                string strSQL = "insert into wxPlan(uId,LastOperatePerId,uName,LastOperatePerson,department,departmentId,department2,Superior_department,Superior_departmentId,uStarTime,uStopTime,uPlan,uMode,uState,createTime,timestamp,uPlace,uPlaceInfo)values('" + Session["uId"] + "','" + Session["uId"] + "','" + Session["uName"] + "','" + Session["uName"] + "','" + Session["uDp"] + "','" + Session["uDpId"] + "','" + Session["uDp2"] + "','" + Session["uUpDp"] + "','" + Session["uSDpId"] + "','" + Date1.Value + "','" + Date2.Value + "','" + TextBox2.Text + "','" + uMode + "','正常','" + DateTime.Now.ToString("yyyyMMddHHmmss") + "','" + DateTime.Now.ToString("yyyyMMddHHmmss") + "','" + bbPlace + "','" + bbPlaceInfo + "')";
                db.ExecuteSQL(strSQL);
                Show(this, "提交成功!");

                string[] strPAmsg = new string[3];
                strPAmsg = BBcheckPushAuthority();//查找登陆人Push表中的配置
                string strPAmsg2="";
                strPAmsg2 = BBcheckPushAuthority2();//查找Push表中的isallow=1的行的userId，直接推送

                string strPushUser = strPAmsg2.Replace(",", "|") + "|" + strPAmsg[2].Replace(",", "|") + Session["uId"];//推送人配置
                string strPushDp = strPAmsg[1].Replace(",", "|");//推送部門配置
                int agentid = Convert.ToInt32(ConfigurationManager.AppSettings["AgentIDPlanFill"]);
                string strAll = "@all";
                string strTextCard = "textcard";
                string strText = "text";
                string suite_access_token = Caches.GetAccessToken(appId, secret, "PlanFQ_access_token");
                string surl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + suite_access_token;
                string param = "{\"touser\":\"" + strPushUser + "\",\"toparty\":\"" + strPushDp + "\",\"totag\":\"" + strAll + "\",\"msgtype\":\"" + strTextCard + "\",\"agentid\":\"" + agentid + "\",\"textcard\":" + "{\"title\":\"" + Session["uName"] + "\n" + Session["uDp2"] + "\",\"description\":\"" + Date1.Value + "至" + Date2.Value + "\n状态:" + uMode + "-" + bbPlace + "\n地点:" + bbPlaceInfo + "\n计划:" + TextBox2.Text + "\",\"url\":\"http://wxqyh.zjky.cn:9099/PlanQuery.aspx?UserIn=" + Session["uId"] + "&StarTimeIn=" + Date1.Value + "\"}" + "}";
                //string param = "{\"touser\":\"" + strPushUser + "\",\"toparty\":\"" + strAll + "\",\"totag\":\"" + strAll + "\",\"msgtype\":\"" + strText + "\",\"agentid\":\"" + agentid + "\",\"text\":" + "{\"content\":\"" + Session["uDp2"] + "-" + Session["uName"] + "-动向上报:" + Date1.Value + "至" + Date2.Value + ":" + uMode + ":" + TextBox2.Text + "\"}" + "}";
                string oauth_suite = HttpHelper.Post(surl, param);
                Helper.WriteLog("填报人:" + Session["uName"] + "[" + Session["uName"] + "]--" + Session["uDp2"] + "[" + Session["uDp2"] + "];推送:user[" + strPushUser + "];OP[" + "];" + oauth_suite, "PlanFill");
            }
        }
    }
}