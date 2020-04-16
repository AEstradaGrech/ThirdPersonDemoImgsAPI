using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdPersonDemoIMGs.Services.Mappers;
using ThirdPersonDemoIMGsDomain.Dtos;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGs.Services
{
    public interface IImageMgmtService
    {
        Task<IEnumerable<ImageDto>> GetAllImages();
        Task<ImageDto> PostImage(ImageDto ImgDto);
    }
}
