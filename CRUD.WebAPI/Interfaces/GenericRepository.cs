using CRUD.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebAPI.Interfaces
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string cacheKey = $"{typeof(T)}";
        private readonly string cacheKeyNew = $"{typeof(T)}New";
        private readonly ApplicationDbContext context;
        private readonly ICacheRepository cacheRepository;

        public GenericRepository(ApplicationDbContext context, ICacheRepository cacheRepository)
        {
            this.context = context;
            this.cacheRepository = cacheRepository;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            await RefreshCache();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            await RefreshCache();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            if (!cacheRepository.TryGet(cacheKey, out IReadOnlyList<T> cachedList))
            {
                cachedList = await context.Set<T>().ToListAsync();
                cacheRepository.Set(cacheKey, cachedList);
            }
            return cachedList;
        }

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            await RefreshCache();
        }

        public async Task RefreshCache()
        {
            cacheRepository.Remove(cacheKey);
            var cachedList = await context.Set<T>().ToListAsync();
            cacheRepository.Set(cacheKeyNew, cachedList);
        }
    }
}
