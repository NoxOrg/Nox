using Microsoft.AspNetCore.Http;
using Nox.Lib;
using Nox.Solution;

namespace Nox.Middlewares;

internal class RelatedEndpointsMiddleware
{
    private readonly PathString _apiPrefix;

    private readonly RequestDelegate _next;

    private readonly IEnumerable<string> _entitiesPluralNames;

    private readonly IEnumerable<string> _navigationNames;

    public RelatedEndpointsMiddleware(RequestDelegate next, NoxSolution solution)
    {
        _next = next;

        _apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix;

        if (solution.Domain is null)
        {
            _entitiesPluralNames = Array.Empty<string>();
            _navigationNames = Array.Empty<string>();
        }
        else
        {
            _entitiesPluralNames = solution.Domain.Entities.Select(e => e.PluralName).ToList();
            _navigationNames = solution.Domain.Entities
                .SelectMany(e => e.Relationships.Select(r => e.GetNavigationPropertyName(r)))
                .Distinct()
                .ToList();
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

        if (context.Request.Method == "PATCH")
        {
            var segments = ParsePath(requestPath);

            if (!ValidateSegments(segments))
            {
                await _next(context);
                return;
            }

            var newPath = BuildNewPatchPath(segments);
            context.Request.Path = newPath;
            context.Request.QueryString = context.Request.QueryString;
        }

        await _next(context);
        return;
    }


    private List<string> ParsePath(string path)
    {
        List<string> segments = new List<string>();

        if (path.StartsWith(_apiPrefix, StringComparison.OrdinalIgnoreCase))
        {
            path = path.Substring(_apiPrefix.Value!.Length);
        }

        if (path.StartsWith("/", StringComparison.Ordinal)) 
        {
            path = path.Substring(1);
        }

        ReadOnlySpan<char> pathSpan = path.AsSpan();
        int startIndex = 0;

        while (startIndex < pathSpan.Length)
        {
            int slashIndex = pathSpan.Slice(startIndex).IndexOf('/');
            if (slashIndex == -1)
            {
                segments.Add(pathSpan.Slice(startIndex).ToString());
                break;
            }
            else
            {
                segments.Add(pathSpan.Slice(startIndex, slashIndex).ToString());
                startIndex += slashIndex + 1;
            }
        }

        return segments;
    }

    private bool ValidateSegments(List<string> segments)
    {
        if (segments.Count < 3) //at least 2 entities should be present /Entity/key/RelatedEntity
            return false;

        if (!_entitiesPluralNames.Contains(segments[0], StringComparer.OrdinalIgnoreCase))
            return false;

        for (int i = 2; i < segments.Count; i += 2)
        {
            if (!_navigationNames.Contains(segments[i], StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }
        }
        return true;
    }

    private PathString BuildNewPatchPath(List<string> segments)
    {
        int count = segments.Count;
        bool isEvenCount = count % 2 != 0;

        if (isEvenCount)
        {
            return new PathString(_apiPrefix + "/" + segments[^1]);
        }
        else
        {
            return new PathString(_apiPrefix + "/" + segments[count - 2] + "/" + segments[^1]);
        }
    }
}
