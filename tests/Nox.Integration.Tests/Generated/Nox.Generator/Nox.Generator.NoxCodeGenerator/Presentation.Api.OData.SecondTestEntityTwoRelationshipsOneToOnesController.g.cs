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

public partial class SecondTestEntityTwoRelationshipsOneToOnesController : SecondTestEntityTwoRelationshipsOneToOnesControllerBase
{
    public SecondTestEntityTwoRelationshipsOneToOnesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class SecondTestEntityTwoRelationshipsOneToOnesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public SecondTestEntityTwoRelationshipsOneToOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOnesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToOneDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> Post([FromBody]SecondTestEntityTwoRelationshipsOneToOneCreateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToOneCommand(secondTestEntityTwoRelationshipsOneToOne));
        
        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> Put([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneUpdateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToOneCommand(key, secondTestEntityTwoRelationshipsOneToOne, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<SecondTestEntityTwoRelationshipsOneToOneDto> secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityTwoRelationshipsOneToOne.GetChangedPropertyNames())
        {
            if(secondTestEntityTwoRelationshipsOneToOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key), new TestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipOneOnOtherSide).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityTwoRelationshipsOneToOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipOneOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key), new TestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
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
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipOneOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key)));
        if (!deletedAllRef)
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
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key), new TestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipTwoOnOtherSide).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityTwoRelationshipsOneToOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipTwoOnOtherSide([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key), new TestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
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
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoOnOtherSideCommand(new SecondTestEntityTwoRelationshipsOneToOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
