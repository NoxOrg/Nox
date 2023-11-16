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

public abstract partial class TestEntityExactlyOneToOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityOneOrManyToExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(new TestEntityExactlyOneToOneOrManyKeyDto(key), new TestEntityOneOrManyToExactlyOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityOneOrManyToExactlyOne([FromRoute] System.String key, [FromBody] TestEntityOneOrManyToExactlyOneCreateDto testEntityOneOrManyToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityOneOrManyToExactlyOne.TestEntityExactlyOneToOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyToExactlyOneCommand(testEntityOneOrManyToExactlyOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityOneOrManyToExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityOneOrManyToExactlyOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToExactlyOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityOneOrManyToExactlyOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityOneOrManyToExactlyOneDto>> GetTestEntityOneOrManyToExactlyOne(System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(key))).Where(x => x.TestEntityOneOrManyToExactlyOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityOneOrManyToExactlyOneDto>(Enumerable.Empty<TestEntityOneOrManyToExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestEntityOneOrManyToExactlyOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityOneOrManyToExactlyOneDto>> PutToTestEntityOneOrManyToExactlyOne(System.String key, [FromBody] TestEntityOneOrManyToExactlyOneUpdateDto testEntityOneOrManyToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToExactlyOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOneOrManyToExactlyOneCommand(related.Id, testEntityOneOrManyToExactlyOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
