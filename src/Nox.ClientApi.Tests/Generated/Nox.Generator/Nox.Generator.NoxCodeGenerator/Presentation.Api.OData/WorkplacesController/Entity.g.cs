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
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
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
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
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
    public async Task<SingleResult<WorkplaceDto>> Get([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new GetWorkplaceByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<WorkplaceDto>> Post([FromBody] WorkplaceCreateDto workplace)
    {
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
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateWorkplaceCommand(key, workplace, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetWorkplaceByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<WorkplaceDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<WorkplaceUpdateDto> workplace)
    {
        if (!ModelState.IsValid || workplace is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in workplace.GetChangedPropertyNames())
        {
            if (workplace.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateWorkplaceCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetWorkplaceByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteWorkplaceByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}