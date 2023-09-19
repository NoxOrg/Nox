using Nox.Types;
using Nox.Types.Schema;

namespace Nox.Solution.Events;

[GenerateJsonSchema("dto")]
public class DomainEvent: NoxComplexTypeDefinition
{
    bool RaiseApplicationEvent { get; set; }
}