using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThirdPersonDemoIMGsDomain.Entities;
using ThirdPersonDemoIMGsDomain.IRepositories;
using ThirdPersonDemoIMGsInfrasturcture.Context.EntityTypeConfigurations;

namespace ThirdPersonDemoIMGsInfrasturcture.Context
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ImageEntityTypeConfiguration());
        }

        public async Task<int> SaveContextAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync();
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync() > 0;
        }

        DbSet<Image> Images { get; set;}

    }
}
