using System;
using System.IO;
using System.Text;
using System.Configuration;
using System.Web;
using System.Xml;
using DotNetOpenAuth.SDK;
using DotNetOpenAuth.DataAccess;

//来自：http://www.DotNetOpenAuth.com
namespace DotNetOpenAuth.Web
{//来自：http://www.DotNetOpenAuth.com
    //测试地址：http://qydev.weixin.qq.com/debug
    //文档地址：http://qydev.weixin.qq.com/wiki/index.php
    /// <summary>
    /// weixin 的摘要说明
    /// </summary>
    public class weixin : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {

            string sToken = ConfigurationManager.AppSettings["Token"];
            string sCorpID = ConfigurationManager.AppSettings["AppID"];
            string sEncodingAESKey = ConfigurationManager.AppSettings["EncodingAESKey"];

            WXBizMsgCrypt wxcpt = new WXBizMsgCrypt(sToken, sEncodingAESKey, sCorpID);
            string sVerifyMsgSig = context.Request["msg_signature"];
            // string sVerifyMsgSig = "5c45ff5e21c57e6ad56bac8758b79b1d9ac89fd3";
             string sVerifyTimeStamp = context.Request["timestamp"];
            //string sVerifyTimeStamp = "1409659589";
            string sVerifyNonce = context.Request["nonce"];
            // string sVerifyNonce = "263014780";
             string sVerifyEchoStr = context.Request["echostr"];
            //string sVerifyEchoStr = "P9nAzCzyDtyTWESHep1vC5X9xho/qYX3Zpb4yKa9SKld1DsH3Iyt3tP3zNdtp+4RPcs8TgAE7OaBO+FZXvnaqQ==";
             // Post请求的密文数据
             string sReqData = string.Empty;
             //string sReqData = "<xml><ToUserName><![CDATA[wx5823bf96d3bd56c7]]></ToUserName><Encrypt><![CDATA[RypEvHKD8QQKFhvQ6QleEB4J58tiPdvo+rtK1I9qca6aM/wvqnLSV5zEPeusUiX5L5X/0lWfrf0QADHHhGd3QczcdCUpj911L3vg3W/sYYvuJTs3TUUkSUXxaccAS0qhxchrRYt66wiSpGLYL42aM6A8dTT+6k4aSknmPj48kzJs8qLjvd4Xgpue06DOdnLxAUHzM6+kDZ+HMZfJYuR+LtwGc2hgf5gsijff0ekUNXZiqATP7PF5mZxZ3Izoun1s4zG4LUMnvw2r+KqCKIw+3IQH03v+BCA9nMELNqbSf6tiWSrXJB3LAVGUcallcrw8V2t9EL4EhzJWrQUax5wLVMNS0+rUPA3k22Ncx4XXZS9o0MBH27Bo6BpNelZpS+/uh9KsNlY6bHCmJU9p8g7m3fVKn28H3KDYA5Pl/T8Z1ptDAVe0lXdQ2YoyyH2uyPIGHBZZIs2pDBS8R07+qN+E7Q==]]></Encrypt><AgentID><![CDATA[218]]></AgentID></xml>";
             int ret = 0;
             string sMsg = "";  // 解析之后的明文
             if (!string.IsNullOrWhiteSpace(sVerifyMsgSig))
             {
                 if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
                 {
                     using (Stream stream = HttpContext.Current.Request.InputStream)
                     {
                         Byte[] postBytes = new Byte[stream.Length];
                         stream.Read(postBytes, 0, (Int32)stream.Length);
                         sReqData = Encoding.UTF8.GetString(postBytes);
                     }

                     if (!string.IsNullOrEmpty(sReqData))
                     {
                         context.Response.ContentType = "text/xml";
                         ret = wxcpt.DecryptMsg(sVerifyMsgSig, sVerifyTimeStamp, sVerifyNonce, sReqData, ref sMsg);
                         if (ret != 0)
                         {
                             context.Response.Write("ERR: Decrypt Fail, ret: " + ret);
                             return;
                         }
                         // ret==0表示解密成功，sMsg表示解密之后的明文xml串
                         // TODO: 对明文的处理
                         // For example:
                         XmlDocument doc = new XmlDocument();
                         doc.LoadXml(sMsg);
                         XmlNode root = doc.FirstChild;
                         //string content = root["Content"].InnerText;
                         //context.Response.Write(content);

                         #region 地理位置接口格式
                         /*
                    <xml>
   <ToUserName><![CDATA[toUser]]></ToUserName>
   <FromUserName><![CDATA[FromUser]]></FromUserName>
   <CreateTime>123456789</CreateTime>
   <MsgType><![CDATA[event]]></MsgType>
   <Event><![CDATA[LOCATION]]></Event>
   <Latitude>23.104105</Latitude>
   <Longitude>113.320107</Longitude>
   <Precision>65.000000</Precision>
   <AgentID>1</AgentID>
</xml>
*/
                         /*
                          <xml>
   <ToUserName><![CDATA[toUser]]></ToUserName>
   <FromUserName><![CDATA[fromUser]]></FromUserName>
   <CreateTime>1351776360</CreateTime>
   <MsgType><![CDATA[location]]></MsgType>
   <Location_X>23.134521</Location_X>
   <Location_Y>113.358803</Location_Y>
   <Scale>20</Scale>
   <Label><![CDATA[位置信息]]></Label>
   <MsgId>1234567890123456</MsgId>
   <AgentID>1</AgentID>
</xml>

                          */
                         #endregion

                         try
                         {
                             string toUserName = "", fromUserName = "", msgType = "", eventStr = "", lat = "", lng = "", precision = "";
                             int createTime = 0, agentID = 0;                             
                             msgType = root["MsgType"].InnerText;
                             if (msgType == "location")
                             {//发送地理位置不普通消息
                                 string Label = "", MsgId = "";
                                 toUserName = root["ToUserName"].InnerText;
                                 fromUserName = root["FromUserName"].InnerText;
                                 lat = root["Location_X"].InnerText;
                                 lng = root["Location_Y"].InnerText;
                                 precision = root["Scale"].InnerText;
                                 Label = root["Label"].InnerText;
                                 MsgId = root["MsgId"].InnerText;
                                 createTime = Convert.ToInt32(root["CreateTime"].InnerText);
                                 agentID = Convert.ToInt32(root["AgentID"].InnerText);
                                 int r = Location.AddLocation(toUserName, fromUserName, createTime, msgType, lat, lng, precision, agentID, Label, MsgId);
                                 context.Response.Write("ok ： " + r.ToString());
                             }
                             else if (msgType == "event")
                             {
                                 eventStr = root["Event"].InnerText;
                                 if (eventStr == "LOCATION")
                                 {//发送地理位置事件，应用控制台配置
                                     toUserName = root["ToUserName"].InnerText;
                                     fromUserName = root["FromUserName"].InnerText;
                                     lat = root["Latitude"].InnerText;
                                     lng = root["Longitude"].InnerText;
                                     precision = root["Precision"].InnerText;
                                     createTime = Convert.ToInt32(root["CreateTime"].InnerText);
                                     agentID = Convert.ToInt32(root["AgentID"].InnerText);
                                     int r = Location.AddLocation(toUserName, fromUserName, createTime, msgType, lat, lng, precision, agentID);
                                     context.Response.Write("ok ： " + r.ToString());
                                 }
                             }
                         }
                         catch (Exception e)
                         {
                             context.Response.Write("ERR: Exception: " + e.Message);
                         }
                     }
                 }
                 else
                 {
                     ret = wxcpt.VerifyURL(sVerifyMsgSig, sVerifyTimeStamp, sVerifyNonce, sVerifyEchoStr, ref sMsg);                                         
                 }

                 //ret==0表示验证成功，sEchoStr参数表示明文，用户需要将sEchoStr作为get请求的返回参数，返回给企业号。
                 if (ret != 0)
                 {
                     context.Response.Write("ERR: VerifyURL fail, ret: " + ret);
                     return;
                 }

                 context.Response.Clear();
   
                 context.Response.Write(sMsg);
                 context.Response.End();
             }
             else
             {
                 context.Response.Write("ERR: Prams " );
             }
        }
 
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}