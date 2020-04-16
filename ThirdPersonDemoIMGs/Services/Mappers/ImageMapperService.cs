using System;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using ThirdPersonDemoIMGsDomain.Dtos;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGs.Services.Mappers
{
    public class ImageMapperService : IImageMapperService
    {
        public async Task<ImageDto> MapToDto(Image entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> MapToEntity(ImageDto dto)
        {
            var entity = new Image();

            entity = (Image)entity.InjectFrom(dto);

            string[] base64Splitted = dto.ImgBase64.Split(',');

            entity.ImgBytes = Convert.FromBase64String(base64Splitted[1]);

            return entity;
        }
    }
}
