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

internal partial class CurrenciesController : CurrenciesControllerBase
{
    public CurrenciesController(IMediator mediator, DtoDbContext databaseContext):base(databaseContext, mediator)
    {}
}
internal abstract class CurrenciesControllerBase : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CurrenciesControllerBase(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CurrencyDto>>> Get()
    {
        var result = await _mediator.Send(new GetCurrenciesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<CurrencyDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetCurrencyByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> Post([FromBody]CurrencyCreateDto currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCurrencyCommand(currency));
        
        var item = (await _mediator.Send(new GetCurrencyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> Put([FromRoute] System.String key, [FromBody] CurrencyUpdateDto currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(key, currency, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<CurrencyDto> currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in currency.GetChangedPropertyNames())
        {
            if(currency.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCurrencyCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCurrencyByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
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
    
    private async Task<BankNoteDto?> TryGetCurrencyCommonBankNotes(System.String key, BankNoteKeyDto childKeyDto)
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
    
    private async Task<ExchangeRateDto?> TryGetCurrencyExchangedFromRates(System.String key, ExchangeRateKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SingleOrDefault();
        return parent?.CurrencyExchangedFromRates.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToCurrencyUsedByCountry([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToCurrencyUsedByCountryCommand(new CurrencyKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCurrencyUsedByCountry([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).Select(x => x.CurrencyUsedByCountry).SingleOrDefault();
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
    
    public async Task<ActionResult> DeleteRefToCurrencyUsedByCountry([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToCurrencyUsedByCountryCommand(new CurrencyKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCurrencyUsedByCountry([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCurrencyToCurrencyUsedByCountryCommand(new CurrencyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToCurrencyUsedByMinimumCashStocks([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToCurrencyUsedByMinimumCashStocksCommand(new CurrencyKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCurrencyUsedByMinimumCashStocks([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).Select(x => x.CurrencyUsedByMinimumCashStocks).SingleOrDefault();
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
    
    public async Task<ActionResult> DeleteRefToCurrencyUsedByMinimumCashStocks([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToCurrencyUsedByMinimumCashStocksCommand(new CurrencyKeyDto(key), new MinimumCashStockKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCurrencyUsedByMinimumCashStocks([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCurrencyToCurrencyUsedByMinimumCashStocksCommand(new CurrencyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
