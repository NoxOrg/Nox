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

public abstract partial class TestEntityZeroOrOneToZeroOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToZeroOrManyKeyDto(key), new TestEntityZeroOrManyToZeroOrOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyToZeroOrOneCreateDto testEntityZeroOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityZeroOrManyToZeroOrOne.TestEntityZeroOrOneToZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyToZeroOrOneCommand(testEntityZeroOrManyToZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManyToZeroOrOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityZeroOrManyToZeroOrOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityZeroOrManyToZeroOrOneDto>> GetTestEntityZeroOrManyToZeroOrOne(System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key))).Where(x => x.TestEntityZeroOrManyToZeroOrOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrManyToZeroOrOneDto>(Enumerable.Empty<TestEntityZeroOrManyToZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestEntityZeroOrManyToZeroOrOne!));
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToZeroOrManyKeyDto(key), new TestEntityZeroOrManyToZeroOrOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrOneToZeroOrManyToTestEntityZeroOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToZeroOrManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrOneToZeroOrManies/{key}/TestEntityZeroOrManyToZeroOrOne")]
    public async Task<ActionResult> DeleteToTestEntityZeroOrManyToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        testEntityZeroOrManyToZeroOrOne.TestEntityZeroOrOneToZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyToZeroOrOneCommand(testEntityZeroOrManyToZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityZeroOrManyToZeroOrOneDto>> GetTestEntityZeroOrManyToZeroOrOne(System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key))).Where(x => x.TestEntityZeroOrManyToZeroOrOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrManyToZeroOrOneDto>(Enumerable.Empty<TestEntityZeroOrManyToZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestEntityZeroOrManyToZeroOrOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrManyToZeroOrOneDto>> PutToTestEntityZeroOrManyToZeroOrOne(System.String key, [FromBody] TestEntityZeroOrManyToZeroOrOneUpdateDto testEntityZeroOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrManyToZeroOrOneByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrManyToZeroOrOneDto>> PutToTestEntityZeroOrManyToZeroOrOne(System.String key, [FromBody] TestEntityZeroOrManyToZeroOrOneUpdateDto testEntityZeroOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrManyToZeroOrOneCommand(related.Id, testEntityZeroOrManyToZeroOrOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
