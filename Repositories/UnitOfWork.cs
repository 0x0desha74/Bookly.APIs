using Bookly.APIs.Data;
using Bookly.APIs.Entities;
using Bookly.APIs.Interfaces;
using System.Collections;

namespace Bookly.APIs.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _dbContext;

        private  Hashtable _repositories;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {

            if (_repositories is null)
                _repositories = new Hashtable();
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(_dbContext);
                _repositories.Add(type, repository);
            }
            return _repositories[type] as GenericRepository<TEntity>;
        }






        public async Task Complete()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

       
    }
}
