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

public abstract partial class TestEntityZeroOrManyToOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestEntityOneOrManyToZeroOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TestEntityOneOrManyToZeroOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).Include(x => x.TestEntityOneOrManyToZeroOrManies).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestEntityOneOrManyToZeroOrManies)
        {
            references.Add(new System.Uri($"TestEntityOneOrManyToZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key), new TestEntityOneOrManyToZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrManyToOneOrManyToTestEntityOneOrManyToZeroOrManiesCommand(new TestEntityZeroOrManyToOneOrManyKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromBody] TestEntityOneOrManyToZeroOrManyCreateDto testEntityOneOrManyToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityOneOrManyToZeroOrMany.TestEntityZeroOrManyToOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyToZeroOrManyCommand(testEntityOneOrManyToZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOneOrManyToZeroOrManyDto>>> GetTestEntityOneOrManyToZeroOrManies(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestEntityOneOrManyToZeroOrManies).SelectMany(x => x.TestEntityOneOrManyToZeroOrManies));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityOneOrManyToZeroOrManyDto>> GetTestEntityOneOrManyToZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManyToZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityOneOrManyToZeroOrManyDto>(Enumerable.Empty<TestEntityOneOrManyToZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrManyDto>> PutToTestEntityOneOrManyToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityOneOrManyToZeroOrManyUpdateDto testEntityOneOrManyToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManyToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOneOrManyToZeroOrManyCommand(relatedKey, testEntityOneOrManyToZeroOrMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrManyDto>> PatchtoTestEntityOneOrManyToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<TestEntityOneOrManyToZeroOrManyPartialUpdateDto> testEntityOneOrManyToZeroOrMany)
    {
        if (!ModelState.IsValid || testEntityOneOrManyToZeroOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManyToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityOneOrManyToZeroOrManyPartialUpdateDto>(testEntityOneOrManyToZeroOrMany);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityOneOrManyToZeroOrManyCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).SelectMany(x => x.TestEntityOneOrManyToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityOneOrManyToZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityOneOrManyToZeroOrManyByIdCommand(new List<TestEntityOneOrManyToZeroOrManyKeyDto> { new TestEntityOneOrManyToZeroOrManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToOneOrManies/{key}/TestEntityOneOrManyToZeroOrManies")]
    public virtual async Task<ActionResult> DeleteToTestEntityOneOrManyToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyToZeroOrManies).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteTestEntityOneOrManyToZeroOrManyByIdCommand(related.Select(item => new TestEntityOneOrManyToZeroOrManyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
