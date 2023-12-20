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

public abstract partial class TransactionsControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToCustomer([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTransactionToCustomerCommand(new TransactionKeyDto(key), new CustomerKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCustomer([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetTransactionByIdQuery(key))).Include(x => x.Customer).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Transaction", $"{key.ToString()}");
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
        
        customer.TransactionsId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateCustomerCommand(customer, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCustomerByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CustomerDto>> GetCustomer(System.Guid key)
    {
        var query = await _mediator.Send(new GetTransactionByIdQuery(key));
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
        
        var related = (await _mediator.Send(new GetTransactionByIdQuery(key))).Select(x => x.Customer).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Customer", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCustomerCommand(related.Id, customer, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCustomerByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult> CreateRefToBooking([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTransactionToBookingCommand(new TransactionKeyDto(key), new BookingKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToBooking([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetTransactionByIdQuery(key))).Include(x => x.Booking).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Transaction", $"{key.ToString()}");
        }
        
        if (entity.Booking is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Bookings/{entity.Booking.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToBooking([FromRoute] System.Guid key, [FromBody] BookingCreateDto booking)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        booking.TransactionId = key;
        var createdKey = await _mediator.Send(new CreateBookingCommand(booking, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetBookingByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<BookingDto>> GetBooking(System.Guid key)
    {
        var query = await _mediator.Send(new GetTransactionByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<BookingDto>(Enumerable.Empty<BookingDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Booking != null).Select(x => x.Booking!));
    }
    
    public virtual async Task<ActionResult<BookingDto>> PutToBooking(System.Guid key, [FromBody] BookingUpdateDto booking)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTransactionByIdQuery(key))).Select(x => x.Booking).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Booking", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateBookingCommand(related.Id, booking, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetBookingByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
