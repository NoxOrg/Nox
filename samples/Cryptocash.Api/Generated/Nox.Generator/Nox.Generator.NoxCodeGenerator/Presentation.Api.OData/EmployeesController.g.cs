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
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class EmployeesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<EmployeePhoneNumberDto>>> GetEmployeePhoneNumbers([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetEmployeeByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.EmployeePhoneNumbers);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Employees/{key}/EmployeePhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult<EmployeePhoneNumberDto>> GetEmployeePhoneNumbersNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetEmployeePhoneNumbers(key, new EmployeePhoneNumberKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToEmployeePhoneNumbers([FromRoute] System.Int64 key, [FromBody] EmployeePhoneNumberCreateDto employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), employeePhoneNumber, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetEmployeePhoneNumbers(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("/api/v1/Employees/{key}/EmployeePhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult<EmployeePhoneNumberDto>> PutToEmployeePhoneNumbersNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] EmployeePhoneNumberUpdateDto employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey), employeePhoneNumber, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetEmployeePhoneNumbers(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("/api/v1/Employees/{key}/EmployeePhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToEmployeePhoneNumbersNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] Delta<EmployeePhoneNumberUpdateDto> employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in employeePhoneNumber.GetChangedPropertyNames())
        {
            if(employeePhoneNumber.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetEmployeePhoneNumbers(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/Employees/{key}/EmployeePhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteEmployeePhoneNumberNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    protected async Task<EmployeePhoneNumberDto?> TryGetEmployeePhoneNumbers(System.Int64 key, EmployeePhoneNumberKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetEmployeeByIdQuery(key))).SingleOrDefault();
        return parent?.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToCashStockOrder([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefEmployeeToCashStockOrderCommand(new EmployeeKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCashStockOrder([FromRoute] System.Int64 key, [FromBody] CashStockOrderCreateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        cashStockOrder.EmployeeId = key;
        var createdKey = await _mediator.Send(new CreateCashStockOrderCommand(cashStockOrder, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCashStockOrderByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToCashStockOrder([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Select(x => x.CashStockOrder).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"CashStockOrders/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CashStockOrderDto>> GetCashStockOrder(System.Int64 key)
    {
        var related = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Where(x => x.CashStockOrder != null);
        if (!related.Any())
        {
            return SingleResult.Create<CashStockOrderDto>(Enumerable.Empty<CashStockOrderDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.CashStockOrder!));
    }
    
    public async Task<ActionResult> DeleteRefToCashStockOrder([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefEmployeeToCashStockOrderCommand(new EmployeeKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCashStockOrder([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefEmployeeToCashStockOrderCommand(new EmployeeKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/Employees/{key}/CashStockOrder")]
    public async Task<ActionResult> DeleteToCashStockOrder([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        cashStockOrder.EmployeeId = key;
        var createdKey = await _mediator.Send(new CreateCashStockOrderCommand(cashStockOrder, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCashStockOrderByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CashStockOrderDto>> GetCashStockOrder(System.Int64 key)
    {
        var related = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Where(x => x.CashStockOrder != null);
        if (!related.Any())
        {
            return SingleResult.Create<CashStockOrderDto>(Enumerable.Empty<CashStockOrderDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.CashStockOrder!));
    }
    
    public virtual async Task<ActionResult<CashStockOrderDto>> PutToCashStockOrder(System.Int64 key, [FromBody] CashStockOrderUpdateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Select(x => x.CashStockOrder).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCashStockOrderByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    public virtual async Task<ActionResult<CashStockOrderDto>> PutToCashStockOrder(System.Int64 key, [FromBody] CashStockOrderUpdateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Select(x => x.CashStockOrder).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCashStockOrderCommand(related.Id, cashStockOrder, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
