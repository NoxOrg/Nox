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

public partial class BookingsController : BookingsControllerBase
            {
                public BookingsController(IMediator mediator, DtoDbContext databaseContext):base(databaseContext, mediator)
                {}
            }
public abstract class BookingsControllerBase : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public BookingsControllerBase(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<BookingDto>>> Get()
    {
        var result = await _mediator.Send(new GetBookingsQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<BookingDto>> Get([FromRoute] System.Guid key)
    {
        var item = await _mediator.Send(new GetBookingByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<BookingDto>> Post([FromBody]BookingCreateDto booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateBookingCommand(booking));
        
        var item = await _mediator.Send(new GetBookingByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<BookingDto>> Put([FromRoute] System.Guid key, [FromBody] BookingUpdateDto booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateBookingCommand(key, booking, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetBookingByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<BookingDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<BookingUpdateDto> booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in booking.GetChangedPropertyNames())
        {
            if(booking.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateBookingCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetBookingByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteBookingByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
