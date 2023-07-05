using Json.Schema.Generation;
using Nox.Types;

namespace Nox.Solution
{
    [Title("Definition namespace for Nox simple types.")]
    [Description("Nox simple types definition used throughout Nox.Solution project.")]
    [AdditionalProperties(false)]
    public class NoxSimpleTypeDefinition : DefinitionBase
    {
        [Required]
        [Title("The name of the attribute. Contains no spaces.")]
        [Description("Assign a descriptive name to the attribute. Should be a singular noun and be unique within a collection of attributes. PascalCase recommended.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = null!;

        [Title("The description of the attribute.")]
        [Description("A descriptive phrase that explains the nature and function of this attribute within a collection.")]
        public string? Description { get; internal set; }

        [Required]
        [Title("The Nox type of this attribute.")]
        [Description("Select the Nox value object type that best represents this attribute and its functional requirements within the domain.")]
        public NoxType Type { get; internal set; } = NoxType.Object;

        #region TypeOptions

        public TextTypeOptions? TextTypeOptions { get; set; }
        public NumberTypeOptions? NumberTypeOptions { get; set; }
        public MoneyTypeOptions? MoneyTypeOptions { get; set; }
        public EntityTypeOptions? EntityTypeOptions { get; set; }

        #endregion TypeOptions

        [Title("Is the attribute required? Boolean value.")]
        [Description("Indicates whether this attribute is required within the collection. Defaults to false.")]
        public bool IsRequired { get; internal set; } = false;

        public TypeUserInterface? UserInterface { get; internal set; }

        [Title("Is this attribute readonly? Boolean value.")]
        [Description("Indicates whether this attribute is readonly. Defaults to false.")]
        public bool IsReadonly { get; internal set; } = false;
    }
}