using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//引入mysql

namespace CSharp直接连接MySQL
{
    class Program
    {
        static void Main(string[] args)//建立与数据库的连接，发出数据库命令
        {
            //将操作都封装在方法里了，测试的时候取消下方注释直接调用方法就行，不要同时调用多个方法，可能会有冲突

            // Read();//读取查询
            //Insert();//插入数据
            //Update();//更新数据
            //Delete();//删除数据
            // ReadUsersCount();//查询一些值
            //ExecuteScalar();//执行一些查询，返回一个单个的值

            Console.ReadKey();
        }

      static void Read()//封装测试-数据库查询操作
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";//sql连接数据参数
           MySqlConnection conn = new MySqlConnection(connectStr);//还未与数据库建立连接
            try//捕捉异常，并打印
            {
                conn.Open();//建立连接
                Console.WriteLine("已经与数据库建立连接");

                string sql = "select * from users";//数据库操作命令,查询users表
                //string sql = "select id,username,registerdate from users";//数据库操作命令，查询users表指定列
                MySqlCommand cmd = new MySqlCommand(sql, conn);//数据库命令类
                //cmd.ExecuteReader();//执行一些查询
                //cmd.ExecuteNonQuery();//插入，删除
                //cmd.ExecuteScalar();//执行一些查询，返回一个单个的值
               
                MySqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();//每次调用Read，读取一条记录，打开第一行。把reader当作一本书
                //Console.WriteLine(reader[0].ToString()+reader[1].ToString()+ reader[2].ToString());//打印当前行的三列数据
                //reader.Read();//第二次调用，打开第二行的数据
                //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());//打印当前行的三列数据
                while(reader.Read())//Read每次调用会返回Ture或False的值，使用while循环来全部遍历
                {
                    Console.WriteLine("执行了一次用户名与密码的查询");
                    Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());//打印当前行的三列数据

                    //其他方式：
                    // Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2));
                   // Console.WriteLine(reader.GetInt32("id") + " " + reader.GetString("username") + " " + reader.GetString("password"));
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally//无论如何都会去执行的语句
            {
                conn.Close();//关闭连接
            }
        }

        static void Insert()//封装测试-数据库插入操作
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";//sql连接数据参数
           MySqlConnection conn = new MySqlConnection(connectStr);//还未与数据库建立连接
            try//捕捉异常，并打印
            {
                conn.Open();//建立连接
                Console.WriteLine("已经与数据库建立连接");

                string sql = "insert into users(username,password) values('游客','123')";//数据库操作命令,插入数据
                //string sql = "insert into users(username,password,registerdate) values('游客2','123','2021-1-3')";//数据库操作命令,插入数据
                //string sql = "insert into users(username,password,registerdate) values('游客3','123','"+DateTime.Now+"')";//数据库操作命令,插入数据

                MySqlCommand cmd = new MySqlCommand(sql, conn);//数据库命令类
                int result = cmd.ExecuteNonQuery();//返回值是数据库受影响行数的记录
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally//无论如何都会去执行的语句
            {
                conn.Close();//关闭连接
            }
        }
        static void Update()//封装测试-数据库更新数据
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";//sql连接数据参数
            MySqlConnection conn = new MySqlConnection(connectStr);//还未与数据库建立连接
            try//捕捉异常，并打印
            {
                conn.Open();//建立连接
                Console.WriteLine("已经与数据库建立连接");

                string sql = "update users set username ='更新后的用户名',password='123' where id =3";//数据库操作命令,更新数据
                //string sql = "insert into users(username,password,registerdate) values('游客2','123','2021-1-3')";//数据库操作命令,插入数据
                //string sql = "insert into users(username,password,registerdate) values('游客3','123','"+DateTime.Now+"')";//数据库操作命令,插入数据

                MySqlCommand cmd = new MySqlCommand(sql, conn);//数据库命令类
                int result = cmd.ExecuteNonQuery();//返回值是数据库受影响行数的记录

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally//无论如何都会去执行的语句
            {
                conn.Close();//关闭连接
            }
        }
        static void Delete()//封装测试-删除数据
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";//sql连接数据参数
            MySqlConnection conn = new MySqlConnection(connectStr);//还未与数据库建立连接
            try//捕捉异常，并打印
            {
                conn.Open();//建立连接
                Console.WriteLine("已经与数据库建立连接");

                string sql = "delete from users where id=7 ";//数据库删除数据
                //string sql = "insert into users(username,password,registerdate) values('游客2','123','2021-1-3')";//数据库操作命令,插入数据
                //string sql = "insert into users(username,password,registerdate) values('游客3','123','"+DateTime.Now+"')";//数据库操作命令,插入数据

                MySqlCommand cmd = new MySqlCommand(sql, conn);//数据库命令类
                int result = cmd.ExecuteNonQuery();//返回值是数据库受影响行数的记录

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally//无论如何都会去执行的语句
            {
                conn.Close();//关闭连接
            }
        }
        static void ReadUsersCount()//封装测试-查询一些值
        {
             string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";//sql连接数据参数
           MySqlConnection conn = new MySqlConnection(connectStr);//还未与数据库建立连接
            try//捕捉异常，并打印
            {
                conn.Open();//建立连接
                Console.WriteLine("已经与数据库建立连接");

                string sql = "select count(*) from users";//数据库操作命令,读取数据行数
               
                MySqlCommand cmd = new MySqlCommand(sql, conn);//数据库命令类
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int count = Convert.ToInt32(reader[0].ToString());
                Console.WriteLine(count);
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally//无论如何都会去执行的语句
            {
                conn.Close();//关闭连接
            }
        }
        static void ExecuteScalar()//封装测试-执行一些查询，返回一个单个的值
        {
            string connectStr = "server=127.0.0.1;port=3306;database=mygamedb;user=root;password=root;";//sql连接数据参数
            MySqlConnection conn = new MySqlConnection(connectStr);//还未与数据库建立连接
            try//捕捉异常，并打印
            {
                conn.Open();//建立连接
                Console.WriteLine("已经与数据库建立连接");

                string sql = "select count(*) from users";//数据库操作命令,读取数据行数

                MySqlCommand cmd = new MySqlCommand(sql, conn);//数据库命令类
                
               
                object o = cmd.ExecuteScalar();
                int count = Convert.ToInt32(o.ToString());
                Console.WriteLine(count);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally//无论如何都会去执行的语句
            {
                conn.Close();//关闭连接
            }
        }

    }
}
