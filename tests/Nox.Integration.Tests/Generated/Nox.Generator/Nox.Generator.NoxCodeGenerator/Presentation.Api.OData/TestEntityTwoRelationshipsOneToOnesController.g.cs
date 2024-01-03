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

public abstract partial class TestEntityTwoRelationshipsOneToOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key), new SecondTestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipOne([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Include(x => x.TestRelationshipOne).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToOne", $"{key.ToString()}");
        }
        
        if (entity.TestRelationshipOne is null)
        {
            return Ok();
        }
        var references = new System.Uri($"SecondTestEntityTwoRelationshipsOneToOnes/{entity.TestRelationshipOne.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOne([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneCreateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityTwoRelationshipsOneToOne.TestRelationshipOneOnOtherSideId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToOneCommand(secondTestEntityTwoRelationshipsOneToOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToOneDto>> GetTestRelationshipOne(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<SecondTestEntityTwoRelationshipsOneToOneDto>(Enumerable.Empty<SecondTestEntityTwoRelationshipsOneToOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestRelationshipOne != null).Select(x => x.TestRelationshipOne!));
    }
    
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> PutToTestRelationshipOne(System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneUpdateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipOne", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToOneCommand(related.Id, secondTestEntityTwoRelationshipsOneToOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> PatchToTestRelationshipOne(System.String key, [FromBody] Delta<SecondTestEntityTwoRelationshipsOneToOnePartialUpdateDto> secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid || secondTestEntityTwoRelationshipsOneToOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipOne", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<SecondTestEntityTwoRelationshipsOneToOnePartialUpdateDto>(secondTestEntityTwoRelationshipsOneToOne);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key), new SecondTestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Include(x => x.TestRelationshipTwo).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("TestEntityTwoRelationshipsOneToOne", $"{key.ToString()}");
        }
        
        if (entity.TestRelationshipTwo is null)
        {
            return Ok();
        }
        var references = new System.Uri($"SecondTestEntityTwoRelationshipsOneToOnes/{entity.TestRelationshipTwo.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwo([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneCreateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        secondTestEntityTwoRelationshipsOneToOne.TestRelationshipTwoOnOtherSideId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToOneCommand(secondTestEntityTwoRelationshipsOneToOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToOneDto>> GetTestRelationshipTwo(System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<SecondTestEntityTwoRelationshipsOneToOneDto>(Enumerable.Empty<SecondTestEntityTwoRelationshipsOneToOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestRelationshipTwo != null).Select(x => x.TestRelationshipTwo!));
    }
    
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> PutToTestRelationshipTwo(System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneUpdateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipTwo", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToOneCommand(related.Id, secondTestEntityTwoRelationshipsOneToOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> PatchToTestRelationshipTwo(System.String key, [FromBody] Delta<SecondTestEntityTwoRelationshipsOneToOnePartialUpdateDto> secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid || secondTestEntityTwoRelationshipsOneToOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipTwo", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<SecondTestEntityTwoRelationshipsOneToOnePartialUpdateDto>(secondTestEntityTwoRelationshipsOneToOne);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
