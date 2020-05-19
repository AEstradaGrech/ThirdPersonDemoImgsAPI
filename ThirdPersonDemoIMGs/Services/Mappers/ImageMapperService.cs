using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using ThirdPersonDemoIMGsDomain.Dtos;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.Enums;

namespace ThirdPersonDemoIMGs.Services.Mappers
{
    public class ImageMapperService : IImageMapperService
    {
     
        public async Task<ImageDto> MapToDto(Image entity)
        {
            var dto = new ImageDto();            

            dto = (ImageDto)dto.InjectFrom(entity);

            //dto.Category = (ImgCategory)entity.Category;

            dto.ImgBase64 = Convert.ToBase64String(entity.ImgBytes);

            return dto;
        }

        public async Task<Image> MapToEntity(ImageDto dto)
        {
            var entity = new Image();            

            entity = (Image)entity.InjectFrom(dto);

            //entity.Category = (int)dto.Category;

            string[] base64Splitted = dto.ImgBase64.Split(',');

            entity.ImgBytes = Convert.FromBase64String(base64Splitted[1]);

            return entity;
        }

        public async Task<IEnumerable<ImageDto>> MapManyToDto(IEnumerable<Image> entities)
        {
            var dtos = new List<ImageDto>();

            foreach(var e in entities)
            {
                dtos.Add(await MapToDto(e));
            }

            return dtos.AsEnumerable();
        }

        public async Task<IEnumerable<Image>> MapManyToEntity(IEnumerable<ImageDto> dtos)
        {
            var entities = new List<Image>();

            foreach(var dto in dtos)
            {
                entities.Add(await MapToEntity(dto));
            }

            return entities;
        }
    }
}
