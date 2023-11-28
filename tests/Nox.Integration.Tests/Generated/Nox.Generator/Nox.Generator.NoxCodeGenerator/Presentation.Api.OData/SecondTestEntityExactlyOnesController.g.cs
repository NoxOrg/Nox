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

public abstract partial class SecondTestEntityExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityExactlyOneToTestEntityExactlyOneCommand(new SecondTestEntityExactlyOneKeyDto(key), new TestEntityExactlyOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestEntityExactlyOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityExactlyOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToTestEntityExactlyOne([FromRoute] System.String key, [FromBody] TestEntityExactlyOneCreateDto testEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityExactlyOne.SecondTestEntityExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneCommand(testEntityExactlyOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityExactlyOneDto>> GetTestEntityExactlyOne(System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(key))).Where(x => x.TestEntityExactlyOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityExactlyOneDto>(Enumerable.Empty<TestEntityExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestEntityExactlyOne!));
    }
    
    public virtual async Task<ActionResult<TestEntityExactlyOneDto>> PutToTestEntityExactlyOne(System.String key, [FromBody] TestEntityExactlyOneUpdateDto testEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityExactlyOneCommand(related.Id, testEntityExactlyOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
