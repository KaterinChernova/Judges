using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Utils.Cache.Redis
{
    public interface IRedisCache<T>
    {
        T[] GetData();
    }
}
