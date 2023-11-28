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

public abstract partial class StoresControllerBase : ODataController
{
    
    #region Owned Relationships
    
    #endregion
    
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToStoreOwner([FromRoute] System.Guid key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreToStoreOwnerCommand(new StoreKeyDto(key), new StoreOwnerKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToStoreOwner([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreOwner).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"StoreOwners/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToStoreOwner([FromRoute] System.Guid key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreToStoreOwnerCommand(new StoreKeyDto(key), new StoreOwnerKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToStoreOwner([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreToStoreOwnerCommand(new StoreKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStoreOwner([FromRoute] System.Guid key, [FromBody] StoreOwnerCreateDto storeOwner)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        storeOwner.StoresId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateStoreOwnerCommand(storeOwner, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreOwnerByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<StoreOwnerDto>> GetStoreOwner(System.Guid key)
    {
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Where(x => x.StoreOwner != null);
        if (!related.Any())
        {
            return SingleResult.Create<StoreOwnerDto>(Enumerable.Empty<StoreOwnerDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.StoreOwner!));
    }
    
    public virtual async Task<ActionResult<StoreOwnerDto>> PutToStoreOwner(System.Guid key, [FromBody] StoreOwnerUpdateDto storeOwner)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreOwner).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreOwnerCommand(related.Id, storeOwner, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/Stores/{key}/StoreOwner")]
    public async Task<ActionResult> DeleteToStoreOwner([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreOwner).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteStoreOwnerByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToStoreLicense([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreToStoreLicenseCommand(new StoreKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToStoreLicense([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreLicense).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"StoreLicenses/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToStoreLicense([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreToStoreLicenseCommand(new StoreKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToStoreLicense([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreToStoreLicenseCommand(new StoreKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStoreLicense([FromRoute] System.Guid key, [FromBody] StoreLicenseCreateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        storeLicense.StoreId = key;
        var createdKey = await _mediator.Send(new CreateStoreLicenseCommand(storeLicense, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<StoreLicenseDto>> GetStoreLicense(System.Guid key)
    {
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Where(x => x.StoreLicense != null);
        if (!related.Any())
        {
            return SingleResult.Create<StoreLicenseDto>(Enumerable.Empty<StoreLicenseDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.StoreLicense!));
    }
    
    public virtual async Task<ActionResult<StoreLicenseDto>> PutToStoreLicense(System.Guid key, [FromBody] StoreLicenseUpdateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreLicense).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreLicenseCommand(related.Id, storeLicense, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/Stores/{key}/StoreLicense")]
    public async Task<ActionResult> DeleteToStoreLicense([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreLicense).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteStoreLicenseByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    #endregion
    
}
