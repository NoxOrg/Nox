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
using Nox.Exceptions;
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class TestEntityExactlyOneToZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityZeroOrOneToExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(new TestEntityExactlyOneToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToExactlyOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityZeroOrOneToExactlyOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(key))).Include(x => x.TestEntityZeroOrOneToExactlyOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrOne", $"{key.ToString()}");
        }
        
        if (entity.TestEntityZeroOrOneToExactlyOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityZeroOrOneToExactlyOnes/{entity.TestEntityZeroOrOneToExactlyOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrOneToExactlyOne([FromRoute] System.String key, [FromBody] TestEntityZeroOrOneToExactlyOneCreateDto testEntityZeroOrOneToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityZeroOrOneToExactlyOne.TestEntityExactlyOneToZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrOneToExactlyOneCommand(testEntityZeroOrOneToExactlyOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityZeroOrOneToExactlyOneDto>> GetTestEntityZeroOrOneToExactlyOne(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityZeroOrOneToExactlyOneDto>(Enumerable.Empty<TestEntityZeroOrOneToExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestEntityZeroOrOneToExactlyOne != null).Select(x => x.TestEntityZeroOrOneToExactlyOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrOneToExactlyOneDto>> PutToTestEntityZeroOrOneToExactlyOne(System.String key, [FromBody] TestEntityZeroOrOneToExactlyOneUpdateDto testEntityZeroOrOneToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOneToExactlyOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToExactlyOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrOneToExactlyOneCommand(related.Id, testEntityZeroOrOneToExactlyOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
