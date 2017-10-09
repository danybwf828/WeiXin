using FluentScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Form1.Public;
using System.Xml;
using System.Collections;
using DotNetOpenAuth.DataAccess;
using DotNetOpenAuth.SDK;
using DotNet.Utilities;

namespace FluentSchedulerFromBB
{
    public partial class Form1 : Form
    {
        int iClearLint = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "ClearLine")); //清屏行数
        string strLogSign = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "LogSign"));           //日志是否记入文本文件（1：不记入，0：记入）
        string strProgramName = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "programName"));   //程序名称
        string strProgramCode = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "ProgramCode"));
        private Thread oThread;
        private object sysObject = new object();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadMission();
        }
        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            #region Schedule
            //// 立即执行每两秒一次的计划任务。（指定一个时间间隔运行，根据自己需求，可以是秒、分、时、天、月、年等。）
            //Schedule<Demo>().ToRunNow().AndEvery(2).Seconds();

            //// 延迟一个指定时间间隔执行一次计划任务。（当然，这个间隔依然可以是秒、分、时、天、月、年等。）
            //Schedule<Demo>().ToRunOnceIn(5).Seconds();

            //// 在一个指定时间执行计划任务（最常用。这里是在每天的下午 1:10 分执行）
            //Schedule(() => Trace.WriteLine("It's 1:10 PM now.")).ToRunEvery(1).Days().At(13, 10);

            //// 立即执行一个在每月的星期一 3:00 的计划任务（可以看出来这个一个比较复杂点的时间，它意思是它也能做到！）
            //Schedule<Demo>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(3, 0);

            //// 在同一个计划中执行两个（多个）任务
            //Schedule<Demo>().AndThen<Demo>().ToRunNow().AndEvery(5).Minutes();
            #endregion
            this.btnRemoveJob.PerformClick();
            loadMission();
        }

        private void btnRemoveJob_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                string strJobName = dgvr.Cells["Column1"].Value.ToString();
                JobManager.RemoveJob(strJobName);
                Log_Txt_BB(strJobName + "任务被终止", "btnRemoveJob_Click");
            }
            this.dataGridView1.Rows.Clear();
            this.btnCreateTask.Enabled = true;
        }

        private void loadMission()
        {
            int MissionCount = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionCount"));
            for (int i = 1; i <= MissionCount; i++)
            {
                string strMissionMode = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionMode" + i.ToString()));
                loadMissionMode(strMissionMode, i, "Load");
            }

        }
        private void loadMissionMode(string missionMode, int missionNmb, string LoadMode)
        {
            string MissionName = "";
            string MissionDesc = "";
            string MissionState = "";
            int MissionParamPer = 0;
            int MissionParamMinut = 0;
            int MissionParamHour = 0;
            int MissionParamDay = 0;
            int MissionParamWeek = 0;
            int MissionParamMonth = 0;
            int MissionParamF = 0;
            switch (missionMode)
            {
                case "PerSeconds":
                    #region 每几秒
                    MissionName = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionName" + missionNmb.ToString()));
                    MissionDesc = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionDesc" + missionNmb.ToString()));
                    MissionState = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionState" + missionNmb.ToString()));
                    MissionParamPer = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamPer" + missionNmb.ToString()));
                    if (LoadMode == "Load")
                    {
                        string[] drDG0 = new string[12];
                        drDG0[0] = MissionName;
                        drDG0[1] = MissionDesc;
                        drDG0[2] = missionMode;
                        drDG0[3] = MissionState;
                        drDG0[6] = "每" + MissionParamPer.ToString() + "秒";
                        this.dataGridView1.Rows.Add(drDG0);
                    }
                    if (MissionState == "ON")
                    {
                        BBcreateMissionPerSeconds(MissionName, MissionParamPer);
                    }
                    break;
                    #endregion
                case "PerSecondsDelay":
                    #region 每几秒(延迟)
                    break;
                    #endregion
                case "PerDays":
                    #region 每几天的几点几分
                    MissionName = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionName" + missionNmb.ToString()));
                    MissionDesc = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionDesc" + missionNmb.ToString()));
                    MissionState = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionState" + missionNmb.ToString()));
                    MissionParamPer = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamPer" + missionNmb.ToString()));
                    MissionParamMinut = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamMinut" + missionNmb.ToString()));
                    MissionParamHour = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamHour" + missionNmb.ToString()));
                    if (LoadMode == "Load")
                    {
                        string[] drDG2 = new string[12];
                        drDG2[0] = MissionName;
                        drDG2[1] = MissionDesc;
                        drDG2[2] = missionMode;
                        drDG2[3] = MissionState;
                        drDG2[6] = "每" + MissionParamPer.ToString() + "天";
                        drDG2[7] = MissionParamHour.ToString() + "点";
                        drDG2[8] = MissionParamMinut.ToString() + "分";
                        this.dataGridView1.Rows.Add(drDG2);
                    }
                    if (MissionState == "ON")
                    {
                        BBcreateMissionPerDays(MissionName, MissionParamPer, MissionParamMinut, MissionParamHour);
                    }
                    break;
                    #endregion
                case "PerWeeks":
                    #region 每几周的几点几分
                    break;
                    #endregion
                case "PerMonthsWeek":
                    #region 每几月的第几周的星期几的几点几分
                    break;
                    #endregion
                case "PerMonthsDay":
                    #region 每几个月的几号的几点几分
                    MissionName = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionName" + missionNmb.ToString()));
                    MissionDesc = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionDesc" + missionNmb.ToString()));
                    MissionState = System.Convert.ToString(PublicFunc.ReadINI("SysConfig", "MissionState" + missionNmb.ToString()));
                    MissionParamPer = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamPer" + missionNmb.ToString()));
                    MissionParamMinut = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamMinut" + missionNmb.ToString()));
                    MissionParamHour = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamHour" + missionNmb.ToString()));
                    MissionParamDay = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamDay" + missionNmb.ToString()));
                    if (LoadMode == "Load")
                    {
                        string[] drDG5 = new string[12];
                        drDG5[0] = MissionName;
                        drDG5[1] = MissionDesc;
                        drDG5[2] = missionMode;
                        drDG5[3] = MissionState;
                        drDG5[6] = "每" + MissionParamPer.ToString() + "月";
                        drDG5[7] = MissionParamDay.ToString() + "号";
                        drDG5[8] = MissionParamHour.ToString() + "点";
                        drDG5[9] = MissionParamMinut.ToString() + "分";
                        this.dataGridView1.Rows.Add(drDG5);
                    }
                    if (MissionState == "ON")
                    {
                        BBcreateMissionPerMonthsDay(MissionName, MissionParamPer, MissionParamDay, MissionParamHour, MissionParamMinut);
                    }
                    break;
                    #endregion
                case "PerMonthsLastDay":
                    #region 每几个月的最后一天的几点几分
                    break;
                    #endregion
            }
        }

        /// <summary>
        /// 立即执行每(intSeconds)秒的任务
        /// </summary>
        /// <param name="MissionName"></param>
        /// <param name="intSeconds"></param>
        private void BBcreateMissionPerSeconds(string MissionName, int intPerSeconds)
        {
            Registry tmpRegistry = new Registry();
            tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunNow().AndEvery(intPerSeconds).Seconds();
            JobManager.Initialize(tmpRegistry);
            Log_Txt_BB("创建" + MissionName + "任务!", MissionName);
        }

        /// <summary>
        /// 延迟(intSeconds)秒执行每(intSeconds)秒的任务
        /// </summary>
        /// <param name="MissionName"></param>
        /// <param name="intSeconds"></param>
        private void BBcreateMissionPerSecondsDelay(string MissionName, int intPerSeconds)
        {
            Registry tmpRegistry = new Registry();
            tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunOnceIn(intPerSeconds).Seconds();
            JobManager.Initialize(tmpRegistry);
            Log_Txt_BB("创建" + MissionName + "任务!", MissionName);
        }

        /// <summary>
        /// 指定时间执行任务(perDays每几天的几点)
        /// </summary>
        /// <param name="MissionName"></param>
        /// <param name="intDays"></param>
        /// <param name="intHours"></param>
        /// <param name="intMinuts"></param>
        private void BBcreateMissionPerDays(string MissionName, int intPerDays, int intMinut, int intHour)
        {
            Registry tmpRegistry = new Registry();
            tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunEvery(intPerDays).Days().At(intHour, intMinut);
            JobManager.Initialize(tmpRegistry);
            Log_Txt_BB("创建" + MissionName + "任务!", MissionName);
        }

        /// <summary>
        /// 指定时间执行任务(perWeeks每几星期的星期几的几点)
        /// </summary>
        /// <param name="MissionName"></param>
        /// <param name="intWeeks"></param>
        /// <param name="dow"></param>
        /// <param name="intHours"></param>
        /// <param name="intMinuts"></param>
        private void BBcreateMissionPerWeeks(string MissionName, int intMinuts, int intHours, DayOfWeek dow, int intWeeks)
        {
            Registry tmpRegistry = new Registry();
            tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunEvery(intWeeks).Weeks().On(dow).At(intHours, intMinuts);
            JobManager.Initialize(tmpRegistry);
            Log_Txt_BB("创建" + MissionName + "任务!", MissionName);
        }

        /// <summary>
        /// 指定时间执行任务(perMonths每几个月的第几个星期几的几点)
        /// </summary>
        /// <param name="MissionName"></param>
        /// <param name="intMonths"></param>
        /// <param name="perTime"></param>
        /// <param name="dow"></param>
        /// <param name="intDays"></param>
        /// <param name="intHours"></param>
        /// <param name="intMinuts"></param>
        private void BBcreateMissionPerMonthsWeek(string MissionName, int intMonths, int howManyTimes, DayOfWeek dow, int intDays, int intHours, int intMinuts)
        {
            Registry tmpRegistry = new Registry();
            switch (howManyTimes)
            {
                case 1:
                    tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunNow().AndEvery(intMonths).Months().OnTheFirst(dow).At(intHours, intMinuts); break;
                case 2:
                    tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunNow().AndEvery(intMonths).Months().OnTheSecond(dow).At(intHours, intMinuts); break;
                case 3:
                    tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunNow().AndEvery(intMonths).Months().OnTheThird(dow).At(intHours, intMinuts); break;
                case 4:
                    tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunNow().AndEvery(intMonths).Months().OnTheFourth(dow).At(intHours, intMinuts); break;
                case 5:
                    tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunNow().AndEvery(intMonths).Months().OnTheLast(dow).At(intHours, intMinuts); break;
            }
            JobManager.Initialize(tmpRegistry);
            Log_Txt_BB("创建" + MissionName + "任务!", MissionName);
        }

        /// <summary>
        /// 指定时间执行任务(perMonths每几个月的几号的几点)
        /// </summary>
        /// <param name="MissionName"></param>
        /// <param name="intMonths"></param>
        /// <param name="intDay"></param>
        /// <param name="intHours"></param>
        /// <param name="intMinuts"></param>
        private void BBcreateMissionPerMonthsDay(string MissionName, int intMonths, int intDay, int intHours, int intMinuts)
        {
            Registry tmpRegistry = new Registry();
            tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunEvery(intMonths).Months().On(intDay).At(intHours, intMinuts);
            JobManager.Initialize(tmpRegistry);
            Log_Txt_BB("创建" + MissionName + "任务!", MissionName);
        }

        /// <summary>
        /// 指定时间执行任务(perMonths每几个月最后一天的几点)
        /// </summary>
        /// <param name="MissionName"></param>
        /// <param name="intMonths"></param>
        /// <param name="intHours"></param>
        /// <param name="intMinuts"></param>
        private void BBcreateMissionPerMonthsLastDay(string MissionName, int intMonths, int intHours, int intMinuts)
        {
            Registry tmpRegistry = new Registry();
            tmpRegistry.Schedule(() => BBmission(MissionName)).WithName(MissionName).ToRunEvery(intMonths).Months().OnTheLastDay().At(intHours, intMinuts);
            JobManager.Initialize(tmpRegistry);
            Log_Txt_BB("创建" + MissionName + "任务!", MissionName);
        }

        private void BBmission(string strMissionName)
        {
            switch (strMissionName)
            {
                case "DqTheoryNews":
                    DqTheoryNewsPer();
                    break;
                case "HrPaySync":
                    HrPaySyncEnable();
                    break;
                case "WxPayPush":
                    WxPayPush();
                    break;
                case "DfTips":
                    DfTips();
                    break;
            }
        }

        /// <summary>
        /// 党群理论新闻推送
        /// </summary>
        private void DqTheoryNewsPer()
        {
            Log_Txt_BB("开始执行任务:党群理论新闻", "Log_Txt_BB");
            rss.Channel readChannel = new rss.Channel();
            readChannel = ReadXml("http://www.people.com.cn/rss/theory.xml");

            //SetText("title：" + readChannel.Title);

            //for (int i = 0; i < readChannel.Items.Count; i++)
            //{
            //    rss.Item item = (rss.Item)readChannel.Items[i];

            //    SetText("item.title：" + item.Title);
            //    SetText("item.Link：" + item.Link);
            //    SetText("item.pubDate：" + item.pubDate);
            //    SetText("item.Description：" + item.Description);
            //}
            rss.Item item = new rss.Item();
            string lastTitle = PublicFunc.ReadINI("SysConfig", "MissionLastTitle1");
            if (string.IsNullOrEmpty(lastTitle)) { item = (rss.Item)readChannel.Items[0]; }
            else
            {
                for (int i = 0; i < readChannel.Items.Count; i++)
                {
                    rss.Item itemTmp = (rss.Item)readChannel.Items[i];
                    if (itemTmp.Title == lastTitle) { item = (rss.Item)readChannel.Items[i + 1]; break; }
                    else if (i == readChannel.Items.Count - 1) { item = (rss.Item)readChannel.Items[0]; }
                }
            }
            PublicFunc.WriteINI("SysConfig", "MissionLastTitle1", item.Title);
            string appId = "wx9a845683e36a17e1";
            string secret = "XXL4ypLPuZbZIRbV-jgjqs25hbfiMswCRUPo5k1i-eE";
            int agentid = 1000054;
            string strAll = "@all";
            string strTextCard = "textcard";
            string strText = "text";
            string suite_access_token = Caches.GetAccessTokenDqNews(appId, secret, "DqTheoryNews_access_token");
            AgentUserList aul = OpenApi.GetAgentUserList(suite_access_token, agentid);

            string strUerIds = "";
            foreach (string strPid in aul.allow_partys.partyid)
            {
                UserList ulTmp = OpenApi.GetUserList(suite_access_token, strPid, 1);
                for (int k = 0; k < ulTmp.userlist.Count; k++)
                {
                    //string strdp = getDPstr(txlToken, ulTmp.userlist[k].department.ToString(), "").Replace("紫金矿业集团>", "");
                    string strSQL = ulTmp.userlist[k].userid;
                    strUerIds = strUerIds + ulTmp.userlist[k].userid + "|";
                }
            }
            foreach (Dictionary<string, string> dicUser in aul.allow_userinfos.user)
            {
                strUerIds = strUerIds + dicUser["userid"].ToString() + "|";
            }

            string surl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + suite_access_token;
            string param = "{\"touser\":\"" + strUerIds + "\",\"toparty\":\"" + strAll + "\",\"totag\":\"" + strAll + "\",\"msgtype\":\"" + strTextCard + "\",\"agentid\":\"" + agentid + "\",\"textcard\":" + "{\"title\":\"" + item.Title + "\",\"description\":\"" + "党群理论每日一学:第" + DateTime.Now.ToString("yyyyMMdd") + "期" + "\",\"url\":\"" + item.Link + "\"}" + "}";
            string oauth_suite = HttpHelper.Post(surl, param);
            Log_Txt_BB("党群理论新闻推送成功!" + "返回值[" + oauth_suite + "];推送人ID[" + strUerIds + "]", "DqTheoryNews");
        }

        /// <summary>
        /// 工资数据同步激活
        /// </summary>
        private void HrPaySyncEnable()
        {
            Log_Txt_BB("开始执行任务:工资数据同步", "WxPayPush");
            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                if (dgvr.Cells["Column1"].Value.ToString() == "WxPayPush")
                {
                    if (dgvr.Cells["Column4"].Value.ToString() == "ON") { JobManager.RemoveJob("WxPayPush"); dgvr.Cells["Column4"].Value = "OFF"; }

                    int perSeconds = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamPer3"));
                    BBcreateMissionPerSeconds("WxPayPush", perSeconds);
                    dgvr.Cells["Column4"].Value = "ON";
                    Log_Txt_BB("激活任务:微信工资推送", "WxPayPush");
                }
            }
            Log_Txt_BB("工资数据同步任务触发", "WxPayPush");
        }

        /// <summary>
        /// 查询工资若已发放微信推送
        /// </summary>
        private void WxPayPush()
        {
            Log_Txt_BB("开始执行任务:微信工资推送", "WxPayPush");
            string strYear = DateTime.Now.Year.ToString();
            string strMonth = DateTime.Now.Month.ToString().PadLeft(2, '0');
            string sqlPay = "select w.psncode as 人员编码,w.psnname as 人员名称,a.cnestyear as 年,a.cperiod as 月, b.deptcode as 部门代码, b.deptname as 部门名称, b.pk_corp as 公司代码,a.psnid as HRXZ0070018,sum(F_1) as  应发合计,sum(F_3) as 实发合计,sum(F_2) as 扣款 from zijinehr.wa_data a inner join zijinehr.bd_deptdoc b on a.deptid = b.pk_deptdoc inner join (select e.ipayoffflag, e.classid, f.cnestyear, f.cnestperiod from zijinehr.wa_periodstate e inner join zijinehr.wa_period f on f.pk_wa_period = e.pk_periodset) d on d.cnestyear = a.cnestyear and d.cnestperiod = a.cnestperiod and d.classid = a.classid left join zijinehr.bd_psndoc w    on a.psnid = w.pk_psndoc left join zijinehr.bd_psncl y on w.pk_psncl = y.pk_psncl where a.cyear = '" + strYear + "' and a.istopflag = '0' and a.icheckflag = '1' and d.ipayoffflag = '1' and a.f_1 <> '0' and y.psnclasscode <> '0' and b.pk_corp='1002' and a.cperiod = '" + strMonth + "' group by b.pk_corp,y.psnclasscode,a.psnid,w.psncode,w.psnname,a.cnestyear,a.cperiod, b.deptcode,b.deptname order by a.cperiod desc";

            Log_Txt_BB("SQLpay:" + sqlPay, "WxPayPush");
            DataSet ds = new DataSet();
            try
            {
                //ds = OracleHelper.Query(strSql01);
                ds = BBoracleHelperNoClient.Query(sqlPay);
            }
            catch (Exception e) { Log_Txt_BB("Error:" + e.ToString(), "WxPayPush"); }


            Log_Txt_BB("ds.Tables[0].Rows.Count:" + ds.Tables[0].Rows.Count.ToString(), "WxPayPush");
            if (ds.Tables[0].Rows.Count > 1)
            {
                string[] strReturn = new string[2];
                try
                {
                    strReturn = GetPushUsers("wx9a845683e36a17e1", "jtZi9yu_YcT0wldGjJezC5s_3w7apzsJmkHRMOSqa2Y", 1000024, "HrSalary_access_token");
                }
                catch (Exception e) { Log_Txt_BB("Error:" + e.ToString(), "WxPayPush"); }
                string suite_access_token = strReturn[0];
                string pushUsers = strReturn[1];

                Log_Txt_BB("suite_access_token:" + suite_access_token + ";pushUsers:" + pushUsers, "WxPayPush");
                int agentid = 1000024;
                string strAll = "@all";
                string strTextCard = "textcard";
                string surl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + suite_access_token;
                string param = "{\"touser\":\"" + pushUsers + "\",\"toparty\":\"" + strAll + "\",\"totag\":\"" + strAll + "\",\"msgtype\":\"" + strTextCard + "\",\"agentid\":\"" + agentid + "\",\"textcard\":" + "{\"title\":\"" + "您的本月工资已审核发放：第" + DateTime.Now.ToString("yyyyMM") + "期" + "\",\"description\":\"" + "请点击详情查看,若有疑问请以HR工资查询系统为准。" + "\",\"url\":\"http://wxqyh.zjky.cn:9099/Moulds/QueryHRsalary/QueryHRsalary1.aspx\"}" + "}";
                string oauth_suite = HttpHelper.Post(surl, param);
                Log_Txt_BB("推送成功,结束任务!" + "返回值[" + oauth_suite + "];推送人ID[" + pushUsers + "]", "WxPayPush");
                foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
                {
                    if (dgvr.Cells["Column1"].Value.ToString() == "WxPayPush")
                    {
                        if (dgvr.Cells["Column4"].Value.ToString() == "ON")
                        {
                            JobManager.RemoveJob("WxPayPush"); dgvr.Cells["Column4"].Value = "OFF";
                            PublicFunc.WriteINI("SysConfig", "MissionState3", "OFF");
                            Log_Txt_BB("WxPayPush任务被终止\n", "WxPayPush");
                        }
                    }
                }
                Log_Txt_BB("推送成功,结束任务!" + pushUsers, "WxPayPush");

                //string TxlAppId = "wx9a845683e36a17e1";
                //string txlsecret = "i_v6R_C3vdd-FJ34nwZ9aH6hTptwqTTp8U8SvKapyWQ";
                //string txltoken = Caches.GetAccessToken(TxlAppId, txlsecret, "TXL_access_token");
                //UserList ulTmp = OpenApi.GetUserList(txltoken, "1", 1);

                //Database db = new Database();
                //DataTable dt = new DataTable();
                //DataTable dtPay = new DataTable();
                //dtPay = ds.Tables[0];
                //db = new Database(MySecurity.SDecryptString("6471D78118BA329322416E4A6DB2D3DC075FA5FA22DA72308BE945300B33B5D432894856B0F335E002E0DC1AFCFE94C158AA62C5117FBDEBF296EE8E252BC7ADF7C3FAC50E93F7956D29DC034606A91DB142329DE6E83CA4", "zjOaCpHrDatabase"));
                //string strSql = "SELECT zjky$dzb_f5651,zjky$dzb_f5652 FROM zjkynew103.ezoffice.zjky$dzb";
                //dt = new DataTable();
                //dt = db.GetDataTable(strSql);

                //foreach (DataRow drPay in dtPay.Rows)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        if (drPay["人员编码"].ToString() == dr["zjky$dzb_f5652"].ToString())
                //        {
                //            string oaName = dr["zjky$dzb_f5651"].ToString();
                //            foreach (UserList.Userlist bbul in ulTmp.userlist)
                //            {
                //                if (bbul.name == oaName) { }
                //            }
                //        }
                //    }
                //}
            }


        }

        /// <summary>
        /// 查询党费缴纳情况并推送提示
        /// </summary>
        private void DfTips()
        {
            Log_Txt_BB("开始执行任务:机关第一支部党费查询", "DfTips");

            DataView dv = new DataView();
            Database db = new Database("Data Source=.;Initial Catalog=XXB_weixin;User ID=sa;Password=Bb123");

            string strSql00 = "update wxGroupUser set userstate = '0'";
            db.ExecuteSQL(strSql00);

            string[] strReturn = new string[2];
            try
            {
                strReturn = GetPushUsers("wx9a845683e36a17e1", "XXL4ypLPuZbZIRbV-jgjqs25hbfiMswCRUPo5k1i-eE", 1000054, "GroupDQ001_access_token");
            }
            catch (Exception e) { Log_Txt_BB("Error:" + e.ToString(), "DfTips"); }
            string suite_access_token = strReturn[0];
            string AgentUsers = strReturn[1];
            foreach (string strtmp in AgentUsers.Split('|'))
            {
                if (!string.IsNullOrEmpty(strtmp))
                {
                    if (strtmp == "17654") { continue; }
                    UserInfo2 ui2 = OpenApi.GetUserInfo2(suite_access_token, strtmp);

                    string strSql02 = "select * from wxGroupUser where UserId = '" + strtmp + "'";
                    dv = db.GetDataView(strSql02);
                    if (dv.Count < 1 )
                    {
                        string strSql03 = "insert into wxGroupUser(AgentId,AppName,UserId,UserName,UserDpId,UserDpName,UserState)values('1000054','机关第一支部','" + strtmp + "','" + ui2.name + "','" + "" + "','" + "" + "','" + "1" + "')";
                        db.ExecuteSQL(strSql03);
                    }
                    else
                    {
                        string strSql04 = "update wxGroupUser set userstate = '1' where UserId = '" + strtmp + "'";
                        db.ExecuteSQL(strSql04);
                    }
                }
            }
            string strSql01 = "select a.id,a.UserId,a.UserName,b.id as DfId,b.UserDpId,b.UserDpName,isnull(b.DangFei,'0') as DangFei,(case when b.State='1' then '已缴' else '未缴' end) as State,b.TimeOfTurnIn,b.CheckPerson from wxGroupUser a left join (select * from wxGroup001DF where TimeOfTurnIn = '" + DateTime.Now.ToString("yyyy-MM") + "') b on a.UserId=b.UserId where a.userstate = '1'";
            Log_Txt_BB("SQL01" + strSql01, "DfTips");
            dv = db.GetDataView(strSql01);
            string dfPushTips = "";
            foreach (DataRow dr in dv.Table.Rows)
            {
                if (dr["State"].ToString() == "未缴")
                {
                    dfPushTips = dfPushTips + dr["UserId"].ToString() + "|";
                }
            }

            int MissionParamPer = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamPer4"));
            int MissionParamMinut = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamMinut4"));
            int MissionParamHour = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamHour4"));
            int MissionParamDay = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionParamDay4"));
            int MissionIsAllowPush = System.Convert.ToInt32(PublicFunc.ReadINI("SysConfig", "MissionIsAllowPush4"));

            int agentid = 1000054;
            string strAll = "@all";
            string strTextCard = "textcard";
            string surl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + suite_access_token;
            string param = "{\"touser\":\"" + dfPushTips + "\",\"toparty\":\"" + strAll + "\",\"totag\":\"" + strAll + "\",\"msgtype\":\"" + strTextCard + "\",\"agentid\":\"" + agentid + "\",\"textcard\":" + "{\"title\":\"" + "温馨提示：您尚未缴纳第" + DateTime.Now.ToString("yyyyMM") + "期党费,请及时缴纳" + "\",\"description\":\"" + "请点击详情查看。您的企业还没有开通微信支付，申请后将在微信支付商户平台中开启【企业微信专区】\n每" + MissionParamPer + "个月" + MissionParamDay + "号" + MissionParamHour + "点" + MissionParamMinut + "分" + "\",\"url\":\"http://wxqyh.zjky.cn:9099/Moulds/ZJGroup/DangQun/DqDfQuery.aspx\"}" + "}";
            if (MissionIsAllowPush == 1)
            {
                string oauth_suite = HttpHelper.Post(surl, param);
                Log_Txt_BB("推送成功,结束任务!" + "返回值[" + oauth_suite + "];推送人ID[" + dfPushTips + "]", "DfTips");
            }
            else
            {
                Log_Txt_BB("推送配置MissionIsAllowPush4=0,取消推送，结束任务!" + "推送人ID[" + dfPushTips + "]", "DfTips");
            }
        }

        /// <summary>
        /// 获取应用可见范围人员ID
        /// </summary>
        /// <param name="strAppId"></param>
        /// <param name="strSecret"></param>
        /// <param name="intAgentid"></param>
        /// <param name="tokenName"></param>
        /// <returns></returns>
        private string[] GetPushUsers(string strAppId, string strSecret, int intAgentid, string tokenName)
        {
            string appId = strAppId;
            string secret = strSecret;
            int agentid = intAgentid;
            string suite_access_token = Caches.GetAccessTokenDqNews(appId, secret, tokenName);
            AgentUserList aul = OpenApi.GetAgentUserList(suite_access_token, agentid);

            string[] strReturn = new string[2];
            strReturn[0] = suite_access_token;
            string strUerIds = "";
            foreach (string strPid in aul.allow_partys.partyid)
            {
                UserList ulTmp = OpenApi.GetUserList(suite_access_token, strPid, 1);
                for (int k = 0; k < ulTmp.userlist.Count; k++)
                {
                    //string strdp = getDPstr(txlToken, ulTmp.userlist[k].department.ToString(), "").Replace("紫金矿业集团>", "");
                    string strSQL = ulTmp.userlist[k].userid;
                    strUerIds = strUerIds + ulTmp.userlist[k].userid + "|";
                }
            }
            foreach (Dictionary<string, string> dicUser in aul.allow_userinfos.user)
            {
                strUerIds = strUerIds + dicUser["userid"].ToString() + "|";
            }
            strReturn[1] = strUerIds;
            return strReturn;
        }

        #region BB写日志
        private void SetText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                Action<string> setTextCallBack = SetText;
                this.Invoke(setTextCallBack, new object[] { text });
            }
            else
            {
                if (this.richTextBox1.Lines.Length >= iClearLint)
                {
                    this.richTextBox1.Clear();
                }
                this.richTextBox1.AppendText(text + "\n");
            }
        }
        /// <summary>
        /// BB写文本日志
        /// </summary>
        /// <param name="strDes"></param>
        /// <param name="strCode"></param>
        /// <param name="strMsg"></param>
        private void Log_Txt_BB(string strMsg, string strMissionName)
        {
            try
            {
                string strISFile = strLogSign;
                string strMsgBB = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "[" + strMissionName + "]" + "[" + strMsg + "]\r\n";
                string strFilePathName = System.Convert.ToString(System.Environment.CurrentDirectory + @"\Log\" + strProgramCode + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".Log");
                //IList ilsMsg = new ArrayList();
                //Thread.Sleep(6);
                lock (sysObject)
                {
                    Mutex mut = new Mutex();
                    mut.WaitOne();
                    LogBB log = new LogBB(strMsgBB, strFilePathName, new LogBB.LogCallback(SetText));
                    if (strISFile != null)//默认为不写文件
                    {
                        if (strISFile == "1")
                        {
                            oThread = new Thread(new ThreadStart(log.LogNoFile));
                        }
                        else
                        {
                            oThread = new Thread(new ThreadStart(log.LogYesFile));
                        }
                    }
                    else
                    {
                        oThread = new Thread(new ThreadStart(log.LogNoFile));
                    }
                    //oThread.Name = ProceSign;
                    oThread.Start();
                    mut.ReleaseMutex();
                }
            }
            catch (Exception ex)
            {
                SetText("写日志出现异常:" + ex.Message);
            }
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText == "Start")
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value.ToString() == "OFF")
                {
                    string strJobName = this.dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                    string strMiMode = this.dataGridView1.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
                    PublicFunc.WriteINI("SysConfig", "MissionState" + (e.RowIndex + 1).ToString(), "ON");
                    loadMissionMode(strMiMode, e.RowIndex + 1, "ClickCellStart");
                    this.dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value = "ON";
                    Log_Txt_BB(strJobName + "任务被启动", "ClickCellStart");
                }
            }
            else if (this.dataGridView1.Columns[e.ColumnIndex].HeaderText == "Stop")
            {
                string strJobName = this.dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                this.dataGridView1.Rows[e.RowIndex].Cells["Column4"].Value = "OFF";
                PublicFunc.WriteINI("SysConfig", "MissionState" + (e.RowIndex + 1).ToString(), "OFF");
                JobManager.RemoveJob(strJobName);
                Log_Txt_BB(strJobName + "任务被终止", "ClickCellStop");
            }
        }

        private XmlNode FoundChildNode(XmlNode Node, string Name)
        {
            XmlNode childlNode = null;
            for (int i = 0; i < Node.ChildNodes.Count; i++)
            {
                if (Node.ChildNodes[i].Name == Name && Node.ChildNodes[i].ChildNodes.Count > 0)
                {
                    childlNode = Node.ChildNodes[i];
                    return childlNode;
                }
            }
            return childlNode;
        }
        private rss.Item getRssItem(XmlNode Node)
        {
            rss.Item item = new rss.Item();
            for (int i = 0; i < Node.ChildNodes.Count; i++)
            {
                if (Node.ChildNodes[i].Name == "title")
                {
                    item.Title = Node.ChildNodes[i].InnerText;
                }
                else if (Node.ChildNodes[i].Name == "description")
                {
                    item.Description = Node.ChildNodes[i].InnerText;
                }
                else if (Node.ChildNodes[i].Name == "link")
                {
                    item.Link = Node.ChildNodes[i].InnerText;
                }
                else if (Node.ChildNodes[i].Name == "pubDate")
                {
                    item.pubDate = Node.ChildNodes[i].InnerText;
                }
            }
            return item;
        }
        public rss.Channel ReadXml(string rssPath)
        {
            XmlTextReader Reader = new XmlTextReader(rssPath);
            // XmlValidatingReader Valid = new XmlValidatingReader(Reader);  
            // Valid.ValidationType = ValidationType.None;  
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Reader);
            XmlNode rssNode = FoundChildNode(xmlDoc, "rss");
            XmlNode channelNode = FoundChildNode(rssNode, "channel");
            rss.Channel channel = new rss.Channel();
            channel.Items = new Hashtable();
            for (int i = 0; i < channelNode.ChildNodes.Count; i++)
            {
                switch (channelNode.ChildNodes[i].Name)
                {
                    case "title":
                        {
                            channel.Title = channelNode.ChildNodes[i].InnerText;
                            break;
                        }
                    case "item":
                        {
                            rss.Item item = this.getRssItem(channelNode.ChildNodes[i]);
                            channel.Items.Add(channel.Items.Count, item);
                            break;
                        }
                }
            }
            return channel;

        }
        public class rss
        {
            public struct Channel
            {
                public string Title;
                public Hashtable Items;
            }

            public struct Item
            {
                public string Title;
                public string Description;
                public string Link;
                public string pubDate;
            }
        }
    }
}
