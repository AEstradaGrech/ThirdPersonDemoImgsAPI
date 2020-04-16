using System;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.IRepositories;

namespace ThirdPersonDemoIMGsInfrasturcture.Repositories
{
    public class ImagesRepository : BaseRespository<Image>, IImagesRepository
    {
        public ImagesRepository()
        {
        }

        public async Task<Image> GetAllImages()
        {
            throw new NotImplementedException();
        }
    }
}
