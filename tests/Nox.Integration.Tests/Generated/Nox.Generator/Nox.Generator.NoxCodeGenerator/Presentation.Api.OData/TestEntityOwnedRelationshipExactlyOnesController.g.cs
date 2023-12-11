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

public abstract partial class TestEntityOwnedRelationshipExactlyOnesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<SecEntityOwnedRelExactlyOneDto>> GetSecEntityOwnedRelExactlyOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.SecEntityOwnedRelExactlyOne);
    }
    
    public virtual async Task<ActionResult> PostToSecEntityOwnedRelExactlyOne([FromRoute] System.String key, [FromBody] SecEntityOwnedRelExactlyOneUpsertDto secEntityOwnedRelExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key), secEntityOwnedRelExactlyOne, _cultureCode, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault()?.SecEntityOwnedRelExactlyOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    public virtual async Task<ActionResult<SecEntityOwnedRelExactlyOneDto>> PutToSecEntityOwnedRelExactlyOne(System.String key, [FromBody] SecEntityOwnedRelExactlyOneUpsertDto secEntityOwnedRelExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key), secEntityOwnedRelExactlyOne, _cultureCode, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault()?.SecEntityOwnedRelExactlyOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToSecEntityOwnedRelExactlyOne(System.String key, [FromBody] Delta<SecEntityOwnedRelExactlyOneUpsertDto> secEntityOwnedRelExactlyOne)
    {
        if (!ModelState.IsValid || secEntityOwnedRelExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secEntityOwnedRelExactlyOne.GetChangedPropertyNames())
        {
            if(secEntityOwnedRelExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key), updateProperties, _cultureCode, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault()?.SecEntityOwnedRelExactlyOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipExactlyOnes/{key}/SecEntityOwnedRelExactlyOne")]
    public virtual async Task<ActionResult> DeleteSecEntityOwnedRelExactlyOneNonConventional(System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecEntityOwnedRelExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
