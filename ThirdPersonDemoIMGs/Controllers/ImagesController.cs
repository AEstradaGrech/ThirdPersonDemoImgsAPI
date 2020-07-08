using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThirdPersonDemoIMGs.Services;
using ThirdPersonDemoIMGsDomain.Dtos;
using Newtonsoft.Json;
using ThirdPersonDemoIMGsDomain.Enums;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdPersonDemoIMGs.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]    
    public class ImagesController : ControllerBase
    {
        private readonly IImageMgmtService _imageMgmtService;

        public ImagesController(IImageMgmtService imageService)
        {
            _imageMgmtService = imageService;
        }

        // GET: api/values
        [HttpGet]
        [Route("get-test-dto")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTestDto()
        {
            var testDto = new ImageDto
            {
                ImgName = "TestName",
                ImgBase64 = "ABunchOfCharacters",
                CreationDate = DateTime.Now
            };

            return Ok(testDto);
        }

        [HttpGet]
        [Route("get-by-name-and-category")]
        [Produces("application/json")]
        [Authorize(Policy = "Anonymous")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByNameAndCategory([FromQuery]string imgName, [FromQuery]ImgCategory category)
        {           
            var response = await _imageMgmtService.GetByNameAndCategory(imgName, category);

            if(response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpGet]
        [Route("get-by-category")]
        [Produces("application/json")]
        [Authorize(Policy = "Anonymous")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByCategory([FromQuery]ImgCategory category)
        {
            var response = await _imageMgmtService.GetByCategory(category);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpGet]
        [Route("get-user-img")]
        [Authorize(Policy="Customers")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserImage([FromQuery]Guid userGuid)
        {
            var response = await _imageMgmtService.GetUserImage(userGuid);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }


        [HttpGet]
        [Route("check-img-name-exists")]
        [Produces("application/json")]
        [Authorize(Policy = "Anonymous")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GheckImageNameExists([FromQuery]string imgName)
        {
            return Ok(await _imageMgmtService.CheckImageNameExists(imgName));
        }


        [HttpPost]
        [Route("post-img")]
        [Authorize(Policy="Customers")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult>PostImage([FromBody]ImageDto imgDto)
        {
            Console.WriteLine($"IMAGE USER GUID :: {imgDto.UserGuid}");
            var response = await _imageMgmtService.PostImage(imgDto);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }

        [HttpPost]
        [Route("get-catalogue-imgs")]
        [Authorize(Policy="Anonymous")]
        [Produces("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCatalogueImgs([FromBody]IEnumerable<string> imgNames)
        {
            Console.WriteLine($"GetCatalogueImgs :: {imgNames}");
            var response = await _imageMgmtService.GetCatalogueImages(imgNames);

            if (response != null)
                return Ok(response);

            return BadRequest();
        }
    }
}
