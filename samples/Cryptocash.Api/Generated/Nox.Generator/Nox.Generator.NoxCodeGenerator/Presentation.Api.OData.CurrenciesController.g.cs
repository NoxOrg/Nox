// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;
using MediatR;
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
        
        var createdKey = await _mediator.Send(new AddBankNoteCommand(new CurrencyKeyDto(key), bankNote));
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
    
    [ODataIgnored]
    [HttpPut("/api/Currencies/{key}/BankNotes/{relatedKey}")]
    public async Task<ActionResult> PutToBankNotes([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey, [FromBody] BankNoteUpdateDto bankNote)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedKey = await _mediator.Send(new UpdateBankNoteCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey), bankNote));
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
    
    [ODataIgnored]
    [HttpPatch("/api/Currencies/{key}/BankNotes/{relatedKey}")]
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
        
        var updated = await _mediator.Send(new PartialUpdateBankNoteCommand(new CurrencyKeyDto(key), new BankNoteKeyDto(relatedKey), updateProperties));
        
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
    
    private async Task<BankNoteDto?> TryGetBankNote( System.String key, BankNoteKeyDto childKeyDto)
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
    
    public async Task<ActionResult> PostToExchangeRates([FromRoute] System.String key, [FromBody] ExchangeRateCreateDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdKey = await _mediator.Send(new AddExchangeRateCommand(new CurrencyKeyDto(key), exchangeRate));
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
    
    [ODataIgnored]
    [HttpPut("/api/Currencies/{key}/ExchangeRates/{relatedKey}")]
    public async Task<ActionResult> PutToExchangeRates([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey, [FromBody] ExchangeRateUpdateDto exchangeRate)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedKey = await _mediator.Send(new UpdateExchangeRateCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey), exchangeRate));
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
    
    [ODataIgnored]
    [HttpPatch("/api/Currencies/{key}/ExchangeRates/{relatedKey}")]
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
        
        var updated = await _mediator.Send(new PartialUpdateExchangeRateCommand(new CurrencyKeyDto(key), new ExchangeRateKeyDto(relatedKey), updateProperties));
        
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
    
    private async Task<ExchangeRateDto?> TryGetExchangeRate( System.String key, ExchangeRateKeyDto childKeyDto)
    {
        var parent = await _mediator.Send(new GetCurrencyByIdQuery(key));
        return parent?.ExchangeRates.SingleOrDefault(x => x.Id == childKeyDto.keyId);
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
        
        var updated = await _mediator.Send(new UpdateCurrencyCommand(key, currency));
        
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
        
        var updated = await _mediator.Send(new PartialUpdateCurrencyCommand(key, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new DeleteCurrencyByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
