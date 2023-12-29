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

public abstract partial class TestEntityZeroOrOneToOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key))).Include(x => x.TestEntityOneOrManyToZeroOrOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany", $"{key.ToString()}");
        }
        
        if (entity.TestEntityOneOrManyToZeroOrOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityOneOrManyToZeroOrOnes/{entity.TestEntityOneOrManyToZeroOrOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToOneOrManyKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key, [FromBody] TestEntityOneOrManyToZeroOrOneCreateDto testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityOneOrManyToZeroOrOne.TestEntityZeroOrOneToOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyToZeroOrOneCommand(testEntityOneOrManyToZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityOneOrManyToZeroOrOneDto>> GetTestEntityOneOrManyToZeroOrOne(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityOneOrManyToZeroOrOneDto>(Enumerable.Empty<TestEntityOneOrManyToZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestEntityOneOrManyToZeroOrOne != null).Select(x => x.TestEntityOneOrManyToZeroOrOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrOneDto>> PutToTestEntityOneOrManyToZeroOrOne(System.String key, [FromBody] TestEntityOneOrManyToZeroOrOneUpdateDto testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOneOrManyToZeroOrOneCommand(related.Id, testEntityOneOrManyToZeroOrOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrOneDto>> PatchToTestEntityOneOrManyToZeroOrOne(System.String key, [FromBody] Delta<TestEntityOneOrManyToZeroOrOnePartialUpdateDto> testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid || testEntityOneOrManyToZeroOrOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityOneOrManyToZeroOrOnePartialUpdateDto>(testEntityOneOrManyToZeroOrOne);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityOneOrManyToZeroOrOneCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrOneToOneOrManies/{key}/TestEntityOneOrManyToZeroOrOne")]
    public virtual async Task<ActionResult> DeleteToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityOneOrManyToZeroOrOneByIdCommand(new List<TestEntityOneOrManyToZeroOrOneKeyDto> { new TestEntityOneOrManyToZeroOrOneKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
