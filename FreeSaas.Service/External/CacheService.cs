using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSaas.Service.External
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _redisCache;
        private readonly ILogger _logger;

        public CacheService(IConnectionMultiplexer muxer, ILogger logger) 
        {
            _redisCache = muxer.GetDatabase();
            _logger = logger;
        }

        public void Dispose()
        {
            
        }

        public CacheValue FindCache(string key)
        {
            _logger.LogInformation($"FindCache -> Key: {key}");

            var getTask = _redisCache.StringGet(key);

            _logger.LogInformation($"FindCache -> Value: {getTask.ToString()}");
            return new CacheValue
            {
                Exists = !string.IsNullOrEmpty(getTask.ToString()),
                ValueString = getTask.ToString()
            };
        }

        public bool SetCacheString(string key, string value)
        {
            var setTask = _redisCache.StringSetAsync(key, value, TimeSpan.FromSeconds(3600));
            Task.WhenAll(setTask);
            return true;
        }
    }
}
