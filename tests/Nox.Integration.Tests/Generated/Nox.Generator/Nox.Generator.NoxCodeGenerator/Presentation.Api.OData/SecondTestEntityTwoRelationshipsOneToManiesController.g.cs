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

public abstract partial class SecondTestEntityTwoRelationshipsOneToManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key), new TestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Include(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{key.ToString()}");
        }
        
        if (entity.TestRelationshipOneOnOtherSide is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityTwoRelationshipsOneToManies/{entity.TestRelationshipOneOnOtherSide.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key), new TestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsOneToManyCreateDto testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityTwoRelationshipsOneToMany.TestRelationshipOneId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsOneToManyCommand(testEntityTwoRelationshipsOneToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsOneToManyDto>> GetTestRelationshipOneOnOtherSide(System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityTwoRelationshipsOneToManyDto>(Enumerable.Empty<TestEntityTwoRelationshipsOneToManyDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestRelationshipOneOnOtherSide != null).Select(x => x.TestRelationshipOneOnOtherSide!));
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToManyDto>> PutToTestRelationshipOneOnOtherSide(System.String key, [FromBody] TestEntityTwoRelationshipsOneToManyUpdateDto testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipOneOnOtherSide", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsOneToManyCommand(related.Id, testEntityTwoRelationshipsOneToMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToManyDto>> PatchToTestRelationshipOneOnOtherSide(System.String key, [FromBody] Delta<TestEntityTwoRelationshipsOneToManyPartialUpdateDto> testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid || testEntityTwoRelationshipsOneToMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipOneOnOtherSide", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityTwoRelationshipsOneToManyPartialUpdateDto>(testEntityTwoRelationshipsOneToMany);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsOneToManyCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOneOnOtherSide")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsOneToManyByIdCommand(new List<TestEntityTwoRelationshipsOneToManyKeyDto> { new TestEntityTwoRelationshipsOneToManyKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key), new TestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Include(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{key.ToString()}");
        }
        
        if (entity.TestRelationshipTwoOnOtherSide is null)
        {
            return Ok();
        }
        var references = new System.Uri($"TestEntityTwoRelationshipsOneToManies/{entity.TestRelationshipTwoOnOtherSide.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key), new TestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsOneToManyCreateDto testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        testEntityTwoRelationshipsOneToMany.TestRelationshipTwoId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsOneToManyCommand(testEntityTwoRelationshipsOneToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsOneToManyDto>> GetTestRelationshipTwoOnOtherSide(System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TestEntityTwoRelationshipsOneToManyDto>(Enumerable.Empty<TestEntityTwoRelationshipsOneToManyDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.TestRelationshipTwoOnOtherSide != null).Select(x => x.TestRelationshipTwoOnOtherSide!));
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToManyDto>> PutToTestRelationshipTwoOnOtherSide(System.String key, [FromBody] TestEntityTwoRelationshipsOneToManyUpdateDto testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipTwoOnOtherSide", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsOneToManyCommand(related.Id, testEntityTwoRelationshipsOneToMany, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToManyDto>> PatchToTestRelationshipTwoOnOtherSide(System.String key, [FromBody] Delta<TestEntityTwoRelationshipsOneToManyPartialUpdateDto> testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid || testEntityTwoRelationshipsOneToMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("TestRelationshipTwoOnOtherSide", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityTwoRelationshipsOneToManyPartialUpdateDto>(testEntityTwoRelationshipsOneToMany);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsOneToManyCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwoOnOtherSide")]
    public virtual async Task<ActionResult> DeleteToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsOneToManyByIdCommand(new List<TestEntityTwoRelationshipsOneToManyKeyDto> { new TestEntityTwoRelationshipsOneToManyKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
