using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.IRepositories;
using ThirdPersonDemoIMGsInfrasturcture.Context;

namespace ThirdPersonDemoIMGsInfrasturcture.Repositories
{
    public abstract class BaseRespository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationContext _context;
        private DbSet<T> _dbSet;

        public DbSet<T> DbSet { get => _dbSet; }

        public BaseRespository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            var e = await _dbSet.FindAsync(entity.Id);

            if(e == null)
            {
                var newEntity = await _dbSet.AddAsync(entity);

                return await _context.SaveEntitiesAsync() ?
                       await _dbSet.FindAsync(newEntity.Entity.Id) : null;
            }

            return null;
        }

        public async Task<T> Remove(T entity)
        {
            var e = await _dbSet.FindAsync(entity.Id);

            if(e != null)
            {
                var removedEntity = _dbSet.Remove(entity);

                return await _context.SaveEntitiesAsync() ? removedEntity.Entity : null;
            }

            return null;
        }
    }
}
