using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;//MySql数据库处理使用
//using System.Windows.Forms;//MessageBox.Show使用需要

namespace AchievementManage
{
    class MyDatabase
    {
        private static string server = "localhost";
        private static string port = "3306";
        private static string database = "achievementmanage";
        private static string uid = "root";
        private static string pwd = "123456";
        private static string ConnectString = "server=localhost;port=3306;database=achievementmanage;uid=root;pwd=123456";//数据库连接字符串

        public static void SetServer(string serverset)
        {
            server = serverset;
            ConnectString = string.Format("server={0};port={1};database={2};uid={3};pwd={4}", server, port, database, uid, pwd);//数据库连接字符串
        }

        public static void SetPort(string portset)
        {
            port = portset;
            ConnectString = string.Format("server={0};port={1};database={2};uid={3};pwd={4}", server, port, database, uid, pwd);//数据库连接字符串
        }

        public static void SetDatabase(string databaseset)
        {
            database = databaseset;
            ConnectString = string.Format("server={0};port={1};database={2};uid={3};pwd={4}", server, port, database, uid, pwd);//数据库连接字符串
        }

        public static void SetUid(string uidset)
        {
            uid = uidset;
            ConnectString = string.Format("server={0};port={1};database={2};uid={3};pwd={4}", server, port, database, uid, pwd);//数据库连接字符串
        }

        public static void SetPwd(string pwdset)
        {
            pwd = pwdset;
            ConnectString = string.Format("server={0};port={1};database={2};uid={3};pwd={4}", server, port, database, uid, pwd);//数据库连接字符串
        }

        public static bool TestMyDatabaseConnect()//测试数据库能否连接成功
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectString))//创建数据库连接对象(通过将连接放到using中可以使得数据库使用后自动释放资源，不需要调用con.Close()释放)
                {
                    con.Open();//打开连接
                    return true;//数据库连接成功
                }
            }
            catch (Exception ex)//数据库连接失败
            {
                //MessageBox.Show(ex.Message);
                //throw new Exception(ex.Message);
                return false;
            }
        }

        public static System.Data.DataTable GetDataTableBySql(string sql)//通过sql语句获取数据集对象
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectString))//创建数据库连接对象(通过将连接放到using中可以使得数据库使用后自动释放资源，不需要调用con.Close()释放)
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);//创建适配器对象
                    DataSet ds = new DataSet();//创建数据集对象               
                    adapter.Fill(ds);//填充数据集
                    return ds.Tables[0];//返回数据表
                }
            }
            catch (MySqlException ex)//异常处理
            {
                 //MessageBox.Show(ex.Message);
                 //throw new Exception(ex.Message);
                 return null;
            }
        }

        public static bool UpdateDataBySql(string sql)//通过sql语句更新数据库内的数据
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectString))//创建数据库连接对象(通过将连接放到using中可以使得数据库使用后自动释放资源，不需要调用con.Close()释放)
                {
                    con.Open();//打开连接
                    MySqlCommand comm = new MySqlCommand(sql, con);//创建Command对象
                    if (comm.ExecuteNonQuery() > 0)//执行更新
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }                          
                }
            }
            catch (MySqlException ex)//异常处理
            {
                //MessageBox.Show(ex.Message);
                //throw new Exception(ex.Message);
                return false;
            }
        }

        public static string CharFilter(string string_in)//对访问数据库的内容进行过滤，过滤掉非法字符，防止SQL注入漏洞
        {
            string string_out = string_in;
            string[] FilterChars = { "\'", "\"", ";", "?", "%", "\\", "/", "*", "=", ">", "<", "!", "&", "|" };//需要过滤掉的特殊字符
            foreach(string filterchar in FilterChars)
            {
                string_out = string_out.Replace(filterchar, "");
            }
            return string_out;
        }
    }
}
