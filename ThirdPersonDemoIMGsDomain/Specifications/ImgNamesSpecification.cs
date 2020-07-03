using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.Extensions;

namespace ThirdPersonDemoIMGsDomain.Specifications
{
    public class ImgNamesSpecification : Specification<Image>
    {
        private IEnumerable<string> _imgNames;

        public ImgNamesSpecification(IEnumerable<string>imgNames)
        {
            _imgNames = imgNames;            
        }       
        /// <summary>
        /// Creates an expression that returns any Image whose name matches any name in the list
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Image, bool>> SatisfiedBy()
        {
            Expression<Func<Image, bool>> finalExpression = null;

            var predicates = new List<Expression<Func<Image, bool>>>();

            foreach (var name in _imgNames)
            {
                Expression<Func<Image, bool>> expression = x => x.ImgName == name;

                predicates.Add(expression);
            }

            return  finalExpression.CombinePredicates<Image>(predicates, Expression.Or);            
        }
    }
}
