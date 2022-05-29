using ClicksGame.DAL.Context;
using ClicksGame.DAL.Interfaces;
using ClicksGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.DAL.Managers
{
    public class RankingManager : IRankingManager
    {
        private readonly ClicksGameContext _context;
        public RankingManager(ClicksGameContext context) => _context = context;

        public bool Add(Ranking r)
        {
            this._context.Rankings.Add(r);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public List<Ranking> GetRanking()
        {
            return _context.Rankings.ToList(); 
        }

        public void Remove(Ranking r)
        {
            var ranking = _context.Rankings.Find(r.ID);
            _context.Remove(ranking);
            _context.SaveChanges();
        }
    }
}
