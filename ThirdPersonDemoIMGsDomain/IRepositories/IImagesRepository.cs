using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGsDomain.IRepositories
{
    public interface IImagesRepository : IRepository<Image>
    {
        Task<IEnumerable<Image>> GetAllImages();
    }
}
