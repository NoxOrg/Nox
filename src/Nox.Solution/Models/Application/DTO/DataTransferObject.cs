using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution
{

    [AdditionalProperties(false)]
    public class DataTransferObject
    {
        [Required]
        [Title("The name of the DTO. Contains no spaces.")]
        [Description("The name of the DTO. It should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = null!;

        [Title("The description of the DTO.")]
        [Description("A phrase describing the DTO and what it represents in the real world.")]
        public string? Description { get; internal set; }

        [Required]
        [Title("The attributes of which the DTO is comprised.")]
        [Description("One or more attributes describing the composition of the DTO.")]
        [AdditionalProperties(false)]
        public IReadOnlyList<NoxSimpleTypeDefinition> Attributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
    }
}