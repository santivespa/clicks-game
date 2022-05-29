using ClicksGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.BLL.Interfaces
{
    public interface IRankingController
    {
        List<Ranking> GetRanking();

        bool Add(Ranking r);
    }
}
