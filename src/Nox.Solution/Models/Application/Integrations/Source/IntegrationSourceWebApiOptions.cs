using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for a web API ETL source.")]
    [Description("This section specified attributes related to an ETL source of type web API. Attributes include the route, response format and http verb.")]
    [AdditionalProperties(false)]
    public class IntegrationSourceWebApiOptions
    {
        [Title("The path component for the request URI.")]
        [Description("The path component for the request URI, e.g. '/myPath' in http://localhost:8081/myPath?myParameter=123.")]
        public string Route { get; set; } = string.Empty;

        [Title("The Http response format.")]
        [Description("The format of the Http response data papyload, eg. Json, XML.")]
        public IntegrationWebApiRequestResponseFormat ResponseFormat { get; set; } = IntegrationWebApiRequestResponseFormat.Json;

        [Title("The Http request verb.")]
        [Description("The relevant verb detailing the Http request type, i.e. GET, POST, etc.")]
        public IntegrationSourceHttpVerb HttpVerb { get; set; } = IntegrationSourceHttpVerb.Get;
    }
}
