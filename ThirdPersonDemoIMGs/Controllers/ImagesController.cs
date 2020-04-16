using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdPersonDemoIMGs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ImagesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTestValues()
        {
            return Ok("TestValue");
        }
    }
}
