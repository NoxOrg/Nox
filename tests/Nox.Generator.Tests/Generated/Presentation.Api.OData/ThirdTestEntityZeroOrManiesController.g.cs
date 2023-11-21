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

public abstract partial class ThirdTestEntityZeroOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToThirdTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(new ThirdTestEntityZeroOrManyKeyDto(key), new ThirdTestEntityOneOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToThirdTestEntityOneOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(key))).Select(x => x.ThirdTestEntityOneOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"ThirdTestEntityOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(new ThirdTestEntityZeroOrManyKeyDto(key), new ThirdTestEntityOneOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityOneOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefThirdTestEntityZeroOrManyToThirdTestEntityOneOrManiesCommand(new ThirdTestEntityZeroOrManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToThirdTestEntityOneOrManies([FromRoute] System.String key, [FromBody] ThirdTestEntityOneOrManyCreateDto thirdTestEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        thirdTestEntityOneOrMany.ThirdTestEntityZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateThirdTestEntityOneOrManyCommand(thirdTestEntityOneOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ThirdTestEntityOneOrManyDto>>> GetThirdTestEntityOneOrManies(System.String key)
    {
        var entity = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.ThirdTestEntityOneOrManies);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/ThirdTestEntityZeroOrManies/{key}/ThirdTestEntityOneOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<ThirdTestEntityOneOrManyDto>> GetThirdTestEntityOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.ThirdTestEntityOneOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<ThirdTestEntityOneOrManyDto>(Enumerable.Empty<ThirdTestEntityOneOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/ThirdTestEntityZeroOrManies/{key}/ThirdTestEntityOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<ThirdTestEntityOneOrManyDto>> PutToThirdTestEntityOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] ThirdTestEntityOneOrManyUpdateDto thirdTestEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.ThirdTestEntityOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateThirdTestEntityOneOrManyCommand(relatedKey, thirdTestEntityOneOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/ThirdTestEntityZeroOrManies/{key}/ThirdTestEntityOneOrManies/{relatedKey}")]
    public async Task<ActionResult> DeleteToThirdTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.ThirdTestEntityOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteThirdTestEntityOneOrManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/ThirdTestEntityZeroOrManies/{key}/ThirdTestEntityOneOrManies")]
    public async Task<ActionResult> DeleteToThirdTestEntityOneOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(key))).Select(x => x.ThirdTestEntityOneOrManies).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteThirdTestEntityOneOrManyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    #endregion
    
}