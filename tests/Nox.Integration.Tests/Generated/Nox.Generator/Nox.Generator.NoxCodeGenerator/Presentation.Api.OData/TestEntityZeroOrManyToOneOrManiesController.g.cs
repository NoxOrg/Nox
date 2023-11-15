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

public abstract partial class TestEntityZeroOrManyToOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromBody] TestEntityOneOrManyToZeroOrManyCreateDto testEntityOneOrManyToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityOneOrManyToZeroOrMany.TestEntityZeroOrManyToOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyToZeroOrManyCommand(testEntityOneOrManyToZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityOneOrManyToZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOneOrManyToZeroOrManyDto>>> GetTestEntityOneOrManyToZeroOrManies(System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManyToZeroOrManies);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityOneOrManyToZeroOrManyDto>> GetTestEntityOneOrManyToZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManyToZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityOneOrManyToZeroOrManyDto>(Enumerable.Empty<TestEntityOneOrManyToZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManyToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityOneOrManyToZeroOrManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies")]
    public async Task<ActionResult> DeleteToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrManies).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteTestEntityOneOrManyToZeroOrManyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrManyDto>> PutToTestEntityOneOrManyToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityOneOrManyToZeroOrManyUpdateDto testEntityOneOrManyToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManyToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOneOrManyToZeroOrManyCommand(relatedKey, testEntityOneOrManyToZeroOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
