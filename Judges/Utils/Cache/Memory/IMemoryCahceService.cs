using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judges.Utils.Cache
{
    public interface IMemoryCahceService<T>
    {
        T[] GetData();
    }
}
