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

public abstract partial class BookingsControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToCustomer([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefBookingToCustomerCommand(new BookingKeyDto(key), new CustomerKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCustomer([FromRoute] System.Guid key, [FromBody] CustomerCreateDto customer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        customer.BookingsId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateCustomerCommand(customer, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCustomerByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToCustomer([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Customer).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Customers/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CustomerDto>> GetCustomer(System.Guid key)
    {
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Where(x => x.Customer != null);
        if (!related.Any())
        {
            return SingleResult.Create<CustomerDto>(Enumerable.Empty<CustomerDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Customer!));
    }
    
    public virtual async Task<ActionResult<CustomerDto>> PutToCustomer(System.Guid key, [FromBody] CustomerUpdateDto customer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Customer).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCustomerCommand(related.Id, customer, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    public async Task<ActionResult> CreateRefToVendingMachine([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefBookingToVendingMachineCommand(new BookingKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachine([FromRoute] System.Guid key, [FromBody] VendingMachineCreateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        vendingMachine.BookingsId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingMachine, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetVendingMachineByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToVendingMachine([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.VendingMachine).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"VendingMachines/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<VendingMachineDto>> GetVendingMachine(System.Guid key)
    {
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Where(x => x.VendingMachine != null);
        if (!related.Any())
        {
            return SingleResult.Create<VendingMachineDto>(Enumerable.Empty<VendingMachineDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.VendingMachine!));
    }
    
    public virtual async Task<ActionResult<VendingMachineDto>> PutToVendingMachine(System.Guid key, [FromBody] VendingMachineUpdateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.VendingMachine).SingleOrDefault();
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
    
    public async Task<ActionResult> CreateRefToCommission([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefBookingToCommissionCommand(new BookingKeyDto(key), new CommissionKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCommission([FromRoute] System.Guid key, [FromBody] CommissionCreateDto commission)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        commission.BookingsId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateCommissionCommand(commission, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCommissionByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToCommission([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Commission).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Commissions/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CommissionDto>> GetCommission(System.Guid key)
    {
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Where(x => x.Commission != null);
        if (!related.Any())
        {
            return SingleResult.Create<CommissionDto>(Enumerable.Empty<CommissionDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Commission!));
    }
    
    public virtual async Task<ActionResult<CommissionDto>> PutToCommission(System.Guid key, [FromBody] CommissionUpdateDto commission)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Commission).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCommissionCommand(related.Id, commission, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    public async Task<ActionResult> CreateRefToTransaction([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefBookingToTransactionCommand(new BookingKeyDto(key), new TransactionKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTransaction([FromRoute] System.Guid key, [FromBody] TransactionCreateDto transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        transaction.BookingId = key;
        var createdKey = await _mediator.Send(new CreateTransactionCommand(transaction, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTransactionByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTransaction([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Transaction).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Transactions/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TransactionDto>> GetTransaction(System.Guid key)
    {
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Where(x => x.Transaction != null);
        if (!related.Any())
        {
            return SingleResult.Create<TransactionDto>(Enumerable.Empty<TransactionDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Transaction!));
    }
    
    public virtual async Task<ActionResult<TransactionDto>> PutToTransaction(System.Guid key, [FromBody] TransactionUpdateDto transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Transaction).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTransactionCommand(related.Id, transaction, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
