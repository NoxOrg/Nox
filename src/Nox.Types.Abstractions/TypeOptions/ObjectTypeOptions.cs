using Nox.Types.Schema;
using System.Collections.Generic;

namespace Nox.Types;

public class ObjectTypeOptions : INoxTypeOptions
{
    [Required] 
    public IReadOnlyList<NoxSimpleTypeDefinition> Attributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
}