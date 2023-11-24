using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using Nox.Solution;
using System.Diagnostics;

namespace Nox.Lib;

public class NoxApiMiddleware
{
    private readonly PathString _apiPrefix;

    private readonly RequestDelegate _next;

    private readonly List<RouteMatcher> _matchers = new();

    public NoxApiMiddleware(RequestDelegate next, NoxSolution solution)
    {
        _next = next;

        _apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix;

        foreach (var route in solution.Presentation.ApiConfiguration.ApiRouteMappings)
        {
            _matchers.Add(new RouteMatcher(route, _apiPrefix));
        }
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path;

        if (!path.HasValue)
        {
            await _next(context);
            return;
        }

        if (!path.StartsWithSegments(_apiPrefix))
        {
            await _next(context);
            return;
        }

        RouteValueDictionary? urlParameters = null;

        ApiRouteMapping? apiRoute = null;

        foreach (var matcher in _matchers)
        {
            urlParameters = matcher.Match(path);

            if (urlParameters != null)
            {
                apiRoute = matcher.ApiRoute;
                break;
            }
        }

        if (urlParameters == null || apiRoute == null)
        {
            await _next(context);
            return;
        }

        Debug.WriteLine(context.Request.Path.Value);

        if (!apiRoute.HttpVerbString.Equals(context.Request.Method))
        {
            await _next(context);
            return;
        }

        var translatedTarget = apiRoute.TargetUrl;

        foreach (var kvp in context.Request.Query)
        {
            translatedTarget = translatedTarget.Replace($"{{{kvp.Key}}}", kvp.Value.ToString());
        }

        foreach (var kvp in urlParameters)
        {
            translatedTarget = translatedTarget.Replace($"{{{kvp.Key}}}", kvp.Value?.ToString());
        }

        foreach (var kvp in apiRoute.ParameterDefaults!)
        {
            if (kvp.Value is null) continue;

            translatedTarget = translatedTarget.Replace($"{{{kvp.Key}}}", kvp.Value.ToString());
        }

        context.Request.Headers.Add("X-Nox-Internal-ApiRouteMapping", 
            new[] { $"{context.Request.Path}?{context.Request.QueryString}" });

        var parts = translatedTarget.Split('?', 2);

        context.Request.Path = new PathString(_apiPrefix+parts[0]);

        if (parts.Length > 1)
        {
            context.Request.QueryString = new QueryString("?" + parts[1]);
        }

        await _next(context);
        return;
    }

}

internal class RouteMatcher
{

    private readonly string _template;

    private readonly TemplateMatcher _matcher;

    private readonly ApiRouteMapping _apiRoute;

    private const Int32 _slash = 47;


    public RouteMatcher(ApiRouteMapping apiRoute, string prefix)
    {
        var leadingChar = apiRoute.Route[0] == _slash ? string.Empty : "/";

        _template = $"{prefix}{leadingChar}{apiRoute.Route}";

        var template = TemplateParser.Parse(_template);

        _apiRoute = apiRoute;

        _matcher = new TemplateMatcher(template, GetDefaults(template));
    }

    internal ApiRouteMapping ApiRoute => _apiRoute;

    public RouteValueDictionary? Match(string requestPath)
    {

        var result = new RouteValueDictionary();

        if (_matcher.TryMatch(requestPath, result))
        {
            return result;
        }

        return null;

    }

    private static RouteValueDictionary GetDefaults(RouteTemplate parsedTemplate)
    {
        var result = new RouteValueDictionary();

        foreach (var parameter in parsedTemplate.Parameters)
        {
            if (parameter.DefaultValue is not null && parameter.Name is not null)
            {
                result.Add(parameter.Name, parameter.DefaultValue);
            }
        }

        return result;
    }
}