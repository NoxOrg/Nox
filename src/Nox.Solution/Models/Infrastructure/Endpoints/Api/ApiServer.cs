using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Details pertaining to the API server settings in a Nox solution.")]
    [Description("Defines settings pertinent to an API server here. These include name, serverUri, Port, connection credentials and provider (OData, gRPC, GraphQL and AttributeRouting.")]
    [AdditionalProperties(false)]
    public class ApiServer: ServerBase
    {
        [Required]
        [Title("The API server provider.")]
        [Description("The provider used for this API server. Examples include OData, gRPC, GraphQL and others.")]
        [AdditionalProperties(false)]
        public ApiServerProvider Provider { get; internal set; } = ApiServerProvider.OData;
    }
}