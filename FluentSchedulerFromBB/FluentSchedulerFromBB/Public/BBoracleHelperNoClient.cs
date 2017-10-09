using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using DotNet.Utilities;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


public abstract class BBoracleHelperNoClient
{
    public BBoracleHelperNoClient() { }

    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    protected static string connectionString = "Password=zjehr123;User ID=zijinehr;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.22.23.103)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));";
    #region  执行简单SQL语句

    /// <summary>
    /// 执行SQL语句，返回影响的记录数
    /// </summary>
    /// <param name="SQLString">SQL语句</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSql(string SQLString)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            using (OracleCommand cmd = new OracleCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw e;
                }
            }
        }
    }

    /// <summary>
    /// 2012-2-21新增重载，执行SQL语句，返回影响的记录数
    /// </summary>
    /// <param name="connection">SqlConnection对象</param>
    /// <param name="trans">SqlTransaction事件</param>
    /// <param name="SQLString">SQL语句</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSql(OracleConnection connection, OracleTransaction trans, string SQLString)
    {
        using (OracleCommand cmd = new OracleCommand(SQLString, connection))
        {
            try
            {
                cmd.Connection = connection;
                cmd.Transaction = trans;
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                trans.Rollback();
                throw e;
            }
        }
    }

    public static int ExecuteSqlByTime(string SQLString, int Times)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            using (OracleCommand cmd = new OracleCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    cmd.CommandTimeout = Times;
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw e;
                }
            }
        }
    }



    /// <summary>
    /// 执行查询语句，返回DataSet
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(string SQLString)
    {

        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                OracleDataAdapter command = new OracleDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }

    }


    /// <summary>
    /// 2012-2-21新增重载，执行查询语句，返回DataSet
    /// </summary>
    /// <param name="connection">SqlConnection对象</param>
    /// <param name="trans">SqlTransaction事务</param>
    /// <param name="SQLString">SQL语句</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(OracleConnection connection, OracleTransaction trans, string SQLString)
    {
        DataSet ds = new DataSet();
        try
        {
            OracleDataAdapter command = new OracleDataAdapter(SQLString, connection);
            command.SelectCommand.Transaction = trans;
            command.Fill(ds, "ds");
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            throw new Exception(ex.Message);
        }
        return ds;

    }


    #endregion

    #region  其他方法
    /// <summary>   
    /// 执行命令,返回受影响的行数   
    /// </summary>   
    /// <param name="tran">事务类 </param>   
    /// <param name="cmdText">操作字符串</param>   
    /// <param name="parms">sql语句需要的参数</param>   
    /// <param name="cmdtype">执行类型,是存储过程还是普通sql</param>   
    /// <returns>返回受影响的行数</returns>   
    public static int ExecuteNonQuery(OracleTransaction tran, string cmdText, OracleParameter[] parms, CommandType cmdtype)
    {
        int retVal = 0;
        OracleCommand cmd = new OracleCommand(cmdText);
        cmd.Connection = tran.Connection;
        cmd.Transaction = tran;
        cmd.CommandType = cmdtype;
        if (parms != null)
        {
            cmd.Parameters.AddRange(parms);
        }
        retVal = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return retVal;
    }

    /// <summary>   
    /// 执行命令,返回受影响的行数   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="parms">需要的参数</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回受影响的行数</returns>   
    public static int ExecuteNonQuery(string cmdText, OracleParameter[] parms, CommandType cmdtype)
    {
        int retVal;
        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleCommand cmd = new OracleCommand(cmdText, conn);
            cmd.CommandType = cmdtype;

            if (parms != null)
            {
                //添加参数      
                cmd.Parameters.AddRange(parms);
            }
            conn.Open();
            retVal = cmd.ExecuteNonQuery();
            conn.Close();
        }

        return retVal;
    }


    /// <summary>   
    /// 执行命令, 返回受影响的行数   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="cmdtype"></param>   
    /// <returns>返回受影响的行数</returns>   
    public static int ExecuteNonQuery(string cmdText, CommandType cmdtype)
    {
        int retVal;

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleCommand cmd = new OracleCommand(cmdText, conn);
            cmd.CommandType = cmdtype;

            conn.Open();

            retVal = cmd.ExecuteNonQuery();
            conn.Close();
        }


        return retVal;
    }

    /// <summary>   
    /// 执行命令, 返回受影响的行数   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <returns>返回受影响的行数</returns>   
    public static int ExecuteNonQuery(string cmdText)
    {
        int retVal;
        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleCommand cmd = new OracleCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            retVal = cmd.ExecuteNonQuery();

            conn.Close();
        }
        return retVal;
    }


    /// <summary>   
    /// 执行命令,返回第一行第一列   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="parms">需要的参数</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回第一行第一列,不存在返回Null</returns>   
    public static object ExecuteScalar(string cmdText, OracleParameter[] parms, CommandType cmdtype)
    {
        object retVal;

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleCommand cmd = new OracleCommand(cmdText, conn);
            cmd.CommandType = cmdtype;

            if (parms != null)
            {
                //添加参数      
                cmd.Parameters.AddRange(parms);
            }

            conn.Open();
            retVal = cmd.ExecuteScalar();
            conn.Close();
        }
        return retVal == DBNull.Value ? null : retVal;
    }



    /// <summary>   
    /// 执行命令,返回第一行第一列   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="parms">需要的参数</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回第一行第一列,不存在返回Null</returns>   
    public static object ExecuteScalar(OracleTransaction tran, string cmdText, OracleParameter[] parms, CommandType cmdtype)
    {

        object retVal;

        OracleCommand cmd = new OracleCommand(cmdText);
        cmd.Connection = tran.Connection;
        cmd.Transaction = tran;
        cmd.CommandType = cmdtype;
        if (parms != null)
        {
            //添加参数      
            cmd.Parameters.AddRange(parms);
        }

        retVal = cmd.ExecuteScalar();

        return retVal == DBNull.Value ? null : retVal;
    }




    /// <summary>   
    /// 执行命令,返回第一行第一列   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回第一行第一列,不存在返回Null</returns>   
    public static object ExecuteScalar(string cmdText, CommandType cmdtype)
    {
        object retVal;

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleCommand cmd = new OracleCommand(cmdText, conn);
            cmd.CommandType = cmdtype;

            conn.Open();
            retVal = cmd.ExecuteScalar();

            conn.Close();
        }
        return retVal == DBNull.Value ? null : retVal;
    }

    /// <summary>   
    /// 执行命令,返回第一行第一列   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <returns>返回第一行第一列,不存在返回Null</returns>   
    public static object ExecuteScalar(string cmdText)
    {
        object retVal;

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleCommand cmd = new OracleCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            retVal = cmd.ExecuteScalar();
            conn.Close();
        }

        return retVal == DBNull.Value ? null : retVal;
    }

    /// <summary>   
    /// 执行命令,返回一个数据读取器,注意使用完毕后关闭读取器   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="parms">需要的参数</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回一个数据读取器</returns>   
    public static OracleDataReader ExecuteReader(string cmdText, OracleParameter[] parms, CommandType cmdtype)
    {
        OracleDataReader reader;

        OracleConnection conn = new OracleConnection(connectionString);

        OracleCommand cmd = new OracleCommand(cmdText, conn);
        cmd.CommandType = cmdtype;

        if (parms != null)
        {
            //添加参数      
            cmd.Parameters.AddRange(parms);
        }

        conn.Open();
        reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return reader;
    }

    /// <summary>   
    ///  执行命令,返回一个数据读取器,注意使用完毕后关闭读取器   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回一个数据读取器</returns>   
    public static OracleDataReader ExecuteReader(string cmdText, CommandType cmdtype)
    {
        OracleDataReader reader;

        OracleConnection conn = new OracleConnection(connectionString);
        OracleCommand cmd = new OracleCommand(cmdText, conn);
        cmd.CommandType = cmdtype;

        conn.Open();
        reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return reader;
    }
    /// <summary>   
    /// 执行命令,返回DataTable   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="parms">需要的参数</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回DataTable</returns>   
    public static DataTable ExecuteDataTable(string cmdText, OracleParameter[] parms, CommandType cmdtype)
    {
        DataTable dt = new DataTable();

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleDataAdapter apt = new OracleDataAdapter(cmdText, conn);
            apt.SelectCommand.CommandType = cmdtype;

            if (parms != null)
            {
                apt.SelectCommand.Parameters.AddRange(parms);
            }

            apt.Fill(dt);
            conn.Close();
        }
        return dt;
    }

    /// <summary>   
    /// 执行命令,返回DataSet   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="parms">需要的参数</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回DataSet</returns>   
    public static DataSet ExecuteDataSet(string cmdText, OracleParameter[] parms, CommandType cmdtype)
    {
        DataSet ds = new DataSet();

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleDataAdapter apt = new OracleDataAdapter(cmdText, conn);
            apt.SelectCommand.CommandType = cmdtype;

            if (parms != null)
            {
                apt.SelectCommand.Parameters.AddRange(parms);
            }

            apt.Fill(ds);
            conn.Close();
        }
        return ds;
    }


    /// <summary>   
    /// 执行命令,返回DataTable   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回DataTable</returns>   
    public static DataTable ExecuteDataTable(string cmdText, CommandType cmdtype)
    {
        DataTable dt = new DataTable();

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleDataAdapter apt = new OracleDataAdapter(cmdText, conn);
            apt.SelectCommand.CommandType = cmdtype;
            apt.Fill(dt);
            conn.Close();
        }
        return dt;
    }

    /// <summary>   
    /// 执行命令,返回DataTable   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <returns>返回DataTable</returns>   
    public static DataTable ExecuteDataTable(string cmdText)
    {
        DataTable dt = new DataTable();

        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            OracleDataAdapter apt = new OracleDataAdapter(cmdText, conn);
            apt.SelectCommand.CommandType = CommandType.StoredProcedure;
            apt.Fill(dt);
            conn.Close();
        }
        return dt;
    }

    /// <summary>   
    /// 执行命令,返回第一行,不存在返回Null   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="parms">需要的参数</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回第一行,不存在返回Null</returns>   
    public static DataRow ExecuteFirstRow(string cmdText, OracleParameter[] parms, CommandType cmdtype)
    {
        DataRow row = null;
        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            DataTable dt = new DataTable();
            OracleDataAdapter apt = new OracleDataAdapter(cmdText, conn);
            apt.SelectCommand.CommandType = cmdtype;

            if (parms != null)
            {
                apt.SelectCommand.Parameters.AddRange(parms);
            }
            apt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }
            conn.Close();
        }
        return row;
    }

    /// <summary>   
    /// 执行命令,返回第一行,不存在返回Null   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <param name="cmdtype">如何解释命令字符串</param>   
    /// <returns>返回第一行,不存在返回Null</returns>   
    public static DataRow ExecuteFirstRow(string cmdText, CommandType cmdtype)
    {
        DataRow row = null;
        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            DataTable dt = new DataTable();
            OracleDataAdapter apt = new OracleDataAdapter(cmdText, conn);
            apt.SelectCommand.CommandType = cmdtype;
            apt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }
            conn.Close();
        }
        return row;
    }

    /// <summary>   
    /// 执行命令,返回第一行,不存在返回Null   
    /// </summary>   
    /// <param name="cmdText">查询的文本</param>   
    /// <returns>返回第一行,不存在返回Null</returns>   
    public static DataRow ExecuteFirstRow(string cmdText)
    {
        DataRow row = null;
        using (OracleConnection conn = new OracleConnection(connectionString))
        {
            DataTable dt = new DataTable();
            OracleDataAdapter apt = new OracleDataAdapter(cmdText, conn);
            apt.SelectCommand.CommandType = CommandType.StoredProcedure;
            apt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }
            conn.Close();
        }
        return row;
    }


    #endregion
}