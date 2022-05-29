using ClicksGame.BLL.Interfaces;
using ClicksGame.Model;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClicksGame.API.Hubs
{
    public class ClicksHub : Hub<IHubClient>
    {

        private readonly IUsersController _usersController;

        private readonly IMessagesController _messagesController;

        private readonly IMainCounterController _mainCounterController;
        private readonly IInvitationsController _invitationController;

        private readonly IRankingController _rankingController;
        public ClicksHub(IMessagesController messagesController, IUsersController usersController, IMainCounterController mainCounterController, IInvitationsController invitationController, IRankingController rankingController) {
            _messagesController = messagesController;
            _usersController = usersController;
            _mainCounterController = mainCounterController;
            _invitationController = invitationController;
            _rankingController = rankingController;
        }


        public override Task OnConnectedAsync()
        {
            var connectionID = Context.ConnectionId;
            var user = _usersController.GetUser(connectionID);
            if (user == null)
            {
                Clients.All.DisplayUsers(_usersController.GetUsers());
                Clients.Caller.DisplayMessages(_messagesController.GetMessages());
                Clients.Caller.GetCount(_mainCounterController.GetCount());
            }

        
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionID = Context.ConnectionId;

            var users = _usersController.Remove(connectionID);
            var messages = _messagesController.RemoveMessages(connectionID);

            Clients.All.DisplayUsers(users);
            Clients.All.DisplayMessages(messages);
            return base.OnDisconnectedAsync(exception);
        }
      


        public void PostMessage(Message msg)
        {
            var connectionID = Context.ConnectionId;
            var result = _messagesController.Add(msg, connectionID);
            if (result)
            {
                Clients.All.DisplayMessages(_messagesController.GetMessages());
            }
        }
        public void Login(string name)
        {
            var connectionID = Context.ConnectionId;
            var user = new User()
            {
                ConnectionID = connectionID,
                UserName = name
            };
            var result = _usersController.Add(user);
            if (result)
            {
                Clients.All.DisplayUsers(_usersController.GetUsers());
                Clients.Caller.SuccessLogin(name);
            }
        
        }

        public void Click()
        {
            var count = _mainCounterController.AddClick();
            Clients.All.GetCount(count);
        }

        public void InviteUser(string userName)
        {
            var connectionID = Context.ConnectionId;
            var invitation = _invitationController.AddInvitation(connectionID, userName);
            if (invitation != null)
            {
                Clients.Client(invitation.To.ConnectionID).InvitationReceived(invitation.From.UserName);
                Clients.Caller.InvitationSended();
            }
        }


        public void AddRanking(Ranking r)
        {
            var connectionID = Context.ConnectionId;
            
            if (r != null)
            {
                
                var user = _usersController.GetUser(connectionID);
                if (user != null)
                {
                    r.UserName = user.UserName;
                    if (user != null)
                    {
                        var result = _rankingController.Add(r);
                        if (result)
                        {

                        }
                    }
                }
               
            }
        }
    }

}
