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
using Nox.Application.Dto;
using Nox.Extensions;
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class CashStockOrdersControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToVendingMachine([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCashStockOrderToVendingMachineCommand(new CashStockOrderKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToVendingMachine([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Select(x => x.VendingMachine).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"VendingMachines/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToVendingMachine([FromRoute] System.Int64 key, [FromBody] VendingMachineCreateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        vendingMachine.CashStockOrdersId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingMachine, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetVendingMachineByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<VendingMachineDto>> GetVendingMachine(System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Where(x => x.VendingMachine != null);
        if (!related.Any())
        {
            return SingleResult.Create<VendingMachineDto>(Enumerable.Empty<VendingMachineDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.VendingMachine!));
    }
    
    public virtual async Task<ActionResult<VendingMachineDto>> PutToVendingMachine(System.Int64 key, [FromBody] VendingMachineUpdateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Select(x => x.VendingMachine).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateVendingMachineCommand(related.Id, vendingMachine, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    public virtual async Task<ActionResult> CreateRefToEmployee([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCashStockOrderToEmployeeCommand(new CashStockOrderKeyDto(key), new EmployeeKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToEmployee([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Select(x => x.Employee).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Employees/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToEmployee([FromRoute] System.Int64 key, [FromBody] EmployeeCreateDto employee)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        employee.CashStockOrderId = key;
        var createdKey = await _mediator.Send(new CreateEmployeeCommand(employee, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetEmployeeByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<EmployeeDto>> GetEmployee(System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Where(x => x.Employee != null);
        if (!related.Any())
        {
            return SingleResult.Create<EmployeeDto>(Enumerable.Empty<EmployeeDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Employee!));
    }
    
    public virtual async Task<ActionResult<EmployeeDto>> PutToEmployee(System.Int64 key, [FromBody] EmployeeUpdateDto employee)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Select(x => x.Employee).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateEmployeeCommand(related.Id, employee, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
