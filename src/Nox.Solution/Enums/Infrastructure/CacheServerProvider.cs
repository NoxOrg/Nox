using System;
using System.Linq;

namespace Nox
{
    public enum CacheServerProvider
    {
        AmazonElasticCache,
        AzureRedis,
        Memcached,
        Redis
    }
}