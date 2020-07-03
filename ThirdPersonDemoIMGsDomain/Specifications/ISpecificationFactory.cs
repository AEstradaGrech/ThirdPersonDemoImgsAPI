using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Enums;

namespace ThirdPersonDemoIMGsDomain.Specifications
{
    public interface ISpecificationFactory
    {
        Task<ImgNameAndCategorySpec> GetNameAndCategorySpec(string imgName, ImgCategory category);
        Task<ImgNamesSpecification> GetImgNamesSpec(IEnumerable<string> imgNames);
    }
}
