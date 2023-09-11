using Nox.Types.Schema;

namespace Nox.Types;

[Title("Defines the request parameters for a domain query.")]
[Description("The ordered parameters that is the input for the requested query. Can contain simple or complex types")]
[AdditionalProperties(false)]
public class ArrayTypeOptions: NoxSimpleTypeDefinition 
{
    public ObjectTypeOptions? ObjectTypeOptions { get; set; }
}