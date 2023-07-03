// Generated

#nullable enable

using Nox.Types;
using Microsoft.AspNetCore.Mvc;
using SampleWebApp.Application;
using SampleWebApp.Application.DataTransferObjects;

namespace SampleWebApp.Presentation.Rest;

/// <summary>
/// Controller for Country entity. The list of countries.
/// </summary>
[ApiController]
[Route("[controller]")]
public partial class CountriesApiController : ControllerBase
{
    
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    protected GetCountriesByContinentQuery GetCountriesByContinent { get; set; } = null!;
    
    /// <summary>
    /// Instructs the service to collect updated population statistics.
    /// </summary>
    protected UpdatePopulationStatisticsCommandHandlerBase UpdatePopulationStatistics { get; set; } = null!;
    
    public CountriesApiController(
        GetCountriesByContinentQuery getCountriesByContinent,
        UpdatePopulationStatisticsCommandHandlerBase updatePopulationStatistics
    )
    {
        GetCountriesByContinent = getCountriesByContinent;
        UpdatePopulationStatistics = updatePopulationStatistics;
    }
    
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    [HttpGet]
    public async Task<IResult> GetCountriesByContinentAsync(Text continentName)
    {
        var result = await GetCountriesByContinent.ExecuteAsync(continentName);
        return Results.Ok(result);
    }
    
    /// <summary>
    /// Instructs the service to collect updated population statistics.
    /// </summary>
    [HttpPost]
    public async Task<IResult> UpdatePopulationStatisticsAsync(UpdatePopulationStatistics command)
    {
        var result = await UpdatePopulationStatistics.ExecuteAsync(command);
        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}
