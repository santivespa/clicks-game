using ClicksGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.DAL.Interfaces
{
    public interface IRankingManager
    {
        List<Ranking> GetRanking();

        bool Add(Ranking r);

        void Remove(Ranking r);

    }
}
