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

public abstract partial class TestEntityTwoRelationshipsOneToManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOne([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToManyCreateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        secondTestEntityTwoRelationshipsOneToMany.TestRelationshipOneOnOtherSideId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToManyCommand(secondTestEntityTwoRelationshipsOneToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"SecondTestEntityTwoRelationshipsOneToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("api/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipOne).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("api/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOne")]
    public async Task<ActionResult> DeleteToTestRelationshipOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("api/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> PutToTestRelationshipOneNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityTwoRelationshipsOneToManyUpdateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
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
        
        return Ok();
    }
    
    public async Task<ActionResult> CreateRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwo([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToManyCreateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        secondTestEntityTwoRelationshipsOneToMany.TestRelationshipTwoOnOtherSideId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToManyCommand(secondTestEntityTwoRelationshipsOneToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"SecondTestEntityTwoRelationshipsOneToManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key), new SecondTestEntityTwoRelationshipsOneToManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityTwoRelationshipsOneToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("api/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public async Task<ActionResult> DeleteToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).SelectMany(x => x.TestRelationshipTwo).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("api/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwo")]
    public async Task<ActionResult> DeleteToTestRelationshipTwo([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToManyByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("api/TestEntityTwoRelationshipsOneToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> PutToTestRelationshipTwoNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityTwoRelationshipsOneToManyUpdateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
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
        
        return Ok();
    }
    
    #endregion
    
}
