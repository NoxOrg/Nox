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
    
    [EnableQuery]
    public async Task<ActionResult<VendingMachineDto>> Get([FromRoute] System.Guid key)
    {
        var item = await _mediator.Send(new GetVendingMachineByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult<VendingMachineDto>> Post([FromBody]VendingMachineCreateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingMachine));
        
        var item = await _mediator.Send(new GetVendingMachineByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public async Task<ActionResult<VendingMachineDto>> Put([FromRoute] System.Guid key, [FromBody] VendingMachineUpdateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateVendingMachineCommand(key, vendingMachine, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public async Task<ActionResult<VendingMachineDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<VendingMachineUpdateDto> vendingMachine)
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
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateVendingMachineCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteVendingMachineByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
