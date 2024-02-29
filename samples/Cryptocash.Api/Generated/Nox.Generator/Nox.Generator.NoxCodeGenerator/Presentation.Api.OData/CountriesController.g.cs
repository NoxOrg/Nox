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
using Nox.Application.Dto;
using Nox.Extensions;
using Nox.Exceptions;
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class CountriesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryTimeZoneDto>>> GetCountryTimeZones([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        return Ok(item.CountryTimeZones);
    }
    
    [EnableQuery]
    [HttpGet("/api/Countries/{key}/CountryTimeZones/{relatedKey}")]
    public virtual async Task<ActionResult<CountryTimeZoneDto>> GetCountryTimeZonesNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetCountryTimeZones(key, new CountryTimeZoneKeyDto(relatedKey));
        if (child is null)
        {
            throw new EntityNotFoundException("CountryTimeZone", $"{relatedKey.ToString()}");
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToCountryTimeZones([FromRoute] System.String key, [FromBody] CountryTimeZoneUpsertDto countryTimeZone)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateCountryTimeZonesForCountryCommand(new CountryKeyDto(key), countryTimeZone, _cultureCode, etag));
        
        var child = await TryGetCountryTimeZones(key, createdKey);
        return Created(child);
    }
    
    public virtual async Task<ActionResult<CountryTimeZoneDto>> PutToCountryTimeZones(System.String key, [FromBody] EntityDtoCollection<CountryTimeZoneUpsertDto> countryTimeZones)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKeys = await _mediator.Send(new UpdateCountryTimeZonesForCountryCommand(new CountryKeyDto(key), countryTimeZones.Values!, _cultureCode, etag));
        
        var children = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault()?.CountryTimeZones?.Where(e => updatedKeys.Any(k => e.Id == k.keyId));
        
        return Ok(children);
    }
    
    public virtual async Task<ActionResult> PatchToCountryTimeZones(System.String key, [FromBody] Delta<CountryTimeZoneUpsertDto> countryTimeZone)
    {
        if (!ModelState.IsValid || countryTimeZone is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CountryTimeZoneUpsertDto>(countryTimeZone);
        
        if(!updatedProperties.ContainsKey("Id") || updatedProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryTimeZonesForCountryCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(updatedProperties["Id"]), updatedProperties, _cultureCode, etag));
        
        var child = await TryGetCountryTimeZones(key, updated!);
        
        return Ok(child);
    }
    
    [HttpDelete("/api/Countries/{key}/CountryTimeZones/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteCountryTimeZoneNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteCountryTimeZonesForCountryCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<CountryTimeZoneDto?> TryGetCountryTimeZones(System.String key, CountryTimeZoneKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.CountryTimeZones.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<HolidayDto>>> GetHolidays([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        return Ok(item.Holidays);
    }
    
    [EnableQuery]
    [HttpGet("/api/Countries/{key}/Holidays/{relatedKey}")]
    public virtual async Task<ActionResult<HolidayDto>> GetHolidaysNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetHolidays(key, new HolidayKeyDto(relatedKey));
        if (child is null)
        {
            throw new EntityNotFoundException("Holiday", $"{relatedKey.ToString()}");
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToHolidays([FromRoute] System.String key, [FromBody] HolidayUpsertDto holiday)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateHolidaysForCountryCommand(new CountryKeyDto(key), holiday, _cultureCode, etag));
        
        var child = await TryGetHolidays(key, createdKey);
        return Created(child);
    }
    
    public virtual async Task<ActionResult<HolidayDto>> PutToHolidays(System.String key, [FromBody] EntityDtoCollection<HolidayUpsertDto> holidays)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKeys = await _mediator.Send(new UpdateHolidaysForCountryCommand(new CountryKeyDto(key), holidays.Values!, _cultureCode, etag));
        
        var children = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault()?.Holidays?.Where(e => updatedKeys.Any(k => e.Id == k.keyId));
        
        return Ok(children);
    }
    
    public virtual async Task<ActionResult> PatchToHolidays(System.String key, [FromBody] Delta<HolidayUpsertDto> holiday)
    {
        if (!ModelState.IsValid || holiday is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<HolidayUpsertDto>(holiday);
        
        if(!updatedProperties.ContainsKey("Id") || updatedProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateHolidaysForCountryCommand(new CountryKeyDto(key), new HolidayKeyDto(updatedProperties["Id"]), updatedProperties, _cultureCode, etag));
        
        var child = await TryGetHolidays(key, updated!);
        
        return Ok(child);
    }
    
    [HttpDelete("/api/Countries/{key}/Holidays/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteHolidayNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteHolidaysForCountryCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<HolidayDto?> TryGetHolidays(System.String key, HolidayKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.Holidays.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToCurrency([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToCurrencyCommand(new CountryKeyDto(key), new CurrencyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCurrency([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetCountryByIdQuery(key))).Include(x => x.Currency).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        if (entity.Currency is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Currencies/{entity.Currency.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToCurrency([FromRoute] System.String key, [FromBody] CurrencyCreateDto currency)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        currency.CountriesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateCurrencyCommand(currency, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCurrencyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CurrencyDto>> GetCurrency(System.String key)
    {
        var query = await _mediator.Send(new GetCountryByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CurrencyDto>(Enumerable.Empty<CurrencyDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Currency != null).Select(x => x.Currency!));
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> PutToCurrency(System.String key, [FromBody] CurrencyUpdateDto currency)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.Currency).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Currency", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(related.Id, currency, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> PatchToCurrency(System.String key, [FromBody] Delta<CurrencyPartialUpdateDto> currency)
    {
        if (!ModelState.IsValid || currency is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.Currency).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Currency", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CurrencyPartialUpdateDto>(currency);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCurrencyCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult> CreateRefToCommissions([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToCommissionsCommand(new CountryKeyDto(key), new CommissionKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/Countries/{key}/Commissions/$ref")]
    public virtual async Task<ActionResult> UpdateRefToCommissionsNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new CommissionKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCountryToCommissionsCommand(new CountryKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCommissions([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetCountryByIdQuery(key))).Include(x => x.Commissions).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Commissions)
        {
            references.Add(new System.Uri($"Commissions/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToCommissions([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToCommissionsCommand(new CountryKeyDto(key), new CommissionKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCommissions([FromRoute] System.String key, [FromBody] CommissionCreateDto commission)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        commission.CountryId = key;
        var createdKey = await _mediator.Send(new CreateCommissionCommand(commission, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCommissionByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CommissionDto>>> GetCommissions(System.String key)
    {
        var query = await _mediator.Send(new GetCountryByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Commissions).SelectMany(x => x.Commissions));
    }
    
    [EnableQuery]
    [HttpGet("/api/Countries/{key}/Commissions/{relatedKey}")]
    public virtual async Task<SingleResult<CommissionDto>> GetCommissionsNonConventional(System.String key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Commissions).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<CommissionDto>(Enumerable.Empty<CommissionDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Countries/{key}/Commissions/{relatedKey}")]
    public virtual async Task<ActionResult<CommissionDto>> PutToCommissionsNonConventional(System.String key, System.Guid relatedKey, [FromBody] CommissionUpdateDto commission)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Commissions).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Commissions", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCommissionCommand(relatedKey, commission, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCommissionByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/Countries/{key}/Commissions/{relatedKey}")]
    public virtual async Task<ActionResult<CommissionDto>> PatchtoCommissionsNonConventional(System.String key, System.Guid relatedKey, [FromBody] Delta<CommissionPartialUpdateDto> commission)
    {
        if (!ModelState.IsValid || commission is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Commissions).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Commissions", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CommissionPartialUpdateDto>(commission);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCommissionCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCommissionByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Countries/{key}/Commissions/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToCommissions([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Commissions).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Commissions", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCommissionByIdCommand(new List<CommissionKeyDto> { new CommissionKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToVendingMachines([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToVendingMachinesCommand(new CountryKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/Countries/{key}/VendingMachines/$ref")]
    public virtual async Task<ActionResult> UpdateRefToVendingMachinesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new VendingMachineKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCountryToVendingMachinesCommand(new CountryKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToVendingMachines([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetCountryByIdQuery(key))).Include(x => x.VendingMachines).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.VendingMachines)
        {
            references.Add(new System.Uri($"VendingMachines/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToVendingMachines([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToVendingMachinesCommand(new CountryKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToVendingMachines([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCountryToVendingMachinesCommand(new CountryKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachines([FromRoute] System.String key, [FromBody] VendingMachineCreateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        vendingMachine.CountryId = key;
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingMachine, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetVendingMachineByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<VendingMachineDto>>> GetVendingMachines(System.String key)
    {
        var query = await _mediator.Send(new GetCountryByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.VendingMachines).SelectMany(x => x.VendingMachines));
    }
    
    [EnableQuery]
    [HttpGet("/api/Countries/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<SingleResult<VendingMachineDto>> GetVendingMachinesNonConventional(System.String key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.VendingMachines).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<VendingMachineDto>(Enumerable.Empty<VendingMachineDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Countries/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<ActionResult<VendingMachineDto>> PutToVendingMachinesNonConventional(System.String key, System.Guid relatedKey, [FromBody] VendingMachineUpdateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.VendingMachines).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("VendingMachines", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateVendingMachineCommand(relatedKey, vendingMachine, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/Countries/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<ActionResult<VendingMachineDto>> PatchtoVendingMachinesNonConventional(System.String key, System.Guid relatedKey, [FromBody] Delta<VendingMachinePartialUpdateDto> vendingMachine)
    {
        if (!ModelState.IsValid || vendingMachine is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.VendingMachines).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("VendingMachines", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<VendingMachinePartialUpdateDto>(vendingMachine);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateVendingMachineCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Countries/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToVendingMachines([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.VendingMachines).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("VendingMachines", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteVendingMachineByIdCommand(new List<VendingMachineKeyDto> { new VendingMachineKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/Countries/{key}/VendingMachines")]
    public virtual async Task<ActionResult> DeleteToVendingMachines([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.VendingMachines).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteVendingMachineByIdCommand(related.Select(item => new VendingMachineKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToCustomers([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToCustomersCommand(new CountryKeyDto(key), new CustomerKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/Countries/{key}/Customers/$ref")]
    public virtual async Task<ActionResult> UpdateRefToCustomersNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new CustomerKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCountryToCustomersCommand(new CountryKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCustomers([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetCountryByIdQuery(key))).Include(x => x.Customers).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Customers)
        {
            references.Add(new System.Uri($"Customers/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToCustomers([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToCustomersCommand(new CountryKeyDto(key), new CustomerKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToCustomers([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCountryToCustomersCommand(new CountryKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCustomers([FromRoute] System.String key, [FromBody] CustomerCreateDto customer)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        customer.CountryId = key;
        var createdKey = await _mediator.Send(new CreateCustomerCommand(customer, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCustomerByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CustomerDto>>> GetCustomers(System.String key)
    {
        var query = await _mediator.Send(new GetCountryByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Customers).SelectMany(x => x.Customers));
    }
    
    [EnableQuery]
    [HttpGet("/api/Countries/{key}/Customers/{relatedKey}")]
    public virtual async Task<SingleResult<CustomerDto>> GetCustomersNonConventional(System.String key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Customers).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<CustomerDto>(Enumerable.Empty<CustomerDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Countries/{key}/Customers/{relatedKey}")]
    public virtual async Task<ActionResult<CustomerDto>> PutToCustomersNonConventional(System.String key, System.Guid relatedKey, [FromBody] CustomerUpdateDto customer)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Customers).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Customers", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCustomerCommand(relatedKey, customer, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCustomerByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/Countries/{key}/Customers/{relatedKey}")]
    public virtual async Task<ActionResult<CustomerDto>> PatchtoCustomersNonConventional(System.String key, System.Guid relatedKey, [FromBody] Delta<CustomerPartialUpdateDto> customer)
    {
        if (!ModelState.IsValid || customer is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Customers).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Customers", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CustomerPartialUpdateDto>(customer);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCustomerCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCustomerByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Countries/{key}/Customers/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToCustomers([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Customers).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Customers", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCustomerByIdCommand(new List<CustomerKeyDto> { new CustomerKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/Countries/{key}/Customers")]
    public virtual async Task<ActionResult> DeleteToCustomers([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.Customers).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteCustomerByIdCommand(related.Select(item => new CustomerKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
