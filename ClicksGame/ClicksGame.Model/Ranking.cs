using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.Model
{
    public class Ranking
    {
        public int ID { get; set; }
        public string UserName { get; set; }

        public int Points { get; set; }
        public DateTime Date { get; set; }

        public Ranking()
        {
            this.Date = DateTime.Now;
        }
    }
}
