using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.IRepositories;
using ThirdPersonDemoIMGsInfrasturcture.Context;

namespace ThirdPersonDemoIMGsInfrasturcture.Repositories
{
    public class ImagesRepository : BaseRespository<Image>, IImagesRepository
    {
        public ImagesRepository(ApplicationContext context) : base(context)
        {
        }   

        public async Task<IEnumerable<Image>> GetAllImages()
        {
            return DbSet.AsEnumerable();
        }    
    }
}
