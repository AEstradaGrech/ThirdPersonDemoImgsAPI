using System;
using System.Linq.Expressions;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.Enums;

namespace ThirdPersonDemoIMGsDomain.Specifications
{
    public class ImgNameAndCategorySpec : Specification<Image>
    {
        private string _imgName;
        private ImgCategory _category;

        public ImgNameAndCategorySpec(string imgName, ImgCategory category)
        {
            _imgName = imgName;
            _category = category;
        }

        public override Expression<Func<Image, bool>> SatisfiedBy()
        {
            return x => (x.ImgName == _imgName && x.Category == _category);            
        }
    }
}
