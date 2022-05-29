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
    public class MainCounterController : IMainCounterController
    {

        private readonly IMainCounterManager _mainCounterManager;
        public MainCounterController(IMainCounterManager mainCounterManager) => _mainCounterManager = mainCounterManager;
      
        public int AddClick()
        {
            return _mainCounterManager.AddAClick();
        }
        public int GetCount()
        {
            return _mainCounterManager.GetCount();

        }
    }
}
