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
    
    public virtual async Task<ActionResult> CreateRefToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(new EntityUniqueConstraintsRelatedForeignKeyKeyDto(key), new EntityUniqueConstraintsWithForeignKeyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/EntityUniqueConstraintsRelatedForeignKeys/{key}/EntityUniqueConstraintsWithForeignKeys/$ref")]
    public virtual async Task<ActionResult> UpdateRefToEntityUniqueConstraintsWithForeignKeysNonConventional([FromRoute] System.Int32 key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new EntityUniqueConstraintsWithForeignKeyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(new EntityUniqueConstraintsRelatedForeignKeyKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key)
    {
        var entity = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).Include(x => x.EntityUniqueConstraintsWithForeignKeys).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.EntityUniqueConstraintsWithForeignKeys)
        {
            references.Add(new System.Uri($"EntityUniqueConstraintsWithForeignKeys/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(new EntityUniqueConstraintsRelatedForeignKeyKeyDto(key), new EntityUniqueConstraintsWithForeignKeyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        entityUniqueConstraintsWithForeignKey.EntityUniqueConstraintsRelatedForeignKeyId = key;
        var createdKey = await _mediator.Send(new CreateEntityUniqueConstraintsWithForeignKeyCommand(entityUniqueConstraintsWithForeignKey, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>> GetEntityUniqueConstraintsWithForeignKeys(System.Int32 key)
    {
        var query = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).Include(x => x.EntityUniqueConstraintsWithForeignKeys);
        var entity = query.SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        return Ok(query.SelectMany(x => x.EntityUniqueConstraintsWithForeignKeys));
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
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
        
        var updatedItem = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/EntityUniqueConstraintsRelatedForeignKeys/{key}/EntityUniqueConstraintsWithForeignKeys/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).SelectMany(x => x.EntityUniqueConstraintsWithForeignKeys).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand(new List<EntityUniqueConstraintsWithForeignKeyKeyDto> { new EntityUniqueConstraintsWithForeignKeyKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/EntityUniqueConstraintsRelatedForeignKeys/{key}/EntityUniqueConstraintsWithForeignKeys")]
    public virtual async Task<ActionResult> DeleteToEntityUniqueConstraintsWithForeignKeys([FromRoute] System.Int32 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key))).Select(x => x.EntityUniqueConstraintsWithForeignKeys).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand(related.Select(item => new EntityUniqueConstraintsWithForeignKeyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
