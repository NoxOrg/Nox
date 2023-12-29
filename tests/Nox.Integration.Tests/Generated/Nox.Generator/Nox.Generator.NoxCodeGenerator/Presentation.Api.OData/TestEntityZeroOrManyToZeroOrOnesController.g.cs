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

public abstract partial class TestEntityZeroOrManyToZeroOrOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(new TestEntityZeroOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestEntityZeroOrOneToZeroOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TestEntityZeroOrOneToZeroOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(new TestEntityZeroOrManyToZeroOrOneKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).Include(x => x.TestEntityZeroOrOneToZeroOrManies).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestEntityZeroOrOneToZeroOrManies)
        {
            references.Add(new System.Uri($"TestEntityZeroOrOneToZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(new TestEntityZeroOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrManyToZeroOrOneToTestEntityZeroOrOneToZeroOrManiesCommand(new TestEntityZeroOrManyToZeroOrOneKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key, [FromBody] TestEntityZeroOrOneToZeroOrManyCreateDto testEntityZeroOrOneToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityZeroOrOneToZeroOrMany.TestEntityZeroOrManyToZeroOrOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrOneToZeroOrManyCommand(testEntityZeroOrOneToZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrOneToZeroOrManyDto>>> GetTestEntityZeroOrOneToZeroOrManies(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestEntityZeroOrOneToZeroOrManies).SelectMany(x => x.TestEntityZeroOrOneToZeroOrManies));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityZeroOrOneToZeroOrManyDto>> GetTestEntityZeroOrOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityZeroOrOneToZeroOrManyDto>(Enumerable.Empty<TestEntityZeroOrOneToZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrOneToZeroOrManyDto>> PutToTestEntityZeroOrOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityZeroOrOneToZeroOrManyUpdateDto testEntityZeroOrOneToZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrOneToZeroOrManyCommand(relatedKey, testEntityZeroOrOneToZeroOrMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityZeroOrOneToZeroOrManyDto>> PatchtoTestEntityZeroOrOneToZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<TestEntityZeroOrOneToZeroOrManyPartialUpdateDto> testEntityZeroOrOneToZeroOrMany)
    {
        if (!ModelState.IsValid || testEntityZeroOrOneToZeroOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in testEntityZeroOrOneToZeroOrMany.GetChangedPropertyNames())
        {
            if(testEntityZeroOrOneToZeroOrMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityZeroOrOneToZeroOrManyCommand(relatedKey, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityZeroOrOneToZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).SelectMany(x => x.TestEntityZeroOrOneToZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand(new List<TestEntityZeroOrOneToZeroOrManyKeyDto> { new TestEntityZeroOrOneToZeroOrManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityZeroOrManyToZeroOrOnes/{key}/TestEntityZeroOrOneToZeroOrManies")]
    public virtual async Task<ActionResult> DeleteToTestEntityZeroOrOneToZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOneToZeroOrManies).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToZeroOrOne", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteTestEntityZeroOrOneToZeroOrManyByIdCommand(related.Select(item => new TestEntityZeroOrOneToZeroOrManyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
