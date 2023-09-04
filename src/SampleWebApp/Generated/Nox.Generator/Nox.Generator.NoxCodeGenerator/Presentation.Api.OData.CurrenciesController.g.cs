﻿// Generated

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
    
    [HttpGet]
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CurrencyDto>>> Get()
    {
        var result = await _mediator.Send(new GetCurrenciesQuery());
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<ActionResult<CurrencyDto>> Get([FromRoute] System.UInt32 key)
    {
        var item = await _mediator.Send(new GetCurrencyByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody]CurrencyCreateDto currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCurrencyCommand(currency));
        
        return Created(createdKey);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromRoute] System.UInt32 key, [FromBody] CurrencyUpdateDto currency)
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
    
    [HttpPatch]
    public async Task<ActionResult> Patch([FromRoute] System.UInt32 key, [FromBody] Delta<CurrencyUpdateDto> currency)
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
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromRoute] System.UInt32 key)
    {
        var result = await _mediator.Send(new DeleteCurrencyByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
