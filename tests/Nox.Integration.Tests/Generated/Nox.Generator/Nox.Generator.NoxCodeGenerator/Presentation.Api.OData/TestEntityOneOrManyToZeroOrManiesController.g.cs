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

public abstract partial class TestEntityOneOrManyToZeroOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrManyKeyDto(key), new TestEntityZeroOrManyToOneOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyToOneOrManyCreateDto testEntityZeroOrManyToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        testEntityZeroOrManyToOneOrMany.TestEntityOneOrManyToZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyToOneOrManyCommand(testEntityZeroOrManyToOneOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManyToOneOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityZeroOrManyToOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrManyToOneOrManyDto>>> GetTestEntityZeroOrManyToOneOrManies(System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManyToOneOrManies);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOneOrManyToZeroOrManies/{key}/TestEntityZeroOrManyToOneOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityZeroOrManyToOneOrManyDto>> GetTestEntityZeroOrManyToOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManyToOneOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrManyToOneOrManyDto>(Enumerable.Empty<TestEntityZeroOrManyToOneOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrManyKeyDto(key), new TestEntityZeroOrManyToOneOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityOneOrManyToZeroOrManies/{key}/TestEntityZeroOrManyToOneOrManies/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManyToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrManyToOneOrManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityOneOrManyToZeroOrManies/{key}/TestEntityZeroOrManyToOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrManyToOneOrManyDto>> PutToTestEntityZeroOrManyToOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityZeroOrManyToOneOrManyUpdateDto testEntityZeroOrManyToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManyToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrManyToOneOrManyCommand(relatedKey, testEntityZeroOrManyToOneOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
