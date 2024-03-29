﻿// Generated

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

public abstract partial class TestEntityZeroOrOneToZeroOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToZeroOrManyKeyDto(key), new TestEntityZeroOrManyToZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key))).Include(x => x.TestEntityZeroOrManyToZeroOrOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrMany", $"{key.ToString()}");
        }
        
        if (entity.TestEntityZeroOrManyToZeroOrOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityZeroOrManyToZeroOrOnes/{entity.TestEntityZeroOrManyToZeroOrOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToZeroOrManyKeyDto(key), new TestEntityZeroOrManyToZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToZeroOrManyKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyToZeroOrOneCreateDto testEntityZeroOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityZeroOrManyToZeroOrOne.TestEntityZeroOrOneToZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyToZeroOrOneCommand(testEntityZeroOrManyToZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityZeroOrManyToZeroOrOneDto>> GetTestEntityZeroOrManyToZeroOrOne(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityZeroOrManyToZeroOrOneDto>(Enumerable.Empty<TestEntityZeroOrManyToZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestEntityZeroOrManyToZeroOrOne != null).Select(x => x.TestEntityZeroOrManyToZeroOrOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrManyToZeroOrOneDto>> PutToTestEntityZeroOrManyToZeroOrOne(System.String key, [FromBody] TestEntityZeroOrManyToZeroOrOneUpdateDto testEntityZeroOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrManyToZeroOrOneCommand(related.Id, testEntityZeroOrManyToZeroOrOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrManyToZeroOrOneDto>> PatchToTestEntityZeroOrManyToZeroOrOne(System.String key, [FromBody] Delta<TestEntityZeroOrManyToZeroOrOnePartialUpdateDto> testEntityZeroOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid || testEntityZeroOrManyToZeroOrOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityZeroOrManyToZeroOrOnePartialUpdateDto>(testEntityZeroOrManyToZeroOrOne);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityZeroOrManyToZeroOrOneCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrOneToZeroOrManies/{key}/TestEntityZeroOrManyToZeroOrOne")]
    public virtual async Task<ActionResult> DeleteToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrMany", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrManyToZeroOrOneByIdCommand(new List<TestEntityZeroOrManyToZeroOrOneKeyDto> { new TestEntityZeroOrManyToZeroOrOneKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
