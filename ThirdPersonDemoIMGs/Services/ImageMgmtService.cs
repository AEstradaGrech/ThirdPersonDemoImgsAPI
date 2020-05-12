﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using ThirdPersonDemoIMGs.Services.Mappers;
using ThirdPersonDemoIMGsDomain.Dtos;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.IRepositories;

namespace ThirdPersonDemoIMGs.Services
{
    public class ImageMgmtService : IImageMgmtService
    {
        private readonly IImagesRepository _imagesRespository;

        private readonly IImageMapperService _mapper;

        public ImageMgmtService(IImagesRepository imagesRepository , IImageMapperService mapper)
        {
            _imagesRespository = imagesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ImageDto>> GetAllImages()
        {           
            return await _mapper.MapManyToDto(await _imagesRespository.GetAllImages());
        }

        public async Task<ImageDto> PostImage(ImageDto imgDto)
        {
            return await _mapper.MapToDto(await _imagesRespository.Add(await _mapper.MapToEntity(imgDto)));
        }
    }
}
