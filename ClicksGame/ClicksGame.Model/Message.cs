using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.Model
{
    public class Message
    {
        public User User { get; set; }
        public string Text { get; set; }

        public bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(this.Text) && this.Text.Length <= 200;
        }
    }
}
