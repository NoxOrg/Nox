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

public abstract partial class TestEntityTwoRelationshipsOneToManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOne/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestRelationshipOneNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new SecondTestEntityTwoRelationshipsOneToManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Include(x => x.TestRelationshipOne).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestRelationshipOne)
        {
            references.Add(new System.Uri($"SecondTestEntityTwoRelationshipsOneToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOne([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToManyCreateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityTwoRelationshipsOneToMany.TestRelationshipOneOnOtherSideId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToManyCommand(secondTestEntityTwoRelationshipsOneToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>> GetTestRelationshipOne(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key));
        if (!query.Any())
        {
            return NotFound();
        }
        return Ok(query.Include(x => x.TestRelationshipOne).SelectMany(x => x.TestRelationshipOne));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public virtual async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToManyDto>> GetTestRelationshipOneNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<SecondTestEntityTwoRelationshipsOneToManyDto>(Enumerable.Empty<SecondTestEntityTwoRelationshipsOneToManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> PutToTestRelationshipOneNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityTwoRelationshipsOneToManyUpdateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToManyCommand(relatedKey, secondTestEntityTwoRelationshipsOneToMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(new List<SecondTestEntityTwoRelationshipsOneToManyKeyDto> { new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOne")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(related.Select(item => new SecondTestEntityTwoRelationshipsOneToManyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwo/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestRelationshipTwoNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new SecondTestEntityTwoRelationshipsOneToManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Include(x => x.TestRelationshipTwo).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestRelationshipTwo)
        {
            references.Add(new System.Uri($"SecondTestEntityTwoRelationshipsOneToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwo([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToManyCreateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityTwoRelationshipsOneToMany.TestRelationshipTwoOnOtherSideId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToManyCommand(secondTestEntityTwoRelationshipsOneToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>> GetTestRelationshipTwo(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key));
        if (!query.Any())
        {
            return NotFound();
        }
        return Ok(query.Include(x => x.TestRelationshipTwo).SelectMany(x => x.TestRelationshipTwo));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public virtual async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToManyDto>> GetTestRelationshipTwoNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<SecondTestEntityTwoRelationshipsOneToManyDto>(Enumerable.Empty<SecondTestEntityTwoRelationshipsOneToManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> PutToTestRelationshipTwoNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityTwoRelationshipsOneToManyUpdateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToManyCommand(relatedKey, secondTestEntityTwoRelationshipsOneToMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(new List<SecondTestEntityTwoRelationshipsOneToManyKeyDto> { new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwo")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipTwo([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(related.Select(item => new SecondTestEntityTwoRelationshipsOneToManyKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
