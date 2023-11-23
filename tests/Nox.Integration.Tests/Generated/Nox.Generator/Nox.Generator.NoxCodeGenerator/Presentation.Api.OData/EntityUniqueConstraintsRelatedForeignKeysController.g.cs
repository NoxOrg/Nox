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
using Nox.Extensions;
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class EntityUniqueConstraintsRelatedForeignKeysControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(new EntityUniqueConstraintsRelatedForeignKeyKeyDto(key), new EntityUniqueConstraintsWithForeignKeyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key)
    {
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).Select(x => x.EntityUniqueConstraintsWithForeignKeys).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"EntityUniqueConstraintsWithForeignKeys/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(new EntityUniqueConstraintsRelatedForeignKeyKeyDto(key), new EntityUniqueConstraintsWithForeignKeyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(new EntityUniqueConstraintsRelatedForeignKeyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key, [FromBody] EntityUniqueConstraintsWithForeignKeyCreateDto entityUniqueConstraintsWithForeignKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        entityUniqueConstraintsWithForeignKey.EntityUniqueConstraintsRelatedForeignKeyId = key;
        var createdKey = await _mediator.Send(new CreateEntityUniqueConstraintsWithForeignKeyCommand(entityUniqueConstraintsWithForeignKey, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>> GetEntityUniqueConstraintsWithForeignKeys(System.Int32 key)
    {
        var entity = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).SelectMany(x => x.EntityUniqueConstraintsWithForeignKeys);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/EntityUniqueConstraintsRelatedForeignKeys/{key}/EntityUniqueConstraintsWithForeignKeys/{relatedKey}")]
    public virtual async Task<SingleResult<EntityUniqueConstraintsWithForeignKeyDto>> GetEntityUniqueConstraintsWithForeignKeysNonConventional(System.Int32 key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).SelectMany(x => x.EntityUniqueConstraintsWithForeignKeys).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<EntityUniqueConstraintsWithForeignKeyDto>(Enumerable.Empty<EntityUniqueConstraintsWithForeignKeyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/EntityUniqueConstraintsRelatedForeignKeys/{key}/EntityUniqueConstraintsWithForeignKeys/{relatedKey}")]
    public virtual async Task<ActionResult<EntityUniqueConstraintsWithForeignKeyDto>> PutToEntityUniqueConstraintsWithForeignKeysNonConventional(System.Int32 key, System.Guid relatedKey, [FromBody] EntityUniqueConstraintsWithForeignKeyUpdateDto entityUniqueConstraintsWithForeignKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).SelectMany(x => x.EntityUniqueConstraintsWithForeignKeys).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateEntityUniqueConstraintsWithForeignKeyCommand(relatedKey, entityUniqueConstraintsWithForeignKey, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/EntityUniqueConstraintsRelatedForeignKeys/{key}/EntityUniqueConstraintsWithForeignKeys/{relatedKey}")]
    public async Task<ActionResult> DeleteToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).SelectMany(x => x.EntityUniqueConstraintsWithForeignKeys).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/EntityUniqueConstraintsRelatedForeignKeys/{key}/EntityUniqueConstraintsWithForeignKeys")]
    public async Task<ActionResult> DeleteToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).Select(x => x.EntityUniqueConstraintsWithForeignKeys).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    #endregion
    
}