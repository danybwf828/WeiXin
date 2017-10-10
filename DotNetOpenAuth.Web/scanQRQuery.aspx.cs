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
{
    public partial class scanQRQuery : System.Web.UI.Page
    {
        public string appId = "", timestamp = "", nonceStr = "", signature = "", secret = "", userID = "", deviceId = "", debug = "", userInfo2 = "", userName = "", uMode = "";

        public static Database db = null;

        public static bool QureyOn = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bool breakWrite = false;
                db = new Database();

                this.Date1.Value = DateTime.Now.ToString("yyyy");
                try
                {
                    string state = Request["state"];
                    string strUserIn = Request["UserIn"];
                    string strStarTimeIn = Request["StarTimeIn"];
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
                        if (QureyOn) { }
                    }
                    else
                    {
                        #region
                        appId = ConfigurationManager.AppSettings["AppID"];
                        secret = ConfigurationManager.AppSettings["SecretQrCode"];
                        string url = Request.Url.ToString();

                        //Helper.WriteLog("AppID:" + appId);
                        //Helper.WriteLog("secret:" + secret);
                        //Helper.WriteLog("url:" + url);

                        string token = Caches.GetAccessToken(appId, secret, "ScanQrCode_access_token");
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
                                    UserInfo2 ui2 = OpenApi.GetUserInfo2(token, userID);
                                    userName = ui2.name; Session["uName"] = ui2.name;
                                    bindData(userName, this.Date1.Value);
                                }
                                else
                                {
                                    userID = "无法获取用户名！";
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

        /// <summary>
        /// 根據用戶id、時間區間查詢綁定
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="strTime"></param>
        void bindData(string uName, string strTime)
        {
            DataView dv = new DataView();
            string strSql01 = "exec sp_configure 'show advanced options',1 reconfigure exec sp_configure 'Ad Hoc Distributed Queries',1 reconfigure";
            string strSql02 = "select '微信' as APP,p.* from participants_info p where p.sing='" + uName + "' UNION all select '钉钉' as APP,p2.* from opendatasource('SQLOLEDB', 'Data Source=172.22.30.221;user ID=sa;password=Bb123;').master.dbo.participants_info p2 where p2.sing='" + uName + "'";
            string strSql03 = "exec sp_configure 'Ad Hoc Distributed Queries',0 reconfigure exec sp_configure 'show advanced options',0 reconfigure";
            Helper.WriteLog("SQL" + strSql01+ strSql02+ strSql03, "scanQRQuery");
            db.ExecuteSQL(strSql01);
            dv = db.GetDataView(strSql02);
            db.ExecuteSQL(strSql03);
            Session["dvlist"] = dv;
            AspNetPager1.RecordCount = dv.Table.Rows.Count;
            BBbindData();
        }
        void BBbindData()
        {
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = (DataView)Session["dvlist"];
            GridView1.DataSource = pds;
            GridView1.DataBind();
        }

        public void Show(System.Web.UI.Page page, string msg)
        {
            Response.Write("<script>alert('" + msg + "')</script>");
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bindData("", this.Date1.Value); 
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
            GridView1.EditIndex = -1;
            BBbindData();
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
                    //string bbtext = "GridViewItemKeyDownEvent('" + "姓名:" + e.Row.Cells[5].Text + @"\n公司:" + e.Row.Cells[4].Text.Replace("&gt;", ">") + @"\n时间:" + e.Row.Cells[9].Text + "至" + e.Row.Cells[10].Text + @"\n状态:" + e.Row.Cells[6].Text + "-" + e.Row.Cells[7].Text + @"\n地点:" + e.Row.Cells[8].Text + @"\n计划:" + e.Row.Cells[11].Text + "')";
                    //e.Row.Attributes.Add("OnDblClick", bbtext);
                }
                catch (Exception eGvDbClk)
                {
                    Helper.WriteLog("双击显示计划任务错误:" + eGvDbClk.ToString() + "]", "PlanQuery");
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set the edit index.
            GridView1.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            BBbindData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Response.Write("<script>confirm('刪除后可查询但无法恢复!确认删除?')</script>");
            string nid = GridView1.Rows[e.RowIndex].Cells[0].Text.ToString();
            string strSql01 = "update wxPlan set uState = '删除',LastOperatePerId = '" + Session["uId"] + "',LastOperatePerson ='" + Session["uName"] + "',timestamp = '" + DateTime.Now.ToString("yyyyMMddHHmmss") + "' where id = '" + nid + "'";
            string strSql02 = "delete from wxPlan where id ='" + nid + "'";
            db.ExecuteSQL(strSql01);
            Show(this, "删除成功!" + nid);

            bindData(userID, this.Date1.Value);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string BBid = ((TextBox)(row.Cells[1].Controls[0])).Text;
            string BBuserId = ((TextBox)(row.Cells[2].Controls[0])).Text;
            string BBuserName = row.Cells[5].Text;
            string BBdf = ((TextBox)(row.Cells[6].Controls[0])).Text;
            string BBstate = ((DropDownList)(row.Cells[7].Controls[0])).Text;

            string sql = "";
            string sqlCheck = "select * from wxGroup001DF where TimeOfTurnIn = '" + this.Date1.Value.ToString() + "' and UserId = '" + BBuserId + "'";
            DataTable dt = new DataTable();
            dt = db.GetDataTable(sqlCheck);
            if (dt.Rows.Count > 0)
            {
                sql = string.Format("update wxGroup001DF set UserId='{0}',UserName='{1}',DangFei='{2}',TimeOfTurnIn='{3}',State='{4}',CheckPerson='{5}',CheckTime='{6}' where id={7}", BBuserId, BBuserName, BBdf, this.Date1.Value.ToString(), BBstate, Session["uName"], DateTime.Now.ToString("yyyyMMddHHmmss"), BBid);
            }
            else
            {
                sql = string.Format("insert into wxGroup001DF (UserId,UserName,DangFei,TimeOfTurnIn,State,CheckPerson,CheckTime)values('" + BBuserId + "','" + BBuserName + "','" + BBdf + "','" + this.Date1.Value.ToString() + "','" + BBstate + "','" + Session["uName"] + "','" + DateTime.Now.ToString("yyyyMMddHHmmss") + "')");
            }
            Helper.WriteLog("SQL02" + sql, "DqDfQuery");

            try
            {
                int i = db.ExecuteSQL(sql);
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language='JavaScript'>alert('修改成功！')</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language='javascript'>alert('修改失败！')</script>");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script language='javascript'>alert('操作无效！')</script>");
            }
            GridView1.EditIndex = -1;
            bindData(userID, this.Date1.Value);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
        public DataTable bbState()
        {
            DataTable tmpDt = new DataTable();
            tmpDt.Columns.Add("State");
            tmpDt.Columns.Add("StateValue");
            DataRow tmpDr1 = tmpDt.NewRow();
            DataRow tmpDr2 = tmpDt.NewRow();
            tmpDr1[0] = "未缴"; tmpDr1[1] = "0"; tmpDt.Rows.Add(tmpDr1); tmpDr2[0] = "已缴"; tmpDr2[1] = "1"; tmpDt.Rows.Add(tmpDr2);
            return tmpDt;
        }
    }
}