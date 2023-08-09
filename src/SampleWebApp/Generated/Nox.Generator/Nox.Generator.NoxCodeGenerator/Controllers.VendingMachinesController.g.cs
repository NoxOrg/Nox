// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;
using Nox.Application;
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class VendingMachinesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// The Automapper.
    /// </summary>
    protected readonly IMapper _mapper;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public VendingMachinesController(
        ODataDbContext databaseContext,
        IMapper mapper,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<VendingMachineDto>>> Get()
    {
        var result = await _mediator.Send(new GetVendingMachinesQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<VendingMachineDto>> Get([FromRoute] System.UInt64 key)
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
    
    public async Task<ActionResult> Put([FromRoute] System.UInt64 key, [FromBody] VendingMachineDto updatedVendingMachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != updatedVendingMachine.Id)
        {
            return BadRequest();
        }
        
        _databaseContext.Entry(updatedVendingMachine).State = EntityState.Modified;
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VendingMachineExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(updatedVendingMachine);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.UInt64 key, [FromBody] Delta<VendingMachineDto> vendingmachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.VendingMachines.FindAsync(key);
        
        if (entity == null)
        {
            return NotFound();
        }
        
        vendingmachine.Patch(entity);
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VendingMachineExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(entity);
    }
    
    private bool VendingMachineExists(System.UInt64 key)
    {
        return _databaseContext.VendingMachines.Any(p => p.Id == key);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.UInt64 key)
    {
        var result = await _mediator.Send(new DeleteVendingMachineByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
