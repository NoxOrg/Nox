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

public abstract partial class TestEntityZeroOrManyToExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(new TestEntityZeroOrManyToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestEntityExactlyOneToZeroOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TestEntityExactlyOneToZeroOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(new TestEntityZeroOrManyToExactlyOneKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).Include(x => x.TestEntityExactlyOneToZeroOrManies).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestEntityExactlyOneToZeroOrManies)
        {
            references.Add(new System.Uri($"TestEntityExactlyOneToZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(new TestEntityZeroOrManyToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrManyToExactlyOneToTestEntityExactlyOneToZeroOrManiesCommand(new TestEntityZeroOrManyToExactlyOneKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key, [FromBody] TestEntityExactlyOneToZeroOrManyCreateDto testEntityExactlyOneToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityExactlyOneToZeroOrMany.TestEntityZeroOrManyToExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneToZeroOrManyCommand(testEntityExactlyOneToZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityExactlyOneToZeroOrManyDto>>> GetTestEntityExactlyOneToZeroOrManies(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestEntityExactlyOneToZeroOrManies).SelectMany(x => x.TestEntityExactlyOneToZeroOrManies));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityExactlyOneToZeroOrManyDto>> GetTestEntityExactlyOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityExactlyOneToZeroOrManyDto>(Enumerable.Empty<TestEntityExactlyOneToZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityExactlyOneToZeroOrManyDto>> PutToTestEntityExactlyOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityExactlyOneToZeroOrManyUpdateDto testEntityExactlyOneToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityExactlyOneToZeroOrManyCommand(relatedKey, testEntityExactlyOneToZeroOrMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityExactlyOneToZeroOrManyDto>> PatchtoTestEntityExactlyOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<TestEntityExactlyOneToZeroOrManyPartialUpdateDto> testEntityExactlyOneToZeroOrMany)
    {
        if (!ModelState.IsValid || testEntityExactlyOneToZeroOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityExactlyOneToZeroOrManyPartialUpdateDto>(testEntityExactlyOneToZeroOrMany);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityExactlyOneToZeroOrManyCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).SelectMany(x => x.TestEntityExactlyOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityExactlyOneToZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityExactlyOneToZeroOrManyByIdCommand(new List<TestEntityExactlyOneToZeroOrManyKeyDto> { new TestEntityExactlyOneToZeroOrManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToExactlyOnes/{key}/TestEntityExactlyOneToZeroOrManies")]
    public virtual async Task<ActionResult> DeleteToTestEntityExactlyOneToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrManies).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToExactlyOne", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteTestEntityExactlyOneToZeroOrManyByIdCommand(related.Select(item => new TestEntityExactlyOneToZeroOrManyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
