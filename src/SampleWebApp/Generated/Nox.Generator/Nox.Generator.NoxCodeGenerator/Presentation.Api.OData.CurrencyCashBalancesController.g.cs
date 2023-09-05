// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class CurrencyCashBalancesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CurrencyCashBalancesController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CurrencyCashBalanceDto>>> Get()
    {
        var result = await _mediator.Send(new GetCurrencyCashBalancesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<CurrencyCashBalanceDto>> Get([FromRoute] System.String keyStoreId, [FromRoute] System.UInt32 keyCurrencyId)
    {
        var item = await _mediator.Send(new GetCurrencyCashBalanceByIdQuery(keyStoreId, keyCurrencyId));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post([FromBody]CurrencyCashBalanceCreateDto currencycashbalance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCurrencyCashBalanceCommand(currencycashbalance));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.String keyStoreId, [FromRoute] System.UInt32 keyCurrencyId, [FromBody] CurrencyCashBalanceUpdateDto currencyCashBalance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateCurrencyCashBalanceCommand(keyStoreId, keyCurrencyId, currencyCashBalance));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.String keyStoreId, [FromRoute] System.UInt32 keyCurrencyId, [FromBody] Delta<CurrencyCashBalanceUpdateDto> currencyCashBalance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in currencyCashBalance.GetChangedPropertyNames())
        {
            if(currencyCashBalance.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateCurrencyCashBalanceCommand(keyStoreId, keyCurrencyId, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.String keyStoreId, [FromRoute] System.UInt32 keyCurrencyId)
    {
        var result = await _mediator.Send(new DeleteCurrencyCashBalanceByIdCommand(keyStoreId, keyCurrencyId));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
