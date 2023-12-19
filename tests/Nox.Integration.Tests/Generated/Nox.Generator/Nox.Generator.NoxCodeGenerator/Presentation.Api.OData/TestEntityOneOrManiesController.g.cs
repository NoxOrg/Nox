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

public abstract partial class TestEntityOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToSecondTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(new TestEntityOneOrManyKeyDto(key), new SecondTestEntityOneOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityOneOrManies/{key}/SecondTestEntityOneOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToSecondTestEntityOneOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new SecondTestEntityOneOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(new TestEntityOneOrManyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToSecondTestEntityOneOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key))).Include(x => x.SecondTestEntityOneOrManies).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityOneOrMany", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.SecondTestEntityOneOrManies)
        {
            references.Add(new System.Uri($"SecondTestEntityOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToSecondTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityOneOrManyToSecondTestEntityOneOrManiesCommand(new TestEntityOneOrManyKeyDto(key), new SecondTestEntityOneOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityOneOrManies([FromRoute] System.String key, [FromBody] SecondTestEntityOneOrManyCreateDto secondTestEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityOneOrMany.TestEntityOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOneOrManyCommand(secondTestEntityOneOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityOneOrManyDto>>> GetSecondTestEntityOneOrManies(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("TestEntityOneOrMany", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.SecondTestEntityOneOrManies).SelectMany(x => x.SecondTestEntityOneOrManies));
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
    
    [HttpPut("/api/v1/TestEntityOneOrManies/{key}/SecondTestEntityOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityOneOrManyDto>> PutToSecondTestEntityOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityOneOrManyUpdateDto secondTestEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.SecondTestEntityOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("SecondTestEntityOneOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityOneOrManyCommand(relatedKey, secondTestEntityOneOrMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityOneOrManies/{key}/SecondTestEntityOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToSecondTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.SecondTestEntityOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("SecondTestEntityOneOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityOneOrManyByIdCommand(new List<SecondTestEntityOneOrManyKeyDto> { new SecondTestEntityOneOrManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    #endregion
    
}
