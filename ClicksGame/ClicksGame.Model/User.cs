using System;

namespace ClicksGame.Model
{
    public class User
    {
        public string ConnectionID { get; set; }
        public string UserName { get; set; }

        public bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(this.UserName) && this.UserName.Length <= 30;
        }
    }
}
