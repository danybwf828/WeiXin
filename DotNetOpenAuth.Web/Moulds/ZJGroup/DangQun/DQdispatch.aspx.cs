using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

using System.Data;
using System.Configuration;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ComputerRepair.DataAccessLayer;

namespace DotNetOpenAuth.Web.Moulds.ZJGroup.DangQun
{
    public partial class DQdispatch : System.Web.UI.Page
    {
        public static Database db = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Files will be upload when postback */
            Helper.WriteLog("setp1:", "DQdispatch");
            if (!IsPostBack)
            {
                Helper.WriteLog("setp2:", "DQdispatch");
                if (this.Request.Files.Count > 0)
                {
                    HttpPostedFile f = this.Request.Files[0];
                    string fname = f.FileName;
                    /* startIndex */
                    int index = fname.LastIndexOf("\\") + 1;
                    /* length */
                    int len = fname.Length - index;
                    fname = fname.Substring(index, len);
                    /* save to server */
                    Helper.WriteLog("setp3:", "DQdispatch");
                    string dtNow = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string filePath = this.Server.MapPath("~/Moulds/ZJGroup/DangQun/Photos/" + dtNow + fname);
                    string strIssTitle = Request.Form["issTitle"];
                    string strIssWords = Request.Form["issWords"];
                    f.SaveAs(filePath);

                    db = new Database();
                    string strSQL = "insert into wxDispatch(d_userID,d_userName,d_issTime,d_timestamp,d_state,d_imagePath1,d_imagePath2,d_title,d_words)values('14789','唐泽','" + dtNow + "','" + dtNow + "','1','" + filePath + "','" + filePath + "','" + strIssTitle + "','" + strIssWords + "')";
                    Helper.WriteLog("setp4:" + strSQL, "DQdispatch");
                    db.ExecuteSQL(strSQL);


                    Response.Write("<script type='text/javascript'>alert('Success!');</script>");
                    Helper.WriteLog("setp5:", "DQdispatch");
                }
            }
        } 
    }
}