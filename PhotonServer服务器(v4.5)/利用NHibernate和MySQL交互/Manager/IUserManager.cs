using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windbelledu.Model;

namespace Windbelledu.Manager//创建管理类，处理CRUD操作
{
    
        interface IUserManager//定义接口
        {
            void Add(User user);
            void Update(User user);
            void Remove(User user);
            User GetById(int id);
            User GetByUsername(string username);
            ICollection<User> GetAllUsers();//定义泛型

        //添加一个验证用户名和密码的接口
        bool VerifyUser(string username, string password);

    }
    
}
