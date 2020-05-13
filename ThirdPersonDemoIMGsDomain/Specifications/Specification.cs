using System;
using System.Linq.Expressions;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGsDomain.Specifications
{
    public class Specification<T> : ISpecification<T> where T : Entity
    {
        private Expression<Func<T, bool>> _predicate;

        public Specification() { }

        public Specification(Expression<Func<T,bool>> predicate)
        {
            _predicate = predicate;
        }

        public virtual Expression<Func<T, bool>> SatisfiedBy()
        {
            return _predicate;
        }
    }
}
