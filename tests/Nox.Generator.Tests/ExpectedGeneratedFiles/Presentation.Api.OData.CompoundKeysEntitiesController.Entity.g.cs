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
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;

using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class CompoundKeysEntitiesController : CompoundKeysEntitiesControllerBase
{
    public CompoundKeysEntitiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class CompoundKeysEntitiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public CompoundKeysEntitiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = Nox.Types.CultureCode.From(httpLanguageProvider.GetLanguage());
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CompoundKeysEntityDto>>> Get()
    {
        var result = await _mediator.Send(new GetCompoundKeysEntitiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<CompoundKeysEntityDto>> Get([FromRoute] System.String keyId1, [FromRoute] System.String keyId2)
    {
        var result = await _mediator.Send(new GetCompoundKeysEntityByIdQuery(keyId1, keyId2));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<CompoundKeysEntityDto>> Post([FromBody] CompoundKeysEntityCreateDto compoundKeysEntity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateCompoundKeysEntityCommand(compoundKeysEntity, _cultureCode));

        var item = (await _mediator.Send(new GetCompoundKeysEntityByIdQuery(createdKey.keyId1, createdKey.keyId2))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<CompoundKeysEntityDto>> Put([FromRoute] System.String keyId1, [FromRoute] System.String keyId2, [FromBody] CompoundKeysEntityUpdateDto compoundKeysEntity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCompoundKeysEntityCommand(keyId1, keyId2, compoundKeysEntity, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetCompoundKeysEntityByIdQuery(updatedKey.keyId1, updatedKey.keyId2))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<CompoundKeysEntityDto>> Patch([FromRoute] System.String keyId1, [FromRoute] System.String keyId2, [FromBody] Delta<CompoundKeysEntityDto> compoundKeysEntity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in compoundKeysEntity.GetChangedPropertyNames())
        {
            if (compoundKeysEntity.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateCompoundKeysEntityCommand(keyId1, keyId2, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetCompoundKeysEntityByIdQuery(updatedKey.keyId1, updatedKey.keyId2))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String keyId1, [FromRoute] System.String keyId2)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCompoundKeysEntityByIdCommand(keyId1, keyId2, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}