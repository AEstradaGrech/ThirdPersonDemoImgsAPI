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
        Task<Image> GetByNameAndCategory(string name, ImgCategory category);
        Task<bool> CheckImageNameExists(string imgName);
        Task<IEnumerable<Image>> GetByCategory(ImgCategory category);
        Task<Image> GetUserImage(Guid userGuid);
        Task<IEnumerable<Image>> GetCatalogueImgs(IEnumerable<string> imgNames);
    }
}
