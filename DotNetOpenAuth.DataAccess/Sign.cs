using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DotNetOpenAuth.DataAccess
{//来自：http://www.DotNetOpenAuth.com
    public class Sign
    {
        public static int AddSign(string UserID, string DeviceId, string lat, string lng)
        {
            try
            {
                string sqlStr = @"INSERT INTO wxSign VALUES(@UserID,@DeviceId,@SignDate,@lat,@lng,@InsertTime);SELECT @@IDENTITY";
                string SignDate= DateTime.Now.ToString("yyyy-MM-dd");
                SqlParameter[] Params = new SqlParameter[6];
                Params[0] = new SqlParameter() { ParameterName = "@UserID", SqlDbType = SqlDbType.VarChar, Value = UserID, Direction = ParameterDirection.Input };
                Params[1] = new SqlParameter() { ParameterName = "@DeviceId", SqlDbType = SqlDbType.VarChar, Value = DeviceId, Direction = ParameterDirection.Input };
                Params[2] = new SqlParameter() { ParameterName = "@SignDate", SqlDbType = SqlDbType.VarChar, Value = SignDate, Direction = ParameterDirection.Input };
                Params[3] = new SqlParameter() { ParameterName = "@lat", SqlDbType = SqlDbType.VarChar, Value = lat, Direction = ParameterDirection.Input };
                Params[4] = new SqlParameter() { ParameterName = "@lng", SqlDbType = SqlDbType.VarChar, Value = lng, Direction = ParameterDirection.Input };
                Params[5] = new SqlParameter() { ParameterName = "@InsertTime", SqlDbType = SqlDbType.DateTime, Value = DateTime.Now, Direction = ParameterDirection.Input };
                
                return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.Conn, CommandType.Text, sqlStr, Params));
            }
            catch
            {
            }
            return 0;
        }
    }
}
