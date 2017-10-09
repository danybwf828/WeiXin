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
    public partial class PlanRules : System.Web.UI.Page
    {
        public string appId = "", timestamp = "", nonceStr = "", signature = "", secret = "", userID = "", deviceId = "", debug = "", userInfo2 = "", userName = "",uMode="";

        public static Database db = null;

        public static bool QureyOn = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bool breakWrite = false;
                db = new Database();

                int weekNum = GetWeekNum(DateTime.Now.DayOfWeek.ToString());

                this.Date1.Value = DateTime.Now.AddDays(8 - weekNum).ToString("yyyy-MM-dd");

                this.Date2.Value = DateTime.Now.AddDays(14 - weekNum).ToString("yyyy-MM-dd");

                string[] strBret = BBcheckRadioBut();
                string strMode = strBret[0];
                string strState = strBret[1];

                try
                {
                    string state = Request["state"];
                    string strUserIn=Request["UserIn"];
                    string strStarTimeIn=Request["StarTimeIn"];
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
                    else if (!string.IsNullOrEmpty(strUserIn))//推送消息进入
                    {
                        this.Date1.Value = strStarTimeIn;
                        this.Date2.Value = "2027-01-01";
                        if (QureyOn) { bindData(strUserIn, strStarTimeIn, "2027-01-01", "", strState); } 
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

                        //Helper.WriteLog("AppID:" + appId);
                        //Helper.WriteLog("secret:" + secret);
                        //Helper.WriteLog("url:" + url);

                        string token = Caches.GetAccessToken(appId, secret, "PlanFQ_access_token");
                        //Helper.WriteLog("token:" + token);

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
                                    //deviceId = ui.DeviceId;
                                    ////Helper.WriteLog("userID:" + userID);
                                    ////Helper.WriteLog("deviceId:" + deviceId);
                                    //UserInfo2 ui2 = OpenApi.GetUserInfo2(token, userID);
                                    //userName = ui2.name; Session["uName"] = ui2.name;
                                    //string position = ui2.position;
                                    //string mobile = ui2.mobile;
                                    //string[] department = ui2.department;
                                    ////Helper.WriteLog("department:" + department[0]);
                                    //int isleader = ui2.isleader;
                                    //string strTmpDp = "";
                                    //string strTmpDpId = "";
                                    //string strTmpDp2 = "";
                                    //for (int i = 0; i < department.Length; i++)
                                    //{
                                    //    string txlsecret = "i_v6R_C3vdd-FJ34nwZ9aH6hTptwqTTp8U8SvKapyWQ";
                                    //    string txltoken = Caches.GetAccessToken(appId, txlsecret, "TXL_access_token");
                                    //    //Helper.WriteLog("txlsecret:" + txlsecret);
                                    //    Session["uDpId"] = department[i];
                                    //    strTmpDp = getDPstr(txltoken, department[i], strTmpDp);
                                    //    strTmpDpId = getDPIDstr(txltoken, department[i], strTmpDpId);
                                    //    strTmpDp2 = "部门" + i.ToString() + ":" + strTmpDp + "\r\n";
                                    //}
                                    //string[] strDptmp = strTmpDp.Split('>');
                                    //Session["uDp"] = strDptmp[strDptmp.Length - 1];
                                    //Session["uSDpId"] = strTmpDpId;
                                    //Session["uUpDp"] = strTmpDp.Replace(strDptmp[strDptmp.Length - 1], "");


                                    bindData(userID, this.Date1.Value, this.Date2.Value, strMode, strState);
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

                                //Helper.WriteLog("debug:" + debug);

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
                    Response.Write("签到失败 : " + ex.Message);
                    breakWrite = true;
                }
                if (breakWrite)
                {
                    Response.End();
                    return;
                }
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
        /// 根據用戶id、時間區間查詢綁定
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="strStarTime"></param>
        /// <param name="strStopTime"></param>
        /// <param name="strMode"></param>
        /// <param name="strState"></param>
        void bindData(string uId,string strStarTime,string strStopTime,string strMode,string strState)
        {
            DataView dv = new DataView();
            string strSql01 = "select id,uId,uName,department,department2,Superior_department,uStarTime,uStopTime,uPlan,uMode,timestamp,uPlace,uPlaceInfo from wxPlan where uId like '%" + uId + "%' and uStarTime >= '" + strStarTime + "' and uStopTime <= '" + strStopTime + "' and uMode like '%" + strMode + "%' and uState like '%" + strState + "%'";
            dv = db.GetDataView(strSql01);
            AspNetPager1.RecordCount = dv.Table.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dv;

            GridView1.DataSource = pds;
            GridView1.DataBind();
        }

        /// <summary>
        /// 根据可查询部门id设置、可查询用户id设置查询綁定
        /// </summary>
        /// <param name="strDp"></param>
        /// <param name="strId"></param>
        /// <param name="strStarTime"></param>
        /// <param name="strStopTime"></param>
        /// <param name="struMode"></param>
        /// <param name="strState"></param>
        void bindData(string strDp, string strId, string strStarTime, string strStopTime, string struMode,string strState)
        {
            DataView dv = new DataView();
            string strSql01 = "";
            string sqltmp = "";
            string sqltmp2 = ""; 
            if (string.IsNullOrEmpty(strDp) )
            {
                if (string.IsNullOrEmpty(strId))
                {
                    strSql01 = "select id,uId,uName,department,departmentId,department2,Superior_department,Superior_departmentId,uStarTime,uStopTime,uPlan,uMode,timestamp,uPlace,uPlaceInfo from wxPlan where uId ='" + Session["uId"] + "' and uStarTime >= '" + strStarTime + "' and uStopTime <= '" + strStopTime + "' and uMode like '%" + struMode + "%' and uState like '%" + strState + "%'";
                }
                else
                {
                    sqltmp2 = "(uId";
                    for (int i = 0; i < strId.Split(',').Length; i++)
                    {
                        if (i == strId.Split(',').Length - 1) { sqltmp2 = sqltmp2 + " like '%" + strId.Split(',')[i] + "%')"; }
                        else { sqltmp2 = sqltmp2 + " like '%" + strId.Split(',')[i] + "%' or uId"; }
                    }
                    strSql01 = "select id,uId,uName,department,departmentId,department2,Superior_department,Superior_departmentId,uStarTime,uStopTime,uPlan,uMode,timestamp,uPlace,uPlaceInfo from wxPlan where " + sqltmp2 + " and uStarTime >= '" + strStarTime + "' and uStopTime <= '" + strStopTime + "' and uMode like '%" + struMode + "%' and uState like '%" + strState + "%'";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(strId))
                {
                    sqltmp = "(Superior_departmentId";
                    for (int i = 0; i < strDp.Split(',').Length; i++)
                    {
                        if (i == strDp.Split(',').Length - 1) { sqltmp = sqltmp + " like '%" + strDp.Split(',')[i] + "%')"; }
                        else { sqltmp = sqltmp + " like '%" + strDp.Split(',')[i] + "%' or Superior_departmentId"; }
                    }
                    strSql01 = "select id,uId,uName,department,departmentId,department2,Superior_department,Superior_departmentId,uStarTime,uStopTime,uPlan,uMode,timestamp,uPlace,uPlaceInfo from wxPlan where " + sqltmp + " and uStarTime >= '" + strStarTime + "' and uStopTime <= '" + strStopTime + "' and uMode like '%" + struMode + "%' and uState like '%" + strState + "%'";
                }
                else
                {
                    sqltmp = "(Superior_departmentId";
                    for (int i = 0; i < strDp.Split(',').Length; i++)
                    {
                        if (i == strDp.Split(',').Length - 1) { sqltmp = sqltmp + " like '%" + strDp.Split(',')[i] + "%')"; }
                        else { sqltmp = sqltmp + " like '%" + strDp.Split(',')[i] + "%' or Superior_departmentId"; }
                    }
                    sqltmp2 = "(uId";
                    for (int i = 0; i < strId.Split(',').Length; i++)
                    {
                        if (i == strId.Split(',').Length - 1) { sqltmp2 = sqltmp2 + " like '%" + strId.Split(',')[i] + "%')"; }
                        else { sqltmp2 = sqltmp2 + " like '%" + strId.Split(',')[i] + "%' or uId"; }
                    }
                    strSql01 = "select id,uId,uName,department,departmentId,department2,Superior_department,Superior_departmentId,uStarTime,uStopTime,uPlan,uMode,timestamp,uPlace,uPlaceInfo from wxPlan where (" + sqltmp + "or " + sqltmp2 + ") and uStarTime >= '" + strStarTime + "' and uStopTime <= '" + strStopTime + "' and uMode like '%" + struMode + "%' and uState like '%" + strState + "%'";
                }
            }
            //Helper.WriteLog("SQL01" + strSql01, "PlanQuery");
            dv = db.GetDataView(strSql01);
            AspNetPager1.RecordCount = dv.Table.Rows.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dv;

            GridView1.DataSource = pds;
            GridView1.DataBind();
        }

        public string[] BBcheckRadioBut()
        {
            string strMode = "";
            if (this.RadioButton1.Checked) { strMode = this.RadioButton1.Text; };
            if (this.RadioButton2.Checked) { strMode = this.RadioButton2.Text; };
            if (this.RadioButton3.Checked) { strMode = this.RadioButton3.Text; };
            string strState = "";
            if (this.RadioButton4.Checked) { strState = this.RadioButton4.Text; };
            if (this.RadioButton5.Checked) { strState = this.RadioButton5.Text; };
            if (this.RadioButton6.Checked) { strState = ""; };
            string[] strRetuStr = new string[2];
            strRetuStr[0]=strMode;strRetuStr[1]=strState;
            return strRetuStr;
        }

        public bool BBcheckPage()
        {
            if (string.IsNullOrEmpty(this.Date1.Value)) { Show(this, "请输入起始时间!"); return false; }
            if (string.IsNullOrEmpty(this.Date2.Value)) { Show(this, "请输入结束时间!"); return false; }
            return true;
        }

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

        public string[] BBcheckQueryAuthority() 
        {
            DataView dv = new DataView(); 
            string[] strUserNDp = new string[3];
            string strSql01 = "select id,userId,userName,userDpId,userDpName,isAllow,QueryDpId,QueryDpName,QueryUserId,QueryUserName from wxQueryAuthority where userId like '%" + Session["uId"] + "%'";
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
                    //Helper.WriteLog("strIsAllow:" + strIsAllow + strQueryDpId + strQueryUserId);
                    strUserNDp[0] = strIsAllow;
                    strUserNDp[1] = strQueryDpId;
                    strUserNDp[2] = strQueryUserId;
                    return strUserNDp;
                }
            }
            catch { return strUserNDp; }
        }

        public void Show(System.Web.UI.Page page, string msg)
        {
            Response.Write("<script>alert('" + msg + "')</script>");
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] strQAmsg = new string[3];
            strQAmsg = BBcheckQueryAuthority();

            string[] strBret = BBcheckRadioBut();
            string strMode = strBret[0];
            string strState = strBret[1];

            if (strQAmsg[0] == "1") { bindData("", this.Date1.Value, this.Date2.Value, strMode,strState); }
            else {  bindData(strQAmsg[1], strQAmsg[2], this.Date1.Value, this.Date2.Value, strMode,strState); }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
        }

        protected void UserDp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void UserCp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)//判定当前的行是否属于datarow类型的行
            {
                //当鼠标放上去的时候 先保存当前行的背景颜色 并给附一颜色
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='yellow',this.style.fontWeight='';");
                //当鼠标离开的时候 将背景颜色还原的以前的颜色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor,this.style.fontWeight='';");
            }
            //单击行改变行背景颜色
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "this.style.backgroundColor='#99FFcc'; this.style.color='buttontext';this.style.cursor='default';");
                try
                {
                    string bbtext = "GridViewItemKeyDownEvent('" + "姓名:" + e.Row.Cells[5].Text + @"\n公司:" + e.Row.Cells[4].Text.Replace("&gt;", ">") + @"\n时间:" + e.Row.Cells[9].Text + "至" + e.Row.Cells[10].Text + @"\n状态:" + e.Row.Cells[6].Text + "-" + e.Row.Cells[7].Text + @"\n地点:" + e.Row.Cells[8].Text + @"\n计划:" + e.Row.Cells[11].Text + "')";
                    e.Row.Attributes.Add("OnDblClick", bbtext);
                }
                catch (Exception eGvDbClk)
                {
                    Helper.WriteLog("双击显示计划任务错误:" + eGvDbClk.ToString() + "]", "PlanQuery");
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Response.Write("<script>confirm('刪除后可查询但无法恢复!确认删除?')</script>");
            string nid = GridView1.Rows[e.RowIndex].Cells[0].Text.ToString();
            string strSql01 = "update wxPlan set uState = '删除',LastOperatePerId = '" + Session["uId"] + "',LastOperatePerson ='" + Session["uName"] + "',timestamp = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "' where id = '" + nid + "'";
            string strSql02 = "delete from wxPlan where id ='" + nid + "'";
            db.ExecuteSQL(strSql01);
            Show(this, "删除成功!" + nid);

            string[] strBret = BBcheckRadioBut();
            string strMode = strBret[0];
            string strState = strBret[1];

            bindData(userID, this.Date1.Value, this.Date2.Value, strMode, strState);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}