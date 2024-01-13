using Nox.Yaml.Attributes;
using System;

namespace Nox.Solution.Models.Infrastructure.Monitoring.Server
{
    [GenerateJsonSchema]
    [AdditionalProperties(false)]
    public class ElasticApmServer
    {
        [Required]
        [Title("Hostname, IP address or URI.")]
        [Description("The name, address, URI or IP of the server to connect to.")]
        [AllowVariable]
        public string ServerUri { get; internal set; } = null!;

        [Title("Service name.")]
        [Description("Allowed characters: a-z, A-Z, 0-9, -, _, and space. Default is the entry assembly of the application")]
        [AllowVariable]        
        public string ServiceName { get; internal set; } = String.Empty;

        [Title("Secret Token")]
        [Description("Default is empty")]
        [AllowVariable]        
        public string SecretToken { get; internal set; } = String.Empty;
        
        [Title("Environment.")]
        [Description("Default is Production.")]
        [AllowVariable]
        public string Environment { get; internal set; } = "Production";

        [Title("Sets Logging for the agent")]
        [Description("Default is Warning. Supported values: Critical, Error, Warning, Info, Debug, Trace and None")]
        [AllowVariable]
        public string LogLevel { get; internal set; } = "Warning";
    }
}
