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

public abstract partial class SecondTestEntityZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(new SecondTestEntityZeroOrOneKeyDto(key), new TestEntityZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityZeroOrOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(key))).Include(x => x.TestEntityZeroOrOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("SecondTestEntityZeroOrOne", $"{key.ToString()}");
        }
        
        if (entity.TestEntityZeroOrOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityZeroOrOnes/{entity.TestEntityZeroOrOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(new SecondTestEntityZeroOrOneKeyDto(key), new TestEntityZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(new SecondTestEntityZeroOrOneKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrOne([FromRoute] System.String key, [FromBody] TestEntityZeroOrOneCreateDto testEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityZeroOrOne.SecondTestEntityZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrOneCommand(testEntityZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityZeroOrOneDto>> GetTestEntityZeroOrOne(System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityZeroOrOneDto>(Enumerable.Empty<TestEntityZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestEntityZeroOrOne != null).Select(x => x.TestEntityZeroOrOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrOneDto>> PutToTestEntityZeroOrOne(System.String key, [FromBody] TestEntityZeroOrOneUpdateDto testEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrOneCommand(related.Id, testEntityZeroOrOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrOneDto>> PatchToTestEntityZeroOrOne(System.String key, [FromBody] Delta<TestEntityZeroOrOnePartialUpdateDto> testEntityZeroOrOne)
    {
        if (!ModelState.IsValid || testEntityZeroOrOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOne", String.Empty);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in testEntityZeroOrOne.GetChangedPropertyNames())
        {
            if(testEntityZeroOrOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityZeroOrOneCommand(related.Id, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/SecondTestEntityZeroOrOnes/{key}/TestEntityZeroOrOne")]
    public virtual async Task<ActionResult> DeleteToTestEntityZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityZeroOrOne", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrOneByIdCommand(new List<TestEntityZeroOrOneKeyDto> { new TestEntityZeroOrOneKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
