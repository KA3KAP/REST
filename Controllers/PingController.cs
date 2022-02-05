using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerRestAPI.Controllers
{
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
            [HttpGet]
            public ActionResult<string> Get()
            {
                return "Dogs House Service. Version 1.0.1";
            }
    }
}
