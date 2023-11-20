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

public abstract partial class TestEntityOneOrManyToExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityExactlyOneToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(new TestEntityOneOrManyToExactlyOneKeyDto(key), new TestEntityExactlyOneToOneOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityExactlyOneToOneOrManies([FromRoute] System.String key, [FromBody] TestEntityExactlyOneToOneOrManyCreateDto testEntityExactlyOneToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        testEntityExactlyOneToOneOrMany.TestEntityOneOrManyToExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneToOneOrManyCommand(testEntityExactlyOneToOneOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityExactlyOneToOneOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToOneOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityExactlyOneToOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityExactlyOneToOneOrManyDto>>> GetTestEntityExactlyOneToOneOrManies(System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityOneOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToOneOrManies);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOneOrManyToExactlyOnes/{key}/TestEntityExactlyOneToOneOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityExactlyOneToOneOrManyDto>> GetTestEntityExactlyOneToOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToOneOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityExactlyOneToOneOrManyDto>(Enumerable.Empty<TestEntityExactlyOneToOneOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityExactlyOneToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityOneOrManyToExactlyOneToTestEntityExactlyOneToOneOrManiesCommand(new TestEntityOneOrManyToExactlyOneKeyDto(key), new TestEntityExactlyOneToOneOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityOneOrManyToExactlyOnes/{key}/TestEntityExactlyOneToOneOrManies/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestEntityExactlyOneToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityExactlyOneToOneOrManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityOneOrManyToExactlyOnes/{key}/TestEntityExactlyOneToOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityExactlyOneToOneOrManyDto>> PutToTestEntityExactlyOneToOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityExactlyOneToOneOrManyUpdateDto testEntityExactlyOneToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityExactlyOneToOneOrManyCommand(relatedKey, testEntityExactlyOneToOneOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
