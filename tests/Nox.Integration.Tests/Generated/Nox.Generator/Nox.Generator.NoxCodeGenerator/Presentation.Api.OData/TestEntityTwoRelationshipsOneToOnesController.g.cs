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

public abstract partial class TestEntityTwoRelationshipsOneToOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key), new SecondTestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipOne([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneCreateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        secondTestEntityTwoRelationshipsOneToOne.TestRelationshipOneOnOtherSideId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToOneCommand(secondTestEntityTwoRelationshipsOneToOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"SecondTestEntityTwoRelationshipsOneToOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToOneDto>> GetTestRelationshipOne(System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Where(x => x.TestRelationshipOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<SecondTestEntityTwoRelationshipsOneToOneDto>(Enumerable.Empty<SecondTestEntityTwoRelationshipsOneToOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestRelationshipOne!));
    }
    
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> PutToTestRelationshipOne(System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneUpdateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToOneCommand(related.Id, secondTestEntityTwoRelationshipsOneToOne, _cultureCode, etag));
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
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key), new SecondTestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTestRelationshipTwo([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneCreateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        secondTestEntityTwoRelationshipsOneToOne.TestRelationshipTwoOnOtherSideId = key;
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToOneCommand(secondTestEntityTwoRelationshipsOneToOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"SecondTestEntityTwoRelationshipsOneToOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToOneDto>> GetTestRelationshipTwo(System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Where(x => x.TestRelationshipTwo != null);
        if (!related.Any())
        {
            return SingleResult.Create<SecondTestEntityTwoRelationshipsOneToOneDto>(Enumerable.Empty<SecondTestEntityTwoRelationshipsOneToOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.TestRelationshipTwo!));
    }
    
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> PutToTestRelationshipTwo(System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneUpdateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToOneCommand(related.Id, secondTestEntityTwoRelationshipsOneToOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
