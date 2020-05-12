using System;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Enums;


namespace ThirdPersonDemoIMGsDomain.Specifications
{
    public class SpecificationFactory : ISpecificationFactory
    {
        public SpecificationFactory()
        {
        }

        public async Task<ImgNameAndCategorySpec> GetNameAndCategorySpec(string imgName, ImgCategory category)
        {
            return new ImgNameAndCategorySpec(imgName, category);
        }
    }
}
