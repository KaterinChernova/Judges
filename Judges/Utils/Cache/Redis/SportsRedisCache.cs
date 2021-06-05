using Judges.Data;
using Judges.Data.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Utils.Cache.Redis
{
    public class SportsRedisCache : EntitiesRedisCache<Sport>
    {
        public SportsRedisCache(IDistributedCache cache, JudgesDbContext judgesDbContext)
            : base(cache, judgesDbContext)
        {
        }

        protected override Sport[] GetFromDb()
        {
            return _judgesDbContext.Sports.ToArray();
        }
    }
}
