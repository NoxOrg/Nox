using Nox.Yaml.Attributes;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("The definition namespace for notification server(s) used in a Nox solution.")]
[Description("Specify properties pertinent to notification servers deployed within a Nox solution here. Examples include email, SMS and IM (Instant Messaging) servers.")]
[AdditionalProperties(false)]
public class Notifications
{
    public EmailServer? EmailServer { get; internal set; }

    public SmsServer? SmsServer { get; internal set; }

    public ImServer? ImServer { get; internal set; }
}