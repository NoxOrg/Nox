﻿// Generated

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

public abstract partial class WorkplacesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<WorkplaceAddressDto>>> GetWorkplaceAddresses([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        
        return Ok(item.WorkplaceAddresses);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Workplaces/{key}/WorkplaceAddresses/{relatedKey}")]
    public virtual async Task<ActionResult<WorkplaceAddressDto>> GetWorkplaceAddressesNonConventional(System.Int64 key, System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetWorkplaceAddresses(key, new WorkplaceAddressKeyDto(relatedKey));
        if (child is null)
        {
            throw new EntityNotFoundException("WorkplaceAddress", $"{relatedKey.ToString()}");
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToWorkplaceAddresses([FromRoute] System.Int64 key, [FromBody] WorkplaceAddressUpsertDto workplaceAddress)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateWorkplaceAddressesForWorkplaceCommand(new WorkplaceKeyDto(key), workplaceAddress, _cultureCode, etag));
        
        var child = await TryGetWorkplaceAddresses(key, createdKey);
        return Created(child);
    }
    
    public virtual async Task<ActionResult<WorkplaceAddressDto>> PutToWorkplaceAddresses(System.Int64 key, [FromBody] EntityDtoCollection<WorkplaceAddressUpsertDto> workplaceAddresses)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKeys = await _mediator.Send(new UpdateWorkplaceAddressesForWorkplaceCommand(new WorkplaceKeyDto(key), workplaceAddresses.Values!, _cultureCode, etag));
        
        var children = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).SingleOrDefault()?.WorkplaceAddresses?.Where(e => updatedKeys.Any(k => e.Id == k.keyId));
        
        return Ok(children);
    }
    
    [HttpPut("/api/v1/Workplaces/{key}/WorkplaceAddresses/{relatedKey}")]
    public virtual async Task<ActionResult<WorkplaceAddressDto>> PutToWorkplaceAddressNonConventional(System.Int64 key, System.Guid relatedKey, [FromBody] WorkplaceAddressUpsertDto workplaceAddress)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        workplaceAddress.Id = relatedKey;
        var updatedKey = await _mediator.Send(new UpdateWorkplaceAddressForSingleWorkplaceCommand(new WorkplaceKeyDto(key), workplaceAddress, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).SingleOrDefault()?.WorkplaceAddresses?.SingleOrDefault(e => e.Id == updatedKey.keyId);
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToWorkplaceAddresses(System.Int64 key, [FromBody] Delta<WorkplaceAddressUpsertDto> workplaceAddress)
    {
        if (!ModelState.IsValid || workplaceAddress is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<WorkplaceAddressUpsertDto>(workplaceAddress);
        
        if(!updatedProperties.ContainsKey("Id") || updatedProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateWorkplaceAddressesForWorkplaceCommand(new WorkplaceKeyDto(key), new WorkplaceAddressKeyDto(updatedProperties["Id"]), updatedProperties, _cultureCode, etag));
        
        var child = await TryGetWorkplaceAddresses(key, updated!);
        
        return Ok(child);
    }
    
    protected async Task<WorkplaceAddressDto?> TryGetWorkplaceAddresses(System.Int64 key, WorkplaceAddressKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).SingleOrDefault();
        return parent?.WorkplaceAddresses.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToCountry([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefWorkplaceToCountryCommand(new WorkplaceKeyDto(key), new CountryKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCountry([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).Include(x => x.Country).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        
        if (entity.Country is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Countries/{entity.Country.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToCountry([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefWorkplaceToCountryCommand(new WorkplaceKeyDto(key), new CountryKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToCountry([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefWorkplaceToCountryCommand(new WorkplaceKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCountry([FromRoute] System.Int64 key, [FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        country.WorkplacesId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CountryDto>> GetCountry(System.Int64 key)
    {
        var query = await _mediator.Send(new GetWorkplaceByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CountryDto>(Enumerable.Empty<CountryDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Country != null).Select(x => x.Country!));
    }
    
    public virtual async Task<ActionResult<CountryDto>> PutToCountry(System.Int64 key, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).Select(x => x.Country).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Country", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCountryCommand(related.Id, country, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCountryByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CountryDto>> PatchToCountry(System.Int64 key, [FromBody] Delta<CountryPartialUpdateDto> country)
    {
        if (!ModelState.IsValid || country is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).Select(x => x.Country).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Country", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CountryPartialUpdateDto>(country);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCountryByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/Workplaces/{key}/Country")]
    public virtual async Task<ActionResult> DeleteToCountry([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).Select(x => x.Country).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCountryByIdCommand(new List<CountryKeyDto> { new CountryKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToTenants([FromRoute] System.Int64 key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefWorkplaceToTenantsCommand(new WorkplaceKeyDto(key), new TenantKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/Workplaces/{key}/Tenants/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTenantsNonConventional([FromRoute] System.Int64 key, [FromBody] ReferencesDto<System.UInt32> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TenantKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefWorkplaceToTenantsCommand(new WorkplaceKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTenants([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).Include(x => x.Tenants).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Tenants)
        {
            references.Add(new System.Uri($"Tenants/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTenants([FromRoute] System.Int64 key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefWorkplaceToTenantsCommand(new WorkplaceKeyDto(key), new TenantKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTenants([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefWorkplaceToTenantsCommand(new WorkplaceKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTenants([FromRoute] System.Int64 key, [FromBody] TenantCreateDto tenant)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        tenant.WorkplacesId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateTenantCommand(tenant, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTenantByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TenantDto>>> GetTenants(System.Int64 key)
    {
        var query = await _mediator.Send(new GetWorkplaceByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Tenants).SelectMany(x => x.Tenants));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Workplaces/{key}/Tenants/{relatedKey}")]
    public virtual async Task<SingleResult<TenantDto>> GetTenantsNonConventional(System.Int64 key, System.UInt32 relatedKey)
    {
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).SelectMany(x => x.Tenants).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TenantDto>(Enumerable.Empty<TenantDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/Workplaces/{key}/Tenants/{relatedKey}")]
    public virtual async Task<ActionResult<TenantDto>> PutToTenantsNonConventional(System.Int64 key, System.UInt32 relatedKey, [FromBody] TenantUpdateDto tenant)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).SelectMany(x => x.Tenants).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Tenants", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTenantCommand(relatedKey, tenant, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTenantByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/Workplaces/{key}/Tenants/{relatedKey}")]
    public virtual async Task<ActionResult<TenantDto>> PatchtoTenantsNonConventional(System.Int64 key, System.UInt32 relatedKey, [FromBody] Delta<TenantPartialUpdateDto> tenant)
    {
        if (!ModelState.IsValid || tenant is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).SelectMany(x => x.Tenants).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Tenants", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TenantPartialUpdateDto>(tenant);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTenantCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTenantByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/Workplaces/{key}/Tenants/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTenants([FromRoute] System.Int64 key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).SelectMany(x => x.Tenants).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Tenants", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTenantByIdCommand(new List<TenantKeyDto> { new TenantKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/Workplaces/{key}/Tenants")]
    public virtual async Task<ActionResult> DeleteToTenants([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(key))).Select(x => x.Tenants).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteTenantByIdCommand(related.Select(item => new TenantKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
