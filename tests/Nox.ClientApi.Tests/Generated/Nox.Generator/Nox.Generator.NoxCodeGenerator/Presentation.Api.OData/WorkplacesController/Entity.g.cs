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

public partial class WorkplacesController : WorkplacesControllerBase
{
    public WorkplacesController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class WorkplacesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public WorkplacesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<WorkplaceDto>>> Get()
    {
        var result = await _mediator.Send(new GetWorkplacesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<WorkplaceDto>> Get([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new GetWorkplaceByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<WorkplaceDto>> Post([FromBody] WorkplaceCreateDto workplace)
    {
        if(workplace is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateWorkplaceCommand(workplace, _cultureCode));

        var item = (await _mediator.Send(new GetWorkplaceByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<WorkplaceDto>> Put([FromRoute] System.Int64 key, [FromBody] WorkplaceUpdateDto workplace)
    {
        if(workplace is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateWorkplaceCommand(key, workplace, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetWorkplaceByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<WorkplaceDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<WorkplacePartialUpdateDto> workplace)
    {
        if(workplace is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<WorkplacePartialUpdateDto>(workplace);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateWorkplaceCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetWorkplaceByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteWorkplaceByIdCommand(new List<WorkplaceKeyDto> { new WorkplaceKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("Workplace", $"{key.ToString()}");
        }

        return NoContent();
    }
}