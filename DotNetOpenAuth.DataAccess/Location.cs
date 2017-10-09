using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DotNetOpenAuth.DataAccess
{//来自：http://www.DotNetOpenAuth.com
    public class Location
    {
        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        /// <param name="toUserName">企业号CorpID</param>
        /// <param name="fromUserName">成员UserID</param>
        /// <param name="createTime">消息创建时间（整型）</param>
        /// <param name="msgType">消息类型，此时固定为：event </param>
        /// <param name="latitude">地理位置纬度 </param>
        /// <param name="longitude">地理位置经度 </param>
        /// <param name="precision">地理位置精度 </param>
        /// <param name="agentID">企业应用的id，整型。可在应用的设置页面查看 </param>
        /// <returns></returns>
        public static int AddLocation(string toUserName, string fromUserName, int createTime, string msgType, string latitude, string longitude, string precision, int agentID, string label="", string msgid="")
        {
            try
            {
                string sqlStr = "INSERT INTO wxLOCATION VALUES(@ToUserName,@FromUserName,@CreateTime,@MsgType,@Latitude,@Longitude,@Precision,@AgentID,@Label,@MsgID);SELECT @@IDENTITY";

                SqlParameter[] Params = new SqlParameter[10];
                Params[0] = new SqlParameter() { ParameterName = "@ToUserName", SqlDbType = SqlDbType.VarChar, Value = toUserName, Direction = ParameterDirection.Input };
                Params[1] = new SqlParameter() { ParameterName = "@FromUserName", SqlDbType = SqlDbType.VarChar, Value = fromUserName, Direction = ParameterDirection.Input };
                Params[2] = new SqlParameter() { ParameterName = "@CreateTime", SqlDbType = SqlDbType.Int, Value = createTime, Direction = ParameterDirection.Input };
                Params[3] = new SqlParameter() { ParameterName = "@MsgType", SqlDbType = SqlDbType.VarChar, Value = msgType, Direction = ParameterDirection.Input };
                Params[4] = new SqlParameter() { ParameterName = "@Latitude", SqlDbType = SqlDbType.VarChar, Value = latitude, Direction = ParameterDirection.Input };
                Params[5] = new SqlParameter() { ParameterName = "@Longitude", SqlDbType = SqlDbType.VarChar, Value = longitude, Direction = ParameterDirection.Input };
                Params[6] = new SqlParameter() { ParameterName = "@Precision", SqlDbType = SqlDbType.VarChar, Value = precision, Direction = ParameterDirection.Input };
                Params[7] = new SqlParameter() { ParameterName = "@AgentID", SqlDbType = SqlDbType.Int, Value = agentID, Direction = ParameterDirection.Input };
                Params[8] = new SqlParameter() { ParameterName = "@Label", SqlDbType = SqlDbType.VarChar, Value = label, Direction = ParameterDirection.Input };
                Params[9] = new SqlParameter() { ParameterName = "@MsgID", SqlDbType = SqlDbType.VarChar, Value = msgid, Direction = ParameterDirection.Input };

                return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.Conn, CommandType.Text, sqlStr, Params));
            }
            catch
            {
            }
            return 0;
        }

    }
}
