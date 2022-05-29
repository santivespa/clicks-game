using ClicksGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.BLL.Interfaces
{
    public interface IUsersController
    {

        bool Add(User user);

        object Remove(string connectionID);

        object GetUsers();


        User GetUser(string connectionID);
        User GetUserByUserName(string userName);

        

    }
}
