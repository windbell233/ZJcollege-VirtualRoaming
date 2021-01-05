using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Windbelledu.Model;
using NHibernate.Criterion;

namespace Windbelledu.Manager
{
    class UserManager : IUserManager //定义实现接口的类
    {

        public void Add(Model.User user)//插入
        {
            //ISession session = NHibernateHelper.OpenSession();
            //session.Save(user);
            //session.Close();
            using (ISession session = NHibernateHelper.OpenSession())//using：使用资源后会自动释放
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
            }
        }
        public void Update(Model.User user)//更新
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }
        public void Remove(Model.User user)//删除
        {

            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }
        public Model.User GetById(int id)//通过id查询
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    User user = session.Get<User>(id);
                    transaction.Commit();
                    return user;
                }
            }
        }
        public Model.User GetByUsername(string username)//通过用户名查询
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria(typeof(User));
                //criteria.Add(Restrictions.Eq("Username", username));
                //User user = criteria.UniqueResult<User>();
                User user = session.CreateCriteria(typeof(User)).Add(Restrictions.Eq("Username", username)).UniqueResult<User>();
                return user;
            }
        }
        public ICollection<Model.User> GetAllUsers()//查询得到所有用户
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria(typeof(User));
                //criteria.Add(Restrictions.Eq("Username", username));
                //User user = criteria.UniqueResult<User>();
                IList<User> users = session.CreateCriteria(typeof(User)).List<User>();
                return users;
            }
        }
        public bool VerifyUser(string username, string password)//验证用户名和密码
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //ICriteria criteria = session.CreateCriteria(typeof(User));
                //criteria.Add(Restrictions.Eq("Username", username));
                //User user = criteria.UniqueResult<User>();
                User user = session
                    .CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("Username", username))
                    .Add(Restrictions.Eq("Password", password))
                    .UniqueResult<User>();
                if (user == null) return false;
                return true;
            }
        }

    }
}
