using Nox.Types;
using Nox.Yaml.Attributes;

namespace Nox.Solution.Events;

[GenerateJsonSchema("dto")]
public class DomainEvent: NoxComplexTypeDefinition
{
    bool RaiseApplicationEvent { get; set; }
}