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

public abstract partial class TestEntityOwnedRelationshipZeroOrOnesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipZeroOrOneDto>> GetSecondTestEntityOwnedRelationshipZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("TestEntityOwnedRelationshipZeroOrOne", $"{key.ToString()}");
        }
        
        return Ok(item.SecondTestEntityOwnedRelationshipZeroOrOne);
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityOwnedRelationshipZeroOrOne([FromRoute] System.String key, [FromBody] SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto secondTestEntityOwnedRelationshipZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(new TestEntityOwnedRelationshipZeroOrOneKeyDto(key), secondTestEntityOwnedRelationshipZeroOrOne, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipZeroOrOne;
        return Created(child);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipZeroOrOneDto>> PutToSecondTestEntityOwnedRelationshipZeroOrOne(System.String key, [FromBody] SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto secondTestEntityOwnedRelationshipZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(new TestEntityOwnedRelationshipZeroOrOneKeyDto(key), secondTestEntityOwnedRelationshipZeroOrOne, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipZeroOrOne;
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToSecondTestEntityOwnedRelationshipZeroOrOne(System.String key, [FromBody] Delta<SecondTestEntityOwnedRelationshipZeroOrOneUpsertDto> secondTestEntityOwnedRelationshipZeroOrOne)
    {
        if (!ModelState.IsValid || secondTestEntityOwnedRelationshipZeroOrOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(new TestEntityOwnedRelationshipZeroOrOneKeyDto(key), updateProperties, _cultureCode, etag));
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipZeroOrOne;
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipZeroOrOnes/{key}/SecondTestEntityOwnedRelationshipZeroOrOne")]
    public virtual async Task<ActionResult> DeleteSecondTestEntityOwnedRelationshipZeroOrOneNonConventional(System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(new TestEntityOwnedRelationshipZeroOrOneKeyDto(key)));
        
        return NoContent();
    }
    
    #endregion
    
}
