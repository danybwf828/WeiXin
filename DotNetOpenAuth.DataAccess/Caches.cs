using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DotNetOpenAuth.SDK;

namespace DotNetOpenAuth.DataAccess
{//来自：http://www.DotNetOpenAuth.com
    public class Caches
    {
        /// <summary>
        /// 添加缓存，如果存在则更新
        /// </summary>
        /// <param name="name"></param>
        /// <param name="itemValue"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public static int AddCache(string name, string itemValue, int expires)
        {
            try
            {
                string sqlStr = @"IF EXISTS(SELECT id FROM wxCache WHERE Name=@Name)
BEGIN
	UPDATE wxCache SET ItemValue=@ItemValue,Expires=@Expires WHERE Name=@Name
END
ELSE
BEGIN
	INSERT INTO wxCache VALUES(@Name,@ItemValue,@Expires)
END
;SELECT @@IDENTITY";

                SqlParameter[] Params = new SqlParameter[3];
                Params[0] = new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.VarChar, Value = name, Direction = ParameterDirection.Input };
                Params[1] = new SqlParameter() { ParameterName = "@ItemValue", SqlDbType = SqlDbType.VarChar, Value = itemValue, Direction = ParameterDirection.Input };
                Params[2] = new SqlParameter() { ParameterName = "@Expires", SqlDbType = SqlDbType.VarChar, Value = expires.ToString(), Direction = ParameterDirection.Input };
               
                return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.Conn, CommandType.Text, sqlStr, Params));
            }
            catch(Exception e)
            {
            }
            return 0;
        }

        public static string GetAccessToken(string corpid, string corpsecret,string tokenName)
        {
            AccessToken at = new AccessToken();
            at.errcode = -1;

            string sql = "SELECT TOP 1 ItemValue,Expires FROM wxCache WHERE Name='" + tokenName + "'";
            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.Conn, CommandType.Text, sql).Tables[0];
            bool result = false;
            if (dt != null)
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        at.expires_in = Convert.ToInt32(dt.Rows[0]["Expires"]);
                        if (at.expires_in > OpenApi.GetTime())
                        {
                            at.errcode = 0;
                            at.errmsg = "ok";
                            at.access_token = dt.Rows[0]["ItemValue"].ToString();
                            result = true;
                        }                       
                    }
                }
                catch
                {
                }
                finally
                {
                    dt.Dispose();
                }
            }
            if(!result)
            {
                at = OpenApi.GetAccessToken(corpid, corpsecret);
                if (at != null && !string.IsNullOrWhiteSpace(at.access_token))
                {
                    AddCache(tokenName, at.access_token, Convert.ToInt32(OpenApi.GetTime()) + at.expires_in);
                }
            }
            return at == null ? string.Empty : at.access_token;
        }

        public static string GetAccessTokenDqNews(string corpid, string corpsecret, string tokenName)
        {
            AccessToken at = new AccessToken();
            at.errcode = -1;

            string sql = "SELECT TOP 1 ItemValue,Expires FROM wxCache WHERE Name='" + tokenName + "'";
            DataTable dt = SqlHelper.ExecuteDataset("Data Source=.;Initial Catalog=XXB_weixin;User ID=sa;Password=Bb123", CommandType.Text, sql).Tables[0];
            bool result = false;
            if (dt != null)
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        at.expires_in = Convert.ToInt32(dt.Rows[0]["Expires"]);
                        if (at.expires_in > OpenApi.GetTime())
                        {
                            at.errcode = 0;
                            at.errmsg = "ok";
                            at.access_token = dt.Rows[0]["ItemValue"].ToString();
                            result = true;
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    dt.Dispose();
                }
            }
            if (!result)
            {
                at = OpenApi.GetAccessToken(corpid, corpsecret);
                if (at != null && !string.IsNullOrWhiteSpace(at.access_token))
                {
                    AddCacheDqNews(tokenName, at.access_token, Convert.ToInt32(OpenApi.GetTime()) + at.expires_in);
                }
            }
            return at == null ? string.Empty : at.access_token;
        }
        
        public static int AddCacheDqNews(string name, string itemValue, int expires)
        {
            try
            {
                string sqlStr = @"IF EXISTS(SELECT id FROM wxCache WHERE Name=@Name)
BEGIN
	UPDATE wxCache SET ItemValue=@ItemValue,Expires=@Expires WHERE Name=@Name
END
ELSE
BEGIN
	INSERT INTO wxCache VALUES(@Name,@ItemValue,@Expires)
END
;SELECT @@IDENTITY";

                SqlParameter[] Params = new SqlParameter[3];
                Params[0] = new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.VarChar, Value = name, Direction = ParameterDirection.Input };
                Params[1] = new SqlParameter() { ParameterName = "@ItemValue", SqlDbType = SqlDbType.VarChar, Value = itemValue, Direction = ParameterDirection.Input };
                Params[2] = new SqlParameter() { ParameterName = "@Expires", SqlDbType = SqlDbType.VarChar, Value = expires.ToString(), Direction = ParameterDirection.Input };

                return Convert.ToInt32(SqlHelper.ExecuteScalar("Data Source=.;Initial Catalog=XXB_weixin;User ID=sa;Password=Bb123", CommandType.Text, sqlStr, Params));
            }
            catch (Exception e)
            {
            }
            return 0;
        }

        public static string GetJsTicket(string accessToken)
        {
            JsApiTicket jat = new JsApiTicket();
            jat.errcode = -1;

            string sql = "SELECT TOP 1 ItemValue,Expires FROM wxCache WHERE Name='jsapi_ticket'";
            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.Conn, CommandType.Text, sql).Tables[0];
            bool result = false;
            if (dt != null)
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        jat.expires_in = Convert.ToInt32(dt.Rows[0]["Expires"]);
                        if (jat.expires_in > OpenApi.GetTime())
                        {
                            jat.errcode = 0;
                            jat.errmsg = "ok";
                            jat.ticket = dt.Rows[0]["ItemValue"].ToString();
                            result = true;
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    dt.Dispose();
                }
            }
            if(!result)
            {
                jat = OpenApi.GetJsApiTicket(accessToken);
                if (jat != null && !string.IsNullOrWhiteSpace(jat.ticket))
                {
                    AddCache("jsapi_ticket", jat.ticket, Convert.ToInt32(OpenApi.GetTime()) + jat.expires_in);
                }
            }
            return jat == null ? string.Empty : jat.ticket;
        }
    }
}
