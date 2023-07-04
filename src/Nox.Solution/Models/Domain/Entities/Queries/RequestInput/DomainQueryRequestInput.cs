using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Defines the input request parameters for a domain query")]
    [Description("Specify the input properties that will comprise the domainquery.The ordered parameters that forms the input for the request query. Can contain simple or complex types")]
    [AdditionalProperties(false)]
    public class DomainQueryRequestInput : NoxComplexTypeDefinition
    {
        
    }
}
