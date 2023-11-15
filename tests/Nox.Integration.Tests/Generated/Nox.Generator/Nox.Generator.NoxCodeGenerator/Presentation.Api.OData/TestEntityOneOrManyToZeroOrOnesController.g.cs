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

public abstract partial class TestEntityOneOrManyToZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToOneOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key, [FromBody] TestEntityZeroOrOneToOneOrManyCreateDto testEntityZeroOrOneToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityZeroOrOneToOneOrMany.TestEntityOneOrManyToZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrOneToOneOrManyCommand(testEntityZeroOrOneToOneOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOneToOneOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityZeroOrOneToOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrOneToOneOrManyDto>>> GetTestEntityZeroOrOneToOneOrManies(System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToOneOrManies);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOneOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToOneOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityZeroOrOneToOneOrManyDto>> GetTestEntityZeroOrOneToOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToOneOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrOneToOneOrManyDto>(Enumerable.Empty<TestEntityZeroOrOneToOneOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToOneOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityOneOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToOneOrManies/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrOneToOneOrManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityOneOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrOneToOneOrManyDto>> PutToTestEntityZeroOrOneToOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityZeroOrOneToOneOrManyUpdateDto testEntityZeroOrOneToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrOneToOneOrManyCommand(relatedKey, testEntityZeroOrOneToOneOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
