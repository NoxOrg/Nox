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

public partial class ThirdTestEntityZeroOrOnesController : ThirdTestEntityZeroOrOnesControllerBase
{
    public ThirdTestEntityZeroOrOnesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class ThirdTestEntityZeroOrOnesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public ThirdTestEntityZeroOrOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ThirdTestEntityZeroOrOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetThirdTestEntityZeroOrOnesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<ThirdTestEntityZeroOrOneDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityZeroOrOneDto>> Post([FromBody]ThirdTestEntityZeroOrOneCreateDto thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateThirdTestEntityZeroOrOneCommand(thirdTestEntityZeroOrOne));
        
        var item = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityZeroOrOneDto>> Put([FromRoute] System.String key, [FromBody] ThirdTestEntityZeroOrOneUpdateDto thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateThirdTestEntityZeroOrOneCommand(key, thirdTestEntityZeroOrOne, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityZeroOrOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<ThirdTestEntityZeroOrOneDto> thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in thirdTestEntityZeroOrOne.GetChangedPropertyNames())
        {
            if(thirdTestEntityZeroOrOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateThirdTestEntityZeroOrOneCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteThirdTestEntityZeroOrOneByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToThirdTestEntityExactlyOneRelationship([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(new ThirdTestEntityZeroOrOneKeyDto(key), new ThirdTestEntityExactlyOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToThirdTestEntityExactlyOneRelationship([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key))).Select(x => x.ThirdTestEntityExactlyOneRelationship).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"ThirdTestEntityExactlyOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityExactlyOneRelationship([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(new ThirdTestEntityZeroOrOneKeyDto(key), new ThirdTestEntityExactlyOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityExactlyOneRelationship([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefThirdTestEntityZeroOrOneToThirdTestEntityExactlyOneRelationshipCommand(new ThirdTestEntityZeroOrOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
