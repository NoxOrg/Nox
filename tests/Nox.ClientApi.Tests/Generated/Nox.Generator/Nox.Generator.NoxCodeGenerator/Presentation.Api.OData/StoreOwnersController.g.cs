// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
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

public abstract partial class StoreOwnersControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToStores([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreOwnerToStoresCommand(new StoreOwnerKeyDto(key), new StoreKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/StoreOwners/{key}/Stores/$ref")]
    public virtual async Task<ActionResult> UpdateRefToStoresNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new StoreKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefStoreOwnerToStoresCommand(new StoreOwnerKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToStores([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetStoreOwnerByIdQuery(key))).Include(x => x.Stores).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("StoreOwner", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Stores)
        {
            references.Add(new System.Uri($"Stores/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToStores([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreOwnerToStoresCommand(new StoreOwnerKeyDto(key), new StoreKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStores([FromRoute] System.String key, [FromBody] StoreCreateDto store)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        store.StoreOwnerId = key;
        var createdKey = await _mediator.Send(new CreateStoreCommand(store, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreDto>>> GetStores(System.String key)
    {
        var query = await _mediator.Send(new GetStoreOwnerByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("StoreOwner", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Stores).SelectMany(x => x.Stores));
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
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreOwnerByIdQuery(key))).SelectMany(x => x.Stores).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Stores", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreCommand(relatedKey, store, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/StoreOwners/{key}/Stores/{relatedKey}")]
    public virtual async Task<ActionResult<StoreDto>> PatchtoStoresNonConventional(System.String key, System.Guid relatedKey, [FromBody] Delta<StorePartialUpdateDto> store)
    {
        if (!ModelState.IsValid || store is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreOwnerByIdQuery(key))).SelectMany(x => x.Stores).Any(x => x.Id == relatedKey);
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
    
    [HttpDelete("/api/v1/StoreOwners/{key}/Stores/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToStores([FromRoute] System.String key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreOwnerByIdQuery(key))).SelectMany(x => x.Stores).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Stores", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteStoreByIdCommand(new List<StoreKeyDto> { new StoreKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    #endregion
    
}
