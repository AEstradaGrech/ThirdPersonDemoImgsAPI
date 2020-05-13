using System;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Enums;

namespace ThirdPersonDemoIMGsDomain.Specifications
{
    public interface ISpecificationFactory
    {
        Task<ImgNameAndCategorySpec> GetNameAndCategorySpec(string imgName, ImgCategory category);
    }
}
