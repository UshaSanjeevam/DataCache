using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCache;
using System.Data;
namespace DataCache.Services
{
    public interface IUserService
    {
        List<string> GetCacheData(int UserID);
      DataTable Authenticate(string username, string password);
    }
}
