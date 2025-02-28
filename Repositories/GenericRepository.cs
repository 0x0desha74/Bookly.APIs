using Bookly.APIs.Data;
using Bookly.APIs.Entities;
using Bookly.APIs.Interfaces;
using Bookly.APIs.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Bookly.APIs.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }


        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecifications<T> spec)
        {
           return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<T> GetEntityWithSpecAsync(ISpecifications<T> spec)
        {
          return  await ApplySpecifications(spec).FirstOrDefaultAsync();
        }




        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }



        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }



        private  IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            return  SpecificationEvaluator<T>.BuildQuery(_dbContext.Set<T>(), spec);
        }


        }
    
}
