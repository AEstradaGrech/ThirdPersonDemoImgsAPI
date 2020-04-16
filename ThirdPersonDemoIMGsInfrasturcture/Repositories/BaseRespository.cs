using System;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.IRepositories;

namespace ThirdPersonDemoIMGsInfrasturcture.Repositories
{
    public abstract class BaseRespository<T> : IRepository<T> where T : Entity
    {
        public BaseRespository()
        {
        }

        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Remove(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
