// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public partial class WorkplacesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public WorkplacesController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<WorkplaceDto>>> Get()
    {
        var result = await _mediator.Send(new GetWorkplacesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<WorkplaceDto>> Get([FromRoute] System.UInt32 key)
    {
        var item = await _mediator.Send(new GetWorkplaceByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult<WorkplaceDto>> Post([FromBody]WorkplaceCreateDto workplace)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateWorkplaceCommand(workplace));
        
        var item = await _mediator.Send(new GetWorkplaceByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public async Task<ActionResult<WorkplaceDto>> Put([FromRoute] System.UInt32 key, [FromBody] WorkplaceUpdateDto workplace)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateWorkplaceCommand(key, workplace));
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetWorkplaceByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public async Task<ActionResult<WorkplaceDto>> Patch([FromRoute] System.UInt32 key, [FromBody] Delta<WorkplaceUpdateDto> workplace)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in workplace.GetChangedPropertyNames())
        {
            if(workplace.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateWorkplaceCommand(key, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetWorkplaceByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.UInt32 key)
    {
        var result = await _mediator.Send(new DeleteWorkplaceByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
