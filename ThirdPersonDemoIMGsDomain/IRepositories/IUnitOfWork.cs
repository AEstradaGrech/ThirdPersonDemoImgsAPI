using System;
using System.Threading;
using System.Threading.Tasks;
using ThirdPersonDemoIMGsDomain.Entities;

namespace ThirdPersonDemoIMGsDomain.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveContextAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
