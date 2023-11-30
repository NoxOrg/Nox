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

public abstract partial class TestEntityTwoRelationshipsManyToManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOne/$ref")]
    public async Task<ActionResult> UpdateRefToTestRelationshipOneNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new SecondTestEntityTwoRelationshipsManyToManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"SecondTestEntityTwoRelationshipsManyToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOne([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsManyToManyCreateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityTwoRelationshipsManyToMany.TestRelationshipOneOnOtherSideId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsManyToManyCommand(secondTestEntityTwoRelationshipsManyToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>> GetTestRelationshipOne(System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public virtual async Task<SingleResult<SecondTestEntityTwoRelationshipsManyToManyDto>> GetTestRelationshipOneNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<SecondTestEntityTwoRelationshipsManyToManyDto>(Enumerable.Empty<SecondTestEntityTwoRelationshipsManyToManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsManyToManyDto>> PutToTestRelationshipOneNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityTwoRelationshipsManyToManyUpdateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsManyToManyCommand(relatedKey, secondTestEntityTwoRelationshipsManyToMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwo/$ref")]
    public async Task<ActionResult> UpdateRefToTestRelationshipTwoNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new SecondTestEntityTwoRelationshipsManyToManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"SecondTestEntityTwoRelationshipsManyToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwo([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsManyToManyCreateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityTwoRelationshipsManyToMany.TestRelationshipTwoOnOtherSideId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsManyToManyCommand(secondTestEntityTwoRelationshipsManyToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>> GetTestRelationshipTwo(System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public virtual async Task<SingleResult<SecondTestEntityTwoRelationshipsManyToManyDto>> GetTestRelationshipTwoNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<SecondTestEntityTwoRelationshipsManyToManyDto>(Enumerable.Empty<SecondTestEntityTwoRelationshipsManyToManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsManyToManyDto>> PutToTestRelationshipTwoNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityTwoRelationshipsManyToManyUpdateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsManyToManyCommand(relatedKey, secondTestEntityTwoRelationshipsManyToMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
