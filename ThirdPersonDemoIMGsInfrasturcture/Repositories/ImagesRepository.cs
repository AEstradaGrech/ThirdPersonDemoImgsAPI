using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.Enums;
using ThirdPersonDemoIMGsDomain.IRepositories;
using ThirdPersonDemoIMGsDomain.Specifications;
using ThirdPersonDemoIMGsInfrasturcture.Context;

namespace ThirdPersonDemoIMGsInfrasturcture.Repositories
{
    public class ImagesRepository : BaseRespository<Image>, IImagesRepository
    {
        private readonly ISpecificationFactory _specFactory;

        public ImagesRepository(ApplicationContext context, ISpecificationFactory specFactory) : base(context)
        {
            _specFactory = specFactory;
        }

        public async Task<bool> CheckImageNameExists(string imgName)
        {
            return await DbSet.AnyAsync(img => img.ImgName == imgName);
        }

        public async Task<IEnumerable<Image>> GetAllImages()
        {
            return DbSet.AsEnumerable();
        }

        public async Task<IEnumerable<Image>> GetByCategory(ImgCategory category)
        {           
            return DbSet.Where(img => img.Category == category)
                        .AsEnumerable();
        }

        public async Task<Image> GetByNameAndCategory(string name, ImgCategory category)
        {
            var spec = await _specFactory.GetNameAndCategorySpec(name, category);

            return await DbSet.Where(spec.SatisfiedBy())
                              .FirstAsync();
        }

        public async Task<IEnumerable<Image>> GetCatalogueImgs(IEnumerable<string> imgNames)
        {
            var spec = await _specFactory.GetImgNamesSpec(imgNames);

            var catalogueSet = DbSet.Where(img => img.Category == ImgCategory.GamesCatalogue);

            return catalogueSet.Where(spec.SatisfiedBy())
                               .AsEnumerable();
        }

        public async Task<Image> GetUserImage(Guid userGuid)
        {
            return await DbSet.SingleOrDefaultAsync(img => img.UserGuid == userGuid);
        }
    }
}
