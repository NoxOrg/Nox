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

public abstract partial class TestEntityZeroOrManyToZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(new TestEntityZeroOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToZeroOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies/$ref")]
    public async Task<ActionResult> UpdateRefToTestEntityZeroOrOneToZeroOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeyDto = referencesDto.References.Select(x => new TestEntityZeroOrOneToZeroOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(new TestEntityZeroOrManyToZeroOrOneKeyDto(key), relatedKeyDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOneToZeroOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityZeroOrOneToZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(new TestEntityZeroOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToZeroOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(new TestEntityZeroOrManyToZeroOrOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key, [FromBody] TestEntityZeroOrOneToZeroOrManyCreateDto testEntityZeroOrOneToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        testEntityZeroOrOneToZeroOrMany.TestEntityZeroOrManyToZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrOneToZeroOrManyCommand(testEntityZeroOrOneToZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>> GetTestEntityZeroOrOneToZeroOrManies(System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToZeroOrManies);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityZeroOrOneToZeroOrManyDto>> GetTestEntityZeroOrOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrOneToZeroOrManyDto>(Enumerable.Empty<TestEntityZeroOrOneToZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrOneToZeroOrManyDto>> PutToTestEntityZeroOrOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityZeroOrOneToZeroOrManyUpdateDto testEntityZeroOrOneToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrOneToZeroOrManyCommand(relatedKey, testEntityZeroOrOneToZeroOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies")]
    public async Task<ActionResult> DeleteToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOneToZeroOrManies).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    #endregion
    
}
