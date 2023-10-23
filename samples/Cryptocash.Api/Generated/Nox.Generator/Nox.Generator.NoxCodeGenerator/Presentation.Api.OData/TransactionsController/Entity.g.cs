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

public abstract partial class TransactionsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    public TransactionsControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TransactionDto>>> Get()
    {
        var result = await _mediator.Send(new GetTransactionsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<TransactionDto>> Get([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new GetTransactionByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TransactionDto>> Post([FromBody] TransactionCreateDto transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTransactionCommand(transaction));

        var item = (await _mediator.Send(new GetTransactionByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TransactionDto>> Put([FromRoute] System.Int64 key, [FromBody] TransactionUpdateDto transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTransactionCommand(key, transaction, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTransactionByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TransactionDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<TransactionDto> transaction)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in transaction.GetChangedPropertyNames())
        {
            if (transaction.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTransactionCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTransactionByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTransactionByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class TransactionsController : TransactionsControllerBase
{
    public TransactionsController(IMediator mediator)
        : base(mediator)
    {}
}