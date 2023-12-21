using Microsoft.AspNetCore.Http;
using Nox.Solution;
using System.Collections.Generic;

namespace Nox.Middlewares;

internal class RelatedEndpointsMiddleware
{
    private readonly PathString _apiPrefix;

    private readonly RequestDelegate _next;

    private readonly HashSet<string> _entitiesPluralNames;

    private readonly HashSet<string> _navigationNames;

    public RelatedEndpointsMiddleware(RequestDelegate next, NoxSolution solution)
    {
        _next = next;

        _apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix;
        
        _entitiesPluralNames = solution.Domain!.Entities.Select(e => e.PluralName).ToHashSet();
        _navigationNames = solution.Domain!.Entities
            .SelectMany(e => e.Relationships.Select(r => e.GetNavigationPropertyName(r)))
            .Distinct()
            .ToHashSet();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestPath = context.Request.Path;

        if (!requestPath.HasValue)
        {
            await _next(context);
            return;
        }

        if (HttpMethods.IsPatch(context.Request.Method))
        {
            if(!TryParseAndValidatePath(requestPath, out var segments))
            {
                await _next(context);
                return;
            }

            var newPath = BuildNewPatchPath(segments);
            context.Request.Path = newPath;
        }

        await _next(context);
        return;
    }


    private bool TryParseAndValidatePath(string path, out List<string> segments)
    {
        segments = new List<string>();

        ReadOnlySpan<char> pathSpan = path.AsSpan();
        int startIndex = _apiPrefix.Value!.Length + 1; //start after prefix+slash - e.g. /api/v1/
        int count = 0;

        while (startIndex < pathSpan.Length)
        {
            int slashIndex = pathSpan.Slice(startIndex).IndexOf('/');
            if (slashIndex == -1)
            {
                var newSegment = pathSpan.Slice(startIndex).ToString();
                if (!IsValidSegment(newSegment, count++))
                    return false;
                segments.Add(newSegment);
                break;
            }
            else
            {
                var newSegment = pathSpan.Slice(startIndex, slashIndex).ToString();
                if (!IsValidSegment(newSegment, count++))
                    return false;
                segments.Add(newSegment);
                startIndex += slashIndex + 1;
            }
        }
        return true;
    }

    private bool IsValidSegment(string segment, int index)
    {
        if (index == 0)
            return _entitiesPluralNames.Contains(segment, StringComparer.OrdinalIgnoreCase);
        else if (index % 2 == 0)
            return _navigationNames.Contains(segment, StringComparer.OrdinalIgnoreCase);
        else
            return true; //even segments are valid by default
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
