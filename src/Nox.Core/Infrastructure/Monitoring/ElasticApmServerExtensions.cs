using Microsoft.Extensions.Configuration;

namespace Nox.Monitoring.ElasticApm;

public static class ElasticApmServerExtensions
{
    public static IConfiguration ToConfiguration(this Nox.Solution.Models.Infrastructure.Monitoring.Server.ElasticApmServer elasticApServerConfiguration)
    {
        var configBuilder = new ConfigurationBuilder();

        configBuilder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            {"ServerUrl", elasticApServerConfiguration.ServerUri},
            {"SecretToken", elasticApServerConfiguration.SecretToken},
            {"LogLevel", elasticApServerConfiguration.LogLevel},
            {"ServiceName", elasticApServerConfiguration.ServiceName},
            {"Environment", elasticApServerConfiguration.Environment},
        });
        var config = configBuilder.Build();
        return config;
    }
}