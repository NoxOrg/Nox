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

public abstract partial class TestEntityExactlyOneToZeroOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityZeroOrManyToExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityExactlyOneToZeroOrManyToTestEntityZeroOrManyToExactlyOneCommand(new TestEntityExactlyOneToZeroOrManyKeyDto(key), new TestEntityZeroOrManyToExactlyOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestEntityZeroOrManyToExactlyOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManyToExactlyOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityZeroOrManyToExactlyOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrManyToExactlyOne([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyToExactlyOneCreateDto testEntityZeroOrManyToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        testEntityZeroOrManyToExactlyOne.TestEntityExactlyOneToZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyToExactlyOneCommand(testEntityZeroOrManyToExactlyOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityZeroOrManyToExactlyOneDto>> GetTestEntityZeroOrManyToExactlyOne(System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrManyByIdQuery(key))).Where(x => x.TestEntityZeroOrManyToExactlyOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrManyToExactlyOneDto>(Enumerable.Empty<TestEntityZeroOrManyToExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestEntityZeroOrManyToExactlyOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrManyToExactlyOneDto>> PutToTestEntityZeroOrManyToExactlyOne(System.String key, [FromBody] TestEntityZeroOrManyToExactlyOneUpdateDto testEntityZeroOrManyToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManyToExactlyOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrManyToExactlyOneCommand(related.Id, testEntityZeroOrManyToExactlyOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}