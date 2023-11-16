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

public abstract partial class TestEntityOwnedRelationshipZeroOrOnesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipZeroOrOneDto>> GetSecondTestEntityOwnedRelationshipZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.SecondTestEntityOwnedRelationshipZeroOrOne);
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityOwnedRelationshipZeroOrOne([FromRoute] System.String key, [FromBody] SecondTestEntityOwnedRelationshipZeroOrOneCreateDto secondTestEntityOwnedRelationshipZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(new TestEntityOwnedRelationshipZeroOrOneKeyDto(key), secondTestEntityOwnedRelationshipZeroOrOne, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipZeroOrOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipZeroOrOneDto>> PutToSecondTestEntityOwnedRelationshipZeroOrOne(System.String key, [FromBody] SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto secondTestEntityOwnedRelationshipZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(new TestEntityOwnedRelationshipZeroOrOneKeyDto(key), secondTestEntityOwnedRelationshipZeroOrOne, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipZeroOrOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToSecondTestEntityOwnedRelationshipZeroOrOne(System.String key, [FromBody] Delta<SecondTestEntityOwnedRelationshipZeroOrOneDto> secondTestEntityOwnedRelationshipZeroOrOne)
    {
        if (!ModelState.IsValid || secondTestEntityOwnedRelationshipZeroOrOne is null)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityOwnedRelationshipZeroOrOne.GetChangedPropertyNames())
        {
            if(secondTestEntityOwnedRelationshipZeroOrOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(new TestEntityOwnedRelationshipZeroOrOneKeyDto(key), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipZeroOrOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipZeroOrOnes/{key}/SecondTestEntityOwnedRelationshipZeroOrOne")]
    public virtual async Task<ActionResult> DeleteSecondTestEntityOwnedRelationshipZeroOrOneNonConventional(System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(new TestEntityOwnedRelationshipZeroOrOneKeyDto(key)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
