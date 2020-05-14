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

        public async Task<IEnumerable<Image>> GetByNameAndCategory(string name, ImgCategory category)
        {
            var spec = await _specFactory.GetNameAndCategorySpec(name, category);

            return DbSet.Where(spec.SatisfiedBy())
                        .AsEnumerable();
        }
    }
}
