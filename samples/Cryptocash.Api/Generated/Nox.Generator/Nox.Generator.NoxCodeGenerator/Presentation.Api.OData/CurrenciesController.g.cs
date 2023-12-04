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

public abstract partial class CurrenciesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<BankNoteDto>>> GetBankNotes([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.BankNotes);
    }
    
    [EnableQuery]
    [HttpGet("/api/Currencies/{key}/BankNotes/{relatedKey}")]
    public virtual async Task<ActionResult<BankNoteDto>> GetBankNotesNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetBankNotes(key, new BankNoteKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToBankNotes([FromRoute] System.String key, [FromBody] BankNoteUpsertDto bankNote)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateBankNotesForCurrencyCommand(new CurrencyKeyDto(key), bankNote, _cultureCode, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetBankNotes(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    public virtual async Task<ActionResult<BankNoteDto>> PutToBankNotes(System.String key, [FromBody] BankNoteUpsertDto bankNote)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateBankNotesForCurrencyCommand(new CurrencyKeyDto(key), bankNote, _cultureCode, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetBankNotes(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToBankNotes(System.String key, [FromBody] Delta<BankNoteUpsertDto> bankNote)
    {
        if (!ModelState.IsValid || bankNote is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in bankNote.GetChangedPropertyNames())
        {
            if(bankNote.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        if(!updateProperties.ContainsKey("Id") || updateProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateBankNotesForCurrencyCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(updateProperties["Id"]), updateProperties, _cultureCode, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetBankNotes(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("/api/Currencies/{key}/BankNotes/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteBankNoteNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteBankNotesForCurrencyCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    protected async Task<BankNoteDto?> TryGetBankNotes(System.String key, BankNoteKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SingleOrDefault();
        return parent?.BankNotes.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ExchangeRateDto>>> GetExchangeRates([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.ExchangeRates);
    }
    
    [EnableQuery]
    [HttpGet("/api/Currencies/{key}/ExchangeRates/{relatedKey}")]
    public virtual async Task<ActionResult<ExchangeRateDto>> GetExchangeRatesNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetExchangeRates(key, new ExchangeRateKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToExchangeRates([FromRoute] System.String key, [FromBody] ExchangeRateUpsertDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateExchangeRatesForCurrencyCommand(new CurrencyKeyDto(key), exchangeRate, _cultureCode, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetExchangeRates(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    public virtual async Task<ActionResult<ExchangeRateDto>> PutToExchangeRates(System.String key, [FromBody] ExchangeRateUpsertDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateExchangeRatesForCurrencyCommand(new CurrencyKeyDto(key), exchangeRate, _cultureCode, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetExchangeRates(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToExchangeRates(System.String key, [FromBody] Delta<ExchangeRateUpsertDto> exchangeRate)
    {
        if (!ModelState.IsValid || exchangeRate is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in exchangeRate.GetChangedPropertyNames())
        {
            if(exchangeRate.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        if(!updateProperties.ContainsKey("Id") || updateProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateExchangeRatesForCurrencyCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(updateProperties["Id"]), updateProperties, _cultureCode, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetExchangeRates(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("/api/Currencies/{key}/ExchangeRates/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteExchangeRateNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteExchangeRatesForCurrencyCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    protected async Task<ExchangeRateDto?> TryGetExchangeRates(System.String key, ExchangeRateKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SingleOrDefault();
        return parent?.ExchangeRates.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToCountries([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToCountriesCommand(new CurrencyKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/Currencies/{key}/Countries/$ref")]
    public virtual async Task<ActionResult> UpdateRefToCountriesNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.String> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new CountryKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCurrencyToCountriesCommand(new CurrencyKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCountries([FromRoute] System.String key)
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
    
    public virtual async Task<ActionResult> DeleteRefToCountries([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToCountriesCommand(new CurrencyKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCountries([FromRoute] System.String key, [FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        country.CurrencyId = key;
        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryDto>>> GetCountries(System.String key)
    {
        var entity = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.Countries);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/Currencies/{key}/Countries/{relatedKey}")]
    public virtual async Task<SingleResult<CountryDto>> GetCountriesNonConventional(System.String key, System.String relatedKey)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.Countries).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<CountryDto>(Enumerable.Empty<CountryDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Currencies/{key}/Countries/{relatedKey}")]
    public virtual async Task<ActionResult<CountryDto>> PutToCountriesNonConventional(System.String key, System.String relatedKey, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
    
    [HttpDelete("/api/Currencies/{key}/Countries/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToCountries([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
    
    public virtual async Task<ActionResult> CreateRefToMinimumCashStocks([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToMinimumCashStocksCommand(new CurrencyKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/Currencies/{key}/MinimumCashStocks/$ref")]
    public virtual async Task<ActionResult> UpdateRefToMinimumCashStocksNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new MinimumCashStockKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCurrencyToMinimumCashStocksCommand(new CurrencyKeyDto(key), relatedKeysDto));
        if (!updatedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToMinimumCashStocks([FromRoute] System.String key)
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
    
    public virtual async Task<ActionResult> DeleteRefToMinimumCashStocks([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToMinimumCashStocksCommand(new CurrencyKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToMinimumCashStocks([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCurrencyToMinimumCashStocksCommand(new CurrencyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToMinimumCashStocks([FromRoute] System.String key, [FromBody] MinimumCashStockCreateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        minimumCashStock.CurrencyId = key;
        var createdKey = await _mediator.Send(new CreateMinimumCashStockCommand(minimumCashStock, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetMinimumCashStockByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<MinimumCashStockDto>>> GetMinimumCashStocks(System.String key)
    {
        var entity = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.MinimumCashStocks);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/Currencies/{key}/MinimumCashStocks/{relatedKey}")]
    public virtual async Task<SingleResult<MinimumCashStockDto>> GetMinimumCashStocksNonConventional(System.String key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.MinimumCashStocks).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<MinimumCashStockDto>(Enumerable.Empty<MinimumCashStockDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/Currencies/{key}/MinimumCashStocks/{relatedKey}")]
    public virtual async Task<ActionResult<MinimumCashStockDto>> PutToMinimumCashStocksNonConventional(System.String key, System.Int64 relatedKey, [FromBody] MinimumCashStockUpdateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
    
    [HttpDelete("/api/Currencies/{key}/MinimumCashStocks/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToMinimumCashStocks([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
    
    [HttpDelete("/api/Currencies/{key}/MinimumCashStocks")]
    public virtual async Task<ActionResult> DeleteToMinimumCashStocks([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
    
    #endregion
    
}
