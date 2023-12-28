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

public abstract partial class TestEntityZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToSecondTestEntityZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(new TestEntityZeroOrOneKeyDto(key), new SecondTestEntityZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToSecondTestEntityZeroOrOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrOneByIdQuery(key))).Include(x => x.SecondTestEntityZeroOrOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOne", $"{key.ToString()}");
        }
        
        if (entity.SecondTestEntityZeroOrOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"SecondTestEntityZeroOrOnes/{entity.SecondTestEntityZeroOrOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToSecondTestEntityZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(new TestEntityZeroOrOneKeyDto(key), new SecondTestEntityZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToSecondTestEntityZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrOneToSecondTestEntityZeroOrOneCommand(new TestEntityZeroOrOneKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityZeroOrOne([FromRoute] System.String key, [FromBody] SecondTestEntityZeroOrOneCreateDto secondTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityZeroOrOne.TestEntityZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityZeroOrOneCommand(secondTestEntityZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<SecondTestEntityZeroOrOneDto>> GetSecondTestEntityZeroOrOne(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityZeroOrOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<SecondTestEntityZeroOrOneDto>(Enumerable.Empty<SecondTestEntityZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.SecondTestEntityZeroOrOne != null).Select(x => x.SecondTestEntityZeroOrOne!));
    }
    
    public virtual async Task<ActionResult<SecondTestEntityZeroOrOneDto>> PutToSecondTestEntityZeroOrOne(System.String key, [FromBody] SecondTestEntityZeroOrOneUpdateDto secondTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneByIdQuery(key))).Select(x => x.SecondTestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityZeroOrOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityZeroOrOneCommand(related.Id, secondTestEntityZeroOrOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityZeroOrOneDto>> PatchToSecondTestEntityZeroOrOne(System.String key, [FromBody] Delta<SecondTestEntityZeroOrOnePartialUpdateDto> secondTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid || secondTestEntityZeroOrOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneByIdQuery(key))).Select(x => x.SecondTestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityZeroOrOne", String.Empty);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityZeroOrOne.GetChangedPropertyNames())
        {
            if(secondTestEntityZeroOrOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityZeroOrOneCommand(related.Id, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrOnes/{key}/SecondTestEntityZeroOrOne")]
    public virtual async Task<ActionResult> DeleteToSecondTestEntityZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneByIdQuery(key))).Select(x => x.SecondTestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOne", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityZeroOrOneByIdCommand(new List<SecondTestEntityZeroOrOneKeyDto> { new SecondTestEntityZeroOrOneKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
