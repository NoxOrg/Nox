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

public abstract partial class TestEntityOwnedRelationshipZeroOrManiesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecEntityOwnedRelZeroOrManyDto>>> GetSecEntityOwnedRelZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrMany", $"{key.ToString()}");
        }
        
        return Ok(item.SecEntityOwnedRelZeroOrManies);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOwnedRelationshipZeroOrManies/{key}/SecEntityOwnedRelZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecEntityOwnedRelZeroOrManyDto>> GetSecEntityOwnedRelZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetSecEntityOwnedRelZeroOrManies(key, new SecEntityOwnedRelZeroOrManyKeyDto(relatedKey));
        if (child is null)
        {
            throw new EntityNotFoundException("SecEntityOwnedRelZeroOrMany", $"{relatedKey.ToString()}");
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToSecEntityOwnedRelZeroOrManies([FromRoute] System.String key, [FromBody] SecEntityOwnedRelZeroOrManyUpsertDto secEntityOwnedRelZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), secEntityOwnedRelZeroOrMany, _cultureCode, etag));
        
        var child = await TryGetSecEntityOwnedRelZeroOrManies(key, createdKey);
        return Created(child);
    }
    
    public virtual async Task<ActionResult<SecEntityOwnedRelZeroOrManyDto>> PutToSecEntityOwnedRelZeroOrManies(System.String key, [FromBody] EntityDtoCollection<SecEntityOwnedRelZeroOrManyUpsertDto> secEntityOwnedRelZeroOrManies)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKeys = await _mediator.Send(new UpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), secEntityOwnedRelZeroOrManies.Values!, _cultureCode, etag));
        
        var children = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(key))).SingleOrDefault()?.SecEntityOwnedRelZeroOrManies?.Where(e => updatedKeys.Any(k => e.Id == k.keyId));
        
        return Ok(children);
    }
    
    [HttpPut("/api/v1/TestEntityOwnedRelationshipZeroOrManies/{key}/SecEntityOwnedRelZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecEntityOwnedRelZeroOrManyDto>> PutToSecEntityOwnedRelZeroOrManyNonConventional(System.String key, System.String relatedKey, [FromBody] SecEntityOwnedRelZeroOrManyUpsertDto secEntityOwnedRelZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        secEntityOwnedRelZeroOrMany.Id = relatedKey;
        var updatedKey = await _mediator.Send(new UpdateSecEntityOwnedRelZeroOrManyForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), secEntityOwnedRelZeroOrMany, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(key))).SingleOrDefault()?.SecEntityOwnedRelZeroOrManies?.SingleOrDefault(e => e.Id == updatedKey.keyId);
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToSecEntityOwnedRelZeroOrManies(System.String key, [FromBody] Delta<SecEntityOwnedRelZeroOrManyUpsertDto> secEntityOwnedRelZeroOrMany)
    {
        if (!ModelState.IsValid || secEntityOwnedRelZeroOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<SecEntityOwnedRelZeroOrManyUpsertDto>(secEntityOwnedRelZeroOrMany);
        
        if(!updatedProperties.ContainsKey("Id") || updatedProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), new SecEntityOwnedRelZeroOrManyKeyDto(updatedProperties["Id"]), updatedProperties, _cultureCode, etag));
        
        var child = await TryGetSecEntityOwnedRelZeroOrManies(key, updated!);
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipZeroOrManies/{key}/SecEntityOwnedRelZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteSecEntityOwnedRelZeroOrManyNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), new SecEntityOwnedRelZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<SecEntityOwnedRelZeroOrManyDto?> TryGetSecEntityOwnedRelZeroOrManies(System.String key, SecEntityOwnedRelZeroOrManyKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(key))).SingleOrDefault();
        return parent?.SecEntityOwnedRelZeroOrManies.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
}
