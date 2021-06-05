using Judges.Data;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Judges.Utils.Cache
{
    public abstract class EntitiesMemoryCache<T> : IMemoryCahceService<T>
    {
        private readonly IMemoryCache _cache;
        protected readonly JudgesDbContext _judgesDbContext;

        public EntitiesMemoryCache(IMemoryCache cache, JudgesDbContext judgesDbContext)
        {
            _cache = cache;
            _judgesDbContext = judgesDbContext;
        }

        public T[] GetData()
        {
            string key = typeof(T).Name;

            if (!_cache.TryGetValue(key, out var sports) || sports == null)
            {
                sports = GetFromDb();

                _cache.Set(key, sports, TimeSpan.FromDays(1));
            }

            if( sports is T[])
            {
                return sports as T[];
            }

            throw new NotSupportedException("Кэш не поддерживает указанный тип.");
        }

        protected abstract T[] GetFromDb();
    }
}
