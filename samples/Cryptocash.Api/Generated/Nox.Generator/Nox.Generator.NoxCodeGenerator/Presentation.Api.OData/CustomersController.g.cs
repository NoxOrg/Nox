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

public abstract partial class CustomersControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToCustomerRelatedPaymentDetails([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToCustomerRelatedPaymentDetailsCommand(new CustomerKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCustomerRelatedPaymentDetails([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.CustomerRelatedPaymentDetails).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"PaymentDetails/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToCustomerRelatedPaymentDetails([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToCustomerRelatedPaymentDetailsCommand(new CustomerKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCustomerRelatedPaymentDetails([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToCustomerRelatedPaymentDetailsCommand(new CustomerKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToCustomerRelatedBookings([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToCustomerRelatedBookingsCommand(new CustomerKeyDto(key), new BookingKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCustomerRelatedBookings([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.CustomerRelatedBookings).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"Bookings/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToCustomerRelatedBookings([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToCustomerRelatedBookingsCommand(new CustomerKeyDto(key), new BookingKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCustomerRelatedBookings([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToCustomerRelatedBookingsCommand(new CustomerKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToCustomerRelatedTransactions([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToCustomerRelatedTransactionsCommand(new CustomerKeyDto(key), new TransactionKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCustomerRelatedTransactions([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.CustomerRelatedTransactions).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"Transactions/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToCustomerRelatedTransactions([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToCustomerRelatedTransactionsCommand(new CustomerKeyDto(key), new TransactionKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCustomerRelatedTransactions([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToCustomerRelatedTransactionsCommand(new CustomerKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToCustomerBaseCountry([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToCustomerBaseCountryCommand(new CustomerKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCustomerBaseCountry([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.CustomerBaseCountry).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Countries/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToCustomerBaseCountry([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToCustomerBaseCountryCommand(new CustomerKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCustomerBaseCountry([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToCustomerBaseCountryCommand(new CustomerKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
