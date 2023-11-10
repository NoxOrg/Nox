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
    
    public async Task<ActionResult> CreateRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOne([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsManyToManyCreateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        secondTestEntityTwoRelationshipsManyToMany.TestRelationshipOneOnOtherSideId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsManyToManyCommand(secondTestEntityTwoRelationshipsManyToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
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
    
    public async Task<ActionResult> DeleteRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
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
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipOneCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("api/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipOne/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsManyToManyDto>> PutToTestRelationshipOneNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityTwoRelationshipsManyToManyUpdateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault()?.SingleOrDefault(x => x.Id == relatedKey);
        if (related == null)
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
    
    public async Task<ActionResult> CreateRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwo([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsManyToManyCreateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        secondTestEntityTwoRelationshipsManyToMany.TestRelationshipTwoOnOtherSideId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsManyToManyCommand(secondTestEntityTwoRelationshipsManyToMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
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
    
    public async Task<ActionResult> DeleteRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key), new SecondTestEntityTwoRelationshipsManyToManyKeyDto(relatedKey)));
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
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityTwoRelationshipsManyToManyToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsManyToManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("api/TestEntityTwoRelationshipsManyToManies/{key}/TestRelationshipTwo/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsManyToManyDto>> PutToTestRelationshipTwoNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityTwoRelationshipsManyToManyUpdateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault()?.SingleOrDefault(x => x.Id == relatedKey);
        if (related == null)
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
    
    #endregion
    
}
