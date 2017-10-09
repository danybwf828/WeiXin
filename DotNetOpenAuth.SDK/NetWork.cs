using System;
using System.IO;
//泛型
//网络
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DotNetOpenAuth.SDK
{//来自：http://www.DotNetOpenAuth.com

    public class RstArray
    {
        public int Ret = 0;
        public string Msg = "";
    }
	
	/*http 请求类*/
    public class NetWork
    {
        const int ERROR_SNSNETWORK_HTTP = 1; //http请求异常，查看返回的错误信息
        public NetWork()
        {
        }

        /// <summary>
        /// 执行一个 HTTP 请求
        /// </summary>
        /// <param name="url">执行请求的URL</param>
        ///  <param name="protocol"> http协议类型 http / https</param>
        /// <returns>返回结果数组</returns>
        static public RstArray GetRequest(string url, string protocol)
        {
            //结果
            RstArray result = new RstArray();
            //请求类
            HttpWebRequest request = null;
            //请求响应类
            HttpWebResponse response = null;
            //响应结果读取类
            StreamReader reader = null;

            //http连接数限制默认为2，多线程情况下可以增加该连接数，非多线程情况下可以注释掉此行代码
            ServicePointManager.DefaultConnectionLimit = 500;

            try
            {
                    //如果是发送HTTPS请求   
                    if (protocol.Equals("https", StringComparison.OrdinalIgnoreCase))
                    {
                        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                        request = WebRequest.Create(url) as HttpWebRequest;
                        request.ProtocolVersion = HttpVersion.Version10;
                    }
                    else
                    {
                        request = WebRequest.Create(url) as HttpWebRequest;
                    }
                    request.Method = "GET";
                    request.Timeout = 3000;

                //response
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                //return
                result.Msg = reader.ReadToEnd();
                result.Ret = 0;

            }
            catch (Exception e)
            {
                result.Msg = e.Message;
                result.Ret = ERROR_SNSNETWORK_HTTP;
            }
            finally
            {
                if (request != null)
                {
                    request.Abort();
                }
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
            return result;
        }
        
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受   
        }  

    }
}