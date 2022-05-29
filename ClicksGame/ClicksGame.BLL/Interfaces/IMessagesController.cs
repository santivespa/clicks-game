using ClicksGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.BLL.Interfaces
{
    public interface IMessagesController
    {
        bool Add(Message message,string connectionID);

        object GetMessages();


        object RemoveMessages(string connectionID);
    }
}
