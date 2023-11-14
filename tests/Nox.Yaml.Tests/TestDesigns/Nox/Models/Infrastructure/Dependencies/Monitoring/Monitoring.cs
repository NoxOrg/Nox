using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("The definition namespace for the APM (Application Performance Monitoring) server used in a Nox solution.")]
[Description("Specify properties pertinent to the APM server here. Examples include name, serverUri, Port, provider and connection credentials.")]
[AdditionalProperties(false)]
public class Monitoring : ServerBase
{
    [Required]
    [Title("The APM server provider.")]
    [Description("The provider used for this APM server. Examples include ElasticAPM.")]
    [AdditionalProperties(false)]
    public MonitoringProvider Provider { get; internal set; } = MonitoringProvider.ElasticApm;
}