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

public abstract partial class CustomersControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToPaymentDetails([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToPaymentDetailsCommand(new CustomerKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/Customers/{key}/PaymentDetails/$ref")]
    public virtual async Task<ActionResult> UpdateRefToPaymentDetailsNonConventional([FromRoute] System.Guid key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new PaymentDetailKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCustomerToPaymentDetailsCommand(new CustomerKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToPaymentDetails([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.PaymentDetails).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.PaymentDetails)
        {
            references.Add(new System.Uri($"PaymentDetails/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToPaymentDetails([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToPaymentDetailsCommand(new CustomerKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToPaymentDetails([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToPaymentDetailsCommand(new CustomerKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToPaymentDetails([FromRoute] System.Guid key, [FromBody] PaymentDetailCreateDto paymentDetail)
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
    public virtual async Task<ActionResult<IQueryable<PaymentDetailDto>>> GetPaymentDetails(System.Guid key)
    {
        var query = await _mediator.Send(new GetCustomerByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.PaymentDetails).SelectMany(x => x.PaymentDetails));
    }
    
    [EnableQuery]
    [HttpGet("/api/Customers/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<SingleResult<PaymentDetailDto>> GetPaymentDetailsNonConventional(System.Guid key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.PaymentDetails).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<PaymentDetailDto>(Enumerable.Empty<PaymentDetailDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Customers/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<ActionResult<PaymentDetailDto>> PutToPaymentDetailsNonConventional(System.Guid key, System.Int64 relatedKey, [FromBody] PaymentDetailUpdateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("PaymentDetails", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdatePaymentDetailCommand(relatedKey, paymentDetail, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetPaymentDetailByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/Customers/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<ActionResult<PaymentDetailDto>> PatchtoPaymentDetailsNonConventional(System.Guid key, System.Int64 relatedKey, [FromBody] Delta<PaymentDetailPartialUpdateDto> paymentDetail)
    {
        if (!ModelState.IsValid || paymentDetail is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("PaymentDetails", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<PaymentDetailPartialUpdateDto>(paymentDetail);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdatePaymentDetailCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetPaymentDetailByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Customers/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToPaymentDetails([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("PaymentDetails", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeletePaymentDetailByIdCommand(new List<PaymentDetailKeyDto> { new PaymentDetailKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/Customers/{key}/PaymentDetails")]
    public virtual async Task<ActionResult> DeleteToPaymentDetails([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.PaymentDetails).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeletePaymentDetailByIdCommand(related.Select(item => new PaymentDetailKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToBookings([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToBookingsCommand(new CustomerKeyDto(key), new BookingKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/Customers/{key}/Bookings/$ref")]
    public virtual async Task<ActionResult> UpdateRefToBookingsNonConventional([FromRoute] System.Guid key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new BookingKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCustomerToBookingsCommand(new CustomerKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToBookings([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.Bookings).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Bookings)
        {
            references.Add(new System.Uri($"Bookings/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToBookings([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToBookingsCommand(new CustomerKeyDto(key), new BookingKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToBookings([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToBookingsCommand(new CustomerKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToBookings([FromRoute] System.Guid key, [FromBody] BookingCreateDto booking)
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
    public virtual async Task<ActionResult<IQueryable<BookingDto>>> GetBookings(System.Guid key)
    {
        var query = await _mediator.Send(new GetCustomerByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Bookings).SelectMany(x => x.Bookings));
    }
    
    [EnableQuery]
    [HttpGet("/api/Customers/{key}/Bookings/{relatedKey}")]
    public virtual async Task<SingleResult<BookingDto>> GetBookingsNonConventional(System.Guid key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Bookings).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<BookingDto>(Enumerable.Empty<BookingDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Customers/{key}/Bookings/{relatedKey}")]
    public virtual async Task<ActionResult<BookingDto>> PutToBookingsNonConventional(System.Guid key, System.Guid relatedKey, [FromBody] BookingUpdateDto booking)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Bookings).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Bookings", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateBookingCommand(relatedKey, booking, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetBookingByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/Customers/{key}/Bookings/{relatedKey}")]
    public virtual async Task<ActionResult<BookingDto>> PatchtoBookingsNonConventional(System.Guid key, System.Guid relatedKey, [FromBody] Delta<BookingPartialUpdateDto> booking)
    {
        if (!ModelState.IsValid || booking is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Bookings).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Bookings", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<BookingPartialUpdateDto>(booking);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateBookingCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetBookingByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Customers/{key}/Bookings/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToBookings([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Bookings).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Bookings", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteBookingByIdCommand(new List<BookingKeyDto> { new BookingKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/Customers/{key}/Bookings")]
    public virtual async Task<ActionResult> DeleteToBookings([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.Bookings).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteBookingByIdCommand(related.Select(item => new BookingKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToTransactions([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToTransactionsCommand(new CustomerKeyDto(key), new TransactionKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/Customers/{key}/Transactions/$ref")]
    public virtual async Task<ActionResult> UpdateRefToTransactionsNonConventional([FromRoute] System.Guid key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new TransactionKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCustomerToTransactionsCommand(new CustomerKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToTransactions([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.Transactions).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Transactions)
        {
            references.Add(new System.Uri($"Transactions/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToTransactions([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCustomerToTransactionsCommand(new CustomerKeyDto(key), new TransactionKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToTransactions([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCustomerToTransactionsCommand(new CustomerKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTransactions([FromRoute] System.Guid key, [FromBody] TransactionCreateDto transaction)
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
    public virtual async Task<ActionResult<IQueryable<TransactionDto>>> GetTransactions(System.Guid key)
    {
        var query = await _mediator.Send(new GetCustomerByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Transactions).SelectMany(x => x.Transactions));
    }
    
    [EnableQuery]
    [HttpGet("/api/Customers/{key}/Transactions/{relatedKey}")]
    public virtual async Task<SingleResult<TransactionDto>> GetTransactionsNonConventional(System.Guid key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Transactions).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TransactionDto>(Enumerable.Empty<TransactionDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Customers/{key}/Transactions/{relatedKey}")]
    public virtual async Task<ActionResult<TransactionDto>> PutToTransactionsNonConventional(System.Guid key, System.Guid relatedKey, [FromBody] TransactionUpdateDto transaction)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Transactions).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Transactions", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTransactionCommand(relatedKey, transaction, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTransactionByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/Customers/{key}/Transactions/{relatedKey}")]
    public virtual async Task<ActionResult<TransactionDto>> PatchtoTransactionsNonConventional(System.Guid key, System.Guid relatedKey, [FromBody] Delta<TransactionPartialUpdateDto> transaction)
    {
        if (!ModelState.IsValid || transaction is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Transactions).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Transactions", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TransactionPartialUpdateDto>(transaction);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTransactionCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetTransactionByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/Customers/{key}/Transactions/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToTransactions([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).SelectMany(x => x.Transactions).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Transactions", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTransactionByIdCommand(new List<TransactionKeyDto> { new TransactionKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/Customers/{key}/Transactions")]
    public virtual async Task<ActionResult> DeleteToTransactions([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.Transactions).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteTransactionByIdCommand(related.Select(item => new TransactionKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToCountry([FromRoute] System.Guid key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCustomerToCountryCommand(new CustomerKeyDto(key), new CountryKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCountry([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetCustomerByIdQuery(key))).Include(x => x.Country).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }
        
        if (entity.Country is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Countries/{entity.Country.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToCountry([FromRoute] System.Guid key, [FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        country.CustomersId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CountryDto>> GetCountry(System.Guid key)
    {
        var query = await _mediator.Send(new GetCustomerByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CountryDto>(Enumerable.Empty<CountryDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Country != null).Select(x => x.Country!));
    }
    
    public virtual async Task<ActionResult<CountryDto>> PutToCountry(System.Guid key, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.Country).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Country", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCountryCommand(related.Id, country, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCountryByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CountryDto>> PatchToCountry(System.Guid key, [FromBody] Delta<CountryPartialUpdateDto> country)
    {
        if (!ModelState.IsValid || country is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCustomerByIdQuery(key))).Select(x => x.Country).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Country", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CountryPartialUpdateDto>(country);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCountryByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
