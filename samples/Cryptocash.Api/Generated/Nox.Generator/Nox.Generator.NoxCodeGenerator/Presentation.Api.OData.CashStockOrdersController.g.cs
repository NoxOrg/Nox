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

public partial class CashStockOrdersController : CashStockOrdersControllerBase
            {
                public CashStockOrdersController(IMediator mediator, DtoDbContext databaseContext):base(databaseContext, mediator)
                {}
            }
public abstract class CashStockOrdersControllerBase : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CashStockOrdersControllerBase(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CashStockOrderDto>>> Get()
    {
        var result = await _mediator.Send(new GetCashStockOrdersQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<CashStockOrderDto>> Get([FromRoute] System.Int64 key)
    {
        var item = await _mediator.Send(new GetCashStockOrderByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<CashStockOrderDto>> Post([FromBody]CashStockOrderCreateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCashStockOrderCommand(cashStockOrder));
        
        var item = await _mediator.Send(new GetCashStockOrderByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<CashStockOrderDto>> Put([FromRoute] System.Int64 key, [FromBody] CashStockOrderUpdateDto cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCashStockOrderCommand(key, cashStockOrder, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetCashStockOrderByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<CashStockOrderDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<CashStockOrderUpdateDto> cashStockOrder)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in cashStockOrder.GetChangedPropertyNames())
        {
            if(cashStockOrder.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCashStockOrderCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetCashStockOrderByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCashStockOrderByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
