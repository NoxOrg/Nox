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

public abstract partial class EntityUniqueConstraintsWithForeignKeysControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToEntityUniqueConstraintsRelatedForeignKey([FromRoute] System.Guid key, [FromRoute] System.Int32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(new EntityUniqueConstraintsWithForeignKeyKeyDto(key), new EntityUniqueConstraintsRelatedForeignKeyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToEntityUniqueConstraintsRelatedForeignKey([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(key))).Select(x => x.EntityUniqueConstraintsRelatedForeignKey).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"EntityUniqueConstraintsRelatedForeignKeys/{related.Id}", UriKind.Relative);
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
        var related = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(key))).Where(x => x.EntityUniqueConstraintsRelatedForeignKey != null);
        if (!related.Any())
        {
            return SingleResult.Create<EntityUniqueConstraintsRelatedForeignKeyDto>(Enumerable.Empty<EntityUniqueConstraintsRelatedForeignKeyDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.EntityUniqueConstraintsRelatedForeignKey!));
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateEntityUniqueConstraintsRelatedForeignKeyCommand(related.Id, entityUniqueConstraintsRelatedForeignKey, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
