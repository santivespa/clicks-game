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
    public class RankingController : IRankingController
    {
        private readonly IRankingManager _rankingManager;
        public RankingController(IRankingManager rankingManager) => _rankingManager = rankingManager;

        public bool Add(Ranking r)
        {
            var ranking = _rankingManager.GetRanking().OrderByDescending(x => x.Points).ToList();
            Ranking top1 = null;
            Ranking top2 = null;
            Ranking top3 = null;
            if (ranking.Count() == 1)
            {
                 top1 = ranking[0];
            }
            if (ranking.Count() == 2)
            {
                 top2 = ranking[1]; 
            }
            if (ranking.Count() == 3)
            {
                 top3 = ranking[2];
            }

            if (top1 == null || top2 == null || top3 == null)
            {
                _rankingManager.Add(r);
            }
            if(top1  != null && top2 != null && top3 != null)
            {
                if (top1.Points < r.Points || top2.Points < r.Points || top3.Points < r.Points)
                {
                    _rankingManager.Add(r);
                    _rankingManager.Remove(top3);

                    return true;
                }
              

            }
            return false;
        }

        public List<Ranking> GetRanking()
        {
            return _rankingManager.GetRanking();
        }
    }
}
