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
using Nox.Exceptions;
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
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToVendingMachine([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Include(x => x.VendingMachine).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("CashStockOrder", $"{key.ToString()}");
        }
        
        if (entity.VendingMachine is null)
        {
            return Ok();
        }
        var references = new System.Uri($"VendingMachines/{entity.VendingMachine.Id}", UriKind.Relative);
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
        var query = await _mediator.Send(new GetCashStockOrderByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<VendingMachineDto>(Enumerable.Empty<VendingMachineDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.VendingMachine != null).Select(x => x.VendingMachine!));
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
            throw new EntityNotFoundException("VendingMachine", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateVendingMachineCommand(related.Id, vendingMachine, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<VendingMachineDto>> PatchToVendingMachine(System.Int64 key, [FromBody] Delta<VendingMachinePartialUpdateDto> vendingMachine)
    {
        if (!ModelState.IsValid || vendingMachine is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Select(x => x.VendingMachine).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("VendingMachine", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<VendingMachinePartialUpdateDto>(vendingMachine);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateVendingMachineCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult> CreateRefToEmployee([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCashStockOrderToEmployeeCommand(new CashStockOrderKeyDto(key), new EmployeeKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToEmployee([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Include(x => x.Employee).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("CashStockOrder", $"{key.ToString()}");
        }
        
        if (entity.Employee is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Employees/{entity.Employee.Id}", UriKind.Relative);
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
        var query = await _mediator.Send(new GetCashStockOrderByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<EmployeeDto>(Enumerable.Empty<EmployeeDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Employee != null).Select(x => x.Employee!));
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
            throw new EntityNotFoundException("Employee", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateEmployeeCommand(related.Id, employee, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetEmployeeByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<EmployeeDto>> PatchToEmployee(System.Int64 key, [FromBody] Delta<EmployeePartialUpdateDto> employee)
    {
        if (!ModelState.IsValid || employee is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCashStockOrderByIdQuery(key))).Select(x => x.Employee).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Employee", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<EmployeePartialUpdateDto>(employee);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateEmployeeCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetEmployeeByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
