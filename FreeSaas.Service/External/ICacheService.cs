using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSaas.Service.External
{
    public interface ICacheService : IDisposable
    {
        CacheValue FindCache(string key);
        
        bool SetCacheString(string key, string value);
    }
}
