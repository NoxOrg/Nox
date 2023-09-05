// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public partial class VendingMachinesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public VendingMachinesController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<VendingMachineDto>>> Get()
    {
        var result = await _mediator.Send(new GetVendingMachinesQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<VendingMachineDto>> Get([FromRoute] System.Guid key)
    {
        var item = await _mediator.Send(new GetVendingMachineByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post([FromBody]VendingMachineCreateDto vendingmachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingmachine));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.Guid key, [FromBody] VendingMachineUpdateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateVendingMachineCommand(key, vendingMachine));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.Guid key, [FromBody] Delta<VendingMachineUpdateDto> vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in vendingMachine.GetChangedPropertyNames())
        {
            if(vendingMachine.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateVendingMachineCommand(key, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var result = await _mediator.Send(new DeleteVendingMachineByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
