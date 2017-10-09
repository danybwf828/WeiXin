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
    public partial class scanQRCodeResult : System.Web.UI.Page
    {
        public string appId = "", nonceStr = "", signature = "", secret = "", userID = "", deviceId = "", debug = "", userName = "", uMode = "";
        public long timestamp = 0;
        public static Database db = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bool breakWrite = false;
                db = new Database();
                try
                {
                    string QRcode = Request["QRcode"];

                    #region
                    appId = ConfigurationManager.AppSettings["AppID"];
                    secret = ConfigurationManager.AppSettings["SecretQrCode"];
                    string url = Request.Url.ToString();
                    string token = Caches.GetAccessToken(appId, secret, "ScanQrCode_access_token");
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        string code = Request["code"];
                        if (string.IsNullOrWhiteSpace(code))
                        {
                            Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appId + "&redirect_uri=" + HttpUtility.HtmlEncode(url) + "&response_type=code&scope=SCOPE&state=" + QRcode + "#wechat_redirect");
                        }
                        else
                        {
                            string state = Request["state"];
                            Session["QRcode"] = QRcode;

                            DataView dv = new DataView();
                            string strSQl01 = "select top 1 qcode,title from meetinfo where qcode='" + QRcode + "' order by id desc";
                            dv = db.GetDataView(strSQl01);
                            if (dv.Count > 0)
                            {
                                Label6.Text = (string)dv[0]["title"];
                                Button1.Text = "确认签到";
                                Button1.Enabled = true;
                            }
                            else
                            {
                                Label6.Text = "";
                                Button1.Text = "无效二维码！";
                                Button1.Enabled = false;
                            }

                            int agentid = Convert.ToInt32(ConfigurationManager.AppSettings["AgentIDScanQrCode"]);
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
                                Session["uDp2"] = strTmpDp4; Session["uUpDp"] = strTmpDp;
                                this.Label1.Text = userName;
                                this.Label4.Text = DateTime.Now.ToString();

                                if (this.Label1.Text.Trim() == "")
                                {
                                    Response.Redirect("scanQRCode.aspx?&signState=error");
                                }

                                Helper.WriteLog("签到人:" + userName + "[" + userID + "]--" + strTmpDp4 + "[" + strTmpDpId + "]--" + Label6.Text, "ScanQrCodeSign");
                            }
                            else
                            {
                            }
                            string jsapi_ticket = Caches.GetJsTicket(token);

                            timestamp = OpenApi.GetTime2();
                            nonceStr = OpenApi.NewGuid();

                            Dictionary<string, string> paramaters = new Dictionary<string, string>();
                            paramaters.Add("noncestr", nonceStr);
                            paramaters.Add("jsapi_ticket", jsapi_ticket);
                            paramaters.Add("timestamp", timestamp.ToString());
                            paramaters.Add("url", url);
                            signature = OpenApi.MakeSig(paramaters, nonceStr);
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

        public string[] FillUser(string strUserId, string userName, string strDpId)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            string strSQl01 = "select SING from participants_info where qcode='" + Session["QRcode"] + "' and userId='" + Session["uId"] + "'";
            dv = db.GetDataView(strSQl01);

            if (dv.Count > 0)
            {
                // Button1.Text = "你已签到！,点击返回";
                Response.Redirect("scanQRCode.aspx?&signState=resubmit");
            }
            else
            {
                string strSQl02 = "insert into participants_info(sing,singtime,meettitle,qcode,belongs,UserId) values('" + Label1.Text + "','" + Label4.Text + "','" + Label6.Text + "','" + Session["QRcode"] + "','" + Session["uUpDp"] + "','" + Session["uId"] + "')";
                db.ExecuteSQL(strSQl02);
                Response.Redirect("scanQRCode.aspx?&signState=success");
            }
        }
    }
}