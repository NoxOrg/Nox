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
    
    public async Task<ActionResult> PostToBankNotes([FromRoute] System.String key, [FromBody] BankNoteCreateDto bankNote)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new AddBankNoteCommand(new CurrencyKeyDto(key), bankNote, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        return Created(new BankNoteDto { Id = createdKey.keyId });
    }
    
    public async Task<ActionResult> PutToBankNotes([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey, [FromBody] BankNoteUpdateDto bankNote)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateBankNoteCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey), bankNote, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        return Updated(new BankNoteDto { Id = updatedKey.keyId });
    }
    
    public async Task<ActionResult> PatchToBankNotes([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey, [FromBody] Delta<BankNoteUpdateDto> bankNote)
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
        
        var etag = GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateBankNoteCommand(new CurrencyKeyDto(key), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(new BankNoteDto { Id = updated.keyId });
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
    
    public async Task<ActionResult> PostToExchangeRates([FromRoute] System.String key, [FromBody] ExchangeRateCreateDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new AddExchangeRateCommand(new CurrencyKeyDto(key), exchangeRate, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        return Created(new ExchangeRateDto { Id = createdKey.keyId });
    }
    
    public async Task<ActionResult> PutToExchangeRates([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey, [FromBody] ExchangeRateUpdateDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateExchangeRateCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey), exchangeRate, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        return Updated(new ExchangeRateDto { Id = updatedKey.keyId });
    }
    
    public async Task<ActionResult> PatchToExchangeRates([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey, [FromBody] Delta<ExchangeRateUpdateDto> exchangeRate)
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
        
        var etag = GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateExchangeRateCommand(new CurrencyKeyDto(key), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(new ExchangeRateDto { Id = updated.keyId });
    }
    
    public async Task<ActionResult> Post([FromBody]CurrencyCreateDto currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCurrencyCommand(currency));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.String key, [FromBody] CurrencyUpdateDto currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(key, currency, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.String key, [FromBody] Delta<CurrencyUpdateDto> currency)
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
        
        var etag = GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCurrencyCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCurrencyByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private System.Guid? GetDecodedEtagHeader()
    {
        var ifMatchValue = Request.Headers.IfMatch.FirstOrDefault();
        string? rawEtag = ifMatchValue;
        if (EntityTagHeaderValue.TryParse(ifMatchValue, out var encodedEtag))
        {
            rawEtag = encodedEtag.Tag.Trim('"');
        }
        
        return System.Guid.TryParse(rawEtag, out var etag) ? etag : null;
    }
}
