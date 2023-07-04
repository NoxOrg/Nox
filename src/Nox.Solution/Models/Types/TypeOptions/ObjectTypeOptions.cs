using Json.Schema.Generation;
using System.Collections.Generic;

namespace Nox.Solution
{
    public class ObjectTypeOptions : DefinitionBase
    {
        [Required] 
        public IReadOnlyList<NoxSimpleTypeDefinition> Attributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
    }
}