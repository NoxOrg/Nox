using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class ObjectTypeOptions : INoxTypeOptions
{
    [Required]
    public IReadOnlyList<NoxSimpleTypeDefinition> Attributes { get; set; } = new List<NoxSimpleTypeDefinition>();
}