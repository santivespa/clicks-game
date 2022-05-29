using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.Model
{
    public class Invitation
    {
        public User From { get; set; }

        public User To { get; set; }


        public DateTime Date { get; set; }
    }
}
