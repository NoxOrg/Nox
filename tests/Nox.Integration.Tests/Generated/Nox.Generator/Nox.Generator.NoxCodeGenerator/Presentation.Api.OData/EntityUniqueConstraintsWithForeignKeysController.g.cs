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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class EntityUniqueConstraintsWithForeignKeysControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToEntityUniqueConstraintsRelatedForeignKey([FromRoute] System.Guid key, [FromRoute] System.Int32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(new EntityUniqueConstraintsWithForeignKeyKeyDto(key), new EntityUniqueConstraintsRelatedForeignKeyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToEntityUniqueConstraintsRelatedForeignKey([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(key))).Include(x => x.EntityUniqueConstraintsRelatedForeignKey).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey", $"{key.ToString()}");
        }
        
        if (entity.EntityUniqueConstraintsRelatedForeignKey is null)
        {
            return Ok();
        }
        var references = new System.Uri($"EntityUniqueConstraintsRelatedForeignKeys/{entity.EntityUniqueConstraintsRelatedForeignKey.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToEntityUniqueConstraintsRelatedForeignKey([FromRoute] System.Guid key, [FromBody] EntityUniqueConstraintsRelatedForeignKeyCreateDto entityUniqueConstraintsRelatedForeignKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        entityUniqueConstraintsRelatedForeignKey.EntityUniqueConstraintsWithForeignKeysId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateEntityUniqueConstraintsRelatedForeignKeyCommand(entityUniqueConstraintsRelatedForeignKey, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<EntityUniqueConstraintsRelatedForeignKeyDto>> GetEntityUniqueConstraintsRelatedForeignKey(System.Guid key)
    {
        var query = await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<EntityUniqueConstraintsRelatedForeignKeyDto>(Enumerable.Empty<EntityUniqueConstraintsRelatedForeignKeyDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.EntityUniqueConstraintsRelatedForeignKey != null).Select(x => x.EntityUniqueConstraintsRelatedForeignKey!));
    }
    
    public virtual async Task<ActionResult<EntityUniqueConstraintsRelatedForeignKeyDto>> PutToEntityUniqueConstraintsRelatedForeignKey(System.Guid key, [FromBody] EntityUniqueConstraintsRelatedForeignKeyUpdateDto entityUniqueConstraintsRelatedForeignKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(key))).Select(x => x.EntityUniqueConstraintsRelatedForeignKey).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateEntityUniqueConstraintsRelatedForeignKeyCommand(related.Id, entityUniqueConstraintsRelatedForeignKey, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<EntityUniqueConstraintsRelatedForeignKeyDto>> PatchToEntityUniqueConstraintsRelatedForeignKey(System.Guid key, [FromBody] Delta<EntityUniqueConstraintsRelatedForeignKeyPartialUpdateDto> entityUniqueConstraintsRelatedForeignKey)
    {
        if (!ModelState.IsValid || entityUniqueConstraintsRelatedForeignKey is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(key))).Select(x => x.EntityUniqueConstraintsRelatedForeignKey).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey", String.Empty);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in entityUniqueConstraintsRelatedForeignKey.GetChangedPropertyNames())
        {
            if(entityUniqueConstraintsRelatedForeignKey.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateEntityUniqueConstraintsRelatedForeignKeyCommand(related.Id, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
