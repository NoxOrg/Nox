using System.Collections.Generic;
using Nox.Types;
using Nox.Types.Schema;

namespace Nox.Solution;

[Title("Definition namespace for a web API integration source.")]
[Description("This section specified attributes related to an integration source of type web API. Attributes include the route, response format and http verb.")]
[AdditionalProperties(false)]
public class IntegrationSourceWebApiOptions
{
    [Title("The path component for the request URI.")]
    [Description("The path component for the request URI, e.g. '/myPath' in http://localhost:8081/myPath?myParameter=123.")]
    public string Route { get; set; } = string.Empty;

    [Title("The Http exchange format.")]
    [Description("The format of the Http response data payload, eg. Json, XML.")]
    public IntegrationWebApiRequestResponseFormat ExchangeFormat { get; set; } = IntegrationWebApiRequestResponseFormat.Json;

    [Title("The Http request verb.")]
    [Description("The relevant verb detailing the Http request type, i.e. GET, POST, etc.")]
    public IntegrationSourceHttpVerb HttpVerb { get; set; } = IntegrationSourceHttpVerb.Get;
    
    [Required]
    [Title("The attributes of the source response.")]
    [Description("One or more attributes describing the composition of the source response message.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<NoxSimpleTypeDefinition> ResponseAttributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
}
