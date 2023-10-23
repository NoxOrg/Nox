﻿// Generated

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

public abstract partial class PaymentProvidersControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    public PaymentProvidersControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<PaymentProviderDto>>> Get()
    {
        var result = await _mediator.Send(new GetPaymentProvidersQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<PaymentProviderDto>> Get([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new GetPaymentProviderByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<PaymentProviderDto>> Post([FromBody] PaymentProviderCreateDto paymentProvider)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreatePaymentProviderCommand(paymentProvider));

        var item = (await _mediator.Send(new GetPaymentProviderByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<PaymentProviderDto>> Put([FromRoute] System.Int64 key, [FromBody] PaymentProviderUpdateDto paymentProvider)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdatePaymentProviderCommand(key, paymentProvider, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetPaymentProviderByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<PaymentProviderDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<PaymentProviderDto> paymentProvider)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in paymentProvider.GetChangedPropertyNames())
        {
            if (paymentProvider.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdatePaymentProviderCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetPaymentProviderByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeletePaymentProviderByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class PaymentProvidersController : PaymentProvidersControllerBase
{
    public PaymentProvidersController(IMediator mediator)
        : base(mediator)
    {}
}