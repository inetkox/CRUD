namespace CRUD.WebAPI.Interfaces
{
    public class CacheConfiguration
    {
        public int AbsoluteExpirationInSeconds { get; set; }
        public int SlidingExpirationInSeconds { get; set; }
    }
}
