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

public abstract partial class EmployeesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<EmployeePhoneNumberDto>>> GetEmployeePhoneNumbers([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetEmployeeByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            throw new EntityNotFoundException("Employee", $"{key.ToString()}");
        }
        
        return Ok(item.EmployeePhoneNumbers);
    }
    
    [EnableQuery]
    [HttpGet("/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult<EmployeePhoneNumberDto>> GetEmployeePhoneNumbersNonConventional(System.Guid key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetEmployeePhoneNumbers(key, new EmployeePhoneNumberKeyDto(relatedKey));
        if (child is null)
        {
            throw new EntityNotFoundException("EmployeePhoneNumber", $"{relatedKey.ToString()}");
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToEmployeePhoneNumbers([FromRoute] System.Guid key, [FromBody] EmployeePhoneNumberUpsertDto employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), employeePhoneNumber, _cultureCode, etag));
        
        var child = await TryGetEmployeePhoneNumbers(key, createdKey);
        return Created(child);
    }
    
    public virtual async Task<ActionResult<EmployeePhoneNumberDto>> PutToEmployeePhoneNumbers(System.Guid key, [FromBody] EntityDtoCollection<EmployeePhoneNumberUpsertDto> employeePhoneNumbers)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKeys = await _mediator.Send(new UpdateEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), employeePhoneNumbers.Values!, _cultureCode, etag));
        
        var children = (await _mediator.Send(new GetEmployeeByIdQuery(key))).SingleOrDefault()?.EmployeePhoneNumbers?.Where(e => updatedKeys.Any(k => e.Id == k.keyId));
        
        return Ok(children);
    }
    
    public virtual async Task<ActionResult> PatchToEmployeePhoneNumbers(System.Guid key, [FromBody] Delta<EmployeePhoneNumberUpsertDto> employeePhoneNumber)
    {
        if (!ModelState.IsValid || employeePhoneNumber is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<EmployeePhoneNumberUpsertDto>(employeePhoneNumber);
        
        if(!updatedProperties.ContainsKey("Id") || updatedProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(updatedProperties["Id"]), updatedProperties, _cultureCode, etag));
        
        var child = await TryGetEmployeePhoneNumbers(key, updated!);
        
        return Ok(child);
    }
    
    [HttpDelete("/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteEmployeePhoneNumberNonConventional(System.Guid key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<EmployeePhoneNumberDto?> TryGetEmployeePhoneNumbers(System.Guid key, EmployeePhoneNumberKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetEmployeeByIdQuery(key))).SingleOrDefault();
        return parent?.EmployeePhoneNumbers.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToCashStockOrder([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefEmployeeToCashStockOrderCommand(new EmployeeKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCashStockOrder([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Include(x => x.CashStockOrder).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Employee", $"{key.ToString()}");
        }
        
        if (entity.CashStockOrder is null)
        {
            return Ok();
        }
        var references = new System.Uri($"CashStockOrders/{entity.CashStockOrder.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToCashStockOrder([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefEmployeeToCashStockOrderCommand(new EmployeeKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToCashStockOrder([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefEmployeeToCashStockOrderCommand(new EmployeeKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCashStockOrder([FromRoute] System.Guid key, [FromBody] CashStockOrderCreateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        cashStockOrder.EmployeeId = key;
        var createdKey = await _mediator.Send(new CreateCashStockOrderCommand(cashStockOrder, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCashStockOrderByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CashStockOrderDto>> GetCashStockOrder(System.Guid key)
    {
        var query = await _mediator.Send(new GetEmployeeByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CashStockOrderDto>(Enumerable.Empty<CashStockOrderDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.CashStockOrder != null).Select(x => x.CashStockOrder!));
    }
    
    public virtual async Task<ActionResult<CashStockOrderDto>> PutToCashStockOrder(System.Guid key, [FromBody] CashStockOrderUpdateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Select(x => x.CashStockOrder).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("CashStockOrder", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCashStockOrderCommand(related.Id, cashStockOrder, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCashStockOrderByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CashStockOrderDto>> PatchToCashStockOrder(System.Guid key, [FromBody] Delta<CashStockOrderPartialUpdateDto> cashStockOrder)
    {
        if (!ModelState.IsValid || cashStockOrder is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Select(x => x.CashStockOrder).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("CashStockOrder", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CashStockOrderPartialUpdateDto>(cashStockOrder);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCashStockOrderCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCashStockOrderByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Employees/{key}/CashStockOrder")]
    public virtual async Task<ActionResult> DeleteToCashStockOrder([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetEmployeeByIdQuery(key))).Select(x => x.CashStockOrder).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Employee", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCashStockOrderByIdCommand(new List<CashStockOrderKeyDto> { new CashStockOrderKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
