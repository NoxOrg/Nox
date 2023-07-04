using Json.Schema.Generation;

namespace Nox.Solution
{
    public class EntityTypeOptions : DefinitionBase
    {
        [Required]
        public string Entity { get; internal set; } = null!;
    }
}