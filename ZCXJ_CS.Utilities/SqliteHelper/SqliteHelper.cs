using System;
using System.Data;
using System.Data.SQLite;
using System.Data.Common;


namespace ZCXJ_CS.Utilities
{
    public class SqliteHelper : IDBHelper
    {
        private SQLiteConnection connection = null;
        private SQLiteTransaction tran = null;
        private string connString = "";

        public SQLiteConnection Connetion
        {
            get { return connection; }
            set { connection = value; }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SqliteHelper()
        {
            connString = "Data Source = " + AppDomain.CurrentDomain.BaseDirectory + "DB.db";
        }

        /// <summary>
        /// 重载构造函数
        /// </summary>
        /// <param name="fileName">数据库文件名</param>
        public SqliteHelper(string fileName)
        {
            connString = "Data Source =" + fileName;
        }

        ~SqliteHelper()
        {
            CloseConnection(Connetion);
        }

        /// <summary>
        /// 创建并返回数据连接对象
        /// </summary>
        /// <returns></returns>
        private SQLiteConnection CreateConnection()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(connString);
                return conn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 更改连接字符串
        /// </summary>
        /// <param name="connStr">新连接字符串</param>
        public void ChangeConnString(string connStr)
        {
            connString = connStr;
        }

        /// <summary>
        /// 关闭数据连接
        /// </summary>
        /// <param name="conn">连接对象</param>
        public void CloseConnection(SQLiteConnection conn)
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (Exception)
            {
                conn = null;
            }
        }

        /// <summary>
        /// 获取命令执行的结果数据集
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <returns>数据集对象</returns>
        public DataSet GetDataSet(string cmdText)
        {
            try
            {
                DataSet ds = new DataSet();
                SQLiteCommand command = new SQLiteCommand();
                using (SQLiteConnection conn = CreateConnection())
                {
                    PrepareCommand(command, conn, cmdText, null);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(ds);
                }
                return ds;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取命令执行的结果数据表
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(string cmdText)
        {
            try
            {
                DataSet ds = new DataSet();
                SQLiteCommand command = new SQLiteCommand();
                using (SQLiteConnection conn = CreateConnection())
                {
                    PrepareCommand(command, conn, cmdText, null);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                    da.Fill(ds);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                    return null;
                }
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取查询所得行
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <returns>数据行记录（仅返回第一条）</returns>
        public DataRow GetDataRow(string cmdText)
        {
            DataSet ds = GetDataSet(cmdText);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0];
            }
            return null;
        }

        /// <summary>
        /// 返回SQLiteDataReader对象
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <returns>SQLiteDataReader对象</returns>
        public DbDataReader ExecuteReader(string cmdText)
        {
            SQLiteCommand command = new SQLiteCommand();
            connection = CreateConnection();
            try
            {
                PrepareCommand(command, connection, cmdText, null);
                //如果关闭关联的 DataReader 对象，则关联的 Connection 对象也将关闭
                SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return (DbDataReader)reader;
            }
            catch
            {
                connection.Close();
                return null;
            }
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string cmdText)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand();
                using (SQLiteConnection conn = CreateConnection())
                {
                    PrepareCommand(command, conn, cmdText, null);
                    return command.ExecuteNonQuery();
                }
            }
            catch (System.Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 批量（事务）执行sql语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public int ExecuteNonQueryBatch(string cmdText)
        {
            SQLiteCommand command = new SQLiteCommand();
            PrepareCommand(command, connection, cmdText, null);
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// 返回结果集中的第一行第一列，忽略其他行或列
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <returns>第一单元格对象</returns>
        public object ExecuteScalar(string cmdText)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand();
                using (SQLiteConnection conn = CreateConnection())
                {
                    PrepareCommand(cmd, conn, cmdText, null);
                    return cmd.ExecuteScalar();
                }
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 压缩数据库
        /// </summary>
        /// <returns></returns>
        public bool CompactDB()
        {
            try
            {
                ExecuteNonQuery("Vacuum;");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 清除数据表内容
        /// </summary>
        /// <param name="table">表名</param>
        /// <returns></returns>
        public bool ClearTable(String table)
        {
            try
            {
                ExecuteNonQuery(String.Format("delete from {0};", table));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 启动事务处理
        /// </summary>
        public void BeginTransaction()
        {
            CloseConnection(connection);
            connection = CreateConnection();
            connection.Open();
            tran = connection.BeginTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                if (tran != null)
                {
                    tran.Commit();
                    tran.Dispose();
                }
            }
            catch (Exception)
            {
                tran = null;
            }
            finally
            {
                CloseConnection(connection);
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran.Dispose();
                }
            }
            catch (Exception)
            {
                tran = null;
            }
            finally
            {
                CloseConnection(connection);
            }
        }

        //命令准备
        private void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] p)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if (p != null)
            {
                foreach (object parm in p)
                    cmd.Parameters.AddWithValue(string.Empty, parm);
            }
        }

    }
}
