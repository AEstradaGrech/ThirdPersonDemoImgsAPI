using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThirdPersonDemoIMGs.Services;
using ThirdPersonDemoIMGsDomain.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdPersonDemoIMGs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageMgmtService _imageMgmtService;

        public ImagesController(ImageMgmtService imageService)
        {
            _imageMgmtService = imageService;
        }
        // GET: api/values
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTestValues()
        {
            return Ok("TestValue");
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult>PostImage(ImageDto imgDto)
        {
            var response = await _imageMgmtService.PostImage(imgDto);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }
    }
}
