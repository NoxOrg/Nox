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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Presentation.Api.OData;

public partial class EntityUniqueConstraintsWithForeignKeysController : EntityUniqueConstraintsWithForeignKeysControllerBase
{
    public EntityUniqueConstraintsWithForeignKeysController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class EntityUniqueConstraintsWithForeignKeysControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public EntityUniqueConstraintsWithForeignKeysControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<EntityUniqueConstraintsWithForeignKeyDto>>> Get()
    {
        var result = await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeysQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<EntityUniqueConstraintsWithForeignKeyDto>> Get([FromRoute] System.Guid key)
    {
        var result = await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<EntityUniqueConstraintsWithForeignKeyDto>> Post([FromBody] EntityUniqueConstraintsWithForeignKeyCreateDto entityUniqueConstraintsWithForeignKey)
    {
        if(entityUniqueConstraintsWithForeignKey is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateEntityUniqueConstraintsWithForeignKeyCommand(entityUniqueConstraintsWithForeignKey, _cultureCode));

        var item = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<EntityUniqueConstraintsWithForeignKeyDto>> Put([FromRoute] System.Guid key, [FromBody] EntityUniqueConstraintsWithForeignKeyUpdateDto entityUniqueConstraintsWithForeignKey)
    {
        if(entityUniqueConstraintsWithForeignKey is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateEntityUniqueConstraintsWithForeignKeyCommand(key, entityUniqueConstraintsWithForeignKey, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<EntityUniqueConstraintsWithForeignKeyDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<EntityUniqueConstraintsWithForeignKeyPartialUpdateDto> entityUniqueConstraintsWithForeignKey)
    {
        if(entityUniqueConstraintsWithForeignKey is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<EntityUniqueConstraintsWithForeignKeyPartialUpdateDto>(entityUniqueConstraintsWithForeignKey);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateEntityUniqueConstraintsWithForeignKeyCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetEntityUniqueConstraintsWithForeignKeyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteEntityUniqueConstraintsWithForeignKeyByIdCommand(new List<EntityUniqueConstraintsWithForeignKeyKeyDto> { new EntityUniqueConstraintsWithForeignKeyKeyDto(key) }, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}