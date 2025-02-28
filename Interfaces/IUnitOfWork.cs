using Bookly.APIs.Entities;
using Bookly.APIs.Repositories;

namespace Bookly.APIs.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        Task<IGenericRepository<TEntity>> Repository<TEntity>() where TEntity : BaseEntity;
        Task Complete();
    }
}
