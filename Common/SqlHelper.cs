using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Data.Common;

namespace SDAU.ZHCZ.Common
{
    public static class SqlHelper
    {
        //连接
        private static SqlConnection GetConn()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        }
        //private static readonly string GetConn1=System.Configuration.ConfigurationManager.ConnectionStrings["My First Sql"].ConnectionString;
        //方法一：获取数据源(不不带参数)     
        public static DataTable GetDataWithoutParameter(string sql, params SqlParameter[] ps)
        {    //创建一个Datatable对象

            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConn())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                if (ps != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(ps);
                }
                adapter.Fill(dt);
            }
            return dt;
        }

        //方法二：获取数据源（带参数）
        public static DataTable GetDataWithParameter(string sql, Dictionary<string, string> dic)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConn())
            {
                //初始化SqlParameter字典集合元素的个数
                SqlParameter[] ps = new SqlParameter[dic.Count];
                SqlCommand cmd = new SqlCommand(sql, conn);
                int index = 0;
                foreach (var item in dic)
                {
                    ps[index++] = new SqlParameter(item.Key, item.Value);
                }
                cmd.Parameters.AddRange(ps);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        
        // 附加方法：判断用户是否存在
        public static bool IsExist(string name)
        {
            bool b = false;
            string sql = "select count(*) from users where uname=@name";
            using (SqlConnection conn = GetConn())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                conn.Open();
                int rows = Convert.ToInt32(cmd.ExecuteScalar());
                if (rows == 1)
                {
                    b = true;
                }
            }
            return b;
        }

        //方法三：执行不带参数的sql语句(insert,update,delete)
        public static int EXNQWithoutParameter(string sql, CommandType type, params SqlParameter[] ps)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //方法四：执行带参数的SQL语句
        public static int EXNQWithParameter(string sql, Dictionary<string, string> dic)
        {
            if (dic == null)
            {
                return EXNQWithoutParameter(sql, CommandType.Text);
            }
            else
            {
                SqlParameter[] ps = new SqlParameter[dic.Count];
                int index = 0;
                using (SqlConnection conn = GetConn())
                {
                    foreach (var item in dic)
                    {
                        ps[index++] = new SqlParameter(item.Key, item.Value);
                    }
                }
                return EXNQWithoutParameter(sql, CommandType.Text, ps);
            }
        }

        //方法五：返回单个值,不带参数（与方法三类似）
        public static object EXSWithoutParameter(string sql, CommandType type, params SqlParameter[] ps)
        {
            using (SqlConnection conn = GetConn())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (ps != null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //方法六：返回单个值,带参数（与方法三类似）
        public static object EXSWithParameter(string sql, Dictionary<string, string> dic)
        {
            if (dic == null)
            {
                return EXSWithoutParameter(sql, CommandType.Text);
            }
            else
            {
                SqlParameter[] ps = new SqlParameter[dic.Count];
                int index = 0;
                using (SqlConnection conn = GetConn())
                {
                    foreach (var item in dic)
                    {
                        ps[index++] = new SqlParameter(item.Key, item.Value);
                    }
                }
                return EXSWithoutParameter(sql, CommandType.Text, ps);
            }
        }

        //返回多行多列的方法
        public static SqlDataReader ExecuteReader(string sql, CommandType type, params SqlParameter[] ps)
        {
            //此处不用using()因为阅读器关闭时尝试调用HasRows无效,返回reader的时候把连接关掉就行
            SqlConnection conn = GetConn();
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (ps != null)
            {
                cmd.Parameters.AddRange(ps);
            }
            cmd.CommandType = type;
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        //返回多行多列的方法2
        public static SqlDataReader ExecuteReader(string sql, Dictionary<string, string> dic)
        {
            if (dic == null)
            {
                return ExecuteReader(sql, CommandType.Text);
            }
            else
            {
                SqlParameter[] ps = new SqlParameter[dic.Count];
                int index = 0;
                using (SqlConnection conn = GetConn())
                {
                    foreach (var item in dic)
                    {
                        ps[index++] = new SqlParameter(item.Key, item.Value);
                    }
                }
                return ExecuteReader(sql, CommandType.Text, ps);
            }
        }

        // 计算字符串的MD5
        public static string GetStringMD5(string msg)
        {
            using (MD5 md5 = MD5.Create())
            {
                //82e01a9b10dd91dd9363a7fb2b558abc
                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                byte[] md5buffer = md5.ComputeHash(buffer);
                md5.Clear();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5buffer.Length; i++)
                {
                    sb.Append(md5buffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        // 计算文件的MD5
        public static string GetFileMD5(string path)
        {
            using (MD5 md5 = MD5.Create())
            {
                //需要一个流
                using (FileStream fread = File.OpenRead(path))
                {
                    byte[] md5buffer = md5.ComputeHash(fread);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < md5buffer.Length; i++)
                    {
                        sb.Append(md5buffer[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }

        }
    }
}
