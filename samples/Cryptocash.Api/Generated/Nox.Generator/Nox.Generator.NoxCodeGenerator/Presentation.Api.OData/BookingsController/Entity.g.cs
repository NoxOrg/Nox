// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using Nox.Extensions;

using System;
using System.Net.Http.Headers;
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
    public BookingsController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class BookingsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public BookingsControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = Nox.Types.CultureCode.From(httpLanguageProvider.GetLanguage());
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<BookingDto>>> Get()
    {
        var result = await _mediator.Send(new GetBookingsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<BookingDto>> Get([FromRoute] System.Guid key)
    {
        var result = await _mediator.Send(new GetBookingByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<BookingDto>> Post([FromBody] BookingCreateDto booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateBookingCommand(booking, _cultureCode));

        var item = (await _mediator.Send(new GetBookingByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<BookingDto>> Put([FromRoute] System.Guid key, [FromBody] BookingUpdateDto booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateBookingCommand(key, booking, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetBookingByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<BookingDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<BookingDto> booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in booking.GetChangedPropertyNames())
        {
            if (booking.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateBookingCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetBookingByIdQuery(updatedKey.keyId))).SingleOrDefault();

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