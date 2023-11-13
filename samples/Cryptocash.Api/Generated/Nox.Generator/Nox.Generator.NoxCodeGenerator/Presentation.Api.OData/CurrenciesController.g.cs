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
using Nox.Extensions;
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class CurrenciesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<BankNoteDto>>> GetCurrencyCommonBankNotes([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.CurrencyCommonBankNotes);
    }
    
    [EnableQuery]
    [HttpGet("api/Currencies/{key}/CurrencyCommonBankNotes/{relatedKey}")]
    public virtual async Task<ActionResult<BankNoteDto>> GetCurrencyCommonBankNotesNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetCurrencyCommonBankNotes(key, new BankNoteKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToCurrencyCommonBankNotes([FromRoute] System.String key, [FromBody] BankNoteCreateDto bankNote)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateBankNoteForCurrencyCommand(new CurrencyKeyDto(key), bankNote, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCurrencyCommonBankNotes(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/Currencies/{key}/CurrencyCommonBankNotes/{relatedKey}")]
    public virtual async Task<ActionResult<BankNoteDto>> PutToBankNotesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] BankNoteUpdateDto bankNote)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateBankNoteForCurrencyCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey), bankNote, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCurrencyCommonBankNotes(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/Currencies/{key}/CurrencyCommonBankNotes/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToBankNotesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<BankNoteDto> bankNote)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in bankNote.GetChangedPropertyNames())
        {
            if(bankNote.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateBankNoteForCurrencyCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetCurrencyCommonBankNotes(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Currencies/{key}/CurrencyCommonBankNotes/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteBankNoteNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteBankNoteForCurrencyCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    protected async Task<BankNoteDto?> TryGetCurrencyCommonBankNotes(System.String key, BankNoteKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SingleOrDefault();
        return parent?.CurrencyCommonBankNotes.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ExchangeRateDto>>> GetCurrencyExchangedFromRates([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.CurrencyExchangedFromRates);
    }
    
    [EnableQuery]
    [HttpGet("api/Currencies/{key}/CurrencyExchangedFromRates/{relatedKey}")]
    public virtual async Task<ActionResult<ExchangeRateDto>> GetCurrencyExchangedFromRatesNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetCurrencyExchangedFromRates(key, new ExchangeRateKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToCurrencyExchangedFromRates([FromRoute] System.String key, [FromBody] ExchangeRateCreateDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateExchangeRateForCurrencyCommand(new CurrencyKeyDto(key), exchangeRate, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCurrencyExchangedFromRates(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/Currencies/{key}/CurrencyExchangedFromRates/{relatedKey}")]
    public virtual async Task<ActionResult<ExchangeRateDto>> PutToExchangeRatesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] ExchangeRateUpdateDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateExchangeRateForCurrencyCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey), exchangeRate, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCurrencyExchangedFromRates(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/Currencies/{key}/CurrencyExchangedFromRates/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToExchangeRatesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<ExchangeRateDto> exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in exchangeRate.GetChangedPropertyNames())
        {
            if(exchangeRate.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateExchangeRateForCurrencyCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetCurrencyExchangedFromRates(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Currencies/{key}/CurrencyExchangedFromRates/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteExchangeRateNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteExchangeRateForCurrencyCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    protected async Task<ExchangeRateDto?> TryGetCurrencyExchangedFromRates(System.String key, ExchangeRateKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SingleOrDefault();
        return parent?.CurrencyExchangedFromRates.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToCountries([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToCountriesCommand(new CurrencyKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCountries([FromRoute] System.String key, [FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        country.CurrencyId = key;
        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToCountries([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).Select(x => x.Countries).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"Countries/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToCountries([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToCountriesCommand(new CurrencyKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("api/Currencies/{key}/Countries/{relatedKey}")]
    public async Task<ActionResult> DeleteToCountries([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.Countries).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCountryByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("api/Currencies/{key}/Countries/{relatedKey}")]
    public virtual async Task<ActionResult<CountryDto>> PutToCountriesNonConventional(System.String key, System.String relatedKey, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.Countries).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCountryCommand(relatedKey, country, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    public async Task<ActionResult> CreateRefToMinimumCashStocks([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToMinimumCashStocksCommand(new CurrencyKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToMinimumCashStocks([FromRoute] System.String key, [FromBody] MinimumCashStockCreateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        minimumCashStock.CurrencyId = key;
        var createdKey = await _mediator.Send(new CreateMinimumCashStockCommand(minimumCashStock, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetMinimumCashStockByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToMinimumCashStocks([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).Select(x => x.MinimumCashStocks).SingleOrDefault();
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
    
    public async Task<ActionResult> DeleteRefToMinimumCashStocks([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToMinimumCashStocksCommand(new CurrencyKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToMinimumCashStocks([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCurrencyToMinimumCashStocksCommand(new CurrencyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("api/Currencies/{key}/MinimumCashStocks/{relatedKey}")]
    public async Task<ActionResult> DeleteToMinimumCashStocks([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.MinimumCashStocks).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteMinimumCashStockByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("api/Currencies/{key}/MinimumCashStocks")]
    public async Task<ActionResult> DeleteToMinimumCashStocks([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).Select(x => x.MinimumCashStocks).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteMinimumCashStockByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("api/Currencies/{key}/MinimumCashStocks/{relatedKey}")]
    public virtual async Task<ActionResult<MinimumCashStockDto>> PutToMinimumCashStocksNonConventional(System.String key, System.Int64 relatedKey, [FromBody] MinimumCashStockUpdateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.MinimumCashStocks).Any(x => x.Id == relatedKey);
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
    
    #endregion
    
}
