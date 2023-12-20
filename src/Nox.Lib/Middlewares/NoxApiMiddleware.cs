using Microsoft.AspNetCore.Http;
using Nox.Solution;

namespace Nox.Lib;

public class NoxApiMiddleware
{
    private readonly PathString _apiPrefix;

    private readonly RequestDelegate _next;

    private readonly Dictionary<string, List<RouteMatcher>> _verbMatchers = new();

    public NoxApiMiddleware(RequestDelegate next, NoxSolution solution)
    {
        _next = next;

        _apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix;

        foreach (var route in solution.Presentation.ApiConfiguration.ApiRouteMappings)
        {
            if (!_verbMatchers.TryGetValue(route.HttpVerbString, out List<RouteMatcher>? matchers))
            {
                matchers = new List<RouteMatcher>();
                _verbMatchers.Add(route.HttpVerbString, matchers);
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

        if (!_verbMatchers.TryGetValue(context.Request.Method, out List<RouteMatcher>? matchers))
        {
            await _next(context);
            return;
        }

        var apiRouteMatcher = matchers.FirstOrDefault(m => m.Match(context.Request));

        if (apiRouteMatcher == null)
        {
            await _next(context);
            return;
        }

        var translatedTarget = apiRouteMatcher.TransformTo(apiRouteMatcher.ApiRoute.TargetUrl);


        if (translatedTarget.Contains($"&{{$RouteQuery}}"))
        {
            translatedTarget = translatedTarget.Replace($"{{$RouteQuery}}", 
                context.Request.QueryString.ToString().TrimStart('?'));
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
