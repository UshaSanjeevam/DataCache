using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataCache.Models;
using DataCache.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace DataCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisCacheController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        public IInMemoryService _radisService;

        public RedisCacheController(IInMemoryService radisService, IDistributedCache cache)
        {
            _radisService = radisService;
            _cache = cache;
        }
        //Directly storing in rediscache
        public async Task<string> getIDistributedRedis(string world)
        {
            var valueFromRedis = _cache.GetString("helloFromRedis");
            await _cache.SetStringAsync("helloFromRedis", world);
            await _cache.RefreshAsync("helloFromRedis");      
            return valueFromRedis;
        }
      
    }
}