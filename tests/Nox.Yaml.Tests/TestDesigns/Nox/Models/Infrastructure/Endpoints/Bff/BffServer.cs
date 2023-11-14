using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("Details pertaining to the BFF server settings in a Nox solution.")]
[Description("Defines settings pertinent to a BFF (Backend for Frontend) server here. These include name, serverUri, Port, connection credentials and provider (e.g. Blazor).")]
[AdditionalProperties(false)]
public class BffServer : ServerBase
{
    [Required]
    [Title("The BFF server provider.")]
    [Description("The provider used for this BFF (Backend for Frontend) server. Examples include Blazor.")]
    [AdditionalProperties(false)]
    public BffServerProvider Provider { get; internal set; } = BffServerProvider.Blazor;
}