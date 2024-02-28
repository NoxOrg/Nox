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
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class CountriesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryLocalNameDto>>> GetCountryLocalNames([FromRoute] System.Int64 key)
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
        
        return Ok(item.CountryLocalNames);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}")]
    public virtual async Task<ActionResult<CountryLocalNameDto>> GetCountryLocalNamesNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetCountryLocalNames(key, new CountryLocalNameKeyDto(relatedKey));
        if (child is null)
        {
            throw new EntityNotFoundException("CountryLocalName", $"{relatedKey.ToString()}");
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToCountryLocalNames([FromRoute] System.Int64 key, [FromBody] CountryLocalNameUpsertDto countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateCountryLocalNamesForCountryCommand(new CountryKeyDto(key), countryLocalName, _cultureCode, etag));
        
        var child = await TryGetCountryLocalNames(key, createdKey);
        return Created(child);
    }
    
    public virtual async Task<ActionResult<CountryLocalNameDto>> PutToCountryLocalNames(System.Int64 key, [FromBody] CountryLocalNameUpsertDto[] countryLocalNames)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryLocalNamesForCountryCommand(new CountryKeyDto(key), countryLocalNames, _cultureCode, etag));
        
        return Ok();
    }
    
    public virtual async Task<ActionResult> PatchToCountryLocalNames(System.Int64 key, [FromBody] Delta<CountryLocalNameUpsertDto> countryLocalName)
    {
        if (!ModelState.IsValid || countryLocalName is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CountryLocalNameUpsertDto>(countryLocalName);
        
        if(!updatedProperties.ContainsKey("Id") || updatedProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryLocalNamesForCountryCommand(new CountryKeyDto(key), new CountryLocalNameKeyDto(updatedProperties["Id"]), updatedProperties, _cultureCode, etag));
        
        var child = await TryGetCountryLocalNames(key, updated!);
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteCountryLocalNameNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteCountryLocalNamesForCountryCommand(new CountryKeyDto(key), new CountryLocalNameKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<CountryLocalNameDto?> TryGetCountryLocalNames(System.Int64 key, CountryLocalNameKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.CountryLocalNames.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<CountryBarCodeDto>> GetCountryBarCode([FromRoute] System.Int64 key)
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
        
        return Ok(item.CountryBarCode);
    }
    
    public virtual async Task<ActionResult> PostToCountryBarCode([FromRoute] System.Int64 key, [FromBody] CountryBarCodeUpsertDto countryBarCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateCountryBarCodeForCountryCommand(new CountryKeyDto(key), countryBarCode, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault()?.CountryBarCode;
        return Created(child);
    }
    
    public virtual async Task<ActionResult<CountryBarCodeDto>> PutToCountryBarCode(System.Int64 key, [FromBody] CountryBarCodeUpsertDto countryBarCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryBarCodeForCountryCommand(new CountryKeyDto(key), countryBarCode, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault()?.CountryBarCode;
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToCountryBarCode(System.Int64 key, [FromBody] Delta<CountryBarCodeUpsertDto> countryBarCode)
    {
        if (!ModelState.IsValid || countryBarCode is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CountryBarCodeUpsertDto>(countryBarCode);
        
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryBarCodeForCountryCommand(new CountryKeyDto(key), updatedProperties, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault()?.CountryBarCode;
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/Countries/{key}/CountryBarCode")]
    public virtual async Task<ActionResult> DeleteCountryBarCodeNonConventional(System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteCountryBarCodeForCountryCommand(new CountryKeyDto(key)));
        
        return NoContent();
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryTimeZoneDto>>> GetCountryTimeZones([FromRoute] System.Int64 key)
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
    [HttpGet("/api/v1/Countries/{key}/CountryTimeZones/{relatedKey}")]
    public virtual async Task<ActionResult<CountryTimeZoneDto>> GetCountryTimeZonesNonConventional(System.Int64 key, System.String relatedKey)
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
    
    public virtual async Task<ActionResult> PostToCountryTimeZones([FromRoute] System.Int64 key, [FromBody] CountryTimeZoneUpsertDto countryTimeZone)
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
    
    public virtual async Task<ActionResult<CountryTimeZoneDto>> PutToCountryTimeZones(System.Int64 key, [FromBody] CountryTimeZoneUpsertDto[] countryTimeZones)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryTimeZonesForCountryCommand(new CountryKeyDto(key), countryTimeZones, _cultureCode, etag));
        
        return Ok();
    }
    
    public virtual async Task<ActionResult> PatchToCountryTimeZones(System.Int64 key, [FromBody] Delta<CountryTimeZoneUpsertDto> countryTimeZone)
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
    
    [HttpDelete("/api/v1/Countries/{key}/CountryTimeZones/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteCountryTimeZoneNonConventional(System.Int64 key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteCountryTimeZonesForCountryCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<CountryTimeZoneDto?> TryGetCountryTimeZones(System.Int64 key, CountryTimeZoneKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.CountryTimeZones.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<HolidayDto>>> GetHolidays([FromRoute] System.Int64 key)
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
    [HttpGet("/api/v1/Countries/{key}/Holidays/{relatedKey}")]
    public virtual async Task<ActionResult<HolidayDto>> GetHolidaysNonConventional(System.Int64 key, System.Guid relatedKey)
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
    
    public virtual async Task<ActionResult> PostToHolidays([FromRoute] System.Int64 key, [FromBody] HolidayUpsertDto holiday)
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
    
    public virtual async Task<ActionResult<HolidayDto>> PutToHolidays(System.Int64 key, [FromBody] HolidayUpsertDto[] holidays)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateHolidaysForCountryCommand(new CountryKeyDto(key), holidays, _cultureCode, etag));
        
        return Ok();
    }
    
    public virtual async Task<ActionResult> PatchToHolidays(System.Int64 key, [FromBody] Delta<HolidayUpsertDto> holiday)
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
    
    [HttpDelete("/api/v1/Countries/{key}/Holidays/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteHolidayNonConventional(System.Int64 key, System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteHolidaysForCountryCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<HolidayDto?> TryGetHolidays(System.Int64 key, HolidayKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.Holidays.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToWorkplaces([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToWorkplacesCommand(new CountryKeyDto(key), new WorkplaceKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/Countries/{key}/Workplaces/$ref")]
    public virtual async Task<ActionResult> UpdateRefToWorkplacesNonConventional([FromRoute] System.Int64 key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new WorkplaceKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCountryToWorkplacesCommand(new CountryKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToWorkplaces([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetCountryByIdQuery(key))).Include(x => x.Workplaces).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Workplaces)
        {
            references.Add(new System.Uri($"Workplaces/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToWorkplaces([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToWorkplacesCommand(new CountryKeyDto(key), new WorkplaceKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToWorkplaces([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCountryToWorkplacesCommand(new CountryKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToWorkplaces([FromRoute] System.Int64 key, [FromBody] WorkplaceCreateDto workplace)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        workplace.CountryId = key;
        var createdKey = await _mediator.Send(new CreateWorkplaceCommand(workplace, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetWorkplaceByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<WorkplaceDto>>> GetWorkplaces(System.Int64 key)
    {
        var query = await _mediator.Send(new GetCountryByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Workplaces).SelectMany(x => x.Workplaces));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Countries/{key}/Workplaces/{relatedKey}")]
    public virtual async Task<SingleResult<WorkplaceDto>> GetWorkplacesNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Workplaces).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<WorkplaceDto>(Enumerable.Empty<WorkplaceDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/Countries/{key}/Workplaces/{relatedKey}")]
    public virtual async Task<ActionResult<WorkplaceDto>> PutToWorkplacesNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] WorkplaceUpdateDto workplace)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Workplaces).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Workplaces", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateWorkplaceCommand(relatedKey, workplace, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetWorkplaceByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/Countries/{key}/Workplaces/{relatedKey}")]
    public virtual async Task<ActionResult<WorkplaceDto>> PatchtoWorkplacesNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] Delta<WorkplacePartialUpdateDto> workplace)
    {
        if (!ModelState.IsValid || workplace is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Workplaces).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Workplaces", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<WorkplacePartialUpdateDto>(workplace);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateWorkplaceCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetWorkplaceByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/Countries/{key}/Workplaces/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToWorkplaces([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Workplaces).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Workplaces", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteWorkplaceByIdCommand(new List<WorkplaceKeyDto> { new WorkplaceKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/Countries/{key}/Workplaces")]
    public virtual async Task<ActionResult> DeleteToWorkplaces([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.Workplaces).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteWorkplaceByIdCommand(related.Select(item => new WorkplaceKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToStores([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToStoresCommand(new CountryKeyDto(key), new StoreKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/Countries/{key}/Stores/$ref")]
    public virtual async Task<ActionResult> UpdateRefToStoresNonConventional([FromRoute] System.Int64 key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new StoreKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCountryToStoresCommand(new CountryKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToStores([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetCountryByIdQuery(key))).Include(x => x.Stores).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Stores)
        {
            references.Add(new System.Uri($"Stores/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToStores([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToStoresCommand(new CountryKeyDto(key), new StoreKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToStores([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCountryToStoresCommand(new CountryKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStores([FromRoute] System.Int64 key, [FromBody] StoreCreateDto store)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        store.CountryId = key;
        var createdKey = await _mediator.Send(new CreateStoreCommand(store, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreDto>>> GetStores(System.Int64 key)
    {
        var query = await _mediator.Send(new GetCountryByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Stores).SelectMany(x => x.Stores));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Countries/{key}/Stores/{relatedKey}")]
    public virtual async Task<SingleResult<StoreDto>> GetStoresNonConventional(System.Int64 key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Stores).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<StoreDto>(Enumerable.Empty<StoreDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/Countries/{key}/Stores/{relatedKey}")]
    public virtual async Task<ActionResult<StoreDto>> PutToStoresNonConventional(System.Int64 key, System.Guid relatedKey, [FromBody] StoreUpdateDto store)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Stores).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Stores", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreCommand(relatedKey, store, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/Countries/{key}/Stores/{relatedKey}")]
    public virtual async Task<ActionResult<StoreDto>> PatchtoStoresNonConventional(System.Int64 key, System.Guid relatedKey, [FromBody] Delta<StorePartialUpdateDto> store)
    {
        if (!ModelState.IsValid || store is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Stores).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Stores", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<StorePartialUpdateDto>(store);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateStoreCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/Countries/{key}/Stores/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToStores([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).SelectMany(x => x.Stores).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Stores", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteStoreByIdCommand(new List<StoreKeyDto> { new StoreKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/Countries/{key}/Stores")]
    public virtual async Task<ActionResult> DeleteToStores([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.Stores).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteStoreByIdCommand(related.Select(item => new StoreKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
