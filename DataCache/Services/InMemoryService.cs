using DataCache.EF;
using DataCache.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataCache.Services
{
    public class InMemoryService : IInMemoryService
    {
      
        private Common _common;
        public InMemoryService(Common common)
        {          
            _common = common;
        }

       
    }
}
