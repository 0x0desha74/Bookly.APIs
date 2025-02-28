using Bookly.APIs.Entities;
using Bookly.APIs.Repositories;

namespace Bookly.APIs.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
