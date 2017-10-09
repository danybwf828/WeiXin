using System;
//泛型
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
//正则

//json类
using System.Web.Script.Serialization;
//xml

namespace DotNetOpenAuth.SDK
{//来自：http://www.DotNetOpenAuth.com
	 
    public class OpenApi
    {
         /*错误码定义*/
        const int OPENAPI_ERROR_REQUIRED_PARAMETER_EMPTY = 1801;// 参数为空
        const int OPENAPI_ERROR_REQUIRED_PARAMETER_INVALID = 1802;// 参数格式错误
        const int OPENAPI_ERROR_RESPONSE_DATA_INVALID = 1803;// 返回包格式错误
        const int OPENAPI_ERROR_HTPP = 1900;// http请求异常, 偏移量1900
        
//https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid=wx43cc0695c501874d&corpsecret=ySDPHqMs1IJ_WMNPd6w-VZq3ehWMRR-vUWZWTWdqwKzVKlggrdz7d4mVuje-8xt3
//{"access_token":"eKhdXtx9rDNod1rnb-9CL5HSksHKR1_iNUkAb0HqdWdey1ZcP6JjN8DdRCEfwfuz","expires_in":7200}
//{"errcode":40001,"errmsg":"invalid credential"}
        public static AccessToken GetAccessToken(string corpid, string corpsecret)
        {
            AccessToken at = new AccessToken();
            at.errcode = -1;
            RstArray rst = NetWork.GetRequest(string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", corpid, corpsecret), "https");
            if (rst != null)
            {
                at.errcode = rst.Ret;
                at.errmsg = rst.Msg;
                if (rst.Ret == 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    at = serializer.Deserialize<AccessToken>(rst.Msg);
                }
            }
            return at;
        }

//https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=eKhdXtx9rDNod1rnb-9CL5HSksHKR1_iNUkAb0HqdWdey1ZcP6JjN8DdRCEfwfuz&code=959a0a7e378267241d9b733fb6c6c49c&agentid=1
//{"UserId":"yubao","DeviceId":"f26bb416b5a023e538049ffdad72be01"}
        public static UserInfo GetUserInfo(string access_token, string code, int agentid)
        {
            UserInfo ui = new UserInfo();
            ui.errcode = -1;
            RstArray rst = NetWork.GetRequest(string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}&agentid={2}", access_token, code, agentid), "https");
            if (rst != null)
            {
                ui.errcode = rst.Ret;
                ui.errmsg = rst.Msg;
                if (rst.Ret == 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    ui = serializer.Deserialize<UserInfo>(rst.Msg);
                }
            }
            return ui;
        }

        //https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token=ACCESS_TOKEN&userid=USERID
        //{"UserId":"yubao","DeviceId":"f26bb416b5a023e538049ffdad72be01"}
        public static UserInfo2 GetUserInfo2(string access_token, string userid)
        {
            UserInfo2 ui2 = new UserInfo2();
            ui2.errcode = -1;
            string bb001 = string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}", access_token, userid);
            RstArray rst = NetWork.GetRequest(string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}", access_token, userid), "https");
            if (rst != null)
            {
                ui2.errcode = rst.Ret;
                ui2.errmsg = rst.Msg;
                if (rst.Ret == 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    ui2 = serializer.Deserialize<UserInfo2>(rst.Msg);
                }
            }
            return ui2;
        }

        public static AgentUserList GetAgentUserList(string access_token, int agentid)
        {
            AgentUserList aul = new AgentUserList();
            aul.errcode = -1;
            string bb001 = string.Format("https://qyapi.weixin.qq.com/cgi-bin/agent/get?access_token={0}&AGENTID={1}", access_token, agentid);
            RstArray rst = NetWork.GetRequest(bb001, "https");
            if (rst != null)
            {
                aul.errcode = rst.Ret;
                aul.errmsg = rst.Msg;
                if (rst.Ret == 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    aul = serializer.Deserialize<AgentUserList>(rst.Msg);
                    
                }
            }
            return aul;
        }
        public static UserList GetUserList(string access_token, string department_id, int fetch_child)
        {
            UserList ul = new UserList();
            ul.errcode = -1;
            RstArray rst = NetWork.GetRequest(string.Format("https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token={0}&department_id={1}&fetch_child={2}", access_token, department_id, fetch_child), "https");
            if (rst != null)
            {
                ul.errcode = rst.Ret;
                ul.errmsg = rst.Msg;
                if (rst.Ret == 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    ul = serializer.Deserialize<UserList>(rst.Msg);
                }
            }
            return ul;
        }

        //https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token=ACCESS_TOKEN&department_id=ID
        //{"UserId":"yubao","DeviceId":"f26bb416b5a023e538049ffdad72be01"}
        public static DepartmentList GetDp(string access_token, string dpid)
        {
            DepartmentList dp = new DepartmentList();
            dp.errcode = -1;
            string bb001 = string.Format("https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={0}&id={1}", access_token, dpid);
            RstArray rst = NetWork.GetRequest(string.Format("https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={0}&department_id={1}", access_token, dpid), "https");
            if (rst != null)
            {
                dp.errcode = rst.Ret;
                dp.errmsg = rst.Msg;
                if (rst.Ret == 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dp = serializer.Deserialize<DepartmentList>(rst.Msg);
                }
            }
            return dp;
        }

        //https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token=ACCESS_TOKEN 
        //{"errcode":0,"errmsg":"ok","ticket":"bxLdikRXVbTPdHSM05e5u5sUoXNKd8-41ZO3MhKoyN5OfkWITDGgnr2fwJ0m9E8NYzWKVZvdVtaUgWvsdshFKA","expires_in":7200}
        public static JsApiTicket GetJsApiTicket(string access_token)
        {
            JsApiTicket jat = new JsApiTicket();
            jat.errcode = -1;
            RstArray rst = NetWork.GetRequest(string.Format("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}", access_token), "https");
            if (rst != null)
            {
                jat.errcode = rst.Ret;
                jat.errmsg = rst.Msg;
                if (rst.Ret == 0)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    jat = serializer.Deserialize<JsApiTicket>(rst.Msg);
                }
            }
            return jat;
        }

        /// <summary>
        ///   生成签名
        /// </summary>
        /// <param name="param">表单参数</param>
        /// <param name="secret">密钥</param>
        /// <returns>返回签名结果</returns>
        //
        static public string MakeSig(Dictionary<string, string> param, string secret)
        {
            string str_sha1_in = MakeSource(param);
            //string str_sha1_in = "jsapi_ticket=sM4AOVdWfPE4DxkXGEs8VMCPGGVi4C3VM0P37wVUCFvkVAy_90u5h9nbSlYy3-Sl-HhTdfl2fzFy1AOcHKP7qg&noncestr=Wm3WZYTPz0wzccnW&timestamp=1414587457&url=http://mp.weixin.qq.com?params=value";
            //0f9de62fce790f9a083d5c99e95740ceb90c27ed

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
            return str_sha1_out;
        }

        static private string MakeSource(Dictionary<string, string> param)
        {
            string query_string = "";
            List<KeyValuePair<string, string>> myList = new List<KeyValuePair<string, string>>(param);
            myList.Sort(delegate(KeyValuePair<string, string> s1, KeyValuePair<string, string> s2)
            {
                return s1.Key.CompareTo(s2.Key);
            });
            foreach (KeyValuePair<string, string> pair in myList)
            {
                query_string = query_string + pair.Key + "=" + pair.Value + "&";
            }
            query_string = query_string.Substring(0, query_string.Length - 1);
            //query_string = UrlEncode(query_string, Encoding.UTF8);
            return query_string;
        }

         /// <summary>
         /// 获取当前时间
         /// </summary>
         /// <returns>返回毫秒数</returns>
         static public long GetTime()
         {
             return (DateTime.Now.Ticks - new DateTime(2017, 1, 1).Ticks) / 10000000;
         }

         /// <summary>
         /// 获取当前时间
         /// </summary>
         /// <returns>返回毫秒数</returns>
         static public long GetTime2()
         {
             return (DateTime.Now.Ticks - new DateTime(1970, 1, 1).Ticks) / 10000;
         }

         /// <summary>
         /// 产生Guid
         /// </summary>
         /// <returns>结果</returns>
         public static string NewGuid()
         {
             return Guid.NewGuid().ToString("N");
         }
    }


    #region 返回结果格式
    public class ErrorResutl
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }

    public class AccessToken : ErrorResutl
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }

    public class UserInfo : ErrorResutl
    {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
    }

    public class UserInfo2 : ErrorResutl
    {
        public string userid { get; set; }
        public string name { get; set; }
        public string[] department { get; set; }
        public string position { get; set; }
        public string mobile { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public int status { get; set; }
        public int isleader { get; set; }
        public List<extattrs> extattr { get; set; }
        public class extattrs
        {
            public string[] attrs { get; set; }
        }
        public string english_name { get; set; }
        public string telephone { get; set; }
        public int enable { get; set; }
        public int hide_mobile { get; set; }
        public int wxplugin_status { get; set; }
    }

    public class DepartmentList : ErrorResutl
    {
        /// <summary>
        /// 部门列表数据。以部门的order字段从小到大排列
        /// </summary>
        public List<Departments> department { get; set; }
        public class Departments
        {
            /// <summary>
            /// 部门id
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 部门名称
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 父部门id，根部门为1
            /// </summary>
            public string parentid { get; set; }
            /// <summary>
            /// 在父部门中的次序值。order值大的排序靠前。
            /// </summary>
            public UInt64 order { get; set; }
        }
    }

    public class UserList : ErrorResutl
    {
        /// <summary>
        /// 用户列表数据。
        /// </summary>
        public List<Userlist> userlist { get; set; }
        public class Userlist
        {
            /// <summary>
            /// id
            /// </summary>
            public string userid { get; set; }
            /// <summary>
            /// 姓名
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 部门id
            /// </summary>
            public string[] department { get; set; }
        }
    }

    public class AgentUserList : ErrorResutl
    {
        public string agentid { get; set; }
        public string name { get; set; }
        public string square_logo_url { get; set; }
        public string description { get; set; }
        public User allow_userinfos { get; set; }
        public class User
        {
            public List<Dictionary<string, string>> user { get; set; }
            //public string[] user { get; set; }
        }
        public Partyid allow_partys { get; set; }
        public class Partyid
        {
            public string[] partyid { get; set; }
        }
        //public string[] allow_partys { get; set; }
        //public string[] allow_tags { get; set; }
        public int close { get; set; }
        public string redirect_domain { get; set; }
        public int report_location_flag { get; set; }
        public int isreportenter { get; set; }
        public string home_url { get; set; }
    }

    public class JsApiTicket : ErrorResutl
    {
        public string ticket { get; set; }
        public int expires_in { get; set; }
    }
    #endregion

}