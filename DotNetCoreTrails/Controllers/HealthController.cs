using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTrails.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet("check")]
        [HttpGet]
        public string Check() => $"Api Health is Good { DateTime.Now}";

        public int GetHours => DateTime.Now.Hour;

        public DateTime GetDateTime => DateTime.Now;
    }
}
