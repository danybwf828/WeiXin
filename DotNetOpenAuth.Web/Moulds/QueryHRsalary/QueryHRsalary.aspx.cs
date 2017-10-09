using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Threading;
using DotNetOpenAuth.DataAccess;
using DotNet.Utilities;
using DotNetOpenAuth.SDK;
using ComputerRepair.DataAccessLayer;
using System.Web.UI.HtmlControls;

namespace DotNetOpenAuth.Web.Moulds.QueryHRsalary
{
    public partial class QueryHrSalary : System.Web.UI.Page
    {
        public string appId = "", timestamp = "", nonceStr = "", signature = "", secret = "", userID = "", deviceId = "", debug = "", userName = "";
        public string[] bbSalaryJBGZBZ = new string[12];
        public string[] bbSalaryGWYGZBZ = new string[12];
        public string[] bbSalaryGWYSFGZ = new string[12];
        public string[] bbSalaryGWRGZBZ = new string[12];
        public string[] bbSalaryGWRSFGZ = new string[12];
        public string[] bbSalaryTime = new string[12];

        public static Database db = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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
                        secret = ConfigurationManager.AppSettings["SecretHrSalary"];
                        string url = Request.Url.ToString();
                        string token = Caches.GetAccessToken(appId, secret, "HrSalary_access_token");

                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            string code = Request["code"];
                            if (string.IsNullOrWhiteSpace(code))
                            {
                                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appId + "&redirect_uri=" + HttpUtility.HtmlEncode(url) + "&response_type=code&scope=SCOPE&state=qiandao#wechat_redirect");
                            }
                            else
                            {
                                int agentid = Convert.ToInt32(ConfigurationManager.AppSettings["AgentIDHrSalary"]);
                                UserInfo ui = OpenApi.GetUserInfo(token, code, agentid);
                                if (ui != null)
                                {
                                    userID = ui.UserId; Session["uId"] = ui.UserId;
                                    UserInfo2 ui2 = OpenApi.GetUserInfo2(token, userID);
                                    userName = ui2.name; Session["uName"] = ui2.name;

                                    //Helper.WriteLog("token:[" + token + "];code[" + code + "];agentid[" + agentid + "];userid[" + userID + "];username[" + userName + "]", "QueryHRslary");

                                    string userHrId = getUserHrIdByUserOaName(userName);
                                    //DataTable tmpdt = getSalaryByName(userName, DateTime.Now.ToString("yyyy"));
                                    DataTable tmpdt = getSalaryByUserId(userHrId, DateTime.Now.ToString("yyyy"));
                                    for (int i = 0; i < tmpdt.Rows.Count; i++)
                                    {
                                        //bbSalaryYF[i] = tmpdt.Rows[i]["应发合计"].ToString();
                                        //bbSalaryKK[i] = tmpdt.Rows[i]["扣款"].ToString();
                                        //bbSalarySF[i] = tmpdt.Rows[i]["实发合计"].ToString();
                                        bbSalaryJBGZBZ[i] = tmpdt.Rows[i]["基本工资标准"].ToString();
                                        bbSalaryGWYGZBZ[i] = tmpdt.Rows[i]["岗位月工资标准"].ToString();
                                        bbSalaryGWYSFGZ[i] = tmpdt.Rows[i]["岗位月上浮工资"].ToString();
                                        bbSalaryGWRGZBZ[i] = tmpdt.Rows[i]["岗位日工资标准"].ToString();
                                        bbSalaryGWRSFGZ[i] = tmpdt.Rows[i]["岗位日上浮工资"].ToString();
                                        bbSalaryTime[i] = tmpdt.Rows[i]["年"].ToString() + "年" + tmpdt.Rows[i]["月"].ToString() + "月";
                                    }
                                    for (int i = 0; i < 12; i++)
                                    {
                                        //if (string.IsNullOrEmpty(bbSalarySF[i])) { bbSalarySF[i] = "本月暂未发放"; }
                                        if (string.IsNullOrEmpty(bbSalaryTime[i])) { bbSalaryTime[i] = DateTime.Now.ToString("yyyy") + "年" + (12 - i + tmpdt.Rows.Count).ToString().PadLeft(2, '0') + "月"; }
                                    }
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
            }
        }

        /// <summary>
        /// 根據用戶名字、年份查询工资
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="strYear"></param>
        public DataTable getSalaryByName(string strUserName,string strYear)
        {
            DataSet ds = new DataSet();
            string strSql01 = "select w.psncode as 人员编码,w.psnname as 人员名称,a.cnestyear as 年,a.cperiod as 月, b.deptcode as 部门代码, b.deptname as 部门名称, b.pk_corp as 公司代码,a.psnid as HRXZ0070018,sum(F_1) as  应发合计,sum(F_3) as 实发合计,sum(F_245) as 奖金,sum(F_246+F_465+F_466)  as 津贴,sum(F_2) as 扣款,sum(F_244) as 职工福利费,sum(F_376) as 工资,sum(F_248) as 假期工资,sum(F_247) as 加班工资,sum(F_381) as 其他收入,sum(F_159 + F_158) 辞退福利,sum(F_322) as 上级单位奖励本年度,sum(F_67) as 上级单位奖励上年度,sum(F_1 + F_148 + F_146 + F_147 + F_143 + F_145 + F_144 + F_399 +F_400 + F_152 + F_402) as 企业承担该员工人员成本,sum(F_88) as 过节费,sum(F_459) as 考核额度,sum(F_24) as 考核工资 from zijinehr.wa_data a inner join zijinehr.bd_deptdoc b on a.deptid = b.pk_deptdoc inner join (select e.ipayoffflag, e.classid, f.cnestyear, f.cnestperiod from zijinehr.wa_periodstate e inner join zijinehr.wa_period f on f.pk_wa_period = e.pk_periodset) d on d.cnestyear = a.cnestyear and d.cnestperiod = a.cnestperiod and d.classid = a.classid left join zijinehr.bd_psndoc w    on a.psnid = w.pk_psndoc left join zijinehr.bd_psncl y on w.pk_psncl = y.pk_psncl where a.cyear = '" + strYear + "' and a.istopflag = '0' and a.icheckflag = '1' and d.ipayoffflag = '1' and a.f_1 <> '0' and y.psnclasscode <> '0' and b.pk_corp='1002' and w.psnname = '" + strUserName + "' group by b.pk_corp,y.psnclasscode,a.psnid,w.psncode,w.psnname,a.cnestyear,a.cperiod, b.deptcode,b.deptname order by a.cperiod desc";
            Helper.WriteLog("strSql01:" + strSql01,"QueryHRslary");
            try
            {
                ds = OracleHelper.Query(strSql01);
            }
            catch (Exception e) { Helper.WriteLog("Error:" + e.ToString(), "QueryHRslary"); }
            return ds.Tables[0];
        }

        
        /// <summary>
        /// 根據用戶Hr人员编码、年份查询工资
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="strYear"></param>
        public DataTable getSalaryByUserId(string strUserHrId, string strYear)
        {
            DataSet ds = new DataSet();
            string strSql01 = "select w.psncode as 人员编码,w.psnname as 人员名称,a.cnestyear as 年,a.cperiod as 月, b.deptcode as 部门代码, b.deptname as 部门名称, b.pk_corp as 公司代码,a.psnid as HRXZ0070018,sum(F_1) as  应发合计,sum(F_3) as 实发合计,sum(F_245) as 奖金,sum(F_246+F_465+F_466)  as 津贴,sum(F_2) as 扣款,sum(F_244) as 职工福利费,sum(F_376) as 工资,sum(F_248) as 假期工资,sum(F_247) as 加班工资,sum(F_381) as 其他收入,sum(F_159 + F_158) 辞退福利,sum(F_322) as 上级单位奖励本年度,sum(F_67) as 上级单位奖励上年度,sum(F_1 + F_148 + F_146 + F_147 + F_143 + F_145 + F_144 + F_399 +F_400 + F_152 + F_402) as 企业承担该员工人员成本,sum(F_88) as 过节费,sum(F_459) as 考核额度,sum(F_24) as 考核工资,sum(F_464) as 基本工资标准，sum(F_46) as 岗位月工资标准,sum(F_336) as 岗位月上浮工资, sum(F_20) as 岗位日工资标准,sum(F_20) as 岗位日上浮工资 from zijinehr.wa_data a inner join zijinehr.bd_deptdoc b on a.deptid = b.pk_deptdoc inner join (select e.ipayoffflag, e.classid, f.cnestyear, f.cnestperiod from zijinehr.wa_periodstate e inner join zijinehr.wa_period f on f.pk_wa_period = e.pk_periodset) d on d.cnestyear = a.cnestyear and d.cnestperiod = a.cnestperiod and d.classid = a.classid left join zijinehr.bd_psndoc w    on a.psnid = w.pk_psndoc left join zijinehr.bd_psncl y on w.pk_psncl = y.pk_psncl where a.cyear = '" + strYear + "' and a.istopflag = '0' and a.icheckflag = '1' and d.ipayoffflag = '1' and a.f_1 <> '0' and y.psnclasscode <> '0' and b.pk_corp='1002' and w.psncode = '" + strUserHrId + "' group by b.pk_corp,y.psnclasscode,a.psnid,w.psncode,w.psnname,a.cnestyear,a.cperiod, b.deptcode,b.deptname order by a.cperiod desc";
            Helper.WriteLog("strSql01:" + strSql01, "QueryHRslary");
            try
            {
                //ds = OracleHelper.Query(strSql01);
                ds = BBoracleHelperNoClient.Query(strSql01);
            }
            catch (Exception e) { Helper.WriteLog("Error:" + e.ToString(), "QueryHRslary"); }
            return ds.Tables[0];

        }

        /// <summary>
        /// 根據用戶微信姓名（OA姓名）查询（OA与HR人员对照表）对应的人员编码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="strYear"></param>
        public string getUserHrIdByUserOaName(string userName)
        {
            db = new Database(MySecurity.SDecryptString(ConfigurationManager.AppSettings["Conn_OaCpHr"], "zjOaCpHrDatabase"));
            string strSql = "SELECT zjky$dzb_f5651,zjky$dzb_f5652 FROM zjkynew103.ezoffice.zjky$dzb where zjky$dzb_f5651 = '" + userName + "'";
            DataTable dt = new DataTable();
            dt = db.GetDataTable(strSql);
            return dt.Rows[0]["zjky$dzb_f5652"].ToString();
        }
    }
}