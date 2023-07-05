using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for the Cache server used in a Nox solution.")]
    [Description("Specify properties pertinent to the solution Cache server here. Examples include name, serverUri, Port and connection credentials")]
    [AdditionalProperties(false)]
    public class CacheServer : ServerBase
    {
        [Required]
        [Title("The cache server provider.")]
        [Description("The provider used for this cache server. Examples include AmazonElasticCache, AzureRedis, Memcached and Redis.")]
        [AdditionalProperties(false)]
        public CacheServerProvider Provider { get; internal set; } = CacheServerProvider.Memcached;
    }
}