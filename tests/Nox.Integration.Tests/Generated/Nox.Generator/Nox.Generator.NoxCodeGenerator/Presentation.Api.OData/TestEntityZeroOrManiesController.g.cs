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

public abstract partial class TestEntityZeroOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToSecondTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(new TestEntityZeroOrManyKeyDto(key), new SecondTestEntityZeroOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManies/{key}/SecondTestEntityZeroOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToSecondTestEntityZeroOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new SecondTestEntityZeroOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(new TestEntityZeroOrManyKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToSecondTestEntityZeroOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(key))).Include(x => x.SecondTestEntityZeroOrManies).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.SecondTestEntityZeroOrManies)
        {
            references.Add(new System.Uri($"SecondTestEntityZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToSecondTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(new TestEntityZeroOrManyKeyDto(key), new SecondTestEntityZeroOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToSecondTestEntityZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrManyToSecondTestEntityZeroOrManiesCommand(new TestEntityZeroOrManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityZeroOrManies([FromRoute] System.String key, [FromBody] SecondTestEntityZeroOrManyCreateDto secondTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityZeroOrMany.TestEntityZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateSecondTestEntityZeroOrManyCommand(secondTestEntityZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityZeroOrManyDto>>> GetSecondTestEntityZeroOrManies(System.String key)
    {
        var query = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(key))).Include(x => x.SecondTestEntityZeroOrManies);
        var entity = query.SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        return Ok(query.SelectMany(x => x.SecondTestEntityZeroOrManies));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityZeroOrManies/{key}/SecondTestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<SecondTestEntityZeroOrManyDto>> GetSecondTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.SecondTestEntityZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<SecondTestEntityZeroOrManyDto>(Enumerable.Empty<SecondTestEntityZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManies/{key}/SecondTestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityZeroOrManyDto>> PutToSecondTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityZeroOrManyUpdateDto secondTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.SecondTestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityZeroOrManyCommand(relatedKey, secondTestEntityZeroOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManies/{key}/SecondTestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToSecondTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.SecondTestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityZeroOrManyByIdCommand(new List<SecondTestEntityZeroOrManyKeyDto> { new SecondTestEntityZeroOrManyKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManies/{key}/SecondTestEntityZeroOrManies")]
    public virtual async Task<ActionResult> DeleteToSecondTestEntityZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(key))).Select(x => x.SecondTestEntityZeroOrManies).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteSecondTestEntityZeroOrManyByIdCommand(related.Select(item => new SecondTestEntityZeroOrManyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
