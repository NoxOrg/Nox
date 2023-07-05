// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class CountriesController : ODataController
{
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    protected GetCountriesByContinentQuery GetCountriesByContinent { get; set; } = null!;
    
    /// <summary>
    /// Instructs the service to collect updated population statistics.
    /// </summary>
    protected UpdatePopulationStatisticsCommandHandlerBase UpdatePopulationStatistics { get; set; } = null!;
    
    public CountriesController(
        ODataDbContext databaseContext,
        GetCountriesByContinentQuery getCountriesByContinent,
        UpdatePopulationStatisticsCommandHandlerBase updatePopulationStatistics
    )
    {
        databaseContext = databaseContext;
        GetCountriesByContinent = getCountriesByContinent;
        UpdatePopulationStatistics = updatePopulationStatistics;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<Country>> Get()
    {
        return Ok(_databaseContext.Countries);
    }
    
    [EnableQuery]
    public ActionResult<Country> Get([FromRoute] string key)
    {
        var item = _databaseContext.Countries.SingleOrDefault(d => d.Id.Equals(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post(Country country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.Countries.Add(country);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(country);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] Country updatedCountry)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != updatedCountry.Id)
        {
            return BadRequest();
        }
        
        _databaseContext.Entry(updatedCountry).State = EntityState.Modified;
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(updatedCountry);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string key, [FromBody] Delta<Country> country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.Countries.FindAsync(key);
        
        if (entity == null)
        {
            return NotFound();
        }
        
        country.Patch(entity);
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(entity);
    }
    
    private bool CountryExists(string key)
    {
        return _databaseContext.Countries.Any(p => p.Id == key);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var country = await _databaseContext.Countries.FindAsync(key);
        if (country == null)
        {
            return NotFound();
        }
        
        _databaseContext.Countries.Remove(country);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
    
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    [HttpGet("GetCountriesByContinent")]
    public async Task<IResult> GetCountriesByContinentAsync(Text continentName)
    {
        var result = await GetCountriesByContinent.ExecuteAsync(continentName);
        return Results.Ok(result);
    }
    
    /// <summary>
    /// Instructs the service to collect updated population statistics.
    /// </summary>
    [HttpPost("UpdatePopulationStatistics")]
    public async Task<IResult> UpdatePopulationStatisticsAsync(UpdatePopulationStatistics command)
    {
        var result = await UpdatePopulationStatistics.ExecuteAsync(command);
        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}
