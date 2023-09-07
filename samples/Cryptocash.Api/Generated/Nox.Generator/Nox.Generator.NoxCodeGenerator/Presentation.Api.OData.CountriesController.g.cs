// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

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
    
    public CountriesController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    #region Owned Relationships
    
    [EnableQuery]
    public async Task<ActionResult<IQueryable<CountryTimeZoneDto>>> GetCountryTimeZones([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = await _mediator.Send(new GetCountryByIdQuery(key));
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.CountryTimeZones);
    }
    
    public async Task<ActionResult> PostToCountryTimeZones([FromRoute] System.String key, [FromBody] CountryTimeZoneCreateDto countryTimeZone)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdKey = await _mediator.Send(new AddCountryTimeZoneCommand(new CountryKeyDto(key), countryTimeZone));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCountryTimeZone(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("/api/Countries/{key}/CountryTimeZones/{relatedKey}")]
    public async Task<ActionResult> PutToCountryTimeZonesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] CountryTimeZoneUpdateDto countryTimeZone)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedKey = await _mediator.Send(new UpdateCountryTimeZoneCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey), countryTimeZone));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCountryTimeZone(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("/api/Countries/{key}/CountryTimeZones/{relatedKey}")]
    public async Task<ActionResult> PatchToCountryTimeZonesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<CountryTimeZoneUpdateDto> countryTimeZone)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in countryTimeZone.GetChangedPropertyNames())
        {
            if(countryTimeZone.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateCountryTimeZoneCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey), updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetCountryTimeZone(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    private async Task<CountryTimeZoneDto?> TryGetCountryTimeZone(System.String key, CountryTimeZoneKeyDto childKeyDto)
    {
        var parent = await _mediator.Send(new GetCountryByIdQuery(key));
        return parent?.CountryTimeZones.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public async Task<ActionResult<IQueryable<HolidayDto>>> GetHolidays([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = await _mediator.Send(new GetCountryByIdQuery(key));
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.Holidays);
    }
    
    public async Task<ActionResult> PostToHolidays([FromRoute] System.String key, [FromBody] HolidayCreateDto holiday)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdKey = await _mediator.Send(new AddHolidayCommand(new CountryKeyDto(key), holiday));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetHoliday(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("/api/Countries/{key}/Holidays/{relatedKey}")]
    public async Task<ActionResult> PutToHolidaysNonConventional(System.String key, System.Int64 relatedKey, [FromBody] HolidayUpdateDto holiday)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedKey = await _mediator.Send(new UpdateHolidayCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey), holiday));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetHoliday(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("/api/Countries/{key}/Holidays/{relatedKey}")]
    public async Task<ActionResult> PatchToHolidaysNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<HolidayUpdateDto> holiday)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in holiday.GetChangedPropertyNames())
        {
            if(holiday.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateHolidayCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey), updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetHoliday(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    private async Task<HolidayDto?> TryGetHoliday(System.String key, HolidayKeyDto childKeyDto)
    {
        var parent = await _mediator.Send(new GetCountryByIdQuery(key));
        return parent?.Holidays.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CountryDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<CountryDto>> Get([FromRoute] System.String key)
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
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.String key, [FromBody] Delta<CountryUpdateDto> country)
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
    
    public async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new DeleteCountryByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
