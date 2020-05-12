using System;
using System.Threading.Tasks;

namespace ThirdPersonDemoIMGsDomain.Specifications
{
    public interface ISpecificationFactory
    {
        Task<ImgNameAndCategorySpec> GetNameAndCategorySpec();
    }
}
