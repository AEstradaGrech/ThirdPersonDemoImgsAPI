using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.Enums;
using ThirdPersonDemoIMGsDomain.Specifications;

namespace ThirdPersonDemoIMGsDomain.IRepositories
{
    public interface IImagesRepository : IRepository<Image>
    {
        Task<IEnumerable<Image>> GetAllImages();
        Task<IEnumerable<Image>> GetByNameAndCategory(string name, ImgCategory category);
    }
}
