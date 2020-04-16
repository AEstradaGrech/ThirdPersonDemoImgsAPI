using System;
using ThirdPersonDemoIMGsDomain.Dtos;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGs.Services.Mappers
{
    public interface IImageMapperService : IMapperService<Image, ImageDto>
    {
    }
}
