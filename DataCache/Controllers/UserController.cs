using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DataCache.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Data;
using Microsoft.Extensions.Caching.Distributed;
using DataCache.Models;

namespace DataCache.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
 
    public class UserController : ControllerBase
    {
        private readonly IDistributedCache _cache;

        public UserController(IDistributedCache cache)
        {
            _cache = cache;
        }
        //By using HttpContext
        [HttpGet("HttpContext")]
        public async Task<string> About()
        {                     
            //Load data from distributed data store asynchronously
            await HttpContext.Session.LoadAsync();
            //Get value from session
            string storedValue = HttpContext.Session.GetString("TestValue");
            
            if (storedValue == null)
            {
                //No value stored, set one
                storedValue = "Testing session in Redis. Time  storage: " + DateTime.Now.ToString("s");
                HttpContext.Session.SetString("TestValue", storedValue);
                HttpContext.Session.SetString("TestValue1", "Data");
                //Store session data asynchronously
                await HttpContext.Session.CommitAsync();
            }
          

            return storedValue + HttpContext.Session.GetString("TestValue1");
        }
        //By using IDistributed
        [HttpGet("IDistributedRedis")]
        public async Task<string> getIDistributedRedis(string world)
        {
            var valueFromRedis = _cache.GetString("helloFromRedis");
            if (valueFromRedis == null)
            {
                await _cache.SetStringAsync("helloFromRedis", world);
            }  
          //  await _cache.RefreshAsync("helloFromRedis");
           // var valueFromRedis = _cache.GetString("helloFromRedis");
            return  valueFromRedis;
          
        }
       

    }
}