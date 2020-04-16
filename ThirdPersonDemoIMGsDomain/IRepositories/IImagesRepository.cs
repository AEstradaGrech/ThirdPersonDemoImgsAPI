using System;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGsDomain.IRepositories
{
    public interface IImagesRepository : IRepository<Image>
    {
        Task<Image> GetAllImages();
    }
}
