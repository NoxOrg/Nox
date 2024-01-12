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

public abstract partial class SecondTestEntityZeroOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(new SecondTestEntityZeroOrManyKeyDto(key), new TestEntityZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestEntityZeroOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TestEntityZeroOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(new SecondTestEntityZeroOrManyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityZeroOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).Include(x => x.TestEntityZeroOrManies).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("SecondTestEntityZeroOrMany", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestEntityZeroOrManies)
        {
            references.Add(new System.Uri($"TestEntityZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(new SecondTestEntityZeroOrManyKeyDto(key), new TestEntityZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityZeroOrManyToTestEntityZeroOrManiesCommand(new SecondTestEntityZeroOrManyKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrManies([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyCreateDto testEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityZeroOrMany.SecondTestEntityZeroOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyCommand(testEntityZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrManyDto>>> GetTestEntityZeroOrManies(System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("SecondTestEntityZeroOrMany", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestEntityZeroOrManies).SelectMany(x => x.TestEntityZeroOrManies));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityZeroOrManyDto>> GetTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrManyDto>(Enumerable.Empty<TestEntityZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrManyDto>> PutToTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityZeroOrManyUpdateDto testEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrManyCommand(relatedKey, testEntityZeroOrMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrManyDto>> PatchtoTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<TestEntityZeroOrManyPartialUpdateDto> testEntityZeroOrMany)
    {
        if (!ModelState.IsValid || testEntityZeroOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityZeroOrManyPartialUpdateDto>(testEntityZeroOrMany);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityZeroOrManyCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrManyByIdCommand(new List<TestEntityZeroOrManyKeyDto> { new TestEntityZeroOrManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityZeroOrManies/{key}/TestEntityZeroOrManies")]
    public virtual async Task<ActionResult> DeleteToTestEntityZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key))).Select(x => x.TestEntityZeroOrManies).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityZeroOrMany", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteTestEntityZeroOrManyByIdCommand(related.Select(item => new TestEntityZeroOrManyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
