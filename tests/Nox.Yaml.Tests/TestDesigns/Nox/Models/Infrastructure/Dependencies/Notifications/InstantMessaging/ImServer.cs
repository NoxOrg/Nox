using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("The definition namespace for the IM server used in a Nox solution.")]
[Description("Specify properties pertinent to the solution IM (Instant Messaging) server here. Examples include name, serverUri, Port, connection credentials and provider")]
[AdditionalProperties(false)]
public class ImServer : ServerBase
{
    [Required]
    [Title("The IM server provider.")]
    [Description("The provider used for this IM server. Examples include WhatsApp and Telegram.")]
    [AdditionalProperties(false)]
    public ImServerProvider Provider { get; internal set; } = ImServerProvider.WhatsApp;
}