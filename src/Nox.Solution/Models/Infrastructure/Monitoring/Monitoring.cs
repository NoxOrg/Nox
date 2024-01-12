using Nox.Solution.Models.Infrastructure.Monitoring.Server;
using Nox.Yaml.Attributes;

namespace Nox.Solution.Models.Infrastructure.Monitoring
{
    [GenerateJsonSchema]
    [Title("The definition namespace for Monitor and Observability pertaining to a Nox solutionn.")]
    [Description("Specify properties pertinent to the APM server here. ")]
    [AdditionalProperties(false)]
    public class Monitoring
    {
        [Required]
        [Title("The Monitoring provider.")]
        [Description("The provider used for this Application. Default is ElasticAPM.")]
        [AdditionalProperties(false)]
        public MonitoringProvider Provider { get; internal set; } = MonitoringProvider.ElasticApm;

        [Title("Elastic APM Server Configuration.")]
        [Description("Configure Elastic APM Server.")]
        [IfEquals(nameof(Provider), MonitoringProvider.ElasticApm)]
        public ElasticApmServer? ElasticApmServer { get; internal set; }
    }
}
