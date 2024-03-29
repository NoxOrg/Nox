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

public abstract partial class SecondTestEntityTwoRelationshipsManyToManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOneOnOtherSide/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestRelationshipOneOnOtherSideNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TestEntityTwoRelationshipsManyToManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Include(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestRelationshipOneOnOtherSide)
        {
            references.Add(new System.Uri($"TestEntityTwoRelationshipsManyToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsManyToManyCreateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityTwoRelationshipsManyToMany.TestRelationshipOneId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsManyToManyCommand(testEntityTwoRelationshipsManyToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>> GetTestRelationshipOneOnOtherSide(System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestRelationshipOneOnOtherSide).SelectMany(x => x.TestRelationshipOneOnOtherSide));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOneOnOtherSide/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsManyToManyDto>> GetTestRelationshipOneOnOtherSideNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOneOnOtherSide).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityTwoRelationshipsManyToManyDto>(Enumerable.Empty<TestEntityTwoRelationshipsManyToManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOneOnOtherSide/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> PutToTestRelationshipOneOnOtherSideNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityTwoRelationshipsManyToManyUpdateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOneOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipOneOnOtherSide", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsManyToManyCommand(relatedKey, testEntityTwoRelationshipsManyToMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOneOnOtherSide/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> PatchtoTestRelationshipOneOnOtherSideNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<TestEntityTwoRelationshipsManyToManyPartialUpdateDto> testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid || testEntityTwoRelationshipsManyToMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOneOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipOneOnOtherSide", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityTwoRelationshipsManyToManyPartialUpdateDto>(testEntityTwoRelationshipsManyToMany);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsManyToManyCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOneOnOtherSide/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOneOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipOneOnOtherSide", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(new List<TestEntityTwoRelationshipsManyToManyKeyDto> { new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOneOnOtherSide")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(related.Select(item => new TestEntityTwoRelationshipsManyToManyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwoOnOtherSide/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestRelationshipTwoOnOtherSideNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TestEntityTwoRelationshipsManyToManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Include(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestRelationshipTwoOnOtherSide)
        {
            references.Add(new System.Uri($"TestEntityTwoRelationshipsManyToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsManyToManyCreateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityTwoRelationshipsManyToMany.TestRelationshipTwoId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsManyToManyCommand(testEntityTwoRelationshipsManyToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>> GetTestRelationshipTwoOnOtherSide(System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestRelationshipTwoOnOtherSide).SelectMany(x => x.TestRelationshipTwoOnOtherSide));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwoOnOtherSide/{relatedKey}")]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsManyToManyDto>> GetTestRelationshipTwoOnOtherSideNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwoOnOtherSide).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityTwoRelationshipsManyToManyDto>(Enumerable.Empty<TestEntityTwoRelationshipsManyToManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwoOnOtherSide/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> PutToTestRelationshipTwoOnOtherSideNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityTwoRelationshipsManyToManyUpdateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwoOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipTwoOnOtherSide", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsManyToManyCommand(relatedKey, testEntityTwoRelationshipsManyToMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwoOnOtherSide/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> PatchtoTestRelationshipTwoOnOtherSideNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<TestEntityTwoRelationshipsManyToManyPartialUpdateDto> testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid || testEntityTwoRelationshipsManyToMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwoOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipTwoOnOtherSide", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityTwoRelationshipsManyToManyPartialUpdateDto>(testEntityTwoRelationshipsManyToMany);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsManyToManyCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwoOnOtherSide/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwoOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipTwoOnOtherSide", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(new List<TestEntityTwoRelationshipsManyToManyKeyDto> { new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwoOnOtherSide")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(related.Select(item => new TestEntityTwoRelationshipsManyToManyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
