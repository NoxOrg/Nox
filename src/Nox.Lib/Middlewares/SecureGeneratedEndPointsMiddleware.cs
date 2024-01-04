using Microsoft.AspNetCore.Http;
using Nox.Application.Services;
using Nox.Solution;
using System.Buffers;
using System.Linq;
using System.Net;

namespace Nox.Middlewares;

/// <summary>
/// Prevents to call default entity endpoints when Create, Update, Read or Delete are not enabled <see cref="EntityPersistence"/>.
/// Returns not found if not enabled
/// </summary>
internal class SecureGeneratedEndPointsMiddleware
{
    internal static bool IsApplicable(NoxSolution solution)
    {
        return
            solution.Domain!.Entities.Any(entity =>
                !(entity.Persistence?.Create.IsEnabled ?? true)
                || !(entity.Persistence?.Update.IsEnabled ?? true)
                || !(entity.Persistence?.Delete.IsEnabled ?? true)
                || !(entity.Persistence?.Read.IsEnabled ?? true)
            );
    }

    private readonly RequestDelegate _next;
    private readonly IReadOnlyDictionary<string, HashSet<string>> _forbiddenEntrySegmentsByVerb;
    /// <summary>
    /// Index to remove api prefix from the requested path
    /// </summary>
    private readonly int _apiPrefixSliceIndex;

    public SecureGeneratedEndPointsMiddleware(RequestDelegate next, NoxSolution solution)
    {
        _next = next;
        //start after prefix - e.g. /api/v1/
        _apiPrefixSliceIndex = (solution.Presentation.ApiConfiguration.ApiRoutePrefix).Length + 1; 
        _forbiddenEntrySegmentsByVerb = ConstructForbiddenEntrySegments(solution);
    }


    public async Task InvokeAsync(HttpContext context)
    {
        if (!_forbiddenEntrySegmentsByVerb.TryGetValue(context.Request.Method, out var forbiddenEntries))
        {
            await _next(context);
            return;
        }

        var nonPrefixedEntrySegment = GetEntrySegmentFromRequest(context);

        if (!forbiddenEntries.Contains(nonPrefixedEntrySegment.ToString()))
        {
            await _next(context);
            return;
        }

        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
    }

    private string GetEntrySegmentFromRequest(HttpContext context)
    {
        ReadOnlySpan<char> nonPrefixedPath = context.Request.Path.ToString().AsSpan().Slice(_apiPrefixSliceIndex);
        var indexOf = nonPrefixedPath.IndexOf("/");
        if(indexOf != -1)
        {
            nonPrefixedPath = nonPrefixedPath.Slice(0, indexOf);
        }        
        return nonPrefixedPath.ToString();
    }
    private static Dictionary<string, HashSet<string>> ConstructForbiddenEntrySegments(NoxSolution solution)
    {
        var forbiddenEntryPathByVerb = new Dictionary<string, HashSet<string>>
        {
            { HttpMethods.Put, new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) },
            { HttpMethods.Post, new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) },
            { HttpMethods.Delete, new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) },
            { HttpMethods.Get, new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) }
        };
        foreach (var entity in solution.Domain!.Entities)
        {
            if (!(entity.Persistence?.Create.IsEnabled ?? true))
            {
                forbiddenEntryPathByVerb[HttpMethods.Post].Add(entity.PluralName);
            }
            if (!(entity.Persistence?.Update.IsEnabled ?? true))
            {
                forbiddenEntryPathByVerb[HttpMethods.Put].Add(entity.PluralName);
            }
            if (!(entity.Persistence?.Delete.IsEnabled ?? true))
            {
                forbiddenEntryPathByVerb[HttpMethods.Delete].Add(entity.PluralName);
            }
            if (!(entity.Persistence?.Read.IsEnabled ?? true))
            {
                forbiddenEntryPathByVerb[HttpMethods.Get].Add(entity.PluralName);
            }
        }
        if (forbiddenEntryPathByVerb[HttpMethods.Post].Count == 0)
        {
            forbiddenEntryPathByVerb.Remove(HttpMethods.Post);
        }
        if (forbiddenEntryPathByVerb[HttpMethods.Put].Count == 0)
        {
            forbiddenEntryPathByVerb.Remove(HttpMethods.Put);
        }
        else
        {
            forbiddenEntryPathByVerb[HttpMethods.Patch] = forbiddenEntryPathByVerb[HttpMethods.Put];
        }
        if (forbiddenEntryPathByVerb[HttpMethods.Delete].Count == 0)
        {
            forbiddenEntryPathByVerb.Remove(HttpMethods.Delete);
        }
        if (forbiddenEntryPathByVerb[HttpMethods.Get].Count == 0)
        {
            forbiddenEntryPathByVerb.Remove(HttpMethods.Get);
        }

        return forbiddenEntryPathByVerb;
    }
}
