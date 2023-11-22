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

public partial class EntityUniqueConstraintsRelatedForeignKeysController : EntityUniqueConstraintsRelatedForeignKeysControllerBase
{
    public EntityUniqueConstraintsRelatedForeignKeysController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class EntityUniqueConstraintsRelatedForeignKeysControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public EntityUniqueConstraintsRelatedForeignKeysControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<EntityUniqueConstraintsRelatedForeignKeyDto>>> Get()
    {
        var result = await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeysQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<EntityUniqueConstraintsRelatedForeignKeyDto>> Get([FromRoute] System.Int32 key)
    {
        var result = await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<EntityUniqueConstraintsRelatedForeignKeyDto>> Post([FromBody] EntityUniqueConstraintsRelatedForeignKeyCreateDto entityUniqueConstraintsRelatedForeignKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateEntityUniqueConstraintsRelatedForeignKeyCommand(entityUniqueConstraintsRelatedForeignKey, _cultureCode));

        var item = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<EntityUniqueConstraintsRelatedForeignKeyDto>> Put([FromRoute] System.Int32 key, [FromBody] EntityUniqueConstraintsRelatedForeignKeyUpdateDto entityUniqueConstraintsRelatedForeignKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateEntityUniqueConstraintsRelatedForeignKeyCommand(key, entityUniqueConstraintsRelatedForeignKey, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<EntityUniqueConstraintsRelatedForeignKeyDto>> Patch([FromRoute] System.Int32 key, [FromBody] Delta<EntityUniqueConstraintsRelatedForeignKeyUpdateDto> entityUniqueConstraintsRelatedForeignKey)
    {
        if (!ModelState.IsValid || entityUniqueConstraintsRelatedForeignKey is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in entityUniqueConstraintsRelatedForeignKey.GetChangedPropertyNames())
        {
            if (entityUniqueConstraintsRelatedForeignKey.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateEntityUniqueConstraintsRelatedForeignKeyCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetEntityUniqueConstraintsRelatedForeignKeyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int32 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteEntityUniqueConstraintsRelatedForeignKeyByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}