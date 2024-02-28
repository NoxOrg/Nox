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

public abstract partial class TenantsControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TenantBrandDto>>> GetTenantBrands([FromRoute] System.UInt32 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetTenantByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }
        
        return Ok(item.TenantBrands);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Tenants/{key}/TenantBrands/{relatedKey}")]
    public virtual async Task<ActionResult<TenantBrandDto>> GetTenantBrandsNonConventional(System.UInt32 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetTenantBrands(key, new TenantBrandKeyDto(relatedKey));
        if (child is null)
        {
            throw new EntityNotFoundException("TenantBrand", $"{relatedKey.ToString()}");
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToTenantBrands([FromRoute] System.UInt32 key, [FromBody] TenantBrandUpsertDto tenantBrand)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateTenantBrandsForTenantCommand(new TenantKeyDto(key), tenantBrand, _cultureCode, etag));
        
        var child = await TryGetTenantBrands(key, createdKey);
        return Created(child);
    }
    
    public virtual async Task<ActionResult<TenantBrandDto>> PutToTenantBrands(System.UInt32 key, [FromBody] TenantBrandUpsertDto[] tenantBrands)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTenantBrandsForTenantCommand(new TenantKeyDto(key), tenantBrands, _cultureCode, etag));
        
        return Ok();
    }
    
    public virtual async Task<ActionResult> PatchToTenantBrands(System.UInt32 key, [FromBody] Delta<TenantBrandUpsertDto> tenantBrand)
    {
        if (!ModelState.IsValid || tenantBrand is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TenantBrandUpsertDto>(tenantBrand);
        
        if(!updatedProperties.ContainsKey("Id") || updatedProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTenantBrandsForTenantCommand(new TenantKeyDto(key), new TenantBrandKeyDto(updatedProperties["Id"]), updatedProperties, _cultureCode, etag));
        
        var child = await TryGetTenantBrands(key, updated!);
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/Tenants/{key}/TenantBrands/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteTenantBrandNonConventional(System.UInt32 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteTenantBrandsForTenantCommand(new TenantKeyDto(key), new TenantBrandKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<TenantBrandDto?> TryGetTenantBrands(System.UInt32 key, TenantBrandKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetTenantByIdQuery(key))).SingleOrDefault();
        return parent?.TenantBrands.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<TenantContactDto>> GetTenantContact([FromRoute] System.UInt32 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetTenantByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }
        
        return Ok(item.TenantContact);
    }
    
    public virtual async Task<ActionResult> PostToTenantContact([FromRoute] System.UInt32 key, [FromBody] TenantContactUpsertDto tenantContact)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateTenantContactForTenantCommand(new TenantKeyDto(key), tenantContact, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetTenantByIdQuery(key))).SingleOrDefault()?.TenantContact;
        return Created(child);
    }
    
    public virtual async Task<ActionResult<TenantContactDto>> PutToTenantContact(System.UInt32 key, [FromBody] TenantContactUpsertDto tenantContact)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTenantContactForTenantCommand(new TenantKeyDto(key), tenantContact, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetTenantByIdQuery(key))).SingleOrDefault()?.TenantContact;
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToTenantContact(System.UInt32 key, [FromBody] Delta<TenantContactUpsertDto> tenantContact)
    {
        if (!ModelState.IsValid || tenantContact is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TenantContactUpsertDto>(tenantContact);
        
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTenantContactForTenantCommand(new TenantKeyDto(key), updatedProperties, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetTenantByIdQuery(key))).SingleOrDefault()?.TenantContact;
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/Tenants/{key}/TenantContact")]
    public virtual async Task<ActionResult> DeleteTenantContactNonConventional(System.UInt32 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteTenantContactForTenantCommand(new TenantKeyDto(key)));
        
        return NoContent();
    }
    
    #endregion
    
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToWorkplaces([FromRoute] System.UInt32 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTenantToWorkplacesCommand(new TenantKeyDto(key), new WorkplaceKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/Tenants/{key}/Workplaces/$ref")]
    public virtual async Task<ActionResult> UpdateRefToWorkplacesNonConventional([FromRoute] System.UInt32 key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new WorkplaceKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTenantToWorkplacesCommand(new TenantKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToWorkplaces([FromRoute] System.UInt32 key)
    {
        var entity = (await _mediator.Send(new GetTenantByIdQuery(key))).Include(x => x.Workplaces).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Workplaces)
        {
            references.Add(new System.Uri($"Workplaces/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToWorkplaces([FromRoute] System.UInt32 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTenantToWorkplacesCommand(new TenantKeyDto(key), new WorkplaceKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToWorkplaces([FromRoute] System.UInt32 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTenantToWorkplacesCommand(new TenantKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToWorkplaces([FromRoute] System.UInt32 key, [FromBody] WorkplaceCreateDto workplace)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        workplace.TenantsId = new List<System.UInt32> { key };
        var createdKey = await _mediator.Send(new CreateWorkplaceCommand(workplace, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetWorkplaceByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<WorkplaceDto>>> GetWorkplaces(System.UInt32 key)
    {
        var query = await _mediator.Send(new GetTenantByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Workplaces).SelectMany(x => x.Workplaces));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Tenants/{key}/Workplaces/{relatedKey}")]
    public virtual async Task<SingleResult<WorkplaceDto>> GetWorkplacesNonConventional(System.UInt32 key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetTenantByIdQuery(key))).SelectMany(x => x.Workplaces).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<WorkplaceDto>(Enumerable.Empty<WorkplaceDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/Tenants/{key}/Workplaces/{relatedKey}")]
    public virtual async Task<ActionResult<WorkplaceDto>> PutToWorkplacesNonConventional(System.UInt32 key, System.Int64 relatedKey, [FromBody] WorkplaceUpdateDto workplace)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTenantByIdQuery(key))).SelectMany(x => x.Workplaces).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Workplaces", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateWorkplaceCommand(relatedKey, workplace, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetWorkplaceByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/Tenants/{key}/Workplaces/{relatedKey}")]
    public virtual async Task<ActionResult<WorkplaceDto>> PatchtoWorkplacesNonConventional(System.UInt32 key, System.Int64 relatedKey, [FromBody] Delta<WorkplacePartialUpdateDto> workplace)
    {
        if (!ModelState.IsValid || workplace is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTenantByIdQuery(key))).SelectMany(x => x.Workplaces).Any(x => x.Id == relatedKey);
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
    
    [HttpDelete("/api/v1/Tenants/{key}/Workplaces/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToWorkplaces([FromRoute] System.UInt32 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTenantByIdQuery(key))).SelectMany(x => x.Workplaces).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Workplaces", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteWorkplaceByIdCommand(new List<WorkplaceKeyDto> { new WorkplaceKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/Tenants/{key}/Workplaces")]
    public virtual async Task<ActionResult> DeleteToWorkplaces([FromRoute] System.UInt32 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTenantByIdQuery(key))).Select(x => x.Workplaces).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteWorkplaceByIdCommand(related.Select(item => new WorkplaceKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
