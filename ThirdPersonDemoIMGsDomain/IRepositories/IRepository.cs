using System;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGsDomain.IRepositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Add(T entity);
        Task<T> Remove(T entity);
    }
}
