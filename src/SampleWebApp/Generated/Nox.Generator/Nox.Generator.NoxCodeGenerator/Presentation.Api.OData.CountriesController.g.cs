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
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class CountriesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    protected readonly GetCountriesByContinentQueryBase _getCountriesByContinent;
    
    public CountriesController(
        DtoDbContext databaseContext,
        IMediator mediator,
        GetCountriesByContinentQueryBase getCountriesByContinent
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
        _getCountriesByContinent = getCountriesByContinent;
    }
    
    [HttpGet]
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CountryDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<ActionResult<CountryDto>> Get([FromRoute] System.Int64 key)
    {
        var item = await _mediator.Send(new GetCountryByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    [HttpPost]
    public async Task<ActionResult> PostToCountryLocalNames([FromRoute] System.Int64 key, [FromBody] CountryLocalNameCreateDto countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdKey = await _mediator.Send(new AddCountryLocalNameCommand(new CountryKeyDto(key), countryLocalName));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        return Created(new CountryLocalNameDto { Id = createdKey.keyId });
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody]CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCountryCommand(country));
        
        return Created(createdKey);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromRoute] System.Int64 key, [FromBody] CountryUpdateDto country)
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
        return Updated(updated);
    }
    
    [HttpPatch]
    public async Task<ActionResult> Patch([FromRoute] System.Int64 key, [FromBody] Delta<CountryUpdateDto> country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in country.GetChangedPropertyNames())
        {
            if(country.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateCountryCommand(key, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromRoute] System.Int64 key)
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
}
