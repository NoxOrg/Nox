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

public abstract partial class TestEntityExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToSecondTestEntityExactlyOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityExactlyOneToSecondTestEntityExactlyOneCommand(new TestEntityExactlyOneKeyDto(key), new SecondTestEntityExactlyOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToSecondTestEntityExactlyOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityExactlyOneByIdQuery(key))).Include(x => x.SecondTestEntityExactlyOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityExactlyOne", $"{key.ToString()}");
        }
        
        if (entity.SecondTestEntityExactlyOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"SecondTestEntityExactlyOnes/{entity.SecondTestEntityExactlyOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityExactlyOne([FromRoute] System.String key, [FromBody] SecondTestEntityExactlyOneCreateDto secondTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityExactlyOne.TestEntityExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityExactlyOneCommand(secondTestEntityExactlyOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<SecondTestEntityExactlyOneDto>> GetSecondTestEntityExactlyOne(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityExactlyOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<SecondTestEntityExactlyOneDto>(Enumerable.Empty<SecondTestEntityExactlyOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.SecondTestEntityExactlyOne != null).Select(x => x.SecondTestEntityExactlyOne!));
    }
    
    public virtual async Task<ActionResult<SecondTestEntityExactlyOneDto>> PutToSecondTestEntityExactlyOne(System.String key, [FromBody] SecondTestEntityExactlyOneUpdateDto secondTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityExactlyOneByIdQuery(key))).Select(x => x.SecondTestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityExactlyOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityExactlyOneCommand(related.Id, secondTestEntityExactlyOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityExactlyOneDto>> PatchToSecondTestEntityExactlyOne(System.String key, [FromBody] Delta<SecondTestEntityExactlyOnePartialUpdateDto> secondTestEntityExactlyOne)
    {
        if (!ModelState.IsValid || secondTestEntityExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityExactlyOneByIdQuery(key))).Select(x => x.SecondTestEntityExactlyOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityExactlyOne", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<SecondTestEntityExactlyOnePartialUpdateDto>(secondTestEntityExactlyOne);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityExactlyOneCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
