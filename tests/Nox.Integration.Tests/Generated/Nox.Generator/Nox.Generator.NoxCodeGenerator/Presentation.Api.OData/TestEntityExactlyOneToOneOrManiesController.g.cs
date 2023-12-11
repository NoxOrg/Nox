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

public abstract partial class TestEntityExactlyOneToOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityOneOrManyToExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityExactlyOneToOneOrManyToTestEntityOneOrManyToExactlyOneCommand(new TestEntityExactlyOneToOneOrManyKeyDto(key), new TestEntityOneOrManyToExactlyOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityOneOrManyToExactlyOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(key))).Include(x => x.TestEntityOneOrManyToExactlyOne).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        if (entity.TestEntityOneOrManyToExactlyOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityOneOrManyToExactlyOnes/{entity.TestEntityOneOrManyToExactlyOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToTestEntityOneOrManyToExactlyOne([FromRoute] System.String key, [FromBody] TestEntityOneOrManyToExactlyOneCreateDto testEntityOneOrManyToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityOneOrManyToExactlyOne.TestEntityExactlyOneToOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyToExactlyOneCommand(testEntityOneOrManyToExactlyOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityOneOrManyToExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityOneOrManyToExactlyOneDto>> GetTestEntityOneOrManyToExactlyOne(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityOneOrManyToExactlyOneDto>(Enumerable.Empty<TestEntityOneOrManyToExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestEntityOneOrManyToExactlyOne != null).Select(x => x.TestEntityOneOrManyToExactlyOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityOneOrManyToExactlyOneDto>> PutToTestEntityOneOrManyToExactlyOne(System.String key, [FromBody] TestEntityOneOrManyToExactlyOneUpdateDto testEntityOneOrManyToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
        
        var updatedItem = (await _mediator.Send(new GetTestEntityOneOrManyToExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
