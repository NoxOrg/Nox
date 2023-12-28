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
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOne/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestRelationshipOneNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new SecondTestEntityTwoRelationshipsManyToManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Include(x => x.TestRelationshipOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestRelationshipOne)
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
        var query = await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestRelationshipOne).SelectMany(x => x.TestRelationshipOne));
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
            throw new EntityNotFoundException("TestRelationshipOne", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsManyToManyCommand(relatedKey, secondTestEntityTwoRelationshipsManyToMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsManyToManyDto>> PatchtoTestRelationshipOneNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<SecondTestEntityTwoRelationshipsManyToManyPartialUpdateDto> secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid || secondTestEntityTwoRelationshipsManyToMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipOne", $"{relatedKey.ToString()}");
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityTwoRelationshipsManyToMany.GetChangedPropertyNames())
        {
            if(secondTestEntityTwoRelationshipsManyToMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand(relatedKey, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipOne", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand(new List<SecondTestEntityTwoRelationshipsManyToManyKeyDto> { new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwo/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTestRelationshipTwoNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new SecondTestEntityTwoRelationshipsManyToManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Include(x => x.TestRelationshipTwo).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.TestRelationshipTwo)
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
        var query = await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.TestRelationshipTwo).SelectMany(x => x.TestRelationshipTwo));
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
            throw new EntityNotFoundException("TestRelationshipTwo", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsManyToManyCommand(relatedKey, secondTestEntityTwoRelationshipsManyToMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsManyToManyDto>> PatchtoTestRelationshipTwoNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<SecondTestEntityTwoRelationshipsManyToManyPartialUpdateDto> secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid || secondTestEntityTwoRelationshipsManyToMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipTwo", $"{relatedKey.ToString()}");
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityTwoRelationshipsManyToMany.GetChangedPropertyNames())
        {
            if(secondTestEntityTwoRelationshipsManyToMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand(relatedKey, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("TestRelationshipTwo", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand(new List<SecondTestEntityTwoRelationshipsManyToManyKeyDto> { new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    #endregion
    
}
