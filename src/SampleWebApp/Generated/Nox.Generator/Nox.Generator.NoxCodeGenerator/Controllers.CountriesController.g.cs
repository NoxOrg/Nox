// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;
using Nox.Application;
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class CountriesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// The Automapper.
    /// </summary>
    protected readonly IMapper _mapper;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    protected readonly GetCountriesByContinentQueryBase _getCountriesByContinent;
    
    /// <summary>
    /// Instructs the service to collect updated population statistics.
    /// </summary>
    protected readonly UpdatePopulationStatisticsCommandHandlerBase _updatePopulationStatistics;
    
    public CountriesController(
        ODataDbContext databaseContext,
        IMapper mapper,
        IMediator mediator,
        GetCountriesByContinentQueryBase getCountriesByContinent,
        UpdatePopulationStatisticsCommandHandlerBase updatePopulationStatistics
    )
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
        _mediator = mediator;
        _getCountriesByContinent = getCountriesByContinent;
        _updatePopulationStatistics = updatePopulationStatistics;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<OCountry>>> Get()
    {
        var result = await _mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<OCountry>> Get([FromRoute] System.String key)
    {
        var item = await _mediator.Send(new GetCountryByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post([FromBody]CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCountryCommand(country));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] OCountry updatedCountry)
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
    
    public async Task<ActionResult> Patch([FromRoute] string country, [FromBody] Delta<OCountry> Id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.Countries.FindAsync(country);
        
        if (entity == null)
        {
            return NotFound();
        }
        
        Id.Patch(entity);
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(country))
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
    
    private bool CountryExists(string country)
    {
        return _databaseContext.Countries.Any(p => p.Id == country);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var result = await _mediator.Send(new DeleteCountryByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    [HttpGet("GetCountriesByContinent")]
    public async Task<IResult> GetCountriesByContinentAsync(Text continentName)
    {
        var result = await _getCountriesByContinent.ExecuteAsync(continentName);
        return Results.Ok(result);
    }
    
    /// <summary>
    /// Instructs the service to collect updated population statistics.
    /// </summary>
    [HttpPost("UpdatePopulationStatistics")]
    public async Task<IResult> UpdatePopulationStatisticsAsync(UpdatePopulationStatistics command)
    {
        var result = await _updatePopulationStatistics.ExecuteAsync(command);
        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}
