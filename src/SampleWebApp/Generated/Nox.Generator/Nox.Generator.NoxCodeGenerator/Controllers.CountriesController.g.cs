// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
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
        IMediator mediator,
        GetCountriesByContinentQueryBase getCountriesByContinent,
        UpdatePopulationStatisticsCommandHandlerBase updatePopulationStatistics
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
        _getCountriesByContinent = getCountriesByContinent;
        _updatePopulationStatistics = updatePopulationStatistics;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CountryDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<CountryDto>> Get([FromRoute] System.String key)
    {
        var item = await _mediator.Send(new GetCountryByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<CountryLocalNames>> GetCountryLocalNames([FromRoute] string key)
    {
        return Ok(_databaseContext.Countries.Where(d => d.Id.Equals(key)).SelectMany(m => m.CountryLocalNames));
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
    
    public async Task<ActionResult> Put([FromRoute] System.String key, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateCountryCommand(key, country));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(country);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.String key, [FromBody] Delta<CountryUpdateDto> country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        var deletedProperties = new HashSet<string>();

        foreach (var propertyName in country.GetChangedPropertyNames())
        {
            if(country.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }
            else
            {
                deletedProperties.Add(propertyName);
            }
        }
        
        var updated = await _mediator.Send(new PartialUpdateCountryCommand(key, updateProperties, deletedProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(country);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.String key)
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
