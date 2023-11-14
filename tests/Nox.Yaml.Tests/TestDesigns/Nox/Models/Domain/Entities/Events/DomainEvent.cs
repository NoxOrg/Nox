using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema("dto")]
public class DomainEvent : NoxComplexTypeDefinition
{
    bool RaiseApplicationEvent { get; set; }
}