using Nox.Types;
using Nox.Yaml;
using Nox.Yaml.Attributes;
using System;
using System.Collections.Generic;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Definition and mapping of API endpoints to internal OData routes.")]
[Description("Defines custom endpoints for this solution and how they map to generated internal OData endpoints.")]
[AdditionalProperties(false)]
public class ApiRouteMapping : YamlConfigNode<NoxSolution,ApiConfiguration>
{
    [Required]
    [Title("The name of the API route. Contains no spaces.")]
    [Description("Assign a descriptive name to the attribute. Should be a descriptive noun and be unique within a solution. PascalCase recommended.")]
    [Pattern(@"^[^\s]*$")]
    public string Name { get; internal set; } = null!;

    [Title("The description of the API route.")]
    [Description("A descriptive phrase that explains the nature and function of this API route mapping.")]
    public string? Description { get; internal set; }

    [Required]
    [Title("The Http verb to map.")]
    [Description("Valid verbs are get, put, post, patch and delete.")]
    public HttpVerb HttpVerb { get; internal set; } = HttpVerb.Get;
    
    [Required]
    [Title("The inbound API route. Contains no spaces.")]
    [Description("Specifies the inbound endpoint for this route mapping. Must be a valid Uri. Parameters specified within '{}' characters, eg. /Customers/HighestRanked?limit={Count}.")]
    [Pattern(@"^[^\s]*$")]
    public string Route { get; internal set; } = null!;
    
    [Required]
    [Title("The outbound API route to map the . Contains no spaces.")]
    [Description("Specifies the outbound URL endpoint for this route mapping. Must be a valid Uri. The input parameters can be mapped to the output, eg. /Customers?$orderByDesc=Rating&$top={Count}")]
    [Pattern(@"^[^\s]*$")]
    public string TargetUrl { get; internal set; } = null!;

    [Title("Specify default for parameters that are omitted in the Route.")]
    [Description("Specifies default values for all parameters that are not specified explicitly on the input route.")]
    public IReadOnlyDictionary<string, object> ParameterDefaults { get; internal set; } = new Dictionary<string, object>();

    [Required]
    [AdditionalProperties(false)]
    public NoxComplexTypeDefinition ResponseOutput { get; internal set; } = default!;

    public override void SetDefaults(NoxSolution topNode, ApiConfiguration parentNode, string yamlPath)
    {
        Route = SanitizeEndpoint(Route);
        TargetUrl = SanitizeEndpoint(TargetUrl);
    }

    private static string SanitizeEndpoint(string route)
    {
        if (string.IsNullOrEmpty(route))
        {
            return string.Empty;
        }
        if (route == "/")
        {
            return string.Empty;
        }
        if (!route.StartsWith("/"))
        {
            return "/" + route;
        }
        if (route.EndsWith("/"))
        {
            return route.TrimEnd('/');
        }
        return route;
    }

}

