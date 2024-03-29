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

public abstract partial class ThirdTestEntityOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToThirdTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(new ThirdTestEntityOneOrManyKeyDto(key), new ThirdTestEntityZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/ThirdTestEntityOneOrManies/{key}/ThirdTestEntityZeroOrManies/$ref")]
    public virtual async Task<ActionResult> UpdateRefToThirdTestEntityZeroOrManiesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new ThirdTestEntityZeroOrManyKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(new ThirdTestEntityOneOrManyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToThirdTestEntityZeroOrManies([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(key))).Include(x => x.ThirdTestEntityZeroOrManies).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("ThirdTestEntityOneOrMany", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.ThirdTestEntityZeroOrManies)
        {
            references.Add(new System.Uri($"ThirdTestEntityZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToThirdTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(new ThirdTestEntityOneOrManyKeyDto(key), new ThirdTestEntityZeroOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToThirdTestEntityZeroOrManies([FromRoute] System.String key, [FromBody] ThirdTestEntityZeroOrManyCreateDto thirdTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        thirdTestEntityZeroOrMany.ThirdTestEntityOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateThirdTestEntityZeroOrManyCommand(thirdTestEntityZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ThirdTestEntityZeroOrManyDto>>> GetThirdTestEntityZeroOrManies(System.String key)
    {
        var query = await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("ThirdTestEntityOneOrMany", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.ThirdTestEntityZeroOrManies).SelectMany(x => x.ThirdTestEntityZeroOrManies));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/ThirdTestEntityOneOrManies/{key}/ThirdTestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<SingleResult<ThirdTestEntityZeroOrManyDto>> GetThirdTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.ThirdTestEntityZeroOrManies).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<ThirdTestEntityZeroOrManyDto>(Enumerable.Empty<ThirdTestEntityZeroOrManyDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/ThirdTestEntityOneOrManies/{key}/ThirdTestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<ThirdTestEntityZeroOrManyDto>> PutToThirdTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] ThirdTestEntityZeroOrManyUpdateDto thirdTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.ThirdTestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("ThirdTestEntityZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateThirdTestEntityZeroOrManyCommand(relatedKey, thirdTestEntityZeroOrMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/ThirdTestEntityOneOrManies/{key}/ThirdTestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<ThirdTestEntityZeroOrManyDto>> PatchtoThirdTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<ThirdTestEntityZeroOrManyPartialUpdateDto> thirdTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid || thirdTestEntityZeroOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.ThirdTestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("ThirdTestEntityZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<ThirdTestEntityZeroOrManyPartialUpdateDto>(thirdTestEntityZeroOrMany);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateThirdTestEntityZeroOrManyCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/ThirdTestEntityOneOrManies/{key}/ThirdTestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToThirdTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(key))).SelectMany(x => x.ThirdTestEntityZeroOrManies).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("ThirdTestEntityZeroOrManies", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteThirdTestEntityZeroOrManyByIdCommand(new List<ThirdTestEntityZeroOrManyKeyDto> { new ThirdTestEntityZeroOrManyKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    #endregion
    
}
