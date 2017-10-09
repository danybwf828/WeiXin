using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DotNetOpenAuth.SDK;

namespace DotNetOpenAuth.DataAccess
{//来自：http://www.DotNetOpenAuth.com
    public class uPlan
    {
        public static DataTable GetUserPlan(string uId, string uName)
        {
            string sql = "SELECT uId,uName,uStartime,uStopTime,uPlan,uMode FROM wxPlan WHERE uId='" + uId + "' and uName='" + uName + "' and uState = '正常'";
            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.Conn, CommandType.Text, sql).Tables[0];
            return dt;
        }
        public static DataTable GetUserPlan(string uId, string uName, string strStarTime, string strStopTime)
        {
            string sql = "SELECT uId,uName,uStartime,uStopTime,uPlan,uMode FROM wxPlan WHERE uId='" + uId + "' and uName='" + uName + "' and uStarTime >'" + strStarTime + "' and uState = '正常'";
            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.Conn, CommandType.Text, sql).Tables[0];
            return dt;
        }
    }
}
