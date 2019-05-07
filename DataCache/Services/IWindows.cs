using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataCache.Services
{
   public interface IWindows
    {
        bool GetWindowsData(string username, string password);
    }
}
