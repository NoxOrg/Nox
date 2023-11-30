using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using Nox.Solution;

namespace Nox.Lib;

public class NoxApiMiddleware
{
    private readonly PathString _apiPrefix;

    private readonly RequestDelegate _next;

    private readonly Dictionary<string, List<RouteMatcher>> _matchers = new();

    public NoxApiMiddleware(RequestDelegate next, NoxSolution solution)
    {
        _next = next;

        _apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix;

        foreach (var route in solution.Presentation.ApiConfiguration.ApiRouteMappings)
        {
            if (!_matchers.TryGetValue(route.HttpVerbString, out List<RouteMatcher>? matchers))
            {
                matchers = new List<RouteMatcher>();
                _matchers.Add(route.HttpVerbString, matchers);
            }

            matchers.Add(new RouteMatcher(route, _apiPrefix));
        }
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestPath = context.Request.Path;

        if (!requestPath.HasValue)
        {
            await _next(context);
            return;
        }

        if (!requestPath.StartsWithSegments(_apiPrefix))
        {
            await _next(context);
            return;
        }

        if (!_matchers.TryGetValue(context.Request.Method, out List<RouteMatcher>? matchers))
        {
            await _next(context);
            return;
        }

        RouteValueDictionary? urlParameters = null;

        ApiRouteMapping? apiRoute = null;

        foreach (var matcher in matchers)
        {
            urlParameters = matcher.Match(requestPath);

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

        var translatedTarget = apiRoute.TargetUrl;

        foreach (var kvp in context.Request.Query)
        {
            if (translatedTarget.Contains($"{{{kvp.Key}}}"))
            {
                translatedTarget = translatedTarget.Replace($"{{{kvp.Key}}}", kvp.Value.ToString());
            }
        }

        foreach (var kvp in urlParameters)
        {
            if (translatedTarget.Contains($"{{{kvp.Key}}}"))
            {
                translatedTarget = translatedTarget.Replace($"{{{kvp.Key}}}", kvp.Value?.ToString());
            }
        }

        foreach (var input in apiRoute.RequestInput)
        {
            if (input.Default is not null && translatedTarget.Contains($"{{{input.Name}}}"))
            {
                translatedTarget = translatedTarget.Replace($"{{{input.Name}}}", input.Default.ToString());
            }
        }

        if (translatedTarget.Contains($"{{$RouteQuery}}"))
        {
            translatedTarget = translatedTarget.Replace($"{{$RouteQuery}}", context.Request.QueryString.ToString().TrimStart('?'));
        }

        var parts = translatedTarget.Split('?', 2);

        context.Request.Path = new PathString(_apiPrefix + parts[0]);

        if (parts.Length > 1)
        {
            context.Request.QueryString = new QueryString("?" + parts[1]);
        }
        else
        {
            context.Request.QueryString = new QueryString();
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