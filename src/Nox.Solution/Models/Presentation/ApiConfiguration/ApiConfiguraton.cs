using Nox.Yaml;
using Nox.Yaml.Attributes;
using System;
using System.Collections.Generic;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for default endpoints pertaining to a Nox solution.")]
[Description("Define default endpoints pertinent to a Nox solution here. These include endpoints for API and BFF servers.")]
[AdditionalProperties(false)]
public class ApiConfiguration : YamlConfigNode<NoxSolution,Presentation>
{
    [Title("The api route prefix, defaults to api/v1 or to api/vMajor({Solution.Version}) if Version is set in the root of the Solution.")]
    [Description(@"Defines the prefix for all Api routes end points.")]
    public string ApiRoutePrefix { get; internal set; } = null!;

    public IReadOnlyList<ApiRouteMapping> ApiRouteMappings { get; internal set; } = Array.Empty<ApiRouteMapping>();
    
    public override void SetDefaults(NoxSolution topNode, Presentation parentNode, string yamlPath)
    {
        DefaultApiRoutePrefix(topNode);
    }

    private void DefaultApiRoutePrefix(NoxSolution topNode)
    {
        if (string.IsNullOrWhiteSpace(ApiRoutePrefix)) ApiRoutePrefix = null!;

        ApiRoutePrefix ??= "/api/v" + new Version(topNode.Version).Major;

        ApiRoutePrefix = SanitizeRoutePrefix(ApiRoutePrefix);
    }

    /// <summary>
    /// Sanitizes the route prefix by stripping trailing forward slashes and adding leading slashes.
    /// </summary>
    /// <param name="routePrefix">Route prefix to sanitize.</param>
    /// <returns>Sanitized route prefix.</returns>
    private static string SanitizeRoutePrefix(string routePrefix)
    {
        if(string.IsNullOrEmpty(routePrefix))
        {
            return string.Empty;
        }
        if (routePrefix == "/")
        {
            return string.Empty;
        }
        if (!routePrefix!.StartsWith("/"))
        {
            return "/" + routePrefix;
        }
        if (routePrefix!.EndsWith("/"))
        {
            return routePrefix.TrimEnd('/');
        }
        return routePrefix;
    }
}