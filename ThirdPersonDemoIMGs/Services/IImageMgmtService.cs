using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdPersonDemoIMGs.Services.Mappers;
using ThirdPersonDemoIMGsDomain.Dtos;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.Enums;

namespace ThirdPersonDemoIMGs.Services
{
    public interface IImageMgmtService
    {
        Task<IEnumerable<ImageDto>> GetAllImages();
        Task<ImageDto> GetByNameAndCategory(string name, ImgCategory category);
        Task<IEnumerable<ImageDto>> GetByCategory(ImgCategory category);
        Task<ImageDto> PostImage(ImageDto ImgDto);
        Task<bool> CheckImageNameExists(string imgName);
        Task<ImageDto> GetUserImage(Guid userGuid);        
    }
}
