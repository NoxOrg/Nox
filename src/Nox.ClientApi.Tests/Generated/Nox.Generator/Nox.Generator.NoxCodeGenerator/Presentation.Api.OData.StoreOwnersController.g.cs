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

[Route("{controller}")]
public partial class StoreOwnersController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public StoreOwnersController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [HttpGet]
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<StoreOwnerDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoreOwnersQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<StoreOwnerDto>> Get([FromRoute] System.String key)
    {
        var item = await _mediator.Send(new GetStoreOwnerByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody]StoreOwnerCreateDto storeowner)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateStoreOwnerCommand(storeowner));
        
        return Created(createdKey);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromRoute] System.String key, [FromBody] StoreOwnerUpdateDto storeOwner)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateStoreOwnerCommand(key, storeOwner));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    [HttpPatch]
    public async Task<ActionResult> Patch([FromRoute] System.String key, [FromBody] Delta<StoreOwnerUpdateDto> storeOwner)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in storeOwner.GetChangedPropertyNames())
        {
            if(storeOwner.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateStoreOwnerCommand(key, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new DeleteStoreOwnerByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
