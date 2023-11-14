using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("The definition namespace for the SMS server used in a Nox solution.")]
[Description("Specify properties pertinent to the solution SMS server here. Examples include name, serverUri, Port, connection credentials and provider")]
[AdditionalProperties(false)]
public class SmsServer : ServerBase
{
    [Required]
    [Title("The SMS server provider.")]
    [Description("The provider used for this SMS server. Examples include Twilio and ClickSend.")]
    [AdditionalProperties(false)]
    public SmsServerProvider Provider { get; internal set; } = SmsServerProvider.ClickSend;
}