using Microsoft.AspNetCore.Http;
using Nox.Application.Services;
using Nox.Solution;
using System.Buffers;

namespace Nox.Middlewares;

/// <summary>
/// Routes nested entity relationships request to last nested relationship
/// Using <see cref="ApiConfiguration.ApiGenerateRelatedEndpointsMaxDepth"/> and <see cref="EntityRelationship.ApiGenerateRelatedEndpoint"/> to automatically
/// routing, example: routes Entity/Key/RelatedEntity1/Key/.../RelatedEntityN/Key/ to /RelatedEntityN-1/Key/RelatedEntityN/Key/
/// </summary>
internal class RelatedEntityRoutingMiddleware
{
    /// <summary>
    /// HttpContext Item that defines if this middleware re routed the request
    /// </summary>
    public const string RoutedBy = "RelatedEntityRoutingMiddlewareRoutedBy";
    internal static bool IsApplicable(NoxSolution solution)
    {
        return
            solution.Presentation.ApiConfiguration.ApiGenerateRelatedEndpointsMaxDepth > 1 &&
            solution.Domain!.Entities.Any(entity =>
                entity.Relationships.Any(r => r.ApiGenerateRelatedEndpoint || r.ApiGenerateReferenceEndpoint)
            );
    }

    private readonly RequestDelegate _next;
    private const string _refSegment = "$ref";
    private const int _minSegmentCount = 5;
    private readonly int _maxSegmentsCount;
    private readonly PathString _apiPrefix;
    /// <summary>
    /// Index to remove api prefix from the requested path
    /// </summary>
    private readonly int _apiPrefixSliceIndex;
    private readonly int _endpointsMaxDepth;
    private readonly IRelationshipChainValidator _relationshipChainValidator;
    private readonly HashSet<string> _entitiesPluralNamesLowerCase;
    private readonly Dictionary<string, string> _navigationNameToEntityPluralName = new(StringComparer.OrdinalIgnoreCase);
    private readonly IReadOnlySet<(string entityName, string navigationName)> _canRedirect;
    private readonly ArrayPool<string> poolOfStrings = ArrayPool<string>.Shared;

    public RelatedEntityRoutingMiddleware(RequestDelegate next, NoxSolution solution, IRelationshipChainValidator relationshipChainValidator)
    {
        _relationshipChainValidator = relationshipChainValidator;

        _next = next;

        _apiPrefix = solution.Presentation.ApiConfiguration.ApiRoutePrefix + "/";

        _apiPrefixSliceIndex = _apiPrefix.Value!.Length; //start after prefix - e.g. /api/v1/

        _endpointsMaxDepth = solution.Presentation.ApiConfiguration.ApiGenerateRelatedEndpointsMaxDepth;

        _maxSegmentsCount = _endpointsMaxDepth * 2 + 3; //Entity + Key + $ref + 2*RelatedEntities Max Depth

        _entitiesPluralNamesLowerCase = solution.Domain!.Entities.Select(e => e.PluralName.ToLower()).ToHashSet();


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
        var canRedirect = new HashSet<(string entityName, string navigationName)>();
        foreach (var entity in solution.Domain!.Entities)
        {
            foreach (var relationship in entity.Relationships)
            {
                var navigationName = entity.GetNavigationPropertyName(relationship);
                if (!_navigationNameToEntityPluralName.ContainsKey(navigationName))
                {
                    _navigationNameToEntityPluralName[navigationName] = relationship.EntityPlural;
                }

                if (relationship.ApiGenerateRelatedEndpoint || relationship.ApiGenerateReferenceEndpoint)
                {
                    canRedirect.Add((entity.PluralName.ToLower(), navigationName.ToLower()));
                }
            }
        }
        _canRedirect = canRedirect;

    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestPath = context.Request.Path;

        if (!requestPath.HasValue)
        {
            await _next(context);
            return;
        }

        if (CanRedirectRequest(requestPath, out string redirectPath))
        {
            context.Request.Path = redirectPath;
            context.Items[RoutedBy] = true;
        }
        await _next(context);
    }


    private bool CanRedirectRequest(string path, out string redirectPath)
    {
        redirectPath = string.Empty;
        path = path.ToLower();
        var segments = poolOfStrings.Rent(_maxSegmentsCount);
        try
        {
            ReadOnlySpan<char> pathSpan = path.AsSpan();

            int startIndex = _apiPrefixSliceIndex;
            int count = 0;
            var segmentsCount = 0;

            while (startIndex < pathSpan.Length)
            {
                if (segmentsCount == _maxSegmentsCount)
                {
                    return false;
                }
                var currentPath = pathSpan.Slice(startIndex);
                int slashIndex = currentPath.IndexOf('/');
                if (slashIndex == -1)
                {
                    var newSegment = currentPath.ToString();
                    if (!IsSegmentValid(newSegment, count, isLast: true))
                        return false;
                    segments[segmentsCount++] = newSegment;
                    break;
                }
                else
                {
                    var newSegment = pathSpan.Slice(startIndex, slashIndex).ToString();
                    if (!IsSegmentValid(newSegment, count++))
                        return false;
                    segments[segmentsCount++] = newSegment;
                    startIndex += slashIndex + 1;
                }
            }

            if (!IsDepthAndCountValid(segments, segmentsCount))
                return false;

            if (!IsFirstPairValid(segments[0], segments[2]))
                return false;

            if (!IsChainValid(segments, segmentsCount))
                return false;

            redirectPath = BuildRedirectToPath(segments, segmentsCount);
            return true;
        }
        finally
        {
            poolOfStrings.Return(segments);
        }
    }

    private bool IsSegmentValid(string segment, int index, bool isLast = false)
    {
        if (isLast && segment.Equals(_refSegment))
            return true;
        else if (index == 0)
            return _entitiesPluralNamesLowerCase.Contains(segment);
        else if (index % 2 == 0)
            return _navigationNameToEntityPluralName.ContainsKey(segment);
        else
            return true; //even segments are valid by default
    }

    private bool IsDepthAndCountValid(IReadOnlyList<string> segments, int segmentCount)
    {
        var count = segmentCount;
        if (segments[count - 1].Equals(_refSegment))
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

    private bool IsChainValid(IReadOnlyList<string> segments, int segmentCount)
    {
        var count = segmentCount;
        if (segments[count - 1].Equals(_refSegment))
            count--;

        var navigationPropertiesCount = (count - 3) / 2; //remove the first pair and last segment that we don't need to validate
        var navigationProperties = new (string navigationName, string navigationKey)[navigationPropertiesCount];

        for (int i = 2, j = 0; i < count - 1 && j < navigationPropertiesCount; i += 2, j++)
        {
            navigationProperties[j] = (navigationName: segments[i], navigationKey: segments[i + 1]);
        }

        return _relationshipChainValidator.IsValid(new RelationshipChain(segments[0], segments[1], navigationProperties));
    }

    private PathString BuildRedirectToPath(IReadOnlyList<string> segments, int segmentsCount)
    {
        var lastSegment = string.Empty;
        int count = segmentsCount;

        if (segments[segmentsCount - 1].Equals(_refSegment))
        {
            count--;
            lastSegment = _refSegment;
        }

        bool isEvenCount = count % 2 != 0;
        int start = isEvenCount ? count - 3 : count - 4;


        if (isEvenCount)
        {
            return new PathString($"{_apiPrefix}{_navigationNameToEntityPluralName[segments[start]]}/{segments[count - 2]}/{segments[count - 1]}/{lastSegment}");
        }
        else
        {
            return new PathString($"{_apiPrefix}{_navigationNameToEntityPluralName[segments[start]]}/{segments[count - 3]}/{segments[count - 2]}/{segments[count - 1]}/{lastSegment}");
        }
    }
}
