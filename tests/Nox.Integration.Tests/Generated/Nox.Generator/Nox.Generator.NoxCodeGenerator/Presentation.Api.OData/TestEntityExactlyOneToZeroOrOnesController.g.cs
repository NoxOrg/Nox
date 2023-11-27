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

public abstract partial class TestEntityExactlyOneToZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityZeroOrOneToExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityExactlyOneToZeroOrOneToTestEntityZeroOrOneToExactlyOneCommand(new TestEntityExactlyOneToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToExactlyOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestEntityZeroOrOneToExactlyOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOneToExactlyOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityZeroOrOneToExactlyOnes/{related.Id}", UriKind.Relative);
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
        var related = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(key))).Where(x => x.TestEntityZeroOrOneToExactlyOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrOneToExactlyOneDto>(Enumerable.Empty<TestEntityZeroOrOneToExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestEntityZeroOrOneToExactlyOne!));
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrOneToExactlyOneCommand(related.Id, testEntityZeroOrOneToExactlyOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
