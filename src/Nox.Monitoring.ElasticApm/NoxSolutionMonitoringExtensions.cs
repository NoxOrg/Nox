using Microsoft.Extensions.Configuration;
using Nox.Solution.Builders;

namespace Nox.Monitoring.ElasticApm;

public static class NoxSolutionMonitoringExtensions
{
    public static IConfiguration ToConfiguration(this Solution.Monitoring? monitoringConfiguration)
    {
        var serverUrl = "http://localhost:8200";
        var secretToken = "";
        var logLevel = "Info";
        var serviceName = "";
        var environment = "";
        
        var configBuilder = new ConfigurationBuilder();
        if (monitoringConfiguration != null)
        {
            var serverUri = new NoxUriBuilder(monitoringConfiguration, "http", "").Uri;
            serverUrl = serverUri!.ToString();
            
            if (!string.IsNullOrWhiteSpace(monitoringConfiguration.Options))
            {
                var options = monitoringConfiguration.Options.Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Split('=', 2))
                    .ToDictionary(e => e[0], e => e[1], StringComparer.OrdinalIgnoreCase);
                if (options.TryGetValue("secretToken", out var secretTokenValue))
                {
                    secretToken = secretTokenValue;
                }
                if (options.TryGetValue("logLevel", out var logLevelValue))
                {
                    logLevel = logLevelValue;
                }
                if (options.TryGetValue("logLevel", out var serviceNameValue))
                {
                    serviceName = serviceNameValue;
                }
                if (options.TryGetValue("logLevel", out var environmentValue))
                {
                    environment = environmentValue;
                }
            }
        }
        
        
        configBuilder.AddInMemoryCollection(new Dictionary<string, string?>
        {
            {"ServerUrl", serverUrl},
            {"SecretToken", secretToken},
            {"LogLevel", logLevel},
            {"ServiceName", serviceName},
            {"Environment", environment},
        });
        var config = configBuilder.Build();
        return config;
    }
}