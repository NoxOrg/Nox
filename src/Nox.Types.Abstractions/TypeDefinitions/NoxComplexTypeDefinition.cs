using Nox.Yaml.Attributes;

namespace Nox.Types;

[GenerateJsonSchema("complexType")]
[Title("A complex nox type.")]
[Description("Defines a complex nox type that includes simple types, objects, arrays and collections.")]
[AdditionalProperties(false)]
public class NoxComplexTypeDefinition : NoxSimpleTypeDefinition
{

    #region TypeOptions

    [IfEquals(nameof(Type), NoxType.Object)]
    public ObjectTypeOptions? ObjectTypeOptions { get; internal set; }

    [IfEquals(nameof(Type), NoxType.Collection)]
    public ArrayTypeOptions? CollectionTypeOptions { get; internal set; }

    [IfEquals(nameof(Type), NoxType.Array)]
    public ArrayTypeOptions? ArrayTypeOptions { get; internal set; }
    
    #endregion
}