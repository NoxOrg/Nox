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

public abstract partial class SecondTestEntityOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(new SecondTestEntityOneOrManyKeyDto(key), new TestEntityOneOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/SecondTestEntityOneOrManies/{key}/TestEntityOneOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestEntityOneOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TestEntityOneOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(new SecondTestEntityOneOrManyKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityOneOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(key))).Include(x => x.TestEntityOneOrManies).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestEntityOneOrManies)
        {
            references.Add(new System.Uri($"TestEntityOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManiesCommand(new SecondTestEntityOneOrManyKeyDto(key), new TestEntityOneOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityOneOrManies([FromRoute] System.String key, [FromBody] TestEntityOneOrManyCreateDto testEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityOneOrMany.SecondTestEntityOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyCommand(testEntityOneOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOneOrManyDto>>> GetTestEntityOneOrManies(System.String key)
    {
        var query = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(key))).Include(x => x.TestEntityOneOrManies);
        var entity = query.SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        return Ok(query.SelectMany(x => x.TestEntityOneOrManies));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/SecondTestEntityOneOrManies/{key}/TestEntityOneOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityOneOrManyDto>> GetTestEntityOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityOneOrManyDto>(Enumerable.Empty<TestEntityOneOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/SecondTestEntityOneOrManies/{key}/TestEntityOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityOneOrManyDto>> PutToTestEntityOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityOneOrManyUpdateDto testEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOneOrManyCommand(relatedKey, testEntityOneOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/SecondTestEntityOneOrManies/{key}/TestEntityOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestEntityOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityOneOrManyByIdCommand(new List<TestEntityOneOrManyKeyDto> { new TestEntityOneOrManyKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
