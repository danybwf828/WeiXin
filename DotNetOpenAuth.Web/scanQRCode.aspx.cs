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
    public partial class scanQRCode : System.Web.UI.Page
    {
        public string appId = "", nonceStr = "", signature = "", secret = "";
        public long timestamp = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bool breakWrite = false;
                try
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
                    secret = ConfigurationManager.AppSettings["SecretQrCode"];
                    string url = Request.Url.ToString();
                    string token = Caches.GetAccessToken(appId, secret, "ScanQrCode_access_token");
                    if (!string.IsNullOrWhiteSpace(token))
                    {
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
    }
}