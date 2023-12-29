using Microsoft.AspNetCore.Http;
using Nox.Solution;
using System.Text;

namespace Nox.Middlewares;

internal class RelatedEndpointsMiddleware
{
    private const string _refSegment = "$ref";
    private const int _minSegmentCount = 5;
 
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

        _apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix + "/";

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

        if (!TryParseAndValidatePath(out var segments, requestPath))
        {
            await _next(context);
            return;
        }

        context.Request.Path = BuildNewPath(segments);        

        await _next(context);
        return;
    }


    private bool TryParseAndValidatePath(out List<string> segments, string path)
    {
        path = path.ToLower();

        segments = new List<string>();

        ReadOnlySpan<char> pathSpan = path.AsSpan();
        int startIndex = _apiPrefix.Value!.Length; //start after prefix - e.g. /api/v1/
        int count = 0;

        while (startIndex < pathSpan.Length)
        {
            int slashIndex = pathSpan.Slice(startIndex).IndexOf('/');
            if (slashIndex == -1)
            {
                var newSegment = pathSpan.Slice(startIndex).ToString();
                if (!IsSegmentValid(newSegment, count++, isLast: true))
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

        if (!IsDepthAndCountValid(segments))
            return false;

        if (!IsFirstPairValid(segments[0], segments[2]))
            return false;

        return true;
    }

    private bool IsSegmentValid(string segment, int index, bool isLast = false)
    {
        if (isLast && segment.Equals(_refSegment, StringComparison.OrdinalIgnoreCase))
            return true;
        else if (index == 0)
            return _entitiesPluralNames.Contains(segment, StringComparer.OrdinalIgnoreCase);
        else if (index % 2 == 0)
            return _navigationNameToEntityPluralName.ContainsKey(segment);
        else
            return true; //even segments are valid by default
    }

    private bool IsDepthAndCountValid(List<string> segments)
    {
        var count = segments.Count;
        if (segments.Last().Equals(_refSegment, StringComparison.OrdinalIgnoreCase))
            count--;

        if (count < _minSegmentCount)
            return false;

        var depth = (int)Math.Ceiling((double)count / 2) - 1;
        return depth <= _endpointsMaxDepth;
    }

    private bool IsFirstPairValid(string entityName, string navigationName)
    {
        return _canRedirect.Contains((entityName, navigationName));
    }

    private PathString BuildNewPath(List<string> segments)
    {
        var lastSegment = string.Empty;
        if (segments.Last().Equals(_refSegment, StringComparison.OrdinalIgnoreCase))
        {
            segments.RemoveAt(segments.Count - 1);
            lastSegment = _refSegment;
        }

        int count = segments.Count;
        bool isEvenCount = count % 2 != 0;
        int start = isEvenCount ? count - 3 : count - 4;

        var pathBuilder = new StringBuilder(_apiPrefix);
        pathBuilder.Append(_navigationNameToEntityPluralName[segments[start]]);
        pathBuilder.Append('/');

        if (isEvenCount)
        {
            pathBuilder.Append($"{segments[count - 2]}/{segments[count - 1]}/{lastSegment}");
        }
        else
        {
            pathBuilder.Append($"{segments[count - 3]}/{segments[count - 2]}/{segments[count - 1]}/{lastSegment}");
        }

        return new PathString(pathBuilder.ToString());
    }
}
