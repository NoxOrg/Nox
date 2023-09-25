// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
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

public partial class CountriesController : CountriesControllerBase
{
    public CountriesController(IMediator mediator):base(mediator)
    {}
}
public abstract class CountriesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CountriesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<CountryDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetCountryByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<CountryDto>> Post([FromBody]CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCountryCommand(country));
        
        var item = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<CountryDto>> Put([FromRoute] System.String key, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCountryCommand(key, country, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetCountryByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<CountryDto>> Patch([FromRoute] System.String key, [FromBody] Delta<CountryDto> country)
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
        var item = (await _mediator.Send(new GetCountryByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCountryByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryTimeZoneDto>>> GetCountryOwnedTimeZones([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.CountryOwnedTimeZones);
    }
    
    [EnableQuery]
    [HttpGet("api/Countries/{key}/CountryOwnedTimeZones/{relatedKey}")]
    public virtual async Task<ActionResult<CountryTimeZoneDto>> GetCountryOwnedTimeZonesNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetCountryOwnedTimeZones(key, new CountryTimeZoneKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToCountryOwnedTimeZones([FromRoute] System.String key, [FromBody] CountryTimeZoneCreateDto countryTimeZone)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateCountryTimeZoneForCountryCommand(new CountryKeyDto(key), countryTimeZone, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCountryOwnedTimeZones(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/Countries/{key}/CountryOwnedTimeZones/{relatedKey}")]
    public virtual async Task<ActionResult<CountryTimeZoneDto>> PutToCountryTimeZonesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] CountryTimeZoneUpdateDto countryTimeZone)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryTimeZoneForCountryCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey), countryTimeZone, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCountryOwnedTimeZones(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/Countries/{key}/CountryOwnedTimeZones/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToCountryTimeZonesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<CountryTimeZoneDto> countryTimeZone)
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
        var updated = await _mediator.Send(new PartialUpdateCountryTimeZoneForCountryCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetCountryOwnedTimeZones(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Countries/{key}/CountryOwnedTimeZones/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteCountryTimeZoneNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteCountryTimeZoneForCountryCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private async Task<CountryTimeZoneDto?> TryGetCountryOwnedTimeZones(System.String key, CountryTimeZoneKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.CountryOwnedTimeZones.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<HolidayDto>>> GetCountryOwnedHolidays([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.CountryOwnedHolidays);
    }
    
    [EnableQuery]
    [HttpGet("api/Countries/{key}/CountryOwnedHolidays/{relatedKey}")]
    public virtual async Task<ActionResult<HolidayDto>> GetCountryOwnedHolidaysNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetCountryOwnedHolidays(key, new HolidayKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToCountryOwnedHolidays([FromRoute] System.String key, [FromBody] HolidayCreateDto holiday)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateHolidayForCountryCommand(new CountryKeyDto(key), holiday, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCountryOwnedHolidays(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/Countries/{key}/CountryOwnedHolidays/{relatedKey}")]
    public virtual async Task<ActionResult<HolidayDto>> PutToHolidaysNonConventional(System.String key, System.Int64 relatedKey, [FromBody] HolidayUpdateDto holiday)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateHolidayForCountryCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey), holiday, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCountryOwnedHolidays(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/Countries/{key}/CountryOwnedHolidays/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToHolidaysNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<HolidayDto> holiday)
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
        var updated = await _mediator.Send(new PartialUpdateHolidayForCountryCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetCountryOwnedHolidays(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Countries/{key}/CountryOwnedHolidays/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteHolidayNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteHolidayForCountryCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private async Task<HolidayDto?> TryGetCountryOwnedHolidays(System.String key, HolidayKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.CountryOwnedHolidays.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToCountryUsedByCurrency([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToCountryUsedByCurrencyCommand(new CountryKeyDto(key), new CurrencyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCountryUsedByCurrency([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.CountryUsedByCurrency).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Currencies/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToCountryUsedByCurrency([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToCountryUsedByCurrencyCommand(new CountryKeyDto(key), new CurrencyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCountryUsedByCurrency([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCountryToCountryUsedByCurrencyCommand(new CountryKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToCountryUsedByCommissions([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToCountryUsedByCommissionsCommand(new CountryKeyDto(key), new CommissionKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCountryUsedByCommissions([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.CountryUsedByCommissions).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"Commissions/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToCountryUsedByCommissions([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToCountryUsedByCommissionsCommand(new CountryKeyDto(key), new CommissionKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCountryUsedByCommissions([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCountryToCountryUsedByCommissionsCommand(new CountryKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToCountryUsedByVendingMachines([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToCountryUsedByVendingMachinesCommand(new CountryKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCountryUsedByVendingMachines([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.CountryUsedByVendingMachines).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"VendingMachines/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToCountryUsedByVendingMachines([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToCountryUsedByVendingMachinesCommand(new CountryKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCountryUsedByVendingMachines([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCountryToCountryUsedByVendingMachinesCommand(new CountryKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToCountryUsedByCustomers([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToCountryUsedByCustomersCommand(new CountryKeyDto(key), new CustomerKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCountryUsedByCustomers([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.CountryUsedByCustomers).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"Customers/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToCountryUsedByCustomers([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToCountryUsedByCustomersCommand(new CountryKeyDto(key), new CustomerKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCountryUsedByCustomers([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCountryToCountryUsedByCustomersCommand(new CountryKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
