using Judges.Data;
using Judges.Data.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Utils.Cache
{
    public class SportsMemoryCache : EntitiesMemoryCache<Sport>
    {
        public SportsMemoryCache(IMemoryCache cache, JudgesDbContext judgesDbContext)
            : base(cache, judgesDbContext)
        {
        }

        protected override Sport[] GetFromDb()
        {
            return _judgesDbContext.Sports.ToArray();
        }
    }
}
