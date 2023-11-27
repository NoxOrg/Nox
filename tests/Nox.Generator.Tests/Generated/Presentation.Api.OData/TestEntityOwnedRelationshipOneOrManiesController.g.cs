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

public abstract partial class TestEntityOwnedRelationshipOneOrManiesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityOwnedRelationshipOneOrManyDto>>> GetSecondTestEntityOwnedRelationshipOneOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.SecondTestEntityOwnedRelationshipOneOrManies);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOwnedRelationshipOneOrManies/{key}/SecondTestEntityOwnedRelationshipOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipOneOrManyDto>> GetSecondTestEntityOwnedRelationshipOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetSecondTestEntityOwnedRelationshipOneOrManies(key, new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityOwnedRelationshipOneOrManies([FromRoute] System.String key, [FromBody] SecondTestEntityOwnedRelationshipOneOrManyUpsertDto secondTestEntityOwnedRelationshipOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), secondTestEntityOwnedRelationshipOneOrMany, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetSecondTestEntityOwnedRelationshipOneOrManies(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("/api/v1/TestEntityOwnedRelationshipOneOrManies/{key}/SecondTestEntityOwnedRelationshipOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipOneOrManyDto>> PutToSecondTestEntityOwnedRelationshipOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityOwnedRelationshipOneOrManyUpsertDto secondTestEntityOwnedRelationshipOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(relatedKey), secondTestEntityOwnedRelationshipOneOrMany, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetSecondTestEntityOwnedRelationshipOneOrManies(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("/api/v1/TestEntityOwnedRelationshipOneOrManies/{key}/SecondTestEntityOwnedRelationshipOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToSecondTestEntityOwnedRelationshipOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<SecondTestEntityOwnedRelationshipOneOrManyUpsertDto> secondTestEntityOwnedRelationshipOneOrMany)
    {
        if (!ModelState.IsValid || secondTestEntityOwnedRelationshipOneOrMany is null)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityOwnedRelationshipOneOrMany.GetChangedPropertyNames())
        {
            if(secondTestEntityOwnedRelationshipOneOrMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetSecondTestEntityOwnedRelationshipOneOrManies(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipOneOrManies/{key}/SecondTestEntityOwnedRelationshipOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteSecondTestEntityOwnedRelationshipOneOrManyNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecondTestEntityOwnedRelationshipOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    protected async Task<SecondTestEntityOwnedRelationshipOneOrManyDto?> TryGetSecondTestEntityOwnedRelationshipOneOrManies(System.String key, SecondTestEntityOwnedRelationshipOneOrManyKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key))).SingleOrDefault();
        return parent?.SecondTestEntityOwnedRelationshipOneOrManies.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
}
