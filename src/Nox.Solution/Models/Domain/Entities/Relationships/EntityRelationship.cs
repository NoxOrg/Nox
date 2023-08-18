using Humanizer;
using Nox.Solution.Extensions;
using Nox.Types.Schema;
using YamlDotNet.Serialization;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Defines a one way relationship to another entity.")]
[Description("Defines a one way relationship to another entity. It is required to define the reverse relationship on the target entity.")]
[AdditionalProperties(false)]
public class EntityRelationship : DefinitionBase
{
    [Required]
    [Title("The name of the relationship. Contains no spaces.")]
    [Description("The name of the relationship, usually in the format EntityRelationshipTargetEntity. Eg \"CountryHasCapitalCity\".")]
    [Pattern(@"^[^\s]*$")]
    public string Name { get; internal set; } = null!;

    [Required]
    [Title("A phrase describing the relationship with the target entity.")]
    [Description("A phrase that describes the relationship of the form <entity> <phrase> <targetEntity>. Eg. \"has capital\" like in <Country> <has capital> <City>")]
    public string Description { get; internal set; } = null!;

    [Required]
    [Title("The type/cardinality of the relationship.")]
    [Description("The cardinality (type) of relationship with the target entity, e.g. OneOrMany, ZeroOrOne, etc.")]
    public virtual EntityRelationshipType Relationship { get; internal set; } = new();

    [Required]
    [Title("The target entity that relates to this entity.")]
    [Description("The name of the target entity that this entity relates to.")]
    public string Entity { get; internal set; } = null!;

    [YamlIgnore] 
    public string EntityPlural => Entity.Pluralize();

    [Title("Determines whether this side of the relationship is exposed in the generated code and ODATA endpoints.")]
    [Description("This boolean controls whether this side of the relationship is exposed in the generated code and ODATA endpoints.")]
    public bool CanNavigate { get; internal set; } = true;

    [YamlIgnore]
    public bool ShouldGenerateForeignOnThisSide => EntityRelationshipExtensions.ShouldGenerateForeignKeyOnThisSide(this);

    [YamlIgnore]
    public bool IsManyRelationshipOnOtherSide => EntityRelationshipExtensions.IsManyRelationshipOnOtherSide(this);

    [YamlIgnore]
    public virtual RelatedEntityInfo Related { get; internal set; } = new();
}

public class RelatedEntityInfo
{
    public Entity Entity { get; internal set; } = null!;
    public virtual EntityRelationship EntityRelationship { get; internal set; } = null!;
}