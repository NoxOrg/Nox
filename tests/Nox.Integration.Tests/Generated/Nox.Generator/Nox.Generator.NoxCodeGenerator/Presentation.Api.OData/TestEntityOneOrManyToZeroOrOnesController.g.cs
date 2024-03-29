﻿// Generated

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

public abstract partial class TestEntityOneOrManyToZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToOneOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityOneOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToOneOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestEntityZeroOrOneToOneOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TestEntityZeroOrOneToOneOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrOneKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).Include(x => x.TestEntityZeroOrOneToOneOrManies).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestEntityZeroOrOneToOneOrManies)
        {
            references.Add(new System.Uri($"TestEntityZeroOrOneToOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManiesCommand(new TestEntityOneOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToOneOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key, [FromBody] TestEntityZeroOrOneToOneOrManyCreateDto testEntityZeroOrOneToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityZeroOrOneToOneOrMany.TestEntityOneOrManyToZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrOneToOneOrManyCommand(testEntityZeroOrOneToOneOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrOneToOneOrManyDto>>> GetTestEntityZeroOrOneToOneOrManies(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrOne", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestEntityZeroOrOneToOneOrManies).SelectMany(x => x.TestEntityZeroOrOneToOneOrManies));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOneOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToOneOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityZeroOrOneToOneOrManyDto>> GetTestEntityZeroOrOneToOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToOneOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrOneToOneOrManyDto>(Enumerable.Empty<TestEntityZeroOrOneToOneOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityOneOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrOneToOneOrManyDto>> PutToTestEntityZeroOrOneToOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityZeroOrOneToOneOrManyUpdateDto testEntityZeroOrOneToOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrOneToOneOrManyCommand(relatedKey, testEntityZeroOrOneToOneOrMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/TestEntityOneOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrOneToOneOrManyDto>> PatchtoTestEntityZeroOrOneToOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<TestEntityZeroOrOneToOneOrManyPartialUpdateDto> testEntityZeroOrOneToOneOrMany)
    {
        if (!ModelState.IsValid || testEntityZeroOrOneToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrManies", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityZeroOrOneToOneOrManyPartialUpdateDto>(testEntityZeroOrOneToOneOrMany);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityZeroOrOneToOneOrManyCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityOneOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestEntityZeroOrOneToOneOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToOneOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrOneToOneOrManyByIdCommand(new List<TestEntityZeroOrOneToOneOrManyKeyDto> { new TestEntityZeroOrOneToOneOrManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    #endregion
    
}
