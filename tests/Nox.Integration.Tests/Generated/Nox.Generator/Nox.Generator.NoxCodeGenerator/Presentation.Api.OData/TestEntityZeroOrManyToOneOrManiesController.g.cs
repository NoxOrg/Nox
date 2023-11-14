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

public abstract partial class TestEntityZeroOrManyToOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromBody] TestEntityOneOrManyToZeroOrManyCreateDto testEntityOneOrManyToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityOneOrManyToZeroOrMany.TestEntityZeroOrManyToOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyToZeroOrManyCommand(testEntityOneOrManyToZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityOneOrManyToZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrManyDto>> PutToTestEntityOneOrManyToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityOneOrManyToZeroOrManyUpdateDto testEntityOneOrManyToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrManies).SingleOrDefault()?.Any(x => x.Id == relatedKey);
        if (related == null || related == false)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOneOrManyToZeroOrManyCommand(relatedKey, testEntityOneOrManyToZeroOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
