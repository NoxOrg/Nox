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

public abstract partial class TestEntityOwnedRelationshipOneOrManiesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecEntityOwnedRelOneOrManyDto>>> GetSecEntityOwnedRelOneOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("TestEntityOwnedRelationshipOneOrMany", $"{key.ToString()}");
        }
        
        return Ok(item.SecEntityOwnedRelOneOrManies);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOwnedRelationshipOneOrManies/{key}/SecEntityOwnedRelOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecEntityOwnedRelOneOrManyDto>> GetSecEntityOwnedRelOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetSecEntityOwnedRelOneOrManies(key, new SecEntityOwnedRelOneOrManyKeyDto(relatedKey));
        if (child is null)
        {
            throw new EntityNotFoundException("SecEntityOwnedRelOneOrMany", $"{relatedKey.ToString()}");
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToSecEntityOwnedRelOneOrManies([FromRoute] System.String key, [FromBody] SecEntityOwnedRelOneOrManyUpsertDto secEntityOwnedRelOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), secEntityOwnedRelOneOrMany, _cultureCode, etag));
        
        var child = await TryGetSecEntityOwnedRelOneOrManies(key, createdKey);
        return Created(child);
    }
    
    public virtual async Task<ActionResult<SecEntityOwnedRelOneOrManyDto>> PutToSecEntityOwnedRelOneOrManies(System.String key, [FromBody] EntityDtoCollection<SecEntityOwnedRelOneOrManyUpsertDto> secEntityOwnedRelOneOrManies)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKeys = await _mediator.Send(new UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), secEntityOwnedRelOneOrManies.Values!, _cultureCode, etag));
        
        var children = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key))).SingleOrDefault()?.SecEntityOwnedRelOneOrManies?.Where(e => updatedKeys.Any(k => e.Id == k.keyId));
        
        return Ok(children);
    }
    
    public virtual async Task<ActionResult> PatchToSecEntityOwnedRelOneOrManies(System.String key, [FromBody] Delta<SecEntityOwnedRelOneOrManyUpsertDto> secEntityOwnedRelOneOrMany)
    {
        if (!ModelState.IsValid || secEntityOwnedRelOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<SecEntityOwnedRelOneOrManyUpsertDto>(secEntityOwnedRelOneOrMany);
        
        if(!updatedProperties.ContainsKey("Id") || updatedProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecEntityOwnedRelOneOrManyKeyDto(updatedProperties["Id"]), updatedProperties, _cultureCode, etag));
        
        var child = await TryGetSecEntityOwnedRelOneOrManies(key, updated!);
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipOneOrManies/{key}/SecEntityOwnedRelOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteSecEntityOwnedRelOneOrManyNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecEntityOwnedRelOneOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<SecEntityOwnedRelOneOrManyDto?> TryGetSecEntityOwnedRelOneOrManies(System.String key, SecEntityOwnedRelOneOrManyKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key))).SingleOrDefault();
        return parent?.SecEntityOwnedRelOneOrManies.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
}
