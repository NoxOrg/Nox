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

public partial class SecondTestEntityTwoRelationshipsOneToOnesController : SecondTestEntityTwoRelationshipsOneToOnesControllerBase
{
    public SecondTestEntityTwoRelationshipsOneToOnesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class SecondTestEntityTwoRelationshipsOneToOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public SecondTestEntityTwoRelationshipsOneToOnesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityTwoRelationshipsOneToOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> Post([FromBody] SecondTestEntityTwoRelationshipsOneToOneCreateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToOneCommand(secondTestEntityTwoRelationshipsOneToOne, _cultureCode));

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> Put([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToOneUpdateDto secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToOneCommand(key, secondTestEntityTwoRelationshipsOneToOne, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<SecondTestEntityTwoRelationshipsOneToOneDto> secondTestEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in secondTestEntityTwoRelationshipsOneToOne.GetChangedPropertyNames())
        {
            if (secondTestEntityTwoRelationshipsOneToOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateSecondTestEntityTwoRelationshipsOneToOneCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToOneByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}