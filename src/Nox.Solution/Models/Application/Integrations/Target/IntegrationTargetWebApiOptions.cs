using System.Collections.Generic;
using Nox.Types;
using Nox.Types.Schema;

namespace Nox.Solution;

[Title("Definition namespace for a web API integration target.")]
[Description("This section specified attributes related to an integration target of type web API. Attributes include the route, request format and http verb.")]
[AdditionalProperties(false)]
public class IntegrationTargetWebApiOptions
{
    public string Route { get; set; } = string.Empty;
    public IntegrationWebApiRequestResponseFormat RequestFormat { get; set; } = IntegrationWebApiRequestResponseFormat.Json;
    public IntegrationTargetHttpVerb HttpVerb { get; set; } = IntegrationTargetHttpVerb.Post;
    
    [Required]
    [Title("The attributes of the target request.")]
    [Description("One or more attributes describing the composition of the target request message.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<NoxSimpleTypeDefinition> RequestAttributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
    
    [Title("The attributes of the target response.")]
    [Description("One or more attributes describing the composition of the target response message, if any.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<NoxSimpleTypeDefinition> ResponseAttributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
}