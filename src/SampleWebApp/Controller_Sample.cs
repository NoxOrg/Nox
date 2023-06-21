// Generated

using Nox.Types;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleService.Application;
using SampleService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace SampleService.Presentation.Api;

/// <summary>
/// Controller for Country entity. The list of countries.
/// </summary>
[ApiController]
public partial class CountryController : ControllerBase
{


    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    protected GetCountriesByContinentQuery GetCountriesByContinent { get; set; } = null!;


    /// <summary>
    /// Instructs the service to collect updated population statistics.
    /// </summary>
    protected UpdatePopulationStatisticsCommandHandlerBase UpdatePopulationStatistics { get; set; } = null!;

    public CountryController(
        GetCountriesByContinentQuery getCountriesByContinent,
        UpdatePopulationStatisticsCommandHandlerBase updatePopulationStatistics
    )
    {
        GetCountriesByContinent = getCountriesByContinent;
        UpdatePopulationStatistics = updatePopulationStatistics;
    }


    [HttpGet]
    public async Task<IResult> GetGetCountriesByContinentAsync(Text continentName)
    {
        var result = await GetCountriesByContinentQuery.ExecuteAsync(continentName);
        return Results.Ok(result);
    }

    [HttpPost]
    public async Task<IResult> UpdatePopulationStatistics(Nox.Commands.UpdatePopulationStatisticsCommand command)
    {
        var result = await UpdatePopulationStatistics.ExecuteAsync(command);
        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}
