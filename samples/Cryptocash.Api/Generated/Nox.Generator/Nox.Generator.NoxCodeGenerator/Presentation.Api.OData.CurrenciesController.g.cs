// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
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

public partial class CurrenciesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CurrenciesController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    #region Owned Relationships
    
    [EnableQuery]
    public async Task<ActionResult<IQueryable<BankNoteDto>>> GetBankNotes([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = await _mediator.Send(new GetCurrencyByIdQuery(key));
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.BankNotes);
    }
    
    [EnableQuery]
    [HttpGet("api/Currencies/{key}/BankNotes/{relatedKey}")]
    public async Task<ActionResult<BankNoteDto>> GetBankNoteNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetBankNote(key, new BankNoteKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public async Task<ActionResult> PostToBankNotes([FromRoute] System.String key, [FromBody] BankNoteCreateDto bankNote)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new AddBankNoteCommand(new CurrencyKeyDto(key), bankNote, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetBankNote(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/Currencies/{key}/BankNotes/{relatedKey}")]
    public async Task<ActionResult<BankNoteDto>> PutToBankNotesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] BankNoteUpdateDto bankNote)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateBankNoteCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey), bankNote, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetBankNote(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/Currencies/{key}/BankNotes/{relatedKey}")]
    public async Task<ActionResult> PatchToBankNotesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<BankNoteUpdateDto> bankNote)
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
        var updated = await _mediator.Send(new PartialUpdateBankNoteCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetBankNote(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Currencies/{key}/BankNotes/{relatedKey}")]
    public async Task<ActionResult> DeleteBankNoteNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteBankNoteCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private async Task<BankNoteDto?> TryGetBankNote(System.String key, BankNoteKeyDto childKeyDto)
    {
        var parent = await _mediator.Send(new GetCurrencyByIdQuery(key));
        return parent?.BankNotes.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public async Task<ActionResult<IQueryable<ExchangeRateDto>>> GetExchangeRates([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = await _mediator.Send(new GetCurrencyByIdQuery(key));
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.ExchangeRates);
    }
    
    [EnableQuery]
    [HttpGet("api/Currencies/{key}/ExchangeRates/{relatedKey}")]
    public async Task<ActionResult<ExchangeRateDto>> GetExchangeRateNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetExchangeRate(key, new ExchangeRateKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public async Task<ActionResult> PostToExchangeRates([FromRoute] System.String key, [FromBody] ExchangeRateCreateDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new AddExchangeRateCommand(new CurrencyKeyDto(key), exchangeRate, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetExchangeRate(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/Currencies/{key}/ExchangeRates/{relatedKey}")]
    public async Task<ActionResult<ExchangeRateDto>> PutToExchangeRatesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] ExchangeRateUpdateDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateExchangeRateCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey), exchangeRate, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetExchangeRate(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/Currencies/{key}/ExchangeRates/{relatedKey}")]
    public async Task<ActionResult> PatchToExchangeRatesNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<ExchangeRateUpdateDto> exchangeRate)
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
        var updated = await _mediator.Send(new PartialUpdateExchangeRateCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetExchangeRate(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Currencies/{key}/ExchangeRates/{relatedKey}")]
    public async Task<ActionResult> DeleteExchangeRateNonConventional(System.String key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteExchangeRateCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private async Task<ExchangeRateDto?> TryGetExchangeRate(System.String key, ExchangeRateKeyDto childKeyDto)
    {
        var parent = await _mediator.Send(new GetCurrencyByIdQuery(key));
        return parent?.ExchangeRates.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CurrencyDto>>> Get()
    {
        var result = await _mediator.Send(new GetCurrenciesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<CurrencyDto>> Get([FromRoute] System.String key)
    {
        var item = await _mediator.Send(new GetCurrencyByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult<CurrencyDto>> Post([FromBody]CurrencyCreateDto currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCurrencyCommand(currency));
        
        var item = await _mediator.Send(new GetCurrencyByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public async Task<ActionResult<CurrencyDto>> Put([FromRoute] System.String key, [FromBody] CurrencyUpdateDto currency)
    {
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(key, currency, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public async Task<ActionResult<CurrencyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<CurrencyUpdateDto> currency)
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
        var item = await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCurrencyByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
