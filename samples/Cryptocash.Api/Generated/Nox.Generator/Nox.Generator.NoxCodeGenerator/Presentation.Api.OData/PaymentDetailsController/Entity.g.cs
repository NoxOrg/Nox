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

public partial class PaymentDetailsController : PaymentDetailsControllerBase
{
    public PaymentDetailsController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class PaymentDetailsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public PaymentDetailsControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = Nox.Types.CultureCode.From(httpLanguageProvider.GetLanguage());
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<PaymentDetailDto>>> Get()
    {
        var result = await _mediator.Send(new GetPaymentDetailsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<PaymentDetailDto>> Get([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new GetPaymentDetailByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<PaymentDetailDto>> Post([FromBody] PaymentDetailCreateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreatePaymentDetailCommand(paymentDetail, _cultureCode));

        var item = (await _mediator.Send(new GetPaymentDetailByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<PaymentDetailDto>> Put([FromRoute] System.Int64 key, [FromBody] PaymentDetailUpdateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdatePaymentDetailCommand(key, paymentDetail, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetPaymentDetailByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<PaymentDetailDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<PaymentDetailDto> paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in paymentDetail.GetChangedPropertyNames())
        {
            if (paymentDetail.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdatePaymentDetailCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetPaymentDetailByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeletePaymentDetailByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}