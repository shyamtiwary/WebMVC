using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MongoDbWebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Route("api/Test/GetAll")]
        [HttpGet]
        public ActionResult GetServerName()
        {
            var serverDT = System.Environment.MachineName + "_" + System.DateTime.Now;
            return Ok(serverDT);
        }
    }
}
