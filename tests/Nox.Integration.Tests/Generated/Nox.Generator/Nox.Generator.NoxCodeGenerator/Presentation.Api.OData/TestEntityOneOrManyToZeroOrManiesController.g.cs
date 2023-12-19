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

public abstract partial class TestEntityOneOrManyToZeroOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrManyKeyDto(key), new TestEntityZeroOrManyToOneOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityOneOrManyToZeroOrManies/{key}/TestEntityZeroOrManyToOneOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestEntityZeroOrManyToOneOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TestEntityZeroOrManyToOneOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrManyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key))).Include(x => x.TestEntityZeroOrManyToOneOrManies).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrMany", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestEntityZeroOrManyToOneOrManies)
        {
            references.Add(new System.Uri($"TestEntityZeroOrManyToOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityOneOrManyToZeroOrManyToTestEntityZeroOrManyToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrManyKeyDto(key), new TestEntityZeroOrManyToOneOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyToOneOrManyCreateDto testEntityZeroOrManyToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityZeroOrManyToOneOrMany.TestEntityOneOrManyToZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyToOneOrManyCommand(testEntityZeroOrManyToOneOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrManyToOneOrManyDto>>> GetTestEntityZeroOrManyToOneOrManies(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrMany", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestEntityZeroOrManyToOneOrManies).SelectMany(x => x.TestEntityZeroOrManyToOneOrManies));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOneOrManyToZeroOrManies/{key}/TestEntityZeroOrManyToOneOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityZeroOrManyToOneOrManyDto>> GetTestEntityZeroOrManyToOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManyToOneOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrManyToOneOrManyDto>(Enumerable.Empty<TestEntityZeroOrManyToOneOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityOneOrManyToZeroOrManies/{key}/TestEntityZeroOrManyToOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrManyToOneOrManyDto>> PutToTestEntityZeroOrManyToOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityZeroOrManyToOneOrManyUpdateDto testEntityZeroOrManyToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManyToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrManyToOneOrManyCommand(relatedKey, testEntityZeroOrManyToOneOrMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityOneOrManyToZeroOrManies/{key}/TestEntityZeroOrManyToOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestEntityZeroOrManyToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManyToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrManyToOneOrManyByIdCommand(new List<TestEntityZeroOrManyToOneOrManyKeyDto> { new TestEntityZeroOrManyToOneOrManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    #endregion
    
}
