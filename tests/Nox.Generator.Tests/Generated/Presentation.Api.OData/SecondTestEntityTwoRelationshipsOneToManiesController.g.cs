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
using Nox.Extensions;
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
    
    public async Task<ActionResult> CreateRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key), new TestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityTwoRelationshipsOneToManies/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key), new TestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsOneToManyCreateDto testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        testEntityTwoRelationshipsOneToMany.TestRelationshipOneId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsOneToManyCommand(testEntityTwoRelationshipsOneToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsOneToManyDto>> GetTestRelationshipOneOnOtherSide(System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Where(x => x.TestRelationshipOneOnOtherSide != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityTwoRelationshipsOneToManyDto>(Enumerable.Empty<TestEntityTwoRelationshipsOneToManyDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestRelationshipOneOnOtherSide!));
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToManyDto>> PutToTestRelationshipOneOnOtherSide(System.String key, [FromBody] TestEntityTwoRelationshipsOneToManyUpdateDto testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsOneToManyCommand(related.Id, testEntityTwoRelationshipsOneToMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOneOnOtherSide")]
    public async Task<ActionResult> DeleteToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsOneToManyByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key), new TestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityTwoRelationshipsOneToManies/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key), new TestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsOneToManyCreateDto testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        testEntityTwoRelationshipsOneToMany.TestRelationshipTwoId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsOneToManyCommand(testEntityTwoRelationshipsOneToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsOneToManyDto>> GetTestRelationshipTwoOnOtherSide(System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Where(x => x.TestRelationshipTwoOnOtherSide != null);
        if (!related.Any())
        {
            return SingleResult.Create<TestEntityTwoRelationshipsOneToManyDto>(Enumerable.Empty<TestEntityTwoRelationshipsOneToManyDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestRelationshipTwoOnOtherSide!));
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToManyDto>> PutToTestRelationshipTwoOnOtherSide(System.String key, [FromBody] TestEntityTwoRelationshipsOneToManyUpdateDto testEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsOneToManyCommand(related.Id, testEntityTwoRelationshipsOneToMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwoOnOtherSide")]
    public async Task<ActionResult> DeleteToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsOneToManyByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    #endregion
    
}