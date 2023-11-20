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

public abstract partial class TestEntityZeroOrManyToExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(new TestEntityZeroOrManyToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key, [FromBody] TestEntityExactlyOneToZeroOrManyCreateDto testEntityExactlyOneToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityExactlyOneToZeroOrMany.TestEntityZeroOrManyToExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneToZeroOrManyCommand(testEntityExactlyOneToZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityExactlyOneToZeroOrManies/{item.Id}", UriKind.Relative));
        }
        
        testEntityExactlyOneToZeroOrMany.TestEntityZeroOrManyToExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneToZeroOrManyCommand(testEntityExactlyOneToZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityExactlyOneToZeroOrManyDto>>> GetTestEntityExactlyOneToZeroOrManies(System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToZeroOrManies);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityExactlyOneToZeroOrManyDto>> GetTestEntityExactlyOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityExactlyOneToZeroOrManyDto>(Enumerable.Empty<TestEntityExactlyOneToZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(new TestEntityZeroOrManyToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(new TestEntityZeroOrManyToExactlyOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityExactlyOneToZeroOrManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies")]
    public async Task<ActionResult> DeleteToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrManies).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteTestEntityExactlyOneToZeroOrManyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityExactlyOneToZeroOrManyDto>> PutToTestEntityExactlyOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityExactlyOneToZeroOrManyUpdateDto testEntityExactlyOneToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityExactlyOneToZeroOrManyCommand(relatedKey, testEntityExactlyOneToZeroOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
