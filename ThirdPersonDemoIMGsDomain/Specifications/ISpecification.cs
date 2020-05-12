using System;
using System.Linq.Expressions;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGsDomain.Specifications
{
    public interface ISpecification<T> where T : Entity
    {
        Expression<Func<T, bool>> SatisfiedBy();
    }
}
