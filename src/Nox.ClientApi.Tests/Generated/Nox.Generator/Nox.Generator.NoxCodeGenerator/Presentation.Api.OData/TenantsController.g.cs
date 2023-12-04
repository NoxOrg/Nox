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
            return NotFound();
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
        if (child == null)
        {
            return NotFound();
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
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetTenantBrands(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    public virtual async Task<ActionResult<TenantBrandDto>> PutToTenantBrands(System.UInt32 key, [FromBody] TenantBrandUpsertDto tenantBrand)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTenantBrandsForTenantCommand(new TenantKeyDto(key), tenantBrand, _cultureCode, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetTenantBrands(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToTenantBrands(System.UInt32 key, [FromBody] Delta<TenantBrandUpsertDto> tenantBrand)
    {
        if (!ModelState.IsValid || tenantBrand is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in tenantBrand.GetChangedPropertyNames())
        {
            if(tenantBrand.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        if(!updateProperties.ContainsKey("Id") || updateProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTenantBrandsForTenantCommand(new TenantKeyDto(key), new TenantBrandKeyDto(updateProperties["Id"]), updateProperties, _cultureCode, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetTenantBrands(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
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
        if (!result)
        {
            return NotFound();
        }
        
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
            return NotFound();
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
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTenantByIdQuery(key))).SingleOrDefault()?.TenantContact;
        if (child == null)
        {
            return NotFound();
        }
        
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
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTenantByIdQuery(key))).SingleOrDefault()?.TenantContact;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToTenantContact(System.UInt32 key, [FromBody] Delta<TenantContactUpsertDto> tenantContact)
    {
        if (!ModelState.IsValid || tenantContact is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in tenantContact.GetChangedPropertyNames())
        {
            if(tenantContact.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTenantContactForTenantCommand(new TenantKeyDto(key), updateProperties, _cultureCode, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = (await _mediator.Send(new GetTenantByIdQuery(key))).SingleOrDefault()?.TenantContact;
        if (child == null)
        {
            return NotFound();
        }
        
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
        if (!result)
        {
            return NotFound();
        }
        
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
        if (!createdRef)
        {
            return NotFound();
        }
        
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
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToWorkplaces([FromRoute] System.UInt32 key)
    {
        var related = (await _mediator.Send(new GetTenantByIdQuery(key))).Select(x => x.Workplaces).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
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
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToWorkplaces([FromRoute] System.UInt32 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTenantToWorkplacesCommand(new TenantKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
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
        var entity = (await _mediator.Send(new GetTenantByIdQuery(key))).SelectMany(x => x.Workplaces);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateWorkplaceCommand(relatedKey, workplace, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteWorkplaceByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteWorkplaceByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    #endregion
    
}
