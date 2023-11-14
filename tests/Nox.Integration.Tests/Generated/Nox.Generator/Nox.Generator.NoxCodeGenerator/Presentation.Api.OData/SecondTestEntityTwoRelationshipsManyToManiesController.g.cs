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

public abstract partial class SecondTestEntityTwoRelationshipsManyToManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsManyToManyCreateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityTwoRelationshipsManyToMany.TestRelationshipOneId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsManyToManyCommand(testEntityTwoRelationshipsManyToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityTwoRelationshipsManyToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
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
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOneOnOtherSide/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOneOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOneOnOtherSide")]
    public async Task<ActionResult> DeleteToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOneOnOtherSide/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> PutToTestRelationshipOneOnOtherSideNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityTwoRelationshipsManyToManyUpdateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOneOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsManyToManyCommand(relatedKey, testEntityTwoRelationshipsManyToMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    public async Task<ActionResult> CreateRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsManyToManyCreateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        testEntityTwoRelationshipsManyToMany.TestRelationshipTwoId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsManyToManyCommand(testEntityTwoRelationshipsManyToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityTwoRelationshipsManyToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key), new TestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
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
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsManyToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwoOnOtherSide/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwoOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwoOnOtherSide")]
    public async Task<ActionResult> DeleteToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("/api/v1/SecondTestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwoOnOtherSide/{relatedKey}")]
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> PutToTestRelationshipTwoOnOtherSideNonConventional(System.String key, System.String relatedKey, [FromBody] TestEntityTwoRelationshipsManyToManyUpdateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwoOnOtherSide).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsManyToManyCommand(relatedKey, testEntityTwoRelationshipsManyToMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
