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

public partial class ThirdTestEntityExactlyOnesController : ThirdTestEntityExactlyOnesControllerBase
{
    public ThirdTestEntityExactlyOnesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class ThirdTestEntityExactlyOnesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public ThirdTestEntityExactlyOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ThirdTestEntityExactlyOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetThirdTestEntityExactlyOnesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<ThirdTestEntityExactlyOneDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityExactlyOneDto>> Post([FromBody]ThirdTestEntityExactlyOneCreateDto thirdTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateThirdTestEntityExactlyOneCommand(thirdTestEntityExactlyOne));
        
        var item = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityExactlyOneDto>> Put([FromRoute] System.String key, [FromBody] ThirdTestEntityExactlyOneUpdateDto thirdTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateThirdTestEntityExactlyOneCommand(key, thirdTestEntityExactlyOne, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityExactlyOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<ThirdTestEntityExactlyOneDto> thirdTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in thirdTestEntityExactlyOne.GetChangedPropertyNames())
        {
            if(thirdTestEntityExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateThirdTestEntityExactlyOneCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteThirdTestEntityExactlyOneByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToThirdTestEntityZeroOrOneRelationship([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(new ThirdTestEntityExactlyOneKeyDto(key), new ThirdTestEntityZeroOrOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToThirdTestEntityZeroOrOneRelationship([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(key))).Select(x => x.ThirdTestEntityZeroOrOneRelationship).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"ThirdTestEntityZeroOrOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityZeroOrOneRelationship([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(new ThirdTestEntityExactlyOneKeyDto(key), new ThirdTestEntityZeroOrOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityZeroOrOneRelationship([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneRelationshipCommand(new ThirdTestEntityExactlyOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
