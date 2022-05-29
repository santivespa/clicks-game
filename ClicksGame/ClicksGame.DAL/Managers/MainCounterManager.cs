using ClicksGame.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.DAL.Interfaces
{
    public class MainCounterManager : IMainCounterManager
    {
        private readonly ClicksGameContext _context;

        public MainCounterManager(ClicksGameContext context) => _context = context;
        public int AddAClick()
        {
            var counter = _context.Counter.First() ;
            counter.Count++;
            _context.SaveChanges();
            return counter.Count;
        }

        public int GetCount()
        {
            var counter = _context.Counter.First();
            return counter.Count;
        }
    }
}
