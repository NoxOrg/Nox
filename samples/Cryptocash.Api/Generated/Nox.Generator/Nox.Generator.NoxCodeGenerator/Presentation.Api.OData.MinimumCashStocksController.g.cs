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

public partial class MinimumCashStocksController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public MinimumCashStocksController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<MinimumCashStockDto>>> Get()
    {
        var result = await _mediator.Send(new GetMinimumCashStocksQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<MinimumCashStockDto>> Get([FromRoute] System.Int64 key)
    {
        var item = await _mediator.Send(new GetMinimumCashStockByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post([FromBody]MinimumCashStockCreateDto minimumcashstock)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateMinimumCashStockCommand(minimumcashstock));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.Int64 key, [FromBody] MinimumCashStockUpdateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateMinimumCashStockCommand(key, minimumCashStock, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.Int64 key, [FromBody] Delta<MinimumCashStockUpdateDto> minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in minimumCashStock.GetChangedPropertyNames())
        {
            if(minimumCashStock.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateMinimumCashStockCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteMinimumCashStockByIdCommand(key, etag));
        
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
