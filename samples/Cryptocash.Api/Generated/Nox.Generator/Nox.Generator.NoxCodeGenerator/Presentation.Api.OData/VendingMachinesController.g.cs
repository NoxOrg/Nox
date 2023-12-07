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
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class VendingMachinesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToCountry([FromRoute] System.Guid key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToCountryCommand(new VendingMachineKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCountry([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Include(x => x.Country).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        if (entity.Country is null)
            return Ok();
        var references = new System.Uri($"Countries/{entity.Country.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToCountry([FromRoute] System.Guid key, [FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        country.VendingMachinesId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CountryDto>> GetCountry(System.Guid key)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Where(x => x.Country != null);
        if (!related.Any())
        {
            return SingleResult.Create<CountryDto>(Enumerable.Empty<CountryDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Country!));
    }
    
    public virtual async Task<ActionResult<CountryDto>> PutToCountry(System.Guid key, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.Country).SingleOrDefault();
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
        
        return Ok();
    }
    
    public virtual async Task<ActionResult> CreateRefToLandLord([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToLandLordCommand(new VendingMachineKeyDto(key), new LandLordKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToLandLord([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Include(x => x.LandLord).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        if (entity.LandLord is null)
            return Ok();
        var references = new System.Uri($"LandLords/{entity.LandLord.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToLandLord([FromRoute] System.Guid key, [FromBody] LandLordCreateDto landLord)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        landLord.VendingMachinesId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateLandLordCommand(landLord, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetLandLordByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<LandLordDto>> GetLandLord(System.Guid key)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Where(x => x.LandLord != null);
        if (!related.Any())
        {
            return SingleResult.Create<LandLordDto>(Enumerable.Empty<LandLordDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.LandLord!));
    }
    
    public virtual async Task<ActionResult<LandLordDto>> PutToLandLord(System.Guid key, [FromBody] LandLordUpdateDto landLord)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.LandLord).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateLandLordCommand(related.Id, landLord, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    public virtual async Task<ActionResult> CreateRefToBookings([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToBookingsCommand(new VendingMachineKeyDto(key), new BookingKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/VendingMachines/{key}/Bookings/$ref")]
    public virtual async Task<ActionResult> UpdateRefToBookingsNonConventional([FromRoute] System.Guid key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new BookingKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefVendingMachineToBookingsCommand(new VendingMachineKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToBookings([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Include(x => x.Bookings).SingleOrDefault();
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
    
    public virtual async Task<ActionResult> DeleteRefToBookings([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefVendingMachineToBookingsCommand(new VendingMachineKeyDto(key), new BookingKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToBookings([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefVendingMachineToBookingsCommand(new VendingMachineKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToBookings([FromRoute] System.Guid key, [FromBody] BookingCreateDto booking)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        booking.VendingMachineId = key;
        var createdKey = await _mediator.Send(new CreateBookingCommand(booking, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetBookingByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<BookingDto>>> GetBookings(System.Guid key)
    {
        var query = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Include(x => x.Bookings);
        var entity = query.SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        return Ok(query.SelectMany(x => x.Bookings));
    }
    
    [EnableQuery]
    [HttpGet("/api/VendingMachines/{key}/Bookings/{relatedKey}")]
    public virtual async Task<SingleResult<BookingDto>> GetBookingsNonConventional(System.Guid key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).SelectMany(x => x.Bookings).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<BookingDto>(Enumerable.Empty<BookingDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/VendingMachines/{key}/Bookings/{relatedKey}")]
    public virtual async Task<ActionResult<BookingDto>> PutToBookingsNonConventional(System.Guid key, System.Guid relatedKey, [FromBody] BookingUpdateDto booking)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).SelectMany(x => x.Bookings).Any(x => x.Id == relatedKey);
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
        
        return Ok();
    }
    
    [HttpDelete("/api/VendingMachines/{key}/Bookings/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToBookings([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).SelectMany(x => x.Bookings).Any(x => x.Id == relatedKey);
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
    
    [HttpDelete("/api/VendingMachines/{key}/Bookings")]
    public virtual async Task<ActionResult> DeleteToBookings([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.Bookings).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteBookingByIdCommand(related.Select(item => new BookingKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToCashStockOrders([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToCashStockOrdersCommand(new VendingMachineKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/VendingMachines/{key}/CashStockOrders/$ref")]
    public virtual async Task<ActionResult> UpdateRefToCashStockOrdersNonConventional([FromRoute] System.Guid key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new CashStockOrderKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefVendingMachineToCashStockOrdersCommand(new VendingMachineKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCashStockOrders([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Include(x => x.CashStockOrders).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.CashStockOrders)
        {
            references.Add(new System.Uri($"CashStockOrders/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToCashStockOrders([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefVendingMachineToCashStockOrdersCommand(new VendingMachineKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToCashStockOrders([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefVendingMachineToCashStockOrdersCommand(new VendingMachineKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCashStockOrders([FromRoute] System.Guid key, [FromBody] CashStockOrderCreateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        cashStockOrder.VendingMachineId = key;
        var createdKey = await _mediator.Send(new CreateCashStockOrderCommand(cashStockOrder, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCashStockOrderByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CashStockOrderDto>>> GetCashStockOrders(System.Guid key)
    {
        var query = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Include(x => x.CashStockOrders);
        var entity = query.SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        return Ok(query.SelectMany(x => x.CashStockOrders));
    }
    
    [EnableQuery]
    [HttpGet("/api/VendingMachines/{key}/CashStockOrders/{relatedKey}")]
    public virtual async Task<SingleResult<CashStockOrderDto>> GetCashStockOrdersNonConventional(System.Guid key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).SelectMany(x => x.CashStockOrders).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<CashStockOrderDto>(Enumerable.Empty<CashStockOrderDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/VendingMachines/{key}/CashStockOrders/{relatedKey}")]
    public virtual async Task<ActionResult<CashStockOrderDto>> PutToCashStockOrdersNonConventional(System.Guid key, System.Int64 relatedKey, [FromBody] CashStockOrderUpdateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).SelectMany(x => x.CashStockOrders).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCashStockOrderCommand(relatedKey, cashStockOrder, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/VendingMachines/{key}/CashStockOrders/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToCashStockOrders([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).SelectMany(x => x.CashStockOrders).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCashStockOrderByIdCommand(new List<CashStockOrderKeyDto> { new CashStockOrderKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/VendingMachines/{key}/CashStockOrders")]
    public virtual async Task<ActionResult> DeleteToCashStockOrders([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.CashStockOrders).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteCashStockOrderByIdCommand(related.Select(item => new CashStockOrderKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToMinimumCashStocks([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToMinimumCashStocksCommand(new VendingMachineKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/VendingMachines/{key}/MinimumCashStocks/$ref")]
    public virtual async Task<ActionResult> UpdateRefToMinimumCashStocksNonConventional([FromRoute] System.Guid key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new MinimumCashStockKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefVendingMachineToMinimumCashStocksCommand(new VendingMachineKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToMinimumCashStocks([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Include(x => x.MinimumCashStocks).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.MinimumCashStocks)
        {
            references.Add(new System.Uri($"MinimumCashStocks/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToMinimumCashStocks([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefVendingMachineToMinimumCashStocksCommand(new VendingMachineKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToMinimumCashStocks([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefVendingMachineToMinimumCashStocksCommand(new VendingMachineKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToMinimumCashStocks([FromRoute] System.Guid key, [FromBody] MinimumCashStockCreateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        minimumCashStock.VendingMachinesId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateMinimumCashStockCommand(minimumCashStock, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetMinimumCashStockByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<MinimumCashStockDto>>> GetMinimumCashStocks(System.Guid key)
    {
        var query = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Include(x => x.MinimumCashStocks);
        var entity = query.SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        return Ok(query.SelectMany(x => x.MinimumCashStocks));
    }
    
    [EnableQuery]
    [HttpGet("/api/VendingMachines/{key}/MinimumCashStocks/{relatedKey}")]
    public virtual async Task<SingleResult<MinimumCashStockDto>> GetMinimumCashStocksNonConventional(System.Guid key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).SelectMany(x => x.MinimumCashStocks).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<MinimumCashStockDto>(Enumerable.Empty<MinimumCashStockDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/VendingMachines/{key}/MinimumCashStocks/{relatedKey}")]
    public virtual async Task<ActionResult<MinimumCashStockDto>> PutToMinimumCashStocksNonConventional(System.Guid key, System.Int64 relatedKey, [FromBody] MinimumCashStockUpdateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).SelectMany(x => x.MinimumCashStocks).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateMinimumCashStockCommand(relatedKey, minimumCashStock, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    [HttpDelete("/api/VendingMachines/{key}/MinimumCashStocks/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToMinimumCashStocks([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).SelectMany(x => x.MinimumCashStocks).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteMinimumCashStockByIdCommand(new List<MinimumCashStockKeyDto> { new MinimumCashStockKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/VendingMachines/{key}/MinimumCashStocks")]
    public virtual async Task<ActionResult> DeleteToMinimumCashStocks([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.MinimumCashStocks).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteMinimumCashStockByIdCommand(related.Select(item => new MinimumCashStockKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
