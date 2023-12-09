using Nox.Yaml;
using Nox.Yaml.Attributes;
using Nox.Yaml.Validation;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Definition and mapping of API endpoints to internal OData routes.")]
[Description("Defines custom endpoints for this solution and how they map to generated internal OData endpoints.")]
[AdditionalProperties(false)]
public class ApiRouteMapping : YamlConfigNode<NoxSolution, ApiConfiguration>
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

    public IReadOnlyList<JsonTypeDefinition> RequestInput { get; internal set; } = Array.Empty<JsonTypeDefinition>();

    public ContentBodyType RequestBodyType { get; internal set; } = ContentBodyType.None;

    [IfEquals(nameof(RequestBodyType), ContentBodyType.Json)]
    [Required]
    public JsonTypeDefinition JsonBodyType { get; internal set; } = null!;

    [Required]
    [AdditionalProperties(false)]
    public JsonTypeDefinition ResponseOutput { get; internal set; } = default!;

    [YamlIgnore]
    public string HttpVerbString { get; private set; } = null!;

    [YamlIgnore]
    public string RequestContentTypeString { get; private set; } = null!;

    [YamlIgnore]
    public string ResponseContentTypeString { get; private set; } = null!;

    public override void SetDefaults(NoxSolution topNode, ApiConfiguration parentNode, string yamlPath)
    {
        Route = SanitizeEndpoint(Route);
        TargetUrl = SanitizeEndpoint(TargetUrl);
        HttpVerbString = HttpVerbToHttpVerbString(HttpVerb);
        RequestContentTypeString = ToContentTypeString(RequestBodyType);
        ResponseContentTypeString = ToContentTypeString(ContentBodyType.Json);
    }

    public override ValidationResult Validate(NoxSolution topNode, ApiConfiguration parentNode, string yamlPath)
    {
        var result = base.Validate(topNode, parentNode, yamlPath);

        if (HttpVerb == HttpVerb.Get && JsonBodyType != null)
        {
            result.AddError(nameof(HttpVerb),$"Endpoint [{Name}] with verb [{HttpVerb}] can not define a value for [{nameof(JsonBodyType)}].");
        }
        return result;
    }

    private static string HttpVerbToHttpVerbString(HttpVerb verb)
    {
        return verb switch
        {
            HttpVerb.Get => "GET",
            HttpVerb.Post => "POST",
            HttpVerb.Put => "PUT",
            HttpVerb.Delete => "DELETE",
            HttpVerb.Patch => "PATCH",
            _ => throw new NotImplementedException()
        };
    }
    private static string ToContentTypeString(ContentBodyType bodyType)
    {
        return bodyType switch
        {
            ContentBodyType.Json => "application/json",
            ContentBodyType.Xml => "application/xml",
            ContentBodyType.Html => "text/html",
            ContentBodyType.Csv => "text/csv",
            _ => "application/octet-stream",
        };
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

