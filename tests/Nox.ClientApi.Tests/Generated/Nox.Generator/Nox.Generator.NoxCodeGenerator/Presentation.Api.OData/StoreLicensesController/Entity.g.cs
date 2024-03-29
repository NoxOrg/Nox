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
using Nox.Exceptions;

using System;
using System.Net.Http.Headers;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Presentation.Api.OData;

public partial class StoreLicensesController : StoreLicensesControllerBase
{
    public StoreLicensesController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class StoreLicensesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public StoreLicensesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreLicenseDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoreLicensesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<StoreLicenseDto>> Get([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new GetStoreLicenseByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<StoreLicenseDto>> Post([FromBody] StoreLicenseCreateDto storeLicense)
    {
        if(storeLicense is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateStoreLicenseCommand(storeLicense, _cultureCode));

        var item = (await _mediator.Send(new GetStoreLicenseByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<StoreLicenseDto>> Put([FromRoute] System.Int64 key, [FromBody] StoreLicenseUpdateDto storeLicense)
    {
        if(storeLicense is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateStoreLicenseCommand(key, storeLicense, _cultureCode, etag));

        var item = (await _mediator.Send(new GetStoreLicenseByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<StoreLicenseDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<StoreLicensePartialUpdateDto> storeLicense)
    {
        if(storeLicense is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<StoreLicensePartialUpdateDto>(storeLicense);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateStoreLicenseCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetStoreLicenseByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteStoreLicenseByIdCommand(new List<StoreLicenseKeyDto> { new StoreLicenseKeyDto(key) }, etag));

        return NoContent();
    }
}