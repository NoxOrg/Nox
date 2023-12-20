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

public partial class TransactionsController : TransactionsControllerBase
{
    public TransactionsController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TransactionsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TransactionsControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TransactionDto>>> Get()
    {
        var result = await _mediator.Send(new GetTransactionsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TransactionDto>> Get([FromRoute] System.Guid key)
    {
        var result = await _mediator.Send(new GetTransactionByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TransactionDto>> Post([FromBody] TransactionCreateDto transaction)
    {
        if(transaction is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTransactionCommand(transaction, _cultureCode));

        var item = (await _mediator.Send(new GetTransactionByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TransactionDto>> Put([FromRoute] System.Guid key, [FromBody] TransactionUpdateDto transaction)
    {
        if(transaction is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTransactionCommand(key, transaction, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Transaction", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTransactionByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TransactionDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<TransactionPartialUpdateDto> transaction)
    {
        if(transaction is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TransactionPartialUpdateDto>(transaction);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTransactionCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Transaction", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTransactionByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTransactionByIdCommand(new List<TransactionKeyDto> { new TransactionKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("Transaction", $"{key.ToString()}");
        }

        return NoContent();
    }
}