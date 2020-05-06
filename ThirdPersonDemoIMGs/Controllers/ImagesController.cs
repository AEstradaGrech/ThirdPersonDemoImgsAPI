﻿using System;
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

        [HttpPost]
        [Route("post-img")]
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
