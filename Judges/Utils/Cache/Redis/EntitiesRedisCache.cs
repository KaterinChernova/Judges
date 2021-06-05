using Judges.Data;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Judges.Utils.Cache.Redis
{
    public abstract class EntitiesRedisCache<T> : IRedisCache<T>
    {
        private readonly IDistributedCache _cache;
        protected readonly JudgesDbContext _judgesDbContext;

        public EntitiesRedisCache(IDistributedCache cache, JudgesDbContext judgesDbContext)
        {
            _cache = cache;
            _judgesDbContext = judgesDbContext;
        }

        public T[] GetData()
        {
            string key = typeof(T).Name;

            string entitesStr = _cache.GetString(key);
            if (string.IsNullOrEmpty(entitesStr))
            {
                T[] entites = GetFromDb();

                entitesStr = JsonConvert.SerializeObject(entites);

                _cache.SetString(key, entitesStr, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
                });

                return entites;
            }

            try
            {
                return JsonConvert.DeserializeObject<T[]>(entitesStr);
            }
            catch(Exception e)
            {
                throw new Exception($"Не удалось преобразовать кэш в объект типа {typeof(T[]).Name}");
            }
        }

        protected abstract T[] GetFromDb();
    }
}
