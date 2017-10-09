using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Utilities;
using System.Configuration;

namespace DotNetOpenAuth.Web
{
    public partial class bbEncrypt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //来自：http://www.DotNetOpenAuth.com
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Helper.WriteLog(MySecurity.SEncryptString("Password=zjehr123;User ID=zijinehr;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.23.103)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));", "zjhrpay"), "defaultEncrypt");
            //Helper.WriteLog(MySecurity.SEncryptString("Data Source=.;Initial Catalog=XXB_weixin;User ID=sa;Password=Bb123", "zjMobileDatabase"), "defaultEncrypt");
            //Helper.WriteLog(MySecurity.SDecryptString("C0DFC80CF83B39DD97F2F94049C0D21EE8236852D70DB171FB25418BF859336360C79F450D31B32C36C3C2B25E6C9AF6FCF0554E21844C7497E6CFD89368530A7FBAC65B1C7B42F5AC80EFD9D0957B52C31302F6A3F110AAB3385BA87B57C0C9315D2F752CBF394DC7DCF4372A4BA9B590B32B7F3209A825F49CC34DA9730B9AE90442F186DD0A9A148DA33F1310C6294A921280FE135475AEDD76E04D0AFC7BC918D9B8B14CBBFB674DD496A96ADBA81E7A91FE74919398B9B90BCC4CE2D106", "zjhrpay"), "defaultDecrypt");
            //Helper.WriteLog(MySecurity.SDecryptString("8C0D15DE55285BC30B7A8F10C7F9D5D8F19EF201B8D40BC3F7DC4DD58E128B217702F902AF8427E4D1D5FF5F833E41BA57300E79F16ADB3AFA44222CC259604B9265BFDD4020A009", "zjMobileDatabase"), "defaultDecrypt");
            Helper.WriteLog(MySecurity.SEncryptString("Data Source=172.22.22.14;Initial Catalog=zjkynew103;User ID=gzcx;Password=gzcx#123", "zjOaCpHrDatabase"), "defaultEncrypt");
            Helper.WriteLog(MySecurity.SDecryptString("6471D78118BA329322416E4A6DB2D3DC075FA5FA22DA72308BE945300B33B5D432894856B0F335E002E0DC1AFCFE94C158AA62C5117FBDEBF296EE8E252BC7ADF7C3FAC50E93F7956D29DC034606A91DB142329DE6E83CA4", "zjOaCpHrDatabase"), "defaultDecrypt");
        }

        /// <summary>
        /// 根據用戶id、時間區間查詢綁定
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="strStarTime"></param>
        /// <param name="strStopTime"></param>
        /// <param name="strMode"></param>
        /// <param name="strState"></param>
        public DataTable getSalaryByName(string userName, string strYear)
        {
            DataTable dv = new DataTable();
            string strSql01 = "select w.psncode as 人员编码,w.psnname as 人员名称,a.cnestyear as 年,a.cperiod as 月, b.deptcode as 部门代码, b.deptname as 部门名称, b.pk_corp as 公司代码,a.psnid as HRXZ0070018,sum(F_1) as  应发合计,sum(F_3) as 实发合计,sum(F_245) as 奖金,sum(F_246+F_465+F_466)  as 津贴,sum(F_2) as 扣款,sum(F_244) as 职工福利费,sum(F_376) as 工资,sum(F_248) as 假期工资,sum(F_247) as 加班工资,sum(F_381) as 其他收入,sum(F_159 + F_158) 辞退福利,sum(F_322) as 上级单位奖励本年度,sum(F_67) as 上级单位奖励上年度,sum(F_1 + F_148 + F_146 + F_147 + F_143 + F_145 + F_144 + F_399 +F_400 + F_152 + F_402) as 企业承担该员工人员成本,sum(F_88) as 过节费,sum(F_459) as 考核额度,sum(F_24) as 考核工资 from zijinehr.wa_data a inner join zijinehr.bd_deptdoc b on a.deptid = b.pk_deptdoc inner join (select e.ipayoffflag, e.classid, f.cnestyear, f.cnestperiod from zijinehr.wa_periodstate e inner join zijinehr.wa_period f on f.pk_wa_period = e.pk_periodset) d on d.cnestyear = a.cnestyear and d.cnestperiod = a.cnestperiod and d.classid = a.classid left join zijinehr.bd_psndoc w    on a.psnid = w.pk_psndoc left join zijinehr.bd_psncl y on w.pk_psncl = y.pk_psncl where a.cyear = '" + strYear + "' and a.istopflag = '0' and a.icheckflag = '1' and d.ipayoffflag = '1' and a.f_1 <> '0' and y.psnclasscode <> '0' and b.pk_corp='1002' and w.psnname = '" + userName + "' group by b.pk_corp,y.psnclasscode,a.psnid,w.psncode,w.psnname,a.cnestyear,a.cperiod, b.deptcode,b.deptname order by a.cperiod desc";
            Helper.WriteLog("strSql01:" + strSql01, "QueryHRslary");
            DataSet ds = OracleHelper.Query(strSql01);
            return ds.Tables[0];
        }
    }
}
