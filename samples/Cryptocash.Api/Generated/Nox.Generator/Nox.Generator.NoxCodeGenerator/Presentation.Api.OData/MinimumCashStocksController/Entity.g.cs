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

public partial class MinimumCashStocksController : MinimumCashStocksControllerBase
{
    public MinimumCashStocksController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class MinimumCashStocksControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public MinimumCashStocksControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<MinimumCashStockDto>>> Get()
    {
        var result = await _mediator.Send(new GetMinimumCashStocksQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<MinimumCashStockDto>> Get([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new GetMinimumCashStockByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<MinimumCashStockDto>> Post([FromBody] MinimumCashStockCreateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateMinimumCashStockCommand(minimumCashStock, _cultureCode));

        var item = (await _mediator.Send(new GetMinimumCashStockByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<MinimumCashStockDto>> Put([FromRoute] System.Int64 key, [FromBody] MinimumCashStockUpdateDto minimumCashStock)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateMinimumCashStockCommand(key, minimumCashStock, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetMinimumCashStockByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<MinimumCashStockDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<MinimumCashStockUpdateDto> minimumCashStock)
    {
        if (!ModelState.IsValid || minimumCashStock is null)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in minimumCashStock.GetChangedPropertyNames())
        {
            if (minimumCashStock.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateMinimumCashStockCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetMinimumCashStockByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteMinimumCashStockByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}