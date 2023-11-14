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

public abstract partial class TestEntityOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToSecondTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(new TestEntityOneOrManyKeyDto(key), new SecondTestEntityOneOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityOneOrManies([FromRoute] System.String key, [FromBody] SecondTestEntityOneOrManyCreateDto secondTestEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        secondTestEntityOneOrMany.TestEntityOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOneOrManyCommand(secondTestEntityOneOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToSecondTestEntityOneOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key))).Select(x => x.SecondTestEntityOneOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"SecondTestEntityOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityOneOrManyDto>>> GetSecondTestEntityOneOrManies(System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.SecondTestEntityOneOrManies);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOneOrManies/{key}/SecondTestEntityOneOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<SecondTestEntityOneOrManyDto>> GetSecondTestEntityOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.SecondTestEntityOneOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<SecondTestEntityOneOrManyDto>(Enumerable.Empty<SecondTestEntityOneOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    public async Task<ActionResult> DeleteRefToSecondTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(new TestEntityOneOrManyKeyDto(key), new SecondTestEntityOneOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityOneOrManies/{key}/SecondTestEntityOneOrManies/{relatedKey}")]
    public async Task<ActionResult> DeleteToSecondTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.SecondTestEntityOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityOneOrManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityOneOrManies/{key}/SecondTestEntityOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityOneOrManyDto>> PutToSecondTestEntityOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityOneOrManyUpdateDto secondTestEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.SecondTestEntityOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityOneOrManyCommand(relatedKey, secondTestEntityOneOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
