using ClicksGame.BLL.Interfaces;
using ClicksGame.DAL.Interfaces;
using ClicksGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.BLL.Controllers
{
    public class InvitationsController : IInvitationsController
    {
        private readonly IUsersController _userController;

        public InvitationsController(IUsersController userController) => _userController = userController;

        // temporarily
        private static List<Invitation> Invitations { get; set; }

        public Invitation AddInvitation(string connectionID, string userNameTo)
        {

            if (Invitations == null)
                Invitations = new List<Invitation>();

            var user1 = _userController.GetUser(connectionID);
            var user2 = _userController.GetUserByUserName(userNameTo);

            if (user1 != null && user2 != null)
            {
                var invitation = new Invitation()
                {
                    From = user1,
                    To = user2,
                    Date = DateTime.Now
                };
                Invitations.Add(invitation);
                return invitation;
            }
            return null;
        }
    }
}
