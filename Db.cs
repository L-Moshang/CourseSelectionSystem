using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace sc
{
	/// <summary>
	/// 数据库连接操作类
	/// </summary>
	public class Db
	{
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected static string connString = ConfigurationSettings.AppSettings["ConnectionString"];

		public Db()
		{
		}

        /// <summary>
        /// 执行select类型的sql语句,返回select得到的数据集
        /// </summary>
        /// <param name="sqlSelect">select语句</param>
        /// <returns>返回select得到的数据集</returns>
        public static DataSet ExecuteSelectSql( string sqlSelect )
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter sda = new SqlDataAdapter(sqlSelect,conn);
            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            return ds;
        }

        /// <summary>
        /// 执行insert,update,delete等语句,改变的行数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>改变的行数</returns>
        public static int ExecuteSql( string sql )
        {
            int rows = -1;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql,conn);
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }    
            
            return rows;
        }

        /// <summary>
        /// 执行需要返回刚插入记录的identity的insert语句,返回改变行数
        /// </summary>
        /// <param name="sqlInsert">insert语句</param>
        /// <param name="identity">identity</param>
        /// <returns>返回改变行数</returns>
        public static int ExecuteInsertSql( string sqlInsert, ref int identity )
        {
            int rows = -1;
            SqlConnection conn = new SqlConnection(connString);			
            SqlCommand cmd = new SqlCommand();			

            try
            {
                conn.Open();				
            }
            catch(SqlException e)
            {
                throw new Exception(e.Message);
            }

            SqlTransaction trans = conn.BeginTransaction();
            try
            {											
                cmd.Connection = conn;				
                cmd.Transaction = trans;
                //执行insert
                cmd.CommandText = sqlInsert;
                rows = cmd.ExecuteNonQuery();
                //select出identity
                cmd.CommandText = "select @@identity";
                SqlDataReader sdr = cmd.ExecuteReader();
                if(sdr.Read())
                {
                    identity = sdr.GetInt32(0);
                }

                trans.Commit();             
            }
            catch(System.Data.SqlClient.SqlException e)
            {			
                trans.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }

            return rows;
        }

	}
}
