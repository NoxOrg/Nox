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

public abstract partial class TestEntityOwnedRelationshipExactlyOnesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipExactlyOneDto>> GetSecondTestEntityOwnedRelationshipExactlyOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.SecondTestEntityOwnedRelationshipExactlyOne);
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityOwnedRelationshipExactlyOne([FromRoute] System.String key, [FromBody] SecondTestEntityOwnedRelationshipExactlyOneUpsertDto secondTestEntityOwnedRelationshipExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key), secondTestEntityOwnedRelationshipExactlyOne, _cultureCode, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipExactlyOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipExactlyOneDto>> PutToSecondTestEntityOwnedRelationshipExactlyOne(System.String key, [FromBody] SecondTestEntityOwnedRelationshipExactlyOneUpsertDto secondTestEntityOwnedRelationshipExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key), secondTestEntityOwnedRelationshipExactlyOne, _cultureCode, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipExactlyOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToSecondTestEntityOwnedRelationshipExactlyOne(System.String key, [FromBody] Delta<SecondTestEntityOwnedRelationshipExactlyOneDto> secondTestEntityOwnedRelationshipExactlyOne)
    {
        if (!ModelState.IsValid || secondTestEntityOwnedRelationshipExactlyOne is null)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityOwnedRelationshipExactlyOne.GetChangedPropertyNames())
        {
            if(secondTestEntityOwnedRelationshipExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key), updateProperties, _cultureCode, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipExactlyOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipExactlyOnes/{key}/SecondTestEntityOwnedRelationshipExactlyOne")]
    public virtual async Task<ActionResult> DeleteSecondTestEntityOwnedRelationshipExactlyOneNonConventional(System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
