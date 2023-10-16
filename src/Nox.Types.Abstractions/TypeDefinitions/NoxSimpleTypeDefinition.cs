using Nox.Types.Schema;
using System.Diagnostics;

namespace Nox.Types;

[GenerateJsonSchema("type")]
[Title("Definition namespace for Nox simple types.")]
[Description("Nox simple types definition used throughout Nox.Solution project.")]
[AdditionalProperties(false)]
[DebuggerDisplay("{Name}, type: {Type} required: {IsRequired}")]
public class NoxSimpleTypeDefinition
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

    [IfEquals(nameof(Type), NoxType.Area)]
    public AreaTypeOptions? AreaTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Date)]
    public DateTypeOptions? DateTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.DateTime)]
    public DateTimeTypeOptions? DateTimeTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.DateTimeDuration)]
    public DateTimeDurationTypeOptions? DateTimeDurationTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.DateTimeRange)]
    public DateTimeRangeTypeOptions? DateTimeRangeTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Distance)]
    public DistanceTypeOptions? DistanceTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.EncryptedText)]
    public EncryptedTextTypeOptions? EncryptedTextTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.EntityId)]
    public EntityIdTypeOptions? EntityIdTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Enumeration)]
    public EnumerationTypeOptions? EnumerationTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.File)]
    public FileTypeOptions? FileTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Formula)]
    public FormulaTypeOptions? FormulaTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.HashedText)]
    public HashedTextTypeOptions? HashedTextTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Image)]
    public ImageTypeOptions? ImageTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Json)]
    public JsonTypeOptions? JsonTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Length)]
    public LengthTypeOptions? LengthTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Markdown)]
    public MarkdownTypeOptions? MarkdownTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Money)]
    public MoneyTypeOptions? MoneyTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Nuid)]
    public NuidTypeOptions? NuidTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Number)]
    public NumberTypeOptions? NumberTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Password)]
    public PasswordTypeOptions? PasswordTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Percentage)]
    public PercentageTypeOptions? PercentageTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Temperature)]
    public TemperatureTypeOptions? TemperatureTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Text)]
    public TextTypeOptions? TextTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Time)]
    public TimeTypeOptions? TimeTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.TranslatedText)]
    public TranslatedTextTypeOptions? TranslatedTextTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.User)]
    public UserTypeOptions? UserTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.VatNumber)]
    public VatNumberTypeOptions? VatNumberTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Volume)]
    public VolumeTypeOptions? VolumeTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Weight)]
    public WeightTypeOptions? WeightTypeOptions { get; set; }

    [IfEquals(nameof(Type), NoxType.Year)]
    public YearTypeOptions? YearTypeOptions { get; set; }

    #endregion TypeOptions

    [Title("Is the attribute required? Boolean value.")]
    [Description("Indicates whether this attribute is required within the collection. Defaults to false.")]
    public bool IsRequired { get; internal set; } = false;

    public TypeUserInterface? UserInterface { get; internal set; }

    [Title("Is this attribute readonly? Boolean value.")]
    [Description("Indicates whether this attribute is readonly. Defaults to false.")]
    public bool IsReadonly { get; internal set; } = false;

    public NoxSimpleTypeDefinition ShallowCopy()
    {
        return (NoxSimpleTypeDefinition)MemberwiseClone();
    }
}