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
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public partial class RatingProgramsController : RatingProgramsControllerBase
{
    public RatingProgramsController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class RatingProgramsControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public RatingProgramsControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<RatingProgramDto>>> Get()
    {
        var result = await _mediator.Send(new GetRatingProgramsQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<RatingProgramDto>> Get([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId)
    {
        var query = await _mediator.Send(new GetRatingProgramByIdQuery(keyStoreId, keyId));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<RatingProgramDto>> Post([FromBody]RatingProgramCreateDto ratingProgram)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateRatingProgramCommand(ratingProgram));
        
        var item = (await _mediator.Send(new GetRatingProgramByIdQuery(createdKey.keyStoreId, createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<RatingProgramDto>> Put([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId, [FromBody] RatingProgramUpdateDto ratingProgram)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateRatingProgramCommand(keyStoreId, keyId, ratingProgram, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetRatingProgramByIdQuery(updated.keyStoreId, updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<RatingProgramDto>> Patch([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId, [FromBody] Delta<RatingProgramDto> ratingProgram)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in ratingProgram.GetChangedPropertyNames())
        {
            if(ratingProgram.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateRatingProgramCommand(keyStoreId, keyId, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetRatingProgramByIdQuery(updated.keyStoreId, updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteRatingProgramByIdCommand(keyStoreId, keyId, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
