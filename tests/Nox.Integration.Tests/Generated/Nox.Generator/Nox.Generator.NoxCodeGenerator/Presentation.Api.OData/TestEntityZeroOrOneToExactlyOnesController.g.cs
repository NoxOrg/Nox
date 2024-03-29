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

public abstract partial class TestEntityZeroOrOneToExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Include(x => x.TestEntityExactlyOneToZeroOrOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne", $"{key.ToString()}");
        }
        
        if (entity.TestEntityExactlyOneToZeroOrOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityExactlyOneToZeroOrOnes/{entity.TestEntityExactlyOneToZeroOrOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromBody] TestEntityExactlyOneToZeroOrOneCreateDto testEntityExactlyOneToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityExactlyOneToZeroOrOne.TestEntityZeroOrOneToExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneToZeroOrOneCommand(testEntityExactlyOneToZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityExactlyOneToZeroOrOneDto>> GetTestEntityExactlyOneToZeroOrOne(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityExactlyOneToZeroOrOneDto>(Enumerable.Empty<TestEntityExactlyOneToZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestEntityExactlyOneToZeroOrOne != null).Select(x => x.TestEntityExactlyOneToZeroOrOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityExactlyOneToZeroOrOneDto>> PutToTestEntityExactlyOneToZeroOrOne(System.String key, [FromBody] TestEntityExactlyOneToZeroOrOneUpdateDto testEntityExactlyOneToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityExactlyOneToZeroOrOneCommand(related.Id, testEntityExactlyOneToZeroOrOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TestEntityExactlyOneToZeroOrOneDto>> PatchToTestEntityExactlyOneToZeroOrOne(System.String key, [FromBody] Delta<TestEntityExactlyOneToZeroOrOnePartialUpdateDto> testEntityExactlyOneToZeroOrOne)
    {
        if (!ModelState.IsValid || testEntityExactlyOneToZeroOrOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityExactlyOneToZeroOrOnePartialUpdateDto>(testEntityExactlyOneToZeroOrOne);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityExactlyOneToZeroOrOneCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrOneToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrOne")]
    public virtual async Task<ActionResult> DeleteToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityExactlyOneToZeroOrOneByIdCommand(new List<TestEntityExactlyOneToZeroOrOneKeyDto> { new TestEntityExactlyOneToZeroOrOneKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
