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
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class StoreOwnersControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToStores([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreOwnerToStoresCommand(new StoreOwnerKeyDto(key), new StoreKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToStores([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetStoreOwnerByIdQuery(key))).Select(x => x.Stores).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"Stores/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToStores([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreOwnerToStoresCommand(new StoreOwnerKeyDto(key), new StoreKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStores([FromRoute] System.String key, [FromBody] StoreCreateDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        store.StoreOwnerId = key;
        var createdKey = await _mediator.Send(new CreateStoreCommand(store, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreDto>>> GetStores(System.String key)
    {
        var entity = (await _mediator.Send(new GetStoreOwnerByIdQuery(key))).SelectMany(x => x.Stores);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/StoreOwners/{key}/Stores/{relatedKey}")]
    public virtual async Task<SingleResult<StoreDto>> GetStoresNonConventional(System.String key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetStoreOwnerByIdQuery(key))).SelectMany(x => x.Stores).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<StoreDto>(Enumerable.Empty<StoreDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/StoreOwners/{key}/Stores/{relatedKey}")]
    public virtual async Task<ActionResult<StoreDto>> PutToStoresNonConventional(System.String key, System.Guid relatedKey, [FromBody] StoreUpdateDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreOwnerByIdQuery(key))).SelectMany(x => x.Stores).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreCommand(relatedKey, store, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/StoreOwners/{key}/Stores/{relatedKey}")]
    public async Task<ActionResult> DeleteToStores([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreOwnerByIdQuery(key))).SelectMany(x => x.Stores).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteStoreByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
