using ClicksGame.API.Models;
using ClicksGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClicksGame.API.Hubs
{
    public interface IHubClient
    {

        Task DisplayMessages(object messages);

        Task DisplayUsers(object users);

        Task SuccessLogin(string userName);


        Task AddClick();

        Task GetCount(int count);


        Task InvitationSended();
        Task InvitationReceived(string userName);

        Task AddRanking(Ranking r);
    }
}
