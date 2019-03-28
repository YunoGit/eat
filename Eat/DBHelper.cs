using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Eat
{
    class DBHelper
    {
        //连接字符串
        private string connString = @"Data Source=.;Initial Catalog=DB;User ID=sa;Pwd=123";
        //Connection对象
        private SqlConnection conn;
        public SqlConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    conn = new SqlConnection(connString);
                }
                return conn;
            }
        }
        //打开链接
        public void DBOpen()
        {
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            else if (Conn.State == ConnectionState.Broken)
            {
                Conn.Close();
                Conn.Open();
            }
        }
        //关闭连接
        public void DBClose()
        {
            if (Conn.State == ConnectionState.Open || Conn.State == ConnectionState.Broken)
            {
                Conn.Close();
            }
        }
    }
}