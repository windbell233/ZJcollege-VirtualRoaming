using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;//引用NHibernate空间
using NHibernate.Cfg;//引用NHibernate配置
using Windbelledu.Model;
using Windbelledu.Manager;

namespace Windbelledu
{
    class Program
    {
        static void Main(string[] args)
        {
            //var configuration = new Configuration();
            //configuration.Configure();//解析nhibernate.cfg.xml，注意保持在同一路径
            //configuration.AddAssembly("Windbelledu"); //解析映射文件 User.hbm.xml
            ////创建ISessionFactory 工厂，与数据库会话
            //ISessionFactory sessionFactory = null;
            //ISession session = null;
            //ITransaction transaction = null;

            //try
            //{
            //    sessionFactory = configuration.BuildSessionFactory();
            //    session = sessionFactory.OpenSession();//打开一个跟数据库的对话

            //    //对数据库进行增加数据操作
            //    //User user = new User() { Username = "NHibernate", Password = "123" };
            //    //session.Save(user);

            //    //事务,事务包含多个操作
            //    transaction = session.BeginTransaction();//开启事务
            //    //进行操作
            //    User user1 = new User() { Username = "NHibernate03", Password = "123" };
            //    User user2 = new User() { Username = "NHibernate04", Password = "123" };
            //    session.Save(user1);
            //    session.Save(user2);
            //    transaction.Commit();//事务提交

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
            //finally//最后创建的操作最后关闭
            //{
            //    if (transaction != null)
            //    {
            //        transaction.Dispose();
            //    }
            //    if (session != null)
            //    {
            //        session.Close();
            //    }
            //    if (sessionFactory != null)
            //    {
            //        sessionFactory.Close();
            //    }
            //}

            //使用封装后的方法
           // User user = new User() {Id=12, Username = "账号名不难重复", Password = "123" };
            IUserManager userManager = new UserManager();
            //userManager.Add(user);//插入数据
            //userManager.Update(user);//更新数据
            //userManager.Remove(user);//删除
            //User user = userManager.GetById(18);//根据主键查询

            //User user = userManager.GetByUsername("野哥");
            //Console.WriteLine(user.Username);
            //Console.WriteLine(user.Password);

            //ICollection<User> users = userManager.GetAllUsers();
            //foreach (User u in users)
            //{
            //    Console.WriteLine(u.Username + " " + u.Password);
            //}

            Console.WriteLine(userManager.VerifyUser("机宝", "222"));//结果应为true
            Console.WriteLine(userManager.VerifyUser("wer2", "wer"));//结果应为False

            Console.ReadKey();
        }
    }
}
