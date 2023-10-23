﻿// Generated

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
    public virtual async Task<ActionResult<IQueryable<EmployeePhoneNumberDto>>> GetEmployeeContactPhoneNumbers([FromRoute] System.Int64 key)
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
        
        return Ok(item.EmployeeContactPhoneNumbers);
    }
    
    [EnableQuery]
    [HttpGet("api/Employees/{key}/EmployeeContactPhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult<EmployeePhoneNumberDto>> GetEmployeeContactPhoneNumbersNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetEmployeeContactPhoneNumbers(key, new EmployeePhoneNumberKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToEmployeeContactPhoneNumbers([FromRoute] System.Int64 key, [FromBody] EmployeePhoneNumberCreateDto employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateEmployeePhoneNumberForEmployeeCommand(new EmployeeKeyDto(key), employeePhoneNumber, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetEmployeeContactPhoneNumbers(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/Employees/{key}/EmployeeContactPhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult<EmployeePhoneNumberDto>> PutToEmployeePhoneNumbersNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] EmployeePhoneNumberUpdateDto employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateEmployeePhoneNumberForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey), employeePhoneNumber, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetEmployeeContactPhoneNumbers(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/Employees/{key}/EmployeeContactPhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToEmployeePhoneNumbersNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] Delta<EmployeePhoneNumberDto> employeePhoneNumber)
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
        var updated = await _mediator.Send(new PartialUpdateEmployeePhoneNumberForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetEmployeeContactPhoneNumbers(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Employees/{key}/EmployeeContactPhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteEmployeePhoneNumberNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteEmployeePhoneNumberForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private async Task<EmployeePhoneNumberDto?> TryGetEmployeeContactPhoneNumbers(System.Int64 key, EmployeePhoneNumberKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetEmployeeByIdQuery(key))).SingleOrDefault();
        return parent?.EmployeeContactPhoneNumbers.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToEmployeeReviewingCashStockOrder([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefEmployeeToEmployeeReviewingCashStockOrderCommand(new EmployeeKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToEmployeeReviewingCashStockOrder([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Select(x => x.EmployeeReviewingCashStockOrder).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"CashStockOrders/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToEmployeeReviewingCashStockOrder([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefEmployeeToEmployeeReviewingCashStockOrderCommand(new EmployeeKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToEmployeeReviewingCashStockOrder([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefEmployeeToEmployeeReviewingCashStockOrderCommand(new EmployeeKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}