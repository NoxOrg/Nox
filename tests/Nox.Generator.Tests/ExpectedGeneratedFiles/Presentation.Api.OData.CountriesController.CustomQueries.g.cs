// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using SampleWebApp.Application;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;

using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public abstract partial class CountriesControllerBase
{
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    protected readonly GetCountriesByContinentQueryBase _getCountriesByContinent;
            
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    [HttpGet("GetCountriesByContinent")]
    public async Task<IResult> GetCountriesByContinentAsync(Text continentName)
    {
        var result = await _getCountriesByContinent.ExecuteAsync(continentName);
        return Results.Ok(result);
    }
}
