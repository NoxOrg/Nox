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
using Nox.Exceptions;

using System;
using System.Net.Http.Headers;
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Presentation.Api.OData;

public partial class CashStockOrdersController : CashStockOrdersControllerBase
{
    public CashStockOrdersController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class CashStockOrdersControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public CashStockOrdersControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CashStockOrderDto>>> Get()
    {
        var result = await _mediator.Send(new GetCashStockOrdersQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<CashStockOrderDto>> Get([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new GetCashStockOrderByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<CashStockOrderDto>> Post([FromBody] CashStockOrderCreateDto cashStockOrder)
    {
        if(cashStockOrder is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateCashStockOrderCommand(cashStockOrder, _cultureCode));

        var item = (await _mediator.Send(new GetCashStockOrderByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<CashStockOrderDto>> Put([FromRoute] System.Int64 key, [FromBody] CashStockOrderUpdateDto cashStockOrder)
    {
        if(cashStockOrder is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCashStockOrderCommand(key, cashStockOrder, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCashStockOrderByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<CashStockOrderDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<CashStockOrderPartialUpdateDto> cashStockOrder)
    {
        if(cashStockOrder is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CashStockOrderPartialUpdateDto>(cashStockOrder);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateCashStockOrderCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCashStockOrderByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCashStockOrderByIdCommand(new List<CashStockOrderKeyDto> { new CashStockOrderKeyDto(key) }, etag));

        return NoContent();
    }
}