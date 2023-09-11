// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Net.Http.Headers;
using Nox.Application;
using Nox.Extensions;
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
    
    [EnableQuery]
    [HttpGet("/api/[controller]/{key}/CountryTimeZones/{relatedKey}")]
    public async Task<ActionResult<CountryTimeZoneDto>> GetCountryTimeZoneNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetCountryTimeZone(key, new CountryTimeZoneKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public async Task<ActionResult> PostToCountryTimeZones([FromRoute] System.String key, [FromBody] CountryTimeZoneCreateDto countryTimeZone)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new AddCountryTimeZoneCommand(new CountryKeyDto(key), countryTimeZone, etag));
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
    
    [HttpPut("/api/[controller]/{key}/CountryTimeZones/{relatedKey}")]
    public async Task<ActionResult<CountryTimeZoneDto>> PutToCountryTimeZonesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] CountryTimeZoneUpdateDto countryTimeZone)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryTimeZoneCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey), countryTimeZone, etag));
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
    
    [HttpPatch("/api/[controller]/{key}/CountryTimeZones/{relatedKey}")]
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
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryTimeZoneCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey), updateProperties, etag));
        
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
    
    [HttpDelete("/api/[controller]/{key}/CountryTimeZones/{relatedKey}")]
    public async Task<ActionResult> DeleteCountryTimeZoneNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteCountryTimeZoneCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
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
    
    [EnableQuery]
    [HttpGet("/api/[controller]/{key}/Holidays/{relatedKey}")]
    public async Task<ActionResult<HolidayDto>> GetHolidayNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetHoliday(key, new HolidayKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public async Task<ActionResult> PostToHolidays([FromRoute] System.String key, [FromBody] HolidayCreateDto holiday)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new AddHolidayCommand(new CountryKeyDto(key), holiday, etag));
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
    
    [HttpPut("/api/[controller]/{key}/Holidays/{relatedKey}")]
    public async Task<ActionResult<HolidayDto>> PutToHolidaysNonConventional(System.String key, System.Int64 relatedKey, [FromBody] HolidayUpdateDto holiday)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateHolidayCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey), holiday, etag));
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
    
    [HttpPatch("/api/[controller]/{key}/Holidays/{relatedKey}")]
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
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateHolidayCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey), updateProperties, etag));
        
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
    
    [HttpDelete("/api/[controller]/{key}/Holidays/{relatedKey}")]
    public async Task<ActionResult> DeleteHolidayNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteHolidayCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
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
    
    public async Task<ActionResult<CountryDto>> Post([FromBody]CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCountryCommand(country));
        
        var item = await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public async Task<ActionResult<CountryDto>> Put([FromRoute] System.String key, [FromBody] CountryUpdateDto country)
    {
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCountryCommand(key, country, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetCountryByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public async Task<ActionResult<CountryDto>> Patch([FromRoute] System.String key, [FromBody] Delta<CountryUpdateDto> country)
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
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetCountryByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCountryByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
