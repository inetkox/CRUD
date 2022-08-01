namespace CRUD.WebAPI.Interfaces
{
    public interface ICacheRepository
    {
        bool TryGet<T>(string cacheKey, out T value);
        T Set<T>(string cacheKey, T value);
        void Remove(string cacheKey);
    }
}
