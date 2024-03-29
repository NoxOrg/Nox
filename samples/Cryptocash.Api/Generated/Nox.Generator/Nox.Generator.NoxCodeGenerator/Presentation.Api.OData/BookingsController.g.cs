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

public abstract partial class BookingsControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToCustomer([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefBookingToCustomerCommand(new BookingKeyDto(key), new CustomerKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCustomer([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetBookingByIdQuery(key))).Include(x => x.Customer).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Booking", $"{key.ToString()}");
        }
        
        if (entity.Customer is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Customers/{entity.Customer.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToCustomer([FromRoute] System.Guid key, [FromBody] CustomerCreateDto customer)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        customer.BookingsId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateCustomerCommand(customer, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCustomerByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CustomerDto>> GetCustomer(System.Guid key)
    {
        var query = await _mediator.Send(new GetBookingByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CustomerDto>(Enumerable.Empty<CustomerDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Customer != null).Select(x => x.Customer!));
    }
    
    public virtual async Task<ActionResult<CustomerDto>> PutToCustomer(System.Guid key, [FromBody] CustomerUpdateDto customer)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Customer).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Customer", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCustomerCommand(related.Id, customer, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCustomerByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CustomerDto>> PatchToCustomer(System.Guid key, [FromBody] Delta<CustomerPartialUpdateDto> customer)
    {
        if (!ModelState.IsValid || customer is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Customer).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Customer", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CustomerPartialUpdateDto>(customer);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCustomerCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCustomerByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult> CreateRefToVendingMachine([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefBookingToVendingMachineCommand(new BookingKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToVendingMachine([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetBookingByIdQuery(key))).Include(x => x.VendingMachine).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Booking", $"{key.ToString()}");
        }
        
        if (entity.VendingMachine is null)
        {
            return Ok();
        }
        var references = new System.Uri($"VendingMachines/{entity.VendingMachine.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToVendingMachine([FromRoute] System.Guid key, [FromBody] VendingMachineCreateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        vendingMachine.BookingsId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingMachine, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetVendingMachineByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<VendingMachineDto>> GetVendingMachine(System.Guid key)
    {
        var query = await _mediator.Send(new GetBookingByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<VendingMachineDto>(Enumerable.Empty<VendingMachineDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.VendingMachine != null).Select(x => x.VendingMachine!));
    }
    
    public virtual async Task<ActionResult<VendingMachineDto>> PutToVendingMachine(System.Guid key, [FromBody] VendingMachineUpdateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.VendingMachine).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("VendingMachine", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateVendingMachineCommand(related.Id, vendingMachine, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<VendingMachineDto>> PatchToVendingMachine(System.Guid key, [FromBody] Delta<VendingMachinePartialUpdateDto> vendingMachine)
    {
        if (!ModelState.IsValid || vendingMachine is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.VendingMachine).SingleOrDefault();
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
    
    public virtual async Task<ActionResult> CreateRefToCommission([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefBookingToCommissionCommand(new BookingKeyDto(key), new CommissionKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCommission([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetBookingByIdQuery(key))).Include(x => x.Commission).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Booking", $"{key.ToString()}");
        }
        
        if (entity.Commission is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Commissions/{entity.Commission.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToCommission([FromRoute] System.Guid key, [FromBody] CommissionCreateDto commission)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        commission.BookingsId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateCommissionCommand(commission, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCommissionByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CommissionDto>> GetCommission(System.Guid key)
    {
        var query = await _mediator.Send(new GetBookingByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CommissionDto>(Enumerable.Empty<CommissionDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Commission != null).Select(x => x.Commission!));
    }
    
    public virtual async Task<ActionResult<CommissionDto>> PutToCommission(System.Guid key, [FromBody] CommissionUpdateDto commission)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Commission).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Commission", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCommissionCommand(related.Id, commission, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCommissionByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CommissionDto>> PatchToCommission(System.Guid key, [FromBody] Delta<CommissionPartialUpdateDto> commission)
    {
        if (!ModelState.IsValid || commission is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Commission).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Commission", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CommissionPartialUpdateDto>(commission);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCommissionCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCommissionByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult> CreateRefToTransaction([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefBookingToTransactionCommand(new BookingKeyDto(key), new TransactionKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTransaction([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetBookingByIdQuery(key))).Include(x => x.Transaction).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Booking", $"{key.ToString()}");
        }
        
        if (entity.Transaction is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Transactions/{entity.Transaction.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToTransaction([FromRoute] System.Guid key, [FromBody] TransactionCreateDto transaction)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        transaction.BookingId = key;
        var createdKey = await _mediator.Send(new CreateTransactionCommand(transaction, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTransactionByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<TransactionDto>> GetTransaction(System.Guid key)
    {
        var query = await _mediator.Send(new GetBookingByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<TransactionDto>(Enumerable.Empty<TransactionDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Transaction != null).Select(x => x.Transaction!));
    }
    
    public virtual async Task<ActionResult<TransactionDto>> PutToTransaction(System.Guid key, [FromBody] TransactionUpdateDto transaction)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Transaction).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Transaction", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTransactionCommand(related.Id, transaction, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTransactionByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<TransactionDto>> PatchToTransaction(System.Guid key, [FromBody] Delta<TransactionPartialUpdateDto> transaction)
    {
        if (!ModelState.IsValid || transaction is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetBookingByIdQuery(key))).Select(x => x.Transaction).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Transaction", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TransactionPartialUpdateDto>(transaction);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTransactionCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTransactionByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
