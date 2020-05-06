using System;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.IRepositories;
using ThirdPersonDemoIMGsInfrasturcture.Context;

namespace ThirdPersonDemoIMGsInfrasturcture.Repositories
{
    public abstract class BaseRespository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationContext _context;

        public BaseRespository(ApplicationContext context)
        {
            _context = context;
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
