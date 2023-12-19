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
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Presentation.Api.OData;

public partial class StoreOwnersController : StoreOwnersControllerBase
{
    public StoreOwnersController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class StoreOwnersControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public StoreOwnersControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreOwnerDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoreOwnersQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<StoreOwnerDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetStoreOwnerByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<StoreOwnerDto>> Post([FromBody] StoreOwnerCreateDto storeOwner)
    {
        if(storeOwner is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateStoreOwnerCommand(storeOwner, _cultureCode));

        var item = (await _mediator.Send(new GetStoreOwnerByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<StoreOwnerDto>> Put([FromRoute] System.String key, [FromBody] StoreOwnerUpdateDto storeOwner)
    {
        if(storeOwner is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateStoreOwnerCommand(key, storeOwner, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("StoreOwner", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetStoreOwnerByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<StoreOwnerDto>> Patch([FromRoute] System.String key, [FromBody] Delta<StoreOwnerPartialUpdateDto> storeOwner)
    {
        if(storeOwner is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<StoreOwnerPartialUpdateDto>(storeOwner);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateStoreOwnerCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("StoreOwner", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetStoreOwnerByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteStoreOwnerByIdCommand(new List<StoreOwnerKeyDto> { new StoreOwnerKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("StoreOwner", $"{key.ToString()}");
        }

        return NoContent();
    }
}