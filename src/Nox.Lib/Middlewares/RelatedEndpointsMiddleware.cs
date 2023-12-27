using Microsoft.AspNetCore.Http;
using Nox.Solution;

namespace Nox.Middlewares;

internal class RelatedEndpointsMiddleware
{
    private readonly RequestDelegate _next;

    private readonly PathString _apiPrefix;

    private readonly int _endpointsMaxDepth;

    private readonly HashSet<string> _entitiesPluralNames;

    private readonly Dictionary<string, string> _navigationNameToEntityPluralName = 
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    private readonly HashSet<(string entityName, string navigationName)> _canRedirect = new(); 

    public RelatedEndpointsMiddleware(RequestDelegate next, NoxSolution solution)
    {
        _next = next;

        _apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix;

        _endpointsMaxDepth = solution.Presentation.ApiConfiguration.ApiGenerateRelatedEndpointsMaxDepth;

        _entitiesPluralNames = solution.Domain!.Entities.Select(e => e.PluralName).ToHashSet();

        /*
        _navigationNameToEntityPluralName is used to map navigationName to EntityPluralName (existing controller name)
        e.g. for the following endpoints 
            /Country/Key/Capital/Key/Monuments/key
            /Country/Key/MajorCities/Key/Monuments/key
            /Continent/Key/Cities/Key/Monuments/key
            /Address/Key/City/Key/Monuments/key
        the dictionary for Cities will be the following
            Capital, Cities
            MajorCities, Cities
            Cities, Cities
            City, City
        */
        foreach (var entity in solution.Domain!.Entities)
        {
            foreach (var relationship in entity.Relationships)
            {
                var navigationName = entity.GetNavigationPropertyName(relationship);
                if (!_navigationNameToEntityPluralName.ContainsKey(navigationName))
                {
                    _navigationNameToEntityPluralName[navigationName] = relationship.EntityPlural;
                }

                if (relationship.ApiGenerateRelatedEndpoint)
                {
                    _canRedirect.Add((entity.PluralName.ToLower(), navigationName.ToLower()));
                }
            }
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


        if (HttpMethods.IsPatch(context.Request.Method))
        {
            if(!TryParseAndValidatePath(requestPath, out var segments))
            {
                await _next(context);
                return;
            }

            context.Request.Path = BuildNewPatchPath(segments);
        }

        await _next(context);
        return;
    }


    private bool TryParseAndValidatePath(string path, out List<string> segments)
    {
        path = path.ToLower();

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
                if (!IsSegmentValid(newSegment, count++))
                    return false;
                segments.Add(newSegment);
                break;
            }
            else
            {
                var newSegment = pathSpan.Slice(startIndex, slashIndex).ToString();
                if (!IsSegmentValid(newSegment, count++))
                    return false;
                segments.Add(newSegment);
                startIndex += slashIndex + 1;
            }
        }

        if (segments.Count <= 3)
            return false;

        if (!IsFirstPairValid(segments[0], segments[2]))
            return false;

        return IsDepthValid(segments);
    }

    private bool IsSegmentValid(string segment, int index)
    {
        if (index == 0)
            return _entitiesPluralNames.Contains(segment, StringComparer.OrdinalIgnoreCase);
        else if (index % 2 == 0)
            return _navigationNameToEntityPluralName.ContainsKey(segment);
        else
            return true; //even segments are valid by default
    }

    private bool IsDepthValid(List<string> segments)
    {
        var count = segments.Count;
        //if(segments.Last() == "$ref")
        //    count--;

        var depth = (int)Math.Ceiling((double)count / 2) - 1;

        return depth <= _endpointsMaxDepth;
    }

    private bool IsFirstPairValid(string entityName, string navigationName)
    {
        return _canRedirect.Contains((entityName, navigationName));
    }

    private PathString BuildNewPatchPath(List<string> segments)
    {
        int count = segments.Count;
        bool isEvenCount = count % 2 != 0;

        if (isEvenCount)
        {
            return new PathString(_apiPrefix + "/" + _navigationNameToEntityPluralName[segments[^1]]);
        }
        else
        {
            return new PathString(_apiPrefix + "/" + _navigationNameToEntityPluralName[segments[count - 2]] + "/" + segments[^1]);
        }
    }
}
