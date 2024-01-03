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
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToVendingMachines([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).Include(x => x.VendingMachines).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("MinimumCashStock", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.VendingMachines)
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
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToVendingMachines([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefMinimumCashStockToVendingMachinesCommand(new MinimumCashStockKeyDto(key)));
        
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
        var query = await _mediator.Send(new GetMinimumCashStockByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("MinimumCashStock", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.VendingMachines).SelectMany(x => x.VendingMachines));
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
            throw new EntityNotFoundException("VendingMachines", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateVendingMachineCommand(relatedKey, vendingMachine, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/MinimumCashStocks/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<ActionResult<VendingMachineDto>> PatchtoVendingMachinesNonConventional(System.Int64 key, System.Guid relatedKey, [FromBody] Delta<VendingMachinePartialUpdateDto> vendingMachine)
    {
        if (!ModelState.IsValid || vendingMachine is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).SelectMany(x => x.VendingMachines).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("VendingMachines", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<VendingMachinePartialUpdateDto>(vendingMachine);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateVendingMachineCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
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
            throw new EntityNotFoundException("VendingMachines", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteVendingMachineByIdCommand(new List<VendingMachineKeyDto> { new VendingMachineKeyDto(relatedKey) }, etag));
        
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
            throw new EntityNotFoundException("MinimumCashStock", $"{key.ToString()}");
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
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCurrency([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).Include(x => x.Currency).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("MinimumCashStock", $"{key.ToString()}");
        }
        
        if (entity.Currency is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Currencies/{entity.Currency.Id}", UriKind.Relative);
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
        var query = await _mediator.Send(new GetMinimumCashStockByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CurrencyDto>(Enumerable.Empty<CurrencyDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Currency != null).Select(x => x.Currency!));
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
            throw new EntityNotFoundException("Currency", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(related.Id, currency, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> PatchToCurrency(System.Int64 key, [FromBody] Delta<CurrencyPartialUpdateDto> currency)
    {
        if (!ModelState.IsValid || currency is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetMinimumCashStockByIdQuery(key))).Select(x => x.Currency).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Currency", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CurrencyPartialUpdateDto>(currency);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCurrencyCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
