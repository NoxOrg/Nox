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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Presentation.Api.OData;

public partial class ForReferenceNumbersController : ForReferenceNumbersControllerBase
{
    public ForReferenceNumbersController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class ForReferenceNumbersControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public ForReferenceNumbersControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ForReferenceNumberDto>>> Get()
    {
        var result = await _mediator.Send(new GetForReferenceNumbersQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<ForReferenceNumberDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetForReferenceNumberByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<ForReferenceNumberDto>> Post([FromBody] ForReferenceNumberCreateDto forReferenceNumber)
    {
        if(forReferenceNumber is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateForReferenceNumberCommand(forReferenceNumber, _cultureCode));

        var item = (await _mediator.Send(new GetForReferenceNumberByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<ForReferenceNumberDto>> Put([FromRoute] System.String key, [FromBody] ForReferenceNumberUpdateDto forReferenceNumber)
    {
        if(forReferenceNumber is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateForReferenceNumberCommand(key, forReferenceNumber, _cultureCode, etag));

        var item = (await _mediator.Send(new GetForReferenceNumberByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<ForReferenceNumberDto>> Patch([FromRoute] System.String key, [FromBody] Delta<ForReferenceNumberPartialUpdateDto> forReferenceNumber)
    {
        if(forReferenceNumber is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<ForReferenceNumberPartialUpdateDto>(forReferenceNumber);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateForReferenceNumberCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetForReferenceNumberByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteForReferenceNumberByIdCommand(new List<ForReferenceNumberKeyDto> { new ForReferenceNumberKeyDto(key) }, etag));

        return NoContent();
    }
}