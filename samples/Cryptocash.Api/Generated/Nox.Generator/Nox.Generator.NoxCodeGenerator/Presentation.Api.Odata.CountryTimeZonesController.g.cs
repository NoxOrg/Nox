// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using CryptocashApi.Application;
using CryptocashApi.Application.Dto;
using CryptocashApi.Application.Queries;
using CryptocashApi.Application.Commands;
using CryptocashApi.Domain;
using CryptocashApi.Infrastructure.Persistence;
using Nox.Types;

namespace CryptocashApi.Presentation.Api.OData;

public partial class CountryTimeZonesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CountryTimeZonesController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CountryTimeZonesDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountryTimeZonesQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<CountryTimeZonesDto>> Get([FromRoute] System.Int64 key)
    {
        var item = await _mediator.Send(new GetCountryTimeZonesByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> CreateRefToCountries([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryTimeZonesToCountryCommand(new CountryTimeZonesKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> Post([FromBody]CountryTimeZonesCreateDto countrytimezones)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCountryTimeZonesCommand(countrytimezones));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.Int64 key, [FromBody] CountryTimeZonesUpdateDto countryTimeZones)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateCountryTimeZonesCommand(key, countryTimeZones));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.Int64 key, [FromBody] Delta<CountryTimeZonesUpdateDto> countryTimeZones)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in countryTimeZones.GetChangedPropertyNames())
        {
            if(countryTimeZones.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateCountryTimeZonesCommand(key, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new DeleteCountryTimeZonesByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
