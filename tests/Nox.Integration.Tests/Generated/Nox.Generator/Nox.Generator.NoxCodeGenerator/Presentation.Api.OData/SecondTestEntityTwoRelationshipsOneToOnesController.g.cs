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

public abstract partial class SecondTestEntityTwoRelationshipsOneToOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key), new TestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Include(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne", $"{key.ToString()}");
        }
        
        if (entity.TestRelationshipOneOnOtherSide is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityTwoRelationshipsOneToOnes/{entity.TestRelationshipOneOnOtherSide.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key), new TestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsOneToOneCreateDto testEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityTwoRelationshipsOneToOne.TestRelationshipOneId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsOneToOneCommand(testEntityTwoRelationshipsOneToOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsOneToOneDto>> GetTestRelationshipOneOnOtherSide(System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityTwoRelationshipsOneToOneDto>(Enumerable.Empty<TestEntityTwoRelationshipsOneToOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestRelationshipOneOnOtherSide != null).Select(x => x.TestRelationshipOneOnOtherSide!));
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> PutToTestRelationshipOneOnOtherSide(System.String key, [FromBody] TestEntityTwoRelationshipsOneToOneUpdateDto testEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipOneOnOtherSide", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsOneToOneCommand(related.Id, testEntityTwoRelationshipsOneToOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> PatchToTestRelationshipOneOnOtherSide(System.String key, [FromBody] Delta<TestEntityTwoRelationshipsOneToOnePartialUpdateDto> testEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid || testEntityTwoRelationshipsOneToOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipOneOnOtherSide", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityTwoRelationshipsOneToOnePartialUpdateDto>(testEntityTwoRelationshipsOneToOne);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsOneToOneCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsOneToOnes/{key}/TestRelationshipOneOnOtherSide")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsOneToOneByIdCommand(new List<TestEntityTwoRelationshipsOneToOneKeyDto> { new TestEntityTwoRelationshipsOneToOneKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key), new TestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Include(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne", $"{key.ToString()}");
        }
        
        if (entity.TestRelationshipTwoOnOtherSide is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityTwoRelationshipsOneToOnes/{entity.TestRelationshipTwoOnOtherSide.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key), new TestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsOneToOneCreateDto testEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityTwoRelationshipsOneToOne.TestRelationshipTwoId = key;
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsOneToOneCommand(testEntityTwoRelationshipsOneToOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsOneToOneDto>> GetTestRelationshipTwoOnOtherSide(System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityTwoRelationshipsOneToOneDto>(Enumerable.Empty<TestEntityTwoRelationshipsOneToOneDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestRelationshipTwoOnOtherSide != null).Select(x => x.TestRelationshipTwoOnOtherSide!));
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> PutToTestRelationshipTwoOnOtherSide(System.String key, [FromBody] TestEntityTwoRelationshipsOneToOneUpdateDto testEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipTwoOnOtherSide", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsOneToOneCommand(related.Id, testEntityTwoRelationshipsOneToOne, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> PatchToTestRelationshipTwoOnOtherSide(System.String key, [FromBody] Delta<TestEntityTwoRelationshipsOneToOnePartialUpdateDto> testEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid || testEntityTwoRelationshipsOneToOne is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipTwoOnOtherSide", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityTwoRelationshipsOneToOnePartialUpdateDto>(testEntityTwoRelationshipsOneToOne);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsOneToOneCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsOneToOnes/{key}/TestRelationshipTwoOnOtherSide")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToOne", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsOneToOneByIdCommand(new List<TestEntityTwoRelationshipsOneToOneKeyDto> { new TestEntityTwoRelationshipsOneToOneKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
