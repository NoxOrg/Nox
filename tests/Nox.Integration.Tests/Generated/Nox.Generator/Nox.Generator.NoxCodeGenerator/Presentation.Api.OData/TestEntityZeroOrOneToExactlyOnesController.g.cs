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
using Nox.Application.Dto;
using Nox.Extensions;
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class TestEntityZeroOrOneToExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityExactlyOneToZeroOrOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromBody] TestEntityExactlyOneToZeroOrOneCreateDto testEntityExactlyOneToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityExactlyOneToZeroOrOne.TestEntityZeroOrOneToExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneToZeroOrOneCommand(testEntityExactlyOneToZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityExactlyOneToZeroOrOneDto>> GetTestEntityExactlyOneToZeroOrOne(System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Where(x => x.TestEntityExactlyOneToZeroOrOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityExactlyOneToZeroOrOneDto>(Enumerable.Empty<TestEntityExactlyOneToZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestEntityExactlyOneToZeroOrOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityExactlyOneToZeroOrOneDto>> PutToTestEntityExactlyOneToZeroOrOne(System.String key, [FromBody] TestEntityExactlyOneToZeroOrOneUpdateDto testEntityExactlyOneToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityExactlyOneToZeroOrOneCommand(related.Id, testEntityExactlyOneToZeroOrOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrOneToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrOne")]
    public async Task<ActionResult> DeleteToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityExactlyOneToZeroOrOneByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    #endregion
    
}
