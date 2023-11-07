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

public abstract partial class VendingMachinesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToVendingMachineInstallationCountry([FromRoute] System.Guid key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToVendingMachineInstallationCountryCommand(new VendingMachineKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachineInstallationCountry([FromRoute] System.Guid key, [FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        country.CountryUsedByVendingMachinesId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToVendingMachineInstallationCountry([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.VendingMachineInstallationCountry).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Countries/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToVendingMachineInstallationCountry([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefVendingMachineToVendingMachineInstallationCountryCommand(new VendingMachineKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToVendingMachineContractedAreaLandLord([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToVendingMachineContractedAreaLandLordCommand(new VendingMachineKeyDto(key), new LandLordKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachineContractedAreaLandLord([FromRoute] System.Guid key, [FromBody] LandLordCreateDto landLord)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        landLord.ContractedAreasForVendingMachinesId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateLandLordCommand(landLord, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetLandLordByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToVendingMachineContractedAreaLandLord([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.VendingMachineContractedAreaLandLord).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"LandLords/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToVendingMachineContractedAreaLandLord([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefVendingMachineToVendingMachineContractedAreaLandLordCommand(new VendingMachineKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToVendingMachineRelatedBookings([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToVendingMachineRelatedBookingsCommand(new VendingMachineKeyDto(key), new BookingKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachineRelatedBookings([FromRoute] System.Guid key, [FromBody] BookingCreateDto booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        booking.BookingRelatedVendingMachineId = key;
        var createdKey = await _mediator.Send(new CreateBookingCommand(booking, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetBookingByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToVendingMachineRelatedBookings([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.VendingMachineRelatedBookings).SingleOrDefault();
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
    
    public async Task<ActionResult> DeleteRefToVendingMachineRelatedBookings([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefVendingMachineToVendingMachineRelatedBookingsCommand(new VendingMachineKeyDto(key), new BookingKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToVendingMachineRelatedBookings([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefVendingMachineToVendingMachineRelatedBookingsCommand(new VendingMachineKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToVendingMachineRelatedCashStockOrders([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(new VendingMachineKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachineRelatedCashStockOrders([FromRoute] System.Guid key, [FromBody] CashStockOrderCreateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        cashStockOrder.CashStockOrderForVendingMachineId = key;
        var createdKey = await _mediator.Send(new CreateCashStockOrderCommand(cashStockOrder, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCashStockOrderByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToVendingMachineRelatedCashStockOrders([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.VendingMachineRelatedCashStockOrders).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"CashStockOrders/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToVendingMachineRelatedCashStockOrders([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(new VendingMachineKeyDto(key), new CashStockOrderKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToVendingMachineRelatedCashStockOrders([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefVendingMachineToVendingMachineRelatedCashStockOrdersCommand(new VendingMachineKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToVendingMachineRequiredMinimumCashStocks([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand(new VendingMachineKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachineRequiredMinimumCashStocks([FromRoute] System.Guid key, [FromBody] MinimumCashStockCreateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        minimumCashStock.MinimumCashStocksRequiredByVendingMachinesId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateMinimumCashStockCommand(minimumCashStock, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetMinimumCashStockByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToVendingMachineRequiredMinimumCashStocks([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetVendingMachineByIdQuery(key))).Select(x => x.VendingMachineRequiredMinimumCashStocks).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"MinimumCashStocks/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToVendingMachineRequiredMinimumCashStocks([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand(new VendingMachineKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToVendingMachineRequiredMinimumCashStocks([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefVendingMachineToVendingMachineRequiredMinimumCashStocksCommand(new VendingMachineKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
