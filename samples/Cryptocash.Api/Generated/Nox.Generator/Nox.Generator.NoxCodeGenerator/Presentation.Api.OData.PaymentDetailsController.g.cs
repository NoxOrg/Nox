// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
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

public partial class PaymentDetailsController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public PaymentDetailsController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<PaymentDetailDto>>> Get()
    {
        var result = await _mediator.Send(new GetPaymentDetailsQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<PaymentDetailDto>> Get([FromRoute] System.Int64 key)
    {
        var item = await _mediator.Send(new GetPaymentDetailByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult<PaymentDetailDto>> Post([FromBody]PaymentDetailCreateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreatePaymentDetailCommand(paymentDetail));
        
        var item = await _mediator.Send(new GetPaymentDetailByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public async Task<ActionResult<PaymentDetailDto>> Put([FromRoute] System.Int64 key, [FromBody] PaymentDetailUpdateDto paymentDetail)
    {
        
        var updated = await _mediator.Send(new UpdatePaymentDetailCommand(key, paymentDetail));
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetPaymentDetailByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public async Task<ActionResult<PaymentDetailDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<PaymentDetailUpdateDto> paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in paymentDetail.GetChangedPropertyNames())
        {
            if(paymentDetail.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdatePaymentDetailCommand(key, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetPaymentDetailByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new DeletePaymentDetailByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
