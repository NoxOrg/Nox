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

public partial class StoresController : StoresControllerBase
{
    public StoresController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class StoresControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public StoresControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoresQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<StoreDto>> Get([FromRoute] System.Guid key)
    {
        var result = await _mediator.Send(new GetStoreByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<StoreDto>> Post([FromBody] StoreCreateDto store)
    {
        if(store is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateStoreCommand(store, _cultureCode));

        var item = (await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<StoreDto>> Put([FromRoute] System.Guid key, [FromBody] StoreUpdateDto store)
    {
        if(store is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateStoreCommand(key, store, _cultureCode, etag));

        var item = (await _mediator.Send(new GetStoreByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<StoreDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<StorePartialUpdateDto> store)
    {
        if(store is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<StorePartialUpdateDto>(store);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateStoreCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetStoreByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteStoreByIdCommand(new List<StoreKeyDto> { new StoreKeyDto(key) }, etag));

        return NoContent();
    }
}