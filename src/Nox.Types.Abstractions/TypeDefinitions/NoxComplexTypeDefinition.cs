using Nox.Types.Schema;

namespace Nox.Types;

[GenerateJsonSchema("dto")]
[Title("A complex nox type.")]
[Description("Defines a complex nox type that includes simple types, objects, arrays and collections.")]
[AdditionalProperties(false)]
public class NoxComplexTypeDefinition : NoxSimpleTypeDefinition
{

    #region TypeOptions

    [IfEquals("Type", NoxType.Object)]
    public ObjectTypeOptions? ObjectTypeOptions { get; internal set; }

    [IfEquals("Type", NoxType.Collection)]
    public ArrayTypeOptions? CollectionTypeOptions { get; internal set; }

    [IfEquals("Type", NoxType.Array)]
    public ArrayTypeOptions? ArrayTypeOptions { get; internal set; }
    
    #endregion
}