using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CRUD.WebAPI.Interfaces
{
    public class MemoryCacheRepository : ICacheRepository
    {
        private readonly IMemoryCache memoryCache;
        private readonly CacheConfiguration cacheConfiguration;
        private MemoryCacheEntryOptions memoryCacheEntryOptions;
        public MemoryCacheRepository(IMemoryCache memoryCache, IOptions<CacheConfiguration> cacheConfiguration)
        {
            this.memoryCache = memoryCache;
            this.cacheConfiguration = cacheConfiguration.Value;
            if (cacheConfiguration != null)
            {
                memoryCacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(this.cacheConfiguration.AbsoluteExpirationInSeconds),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(this.cacheConfiguration.SlidingExpirationInSeconds)
                };
            }
        }

        public bool TryGet<T>(string cacheKey, out T value)
        {
            memoryCache.TryGetValue(cacheKey, out value);
            if (value == null) 
                return false;
            else 
                return true;
        }
        public T Set<T>(string cacheKey, T value)
        {
            return memoryCache.Set(cacheKey, value, memoryCacheEntryOptions);
        }
        public void Remove(string cacheKey)
        {
            memoryCache.Remove(cacheKey);
        }
    }
}
