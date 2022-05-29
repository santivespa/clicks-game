using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.DAL.Interfaces
{
    public interface IMainCounterManager
    {

        int AddAClick();

        int GetCount();
    }
}
