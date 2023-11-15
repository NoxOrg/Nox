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

public abstract partial class SecondTestEntityZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(new SecondTestEntityZeroOrOneKeyDto(key), new TestEntityZeroOrOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrOne([FromRoute] System.String key, [FromBody] TestEntityZeroOrOneCreateDto testEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityZeroOrOne.SecondTestEntityZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrOneCommand(testEntityZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityZeroOrOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityZeroOrOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityZeroOrOneDto>> GetTestEntityZeroOrOne(System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(key))).Where(x => x.TestEntityZeroOrOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrOneDto>(Enumerable.Empty<TestEntityZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestEntityZeroOrOne!));
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(new SecondTestEntityZeroOrOneKeyDto(key), new TestEntityZeroOrOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityZeroOrOneToTestEntityZeroOrOneCommand(new SecondTestEntityZeroOrOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityZeroOrOnes/{key}/TestEntityZeroOrOne")]
    public async Task<ActionResult> DeleteToTestEntityZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrOneByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrOneDto>> PutToTestEntityZeroOrOne(System.String key, [FromBody] TestEntityZeroOrOneUpdateDto testEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrOneCommand(related.Id, testEntityZeroOrOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
