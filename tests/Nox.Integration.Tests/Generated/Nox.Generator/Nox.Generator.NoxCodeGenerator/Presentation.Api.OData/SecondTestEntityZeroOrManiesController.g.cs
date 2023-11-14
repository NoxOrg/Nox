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

public abstract partial class SecondTestEntityZeroOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(new SecondTestEntityZeroOrManyKeyDto(key), new TestEntityZeroOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrManies([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyCreateDto testEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityZeroOrMany.SecondTestEntityZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyCommand(testEntityZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityZeroOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrManyDto>>> GetTestEntityZeroOrManies(System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManies);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityZeroOrManyDto>> GetTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrManyDto>(Enumerable.Empty<TestEntityZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(new SecondTestEntityZeroOrManyKeyDto(key), new TestEntityZeroOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(new SecondTestEntityZeroOrManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies")]
    public async Task<ActionResult> DeleteToTestEntityZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManies).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteTestEntityZeroOrManyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrManyDto>> PutToTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityZeroOrManyUpdateDto testEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrManyCommand(relatedKey, testEntityZeroOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
