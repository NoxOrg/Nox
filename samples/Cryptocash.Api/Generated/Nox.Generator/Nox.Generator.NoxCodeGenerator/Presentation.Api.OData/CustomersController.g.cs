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

public abstract partial class CustomersControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToPaymentDetails([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToPaymentDetailsCommand(new CustomerKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/Customers/{key}/PaymentDetails/$ref")]
    public virtual async Task<ActionResult> UpdateRefToPaymentDetailsNonConventional([FromRoute] System.Int64 key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new PaymentDetailKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCustomerToPaymentDetailsCommand(new CustomerKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToPaymentDetails([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.PaymentDetails).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.PaymentDetails)
        {
            references.Add(new System.Uri($"PaymentDetails/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToPaymentDetails([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToPaymentDetailsCommand(new CustomerKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToPaymentDetails([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToPaymentDetailsCommand(new CustomerKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToPaymentDetails([FromRoute] System.Int64 key, [FromBody] PaymentDetailCreateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        paymentDetail.CustomerId = key;
        var createdKey = await _mediator.Send(new CreatePaymentDetailCommand(paymentDetail, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetPaymentDetailByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<PaymentDetailDto>>> GetPaymentDetails(System.Int64 key)
    {
        var query = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.PaymentDetails);
        var entity = query.SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        return Ok(query.SelectMany(x => x.PaymentDetails));
    }
    
    [EnableQuery]
    [HttpGet("/api/Customers/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<SingleResult<PaymentDetailDto>> GetPaymentDetailsNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.PaymentDetails).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<PaymentDetailDto>(Enumerable.Empty<PaymentDetailDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Customers/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<ActionResult<PaymentDetailDto>> PutToPaymentDetailsNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] PaymentDetailUpdateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdatePaymentDetailCommand(relatedKey, paymentDetail, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetPaymentDetailByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Customers/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToPaymentDetails([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeletePaymentDetailByIdCommand(new List<PaymentDetailKeyDto> { new PaymentDetailKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/Customers/{key}/PaymentDetails")]
    public virtual async Task<ActionResult> DeleteToPaymentDetails([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.PaymentDetails).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeletePaymentDetailByIdCommand(related.Select(item => new PaymentDetailKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToBookings([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToBookingsCommand(new CustomerKeyDto(key), new BookingKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/Customers/{key}/Bookings/$ref")]
    public virtual async Task<ActionResult> UpdateRefToBookingsNonConventional([FromRoute] System.Int64 key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new BookingKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCustomerToBookingsCommand(new CustomerKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToBookings([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.Bookings).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Bookings)
        {
            references.Add(new System.Uri($"Bookings/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToBookings([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToBookingsCommand(new CustomerKeyDto(key), new BookingKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToBookings([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToBookingsCommand(new CustomerKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToBookings([FromRoute] System.Int64 key, [FromBody] BookingCreateDto booking)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        booking.CustomerId = key;
        var createdKey = await _mediator.Send(new CreateBookingCommand(booking, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetBookingByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<BookingDto>>> GetBookings(System.Int64 key)
    {
        var query = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.Bookings);
        var entity = query.SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        return Ok(query.SelectMany(x => x.Bookings));
    }
    
    [EnableQuery]
    [HttpGet("/api/Customers/{key}/Bookings/{relatedKey}")]
    public virtual async Task<SingleResult<BookingDto>> GetBookingsNonConventional(System.Int64 key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Bookings).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<BookingDto>(Enumerable.Empty<BookingDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Customers/{key}/Bookings/{relatedKey}")]
    public virtual async Task<ActionResult<BookingDto>> PutToBookingsNonConventional(System.Int64 key, System.Guid relatedKey, [FromBody] BookingUpdateDto booking)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Bookings).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateBookingCommand(relatedKey, booking, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetBookingByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Customers/{key}/Bookings/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToBookings([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Bookings).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteBookingByIdCommand(new List<BookingKeyDto> { new BookingKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/Customers/{key}/Bookings")]
    public virtual async Task<ActionResult> DeleteToBookings([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.Bookings).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteBookingByIdCommand(related.Select(item => new BookingKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToTransactions([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToTransactionsCommand(new CustomerKeyDto(key), new TransactionKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/Customers/{key}/Transactions/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTransactionsNonConventional([FromRoute] System.Int64 key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TransactionKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCustomerToTransactionsCommand(new CustomerKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTransactions([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.Transactions).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Transactions)
        {
            references.Add(new System.Uri($"Transactions/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTransactions([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToTransactionsCommand(new CustomerKeyDto(key), new TransactionKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTransactions([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToTransactionsCommand(new CustomerKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTransactions([FromRoute] System.Int64 key, [FromBody] TransactionCreateDto transaction)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        transaction.CustomerId = key;
        var createdKey = await _mediator.Send(new CreateTransactionCommand(transaction, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTransactionByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TransactionDto>>> GetTransactions(System.Int64 key)
    {
        var query = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.Transactions);
        var entity = query.SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        return Ok(query.SelectMany(x => x.Transactions));
    }
    
    [EnableQuery]
    [HttpGet("/api/Customers/{key}/Transactions/{relatedKey}")]
    public virtual async Task<SingleResult<TransactionDto>> GetTransactionsNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Transactions).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TransactionDto>(Enumerable.Empty<TransactionDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Customers/{key}/Transactions/{relatedKey}")]
    public virtual async Task<ActionResult<TransactionDto>> PutToTransactionsNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] TransactionUpdateDto transaction)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Transactions).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTransactionCommand(relatedKey, transaction, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetTransactionByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Customers/{key}/Transactions/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTransactions([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Transactions).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTransactionByIdCommand(new List<TransactionKeyDto> { new TransactionKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/Customers/{key}/Transactions")]
    public virtual async Task<ActionResult> DeleteToTransactions([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.Transactions).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteTransactionByIdCommand(related.Select(item => new TransactionKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToCountry([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToCountryCommand(new CustomerKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCountry([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.Country).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        if (entity.Country is null)
            return Ok();
        var references = new System.Uri($"Countries/{entity.Country.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToCountry([FromRoute] System.Int64 key, [FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        country.CustomersId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CountryDto>> GetCountry(System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Where(x => x.Country != null);
        if (!related.Any())
        {
            return SingleResult.Create<CountryDto>(Enumerable.Empty<CountryDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Country!));
    }
    
    public virtual async Task<ActionResult<CountryDto>> PutToCountry(System.Int64 key, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.Country).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCountryCommand(related.Id, country, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetCountryByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
