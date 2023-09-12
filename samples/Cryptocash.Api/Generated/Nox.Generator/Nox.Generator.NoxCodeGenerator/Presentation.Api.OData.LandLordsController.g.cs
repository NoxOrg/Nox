// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Net.Http.Headers;
using Nox.Application;
using Nox.Extensions;
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public partial class LandLordsController : LandLordsControllerBase
            {
                public LandLordsController(IMediator mediator, DtoDbContext databaseContext):base(databaseContext, mediator)
                {}
            }
public abstract class LandLordsControllerBase : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public LandLordsControllerBase(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<LandLordDto>>> Get()
    {
        var result = await _mediator.Send(new GetLandLordsQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<LandLordDto>> Get([FromRoute] System.Int64 key)
    {
        var item = await _mediator.Send(new GetLandLordByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<LandLordDto>> Post([FromBody]LandLordCreateDto landLord)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateLandLordCommand(landLord));
        
        var item = await _mediator.Send(new GetLandLordByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<LandLordDto>> Put([FromRoute] System.Int64 key, [FromBody] LandLordUpdateDto landLord)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateLandLordCommand(key, landLord, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetLandLordByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<LandLordDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<LandLordUpdateDto> landLord)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in landLord.GetChangedPropertyNames())
        {
            if(landLord.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateLandLordCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetLandLordByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteLandLordByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
