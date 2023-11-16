using Humanizer;
using Nox.Solution.Extensions;
using Nox.Types;
using Nox.Yaml.Attributes;
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

    public TypeUserInterface? UserInterface { get; internal set; }

    [YamlIgnore] 
    public string EntityPlural => Entity.Pluralize();

    [Title("Define the Entity on this relationship side contains a Navigation Property to the related Entity.")]
    [Description("Default is true, allows to navigate from this Entity to the related Entity, and generates all endpoints to manage the Entity relaionships, including enabling ODataQueries for related entities.")]
    public bool CanNavigate { get; internal set; } = true;

    [YamlIgnore]
    public bool IsForeignKeyOnThisSide => EntityRelationshipExtensions.IsForeignKeyOnThisSide(this);

    /// <summary>
    /// This relationship is a zero or one relation to the other entity
    /// </summary>
    [YamlIgnore]
    public bool WithSingleEntity => EntityRelationshipExtensions.WithSingleEntity(this);

    /// <summary>
    /// This relationship is a zero or one relation to the other entity
    /// </summary>
    [YamlIgnore]
    public bool WithMultiEntity => EntityRelationshipExtensions.WithMultiEntity(this);

    /// <summary>
    /// Get referenced primitive type of relationship
    /// </summary>
    [YamlIgnore]
    public string ForeignKeyPrimitiveType => EntityRelationshipExtensions.GetPrimitiveForeignKeyType(this);

    [YamlIgnore]
    public virtual RelatedEntityInfo Related { get; internal set; } = new();
}

public class RelatedEntityInfo
{
    public Entity Entity { get; internal set; } = default!;
    public virtual EntityRelationship EntityRelationship { get; internal set; } = default!; 
}