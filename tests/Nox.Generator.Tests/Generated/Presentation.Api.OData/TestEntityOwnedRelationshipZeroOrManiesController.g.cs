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
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityOwnedRelationshipZeroOrManyDto>>> GetSecondTestEntityOwnedRelationshipZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.SecondTestEntityOwnedRelationshipZeroOrManies);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOwnedRelationshipZeroOrManies/{key}/SecondTestEntityOwnedRelationshipZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipZeroOrManyDto>> GetSecondTestEntityOwnedRelationshipZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetSecondTestEntityOwnedRelationshipZeroOrManies(key, new SecondTestEntityOwnedRelationshipZeroOrManyKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityOwnedRelationshipZeroOrManies([FromRoute] System.String key, [FromBody] SecondTestEntityOwnedRelationshipZeroOrManyCreateDto secondTestEntityOwnedRelationshipZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), secondTestEntityOwnedRelationshipZeroOrMany, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetSecondTestEntityOwnedRelationshipZeroOrManies(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("/api/v1/TestEntityOwnedRelationshipZeroOrManies/{key}/SecondTestEntityOwnedRelationshipZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipZeroOrManyDto>> PutToSecondTestEntityOwnedRelationshipZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto secondTestEntityOwnedRelationshipZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), new SecondTestEntityOwnedRelationshipZeroOrManyKeyDto(relatedKey), secondTestEntityOwnedRelationshipZeroOrMany, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetSecondTestEntityOwnedRelationshipZeroOrManies(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("/api/v1/TestEntityOwnedRelationshipZeroOrManies/{key}/SecondTestEntityOwnedRelationshipZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToSecondTestEntityOwnedRelationshipZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto> secondTestEntityOwnedRelationshipZeroOrMany)
    {
        if (!ModelState.IsValid || secondTestEntityOwnedRelationshipZeroOrMany is null)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityOwnedRelationshipZeroOrMany.GetChangedPropertyNames())
        {
            if(secondTestEntityOwnedRelationshipZeroOrMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), new SecondTestEntityOwnedRelationshipZeroOrManyKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetSecondTestEntityOwnedRelationshipZeroOrManies(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipZeroOrManies/{key}/SecondTestEntityOwnedRelationshipZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteSecondTestEntityOwnedRelationshipZeroOrManyNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecondTestEntityOwnedRelationshipZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), new SecondTestEntityOwnedRelationshipZeroOrManyKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    protected async Task<SecondTestEntityOwnedRelationshipZeroOrManyDto?> TryGetSecondTestEntityOwnedRelationshipZeroOrManies(System.String key, SecondTestEntityOwnedRelationshipZeroOrManyKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(key))).SingleOrDefault();
        return parent?.SecondTestEntityOwnedRelationshipZeroOrManies.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
}