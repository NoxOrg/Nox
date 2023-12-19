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

namespace Cryptocash.Presentation.Api.OData;

public partial class PaymentProvidersController : PaymentProvidersControllerBase
{
    public PaymentProvidersController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class PaymentProvidersControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public PaymentProvidersControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<PaymentProviderDto>>> Get()
    {
        var result = await _mediator.Send(new GetPaymentProvidersQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<PaymentProviderDto>> Get([FromRoute] System.Guid key)
    {
        var result = await _mediator.Send(new GetPaymentProviderByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<PaymentProviderDto>> Post([FromBody] PaymentProviderCreateDto paymentProvider)
    {
        if(paymentProvider is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreatePaymentProviderCommand(paymentProvider, _cultureCode));

        var item = (await _mediator.Send(new GetPaymentProviderByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<PaymentProviderDto>> Put([FromRoute] System.Guid key, [FromBody] PaymentProviderUpdateDto paymentProvider)
    {
        if(paymentProvider is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdatePaymentProviderCommand(key, paymentProvider, _cultureCode, etag));

        var item = (await _mediator.Send(new GetPaymentProviderByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<PaymentProviderDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<PaymentProviderPartialUpdateDto> paymentProvider)
    {
        if(paymentProvider is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<PaymentProviderPartialUpdateDto>(paymentProvider);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdatePaymentProviderCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetPaymentProviderByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeletePaymentProviderByIdCommand(new List<PaymentProviderKeyDto> { new PaymentProviderKeyDto(key) }, etag));

        return NoContent();
    }
}