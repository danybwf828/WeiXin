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
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace DotNetOpenAuth.Web.Moulds.QueryHRsalary
{
    public partial class QueryHrSalary2 : System.Web.UI.Page
    {
        public string appId = "", timestamp = "", nonceStr = "", signature = "", secret = "", userID = "", deviceId = "", debug = "", userName = "";
        public string[] bbSalaryKK = new string[12];
        public string[] bbSalaryBCKS = new string[12];
        public string[] bbSalaryYLGRKK = new string[12];
        public string[] bbSalaryYiLGRKK = new string[12];
        public string[] bbSalarySYGRKK = new string[12];
        public string[] bbSalaryZFGJJGRKK = new string[12];
        public string[] bbSalaryZFGJJDKKK = new string[12];
        public string[] bbSalarySBGJJKKHJ = new string[12];
        public string[] bbSalaryDKQTDWGJJZFBF = new string[12];
        public string[] bbSalaryDKQTDWSBGRZF = new string[12];
        public string[] bbSalaryQTKKJESM = new string[12];
        public string[] bbSalaryKFK = new string[12];
        public string[] bbSalaryDKJK = new string[12];
        public string[] bbSalarySDFKK = new string[12];
        public string[] bbSalaryGHHFDK = new string[12];
        public string[] bbSalaryDFGZKH = new string[12];
        public string[] bbSalaryGSQSDN = new string[12];
        public string[] bbSalaryDKSNGSQS = new string[12];
        public string[] bbSalaryYBQS = new string[12];
        public string[] bbSalarySBQS = new string[12];
        public string[] bbSalaryQQKK = new string[12];
        public string[] bbSalaryQTKKJE = new string[12];
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
                                        bbSalaryKK[i] = tmpdt.Rows[i]["扣款合计"].ToString();
                                        bbSalaryBCKS[i] = tmpdt.Rows[i]["本次扣税"].ToString();
                                        bbSalaryYLGRKK[i] = tmpdt.Rows[i]["养老个人扣款"].ToString();
                                        bbSalaryYiLGRKK[i] = tmpdt.Rows[i]["医疗个人扣款"].ToString();
                                        bbSalarySYGRKK[i] = tmpdt.Rows[i]["失业个人扣款"].ToString();
                                        bbSalaryZFGJJGRKK[i] = tmpdt.Rows[i]["住房公积金个人扣款"].ToString();
                                        bbSalaryZFGJJDKKK[i] = tmpdt.Rows[i]["住房公积金贷款扣款"].ToString();
                                        bbSalarySBGJJKKHJ[i] = tmpdt.Rows[i]["社保公积金扣款合计"].ToString();
                                        bbSalaryDKQTDWGJJZFBF[i] = tmpdt.Rows[i]["代扣其它单位公积金自付部分"].ToString();
                                        bbSalaryDKQTDWSBGRZF[i] = tmpdt.Rows[i]["代扣其它单位社保个人自付"].ToString();
                                        bbSalaryQTKKJESM[i] = tmpdt.Rows[i]["其他扣款金额说明"].ToString();
                                        bbSalaryKFK[i] = tmpdt.Rows[i]["扣罚款"].ToString();
                                        bbSalaryDKJK[i] = tmpdt.Rows[i]["代扣捐款"].ToString();
                                        bbSalarySDFKK[i] = tmpdt.Rows[i]["水电费扣款"].ToString();
                                        bbSalaryGHHFDK[i] = tmpdt.Rows[i]["工会会费代扣"].ToString();
                                        bbSalaryDFGZKH[i] = tmpdt.Rows[i]["多发工资扣回"].ToString();
                                        bbSalaryGSQSDN[i] = tmpdt.Rows[i]["个税清算当年"].ToString();
                                        bbSalaryDKSNGSQS[i] = tmpdt.Rows[i]["代扣上年个税清算"].ToString();
                                        bbSalaryYBQS[i] = tmpdt.Rows[i]["医保清算"].ToString();
                                        bbSalarySBQS[i] = tmpdt.Rows[i]["社保清算"].ToString();
                                        bbSalaryQQKK[i] = tmpdt.Rows[i]["缺勤扣款"].ToString();
                                        bbSalaryQTKKJE[i] = tmpdt.Rows[i]["其他扣款金额"].ToString();
                                        bbSalaryTime[i] = tmpdt.Rows[i]["年"].ToString() + "年" + tmpdt.Rows[i]["月"].ToString() + "月";
                                    }
                                    for (int i = 0; i < 12; i++)
                                    {
                                        if (string.IsNullOrEmpty(bbSalaryKK[i])) { bbSalaryKK[i] = "本月暂未扣款"; }
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
        public DataTable getSalaryByName(string strUserName, string strYear)
        {
            DataSet ds = new DataSet();
            string strSql01 = "select w.psncode as 人员编码,w.psnname as 人员名称,a.cnestyear as 年,a.cperiod as 月, b.deptcode as 部门代码, b.deptname as 部门名称, b.pk_corp as 公司代码,a.psnid as HRXZ0070018,sum(F_1) as  应发合计,sum(F_3) as 实发合计,sum(F_245) as 奖金,sum(F_246+F_465+F_466)  as 津贴,sum(F_2) as 扣款,sum(F_244) as 职工福利费,sum(F_376) as 工资,sum(F_248) as 假期工资,sum(F_247) as 加班工资,sum(F_381) as 其他收入,sum(F_159 + F_158) 辞退福利,sum(F_322) as 上级单位奖励本年度,sum(F_67) as 上级单位奖励上年度,sum(F_1 + F_148 + F_146 + F_147 + F_143 + F_145 + F_144 + F_399 +F_400 + F_152 + F_402) as 企业承担该员工人员成本,sum(F_148 + F_146 + F_147 + F_143 + F_145 + F_144 + F_399 + F_400 + F_152 + F_402) as 其他人工成本,sum(F_88) as 过节费,sum(F_459) as 考核额度,sum(F_24) as 考核工资 from zijinehr.wa_data a inner join zijinehr.bd_deptdoc b on a.deptid = b.pk_deptdoc inner join (select e.ipayoffflag, e.classid, f.cnestyear, f.cnestperiod from zijinehr.wa_periodstate e inner join zijinehr.wa_period f on f.pk_wa_period = e.pk_periodset) d on d.cnestyear = a.cnestyear and d.cnestperiod = a.cnestperiod and d.classid = a.classid left join zijinehr.bd_psndoc w    on a.psnid = w.pk_psndoc left join zijinehr.bd_psncl y on w.pk_psncl = y.pk_psncl where a.cyear = '" + strYear + "' and a.istopflag = '0' and a.icheckflag = '1' and d.ipayoffflag = '1' and a.f_1 <> '0' and y.psnclasscode <> '0' and b.pk_corp='1002' and w.psnname = '" + strUserName + "' group by b.pk_corp,y.psnclasscode,a.psnid,w.psncode,w.psnname,a.cnestyear,a.cperiod, b.deptcode,b.deptname order by a.cperiod desc";
            Helper.WriteLog("strSql01:" + strSql01, "QueryHRslary");
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
            string strSql01 = "select w.psncode as 人员编码,w.psnname as 人员名称,a.cnestyear as 年,a.cperiod as 月, b.deptcode as 部门代码, b.deptname as 部门名称, b.pk_corp as 公司代码,a.psnid as HRXZ0070018,sum(F_2) as 扣款合计,sum(F_4) as 本次扣税,sum(F_174) as 养老个人扣款,sum(F_177) as 医疗个人扣款,sum(F_180) as 失业个人扣款,sum(F_183) as 住房公积金个人扣款,sum(F_193) as 住房公积金贷款扣款,sum(F_243) as 社保公积金扣款合计,sum(F_343) as 代扣其它单位公积金自付部分,sum(F_343) as 代扣其它单位社保个人自付,sum(F_101) as 其他扣款金额说明,sum(F_190) as 扣罚款,sum(F_191) as 代扣捐款,sum(F_196) as 水电费扣款,sum(F_197) as 工会会费代扣,sum(F_189) as 多发工资扣回,sum(F_188) as 个税清算当年,sum(F_187) as 代扣上年个税清算,sum(F_366) as 医保清算,sum(F_365) as 社保清算,sum(F_395) as 缺勤扣款,sum(F_198) as 其他扣款金额 from zijinehr.wa_data a inner join zijinehr.bd_deptdoc b on a.deptid = b.pk_deptdoc inner join (select e.ipayoffflag, e.classid, f.cnestyear, f.cnestperiod from zijinehr.wa_periodstate e inner join zijinehr.wa_period f on f.pk_wa_period = e.pk_periodset) d on d.cnestyear = a.cnestyear and d.cnestperiod = a.cnestperiod and d.classid = a.classid left join zijinehr.bd_psndoc w    on a.psnid = w.pk_psndoc left join zijinehr.bd_psncl y on w.pk_psncl = y.pk_psncl where a.cyear = '" + strYear + "' and a.istopflag = '0' and a.icheckflag = '1' and d.ipayoffflag = '1' and a.f_1 <> '0' and y.psnclasscode <> '0' and b.pk_corp='1002' and w.psncode = '" + strUserHrId + "' group by b.pk_corp,y.psnclasscode,a.psnid,w.psncode,w.psnname,a.cnestyear,a.cperiod, b.deptcode,b.deptname order by a.cperiod desc";
            Helper.WriteLog("strSql01:" + strSql01, "QueryHRslary");
            //try
            //{
            //    string connStr = "User Id=zijinehr;Password=zjehr123;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.23.103)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)))";
            //    using (var conn = new OracleConnection(connStr))
            //    {
            //        conn.Open();
            //        string sql = strSql01;
            //        OracleDataAdapter oda = new OracleDataAdapter(sql, conn);
            //        oda.Fill(ds);
            //        DataTable dt = ds.Tables[0];
            //    }
            //}
            //catch (OracleException ex)
            //{
            //    throw new Exception(ex.Message);
            //}
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