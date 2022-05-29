using ClicksGame.BLL.Interfaces;
using ClicksGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.BLL.Controllers
{
    public class MessagesController : IMessagesController
    {
        private readonly IUsersController _userController;

        public MessagesController(IUsersController userController) => _userController = userController;

        // temporarily
        private static List<Message> Messages { get; set; }


        public bool Add(Message message, string connectionID)
        {
            if (Messages == null)
                Messages = new List<Message>();
            if (message.IsValid())
            {
                var user = _userController.GetUser(connectionID);
                if (user != null)
                {

                    message.User = user;
                    Messages.Add(message);
                    return true;
                }
            }
           
            return false;
        }

        public object RemoveMessages(string connectionID)
        {
            if (Messages == null)
                Messages = new List<Message>();
            var messages = Messages.Where(x => x.User.ConnectionID == connectionID);
            Messages = Messages.Except(messages).ToList();
            return Messages.Select(x => ChatMessage(x)).ToList();

        }

        public object GetMessages()
        {
            if (Messages == null)
                Messages = new List<Message>();
            return Messages.Select(x => ChatMessage(x)).ToList();
        }


        private object ChatMessage(Message m)
        {
            return new
            {
                Text = m.Text,
                UserName = m.User.UserName
            };
        }
    }
}
