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

public partial class TenantsController : TenantsControllerBase
{
    public TenantsController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TenantsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TenantsControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TenantDto>>> Get()
    {
        var result = await _mediator.Send(new GetTenantsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TenantDto>> Get([FromRoute] System.UInt32 key)
    {
        var result = await _mediator.Send(new GetTenantByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TenantDto>> Post([FromBody] TenantCreateDto tenant)
    {
        if(tenant is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTenantCommand(tenant, _cultureCode));

        var item = (await _mediator.Send(new GetTenantByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TenantDto>> Put([FromRoute] System.UInt32 key, [FromBody] TenantUpdateDto tenant)
    {
        if(tenant is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTenantCommand(key, tenant, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTenantByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TenantDto>> Patch([FromRoute] System.UInt32 key, [FromBody] Delta<TenantPartialUpdateDto> tenant)
    {
        if(tenant is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TenantPartialUpdateDto>(tenant);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTenantCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTenantByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.UInt32 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTenantByIdCommand(new List<TenantKeyDto> { new TenantKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }

        return NoContent();
    }
}