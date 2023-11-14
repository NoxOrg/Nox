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

public abstract partial class TestEntityZeroOrOneToOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key, [FromBody] TestEntityOneOrManyToZeroOrOneCreateDto testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityOneOrManyToZeroOrOne.TestEntityZeroOrOneToOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyToZeroOrOneCommand(testEntityOneOrManyToZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityOneOrManyToZeroOrOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityOneOrManyToZeroOrOneDto>> GetTestEntityOneOrManyToZeroOrOne(System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key))).Where(x => x.TestEntityOneOrManyToZeroOrOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityOneOrManyToZeroOrOneDto>(Enumerable.Empty<TestEntityOneOrManyToZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestEntityOneOrManyToZeroOrOne!));
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrOneToOneOrManyToTestEntityOneOrManyToZeroOrOneCommand(new TestEntityZeroOrOneToOneOrManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrOneToOneOrManies/{key}/TestEntityOneOrManyToZeroOrOne")]
    public async Task<ActionResult> DeleteToTestEntityOneOrManyToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityOneOrManyToZeroOrOneByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrOneDto>> PutToTestEntityOneOrManyToZeroOrOne(System.String key, [FromBody] TestEntityOneOrManyToZeroOrOneUpdateDto testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOneOrManyToZeroOrOneCommand(related.Id, testEntityOneOrManyToZeroOrOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
