using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCache.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IUserService _userService;       
        public ValuesController( IUserService userService)
        {
            
            _userService = userService;
           
        }
       
    }
}