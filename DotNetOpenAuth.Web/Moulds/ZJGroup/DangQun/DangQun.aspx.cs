using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DotNetOpenAuth.DataAccess;
using DotNetOpenAuth.SDK;
using System.Threading;

namespace DotNetOpenAuth.Web.Moulds.ZJGroup.DangQun
{
    public partial class DaongQun : System.Web.UI.Page
    {
        public string appId = "", timestamp = "", nonceStr = "", signature = "", secret = "", userID = "", deviceId = "", debug = "", userName = "", userAvatar = "";
        public string[] bbLi = new string[12];
        public List<string[]> bbLiList = new List<string[]>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsCallback)
            {
                bool breakWrite = false;
                try
                {
                    string state = Request["state"];
                    string strUserIn = Request["UserIn"];
                    string strStarTimeIn = Request["StarTimeIn"];
                    if (state == "Sign") { }
                    else
                    {
                        #region
                        appId = ConfigurationManager.AppSettings["AppID"];
                        secret = ConfigurationManager.AppSettings["SecretGroupDQ001"];
                        string url = Request.Url.ToString();
                        string token = Caches.GetAccessToken(appId, secret, "GroupDQ001_access_token");

                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            string code = Request["code"];
                            if (string.IsNullOrWhiteSpace(code))
                            {
                                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appId + "&redirect_uri=" + HttpUtility.HtmlEncode(url) + "&response_type=code&scope=SCOPE&state=qiandao#wechat_redirect");
                            }
                            else
                            {
                                int agentid = Convert.ToInt32(ConfigurationManager.AppSettings["AgentIDGroupDQ001"]);
                                UserInfo ui = OpenApi.GetUserInfo(token, code, agentid);
                                if (ui != null)
                                {
                                    userID = ui.UserId; Session["uId"] = ui.UserId;
                                    UserInfo2 ui2 = OpenApi.GetUserInfo2(token, userID);
                                    userName = ui2.name; Session["uName"] = ui2.name;
                                    userAvatar = ui2.avatar;
                                    Helper.WriteLog("token:[" + token + "];code[" + code + "];agentid[" + agentid + "];userid[" + userID + "];username[" + userName + "]", "GroupDQ001");

                                    //string userHrId = getUserHrIdByUserOaName(userName);
                                    ////DataTable tmpdt = getSalaryByName(userName, DateTime.Now.ToString("yyyy"));
                                    //DataTable tmpdt = getSalaryByUserId(userHrId, DateTime.Now.ToString("yyyy"));
                                    //for (int i = 0; i < tmpdt.Rows.Count; i++)
                                    //{
                                    //    bbSalaryYF[i] = tmpdt.Rows[i]["应发合计"].ToString();
                                    //    bbSalaryKK[i] = tmpdt.Rows[i]["扣款"].ToString();
                                    //    bbSalarySF[i] = tmpdt.Rows[i]["实发合计"].ToString();
                                    //    bbSalaryGZ[i] = tmpdt.Rows[i]["工资"].ToString();
                                    //    bbSalaryJQGZ[i] = tmpdt.Rows[i]["假期工资"].ToString();
                                    //    bbSalaryJT[i] = tmpdt.Rows[i]["津贴"].ToString();
                                    //    bbSalaryJBGZ[i] = tmpdt.Rows[i]["加班工资"].ToString();
                                    //    bbSalaryKHED[i] = tmpdt.Rows[i]["考核额度"].ToString();
                                    //    bbSalaryKHGZ[i] = tmpdt.Rows[i]["考核工资"].ToString();
                                    //    bbSalaryJJXSR[i] = tmpdt.Rows[i]["奖金"].ToString();
                                    //    bbSalaryFLXSR[i] = tmpdt.Rows[i]["职工福利费"].ToString();
                                    //    bbSalaryQTRGCB[i] = tmpdt.Rows[i]["其他人工成本"].ToString();
                                    //    bbSalarySJDWJLBND[i] = tmpdt.Rows[i]["上级单位奖励本年度"].ToString();
                                    //    bbSalarySJDWJLSND[i] = tmpdt.Rows[i]["上级单位奖励上年度"].ToString();
                                    //    bbSalaryTime[i] = tmpdt.Rows[i]["年"].ToString() + "年" + tmpdt.Rows[i]["月"].ToString() + "月";
                                    //}
                                    //for (int i = 0; i < 12; i++)
                                    //{
                                    //    if (string.IsNullOrEmpty(bbSalarySF[i])) { bbSalarySF[i] = "本月暂未发放"; }
                                    //    if (string.IsNullOrEmpty(bbSalaryTime[i])) { bbSalaryTime[i] = DateTime.Now.ToString("yyyy") + "年" + (12 - i + tmpdt.Rows.Count).ToString().PadLeft(2, '0') + "月"; }
                                    //}
                                }
                                else { userID = "准备就绪！"; }
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
                catch (ThreadAbortException ThreadAbortException)
                {
                    Helper.WriteLog("ThreadAbortException:" + ThreadAbortException, "QueryHRslary");
                }
                catch (Exception ex)
                {
                    Response.Clear();
                    Response.Write("失败 : " + ex.Message);
                    breakWrite = true;
                }
                if (breakWrite) { Response.End(); return; }
                bbLi[0] = "img/DQ01.png";
                bbLi[1] = "党群user";
                bbLi[2] = "党群titil";
                bbLi[3] = "WordsDesc";
                bbLi[4] = "WordsHide";
                bbLi[5] = "img/m3.jpg";
                bbLiList.Add(bbLi);
            }
        }
    }
}