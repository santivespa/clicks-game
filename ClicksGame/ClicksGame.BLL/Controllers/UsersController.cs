using ClicksGame.BLL.Interfaces;
using ClicksGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.BLL.Controllers
{
    public class UsersController : IUsersController
    {

       // temporarily
        private static List<User> Users { get; set; }

        public bool Add(User user)
        {
            if (Users == null)
                Users = new List<User>();
            if (user.IsValid())
            {
                if (Users.FirstOrDefault(x => x.ConnectionID == user.ConnectionID) == null)
                {
                    if (Users.FirstOrDefault(x => x.UserName == user.UserName) == null)
                    {
                        Users.Add(user);
                        return true;
                    }
                }
            }
            return false;
        }

        public object Remove(string connectionID)
        {
            if (Users == null)
                Users = new List<User>();
            var user = Users.FirstOrDefault(x => x.ConnectionID == connectionID);
            Users.Remove(user);
            return Users;
        }

        public User GetUser(string connectionID)
        {
            if (Users == null)
                Users = new List<User>();
            var user = Users.FirstOrDefault(x => x.ConnectionID == connectionID);
            return user;
        }

        public User GetUserByUserName(string userName)
        {
            if (Users == null)
                Users = new List<User>();
            var user = Users.FirstOrDefault(x => x.UserName == userName);
            return user;
        }
        public object GetUsers()
        {
            if (Users == null)
                Users = new List<User>();
            var users = Users.Select(x =>
              new
              {
                  UserName = x.UserName
              }
          ).ToList();
            return users;
        }

      
    }
}
