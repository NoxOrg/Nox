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

public abstract partial class MinimumCashStocksControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToVendingMachines([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefMinimumCashStockToVendingMachinesCommand(new MinimumCashStockKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/MinimumCashStocks/{key}/VendingMachines/$ref")]
    public virtual async Task<ActionResult> UpdateRefToVendingMachinesNonConventional([FromRoute] System.Int64 key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new VendingMachineKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefMinimumCashStockToVendingMachinesCommand(new MinimumCashStockKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToVendingMachines([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).Select(x => x.VendingMachines).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"VendingMachines/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToVendingMachines([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefMinimumCashStockToVendingMachinesCommand(new MinimumCashStockKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToVendingMachines([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefMinimumCashStockToVendingMachinesCommand(new MinimumCashStockKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachines([FromRoute] System.Int64 key, [FromBody] VendingMachineCreateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        vendingMachine.MinimumCashStocksId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingMachine, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetVendingMachineByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<VendingMachineDto>>> GetVendingMachines(System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).SelectMany(x => x.VendingMachines);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/MinimumCashStocks/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<SingleResult<VendingMachineDto>> GetVendingMachinesNonConventional(System.Int64 key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).SelectMany(x => x.VendingMachines).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<VendingMachineDto>(Enumerable.Empty<VendingMachineDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/MinimumCashStocks/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<ActionResult<VendingMachineDto>> PutToVendingMachinesNonConventional(System.Int64 key, System.Guid relatedKey, [FromBody] VendingMachineUpdateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).SelectMany(x => x.VendingMachines).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateVendingMachineCommand(relatedKey, vendingMachine, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/MinimumCashStocks/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToVendingMachines([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).SelectMany(x => x.VendingMachines).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteVendingMachineByIdCommand(new List<VendingMachineKeyDto> { new VendingMachineKeyDto(relatedKey) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/MinimumCashStocks/{key}/VendingMachines")]
    public virtual async Task<ActionResult> DeleteToVendingMachines([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).Select(x => x.VendingMachines).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteVendingMachineByIdCommand(related.Select(item => new VendingMachineKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToCurrency([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefMinimumCashStockToCurrencyCommand(new MinimumCashStockKeyDto(key), new CurrencyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCurrency([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).Select(x => x.Currency).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Currencies/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToCurrency([FromRoute] System.Int64 key, [FromBody] CurrencyCreateDto currency)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        currency.MinimumCashStocksId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateCurrencyCommand(currency, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCurrencyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CurrencyDto>> GetCurrency(System.Int64 key)
    {
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).Where(x => x.Currency != null);
        if (!related.Any())
        {
            return SingleResult.Create<CurrencyDto>(Enumerable.Empty<CurrencyDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Currency!));
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> PutToCurrency(System.Int64 key, [FromBody] CurrencyUpdateDto currency)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).Select(x => x.Currency).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(related.Id, currency, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        var updatedItem = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
