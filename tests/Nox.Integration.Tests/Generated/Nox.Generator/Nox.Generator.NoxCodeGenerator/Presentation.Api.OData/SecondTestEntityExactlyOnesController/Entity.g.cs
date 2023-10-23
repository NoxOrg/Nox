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

using System;
using System.Net.Http.Headers;
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class SecondTestEntityExactlyOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    public SecondTestEntityExactlyOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityExactlyOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetSecondTestEntityExactlyOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<SecondTestEntityExactlyOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<SecondTestEntityExactlyOneDto>> Post([FromBody] SecondTestEntityExactlyOneCreateDto secondTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateSecondTestEntityExactlyOneCommand(secondTestEntityExactlyOne));

        var item = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityExactlyOneDto>> Put([FromRoute] System.String key, [FromBody] SecondTestEntityExactlyOneUpdateDto secondTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityExactlyOneCommand(key, secondTestEntityExactlyOne, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityExactlyOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<SecondTestEntityExactlyOneDto> secondTestEntityExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in secondTestEntityExactlyOne.GetChangedPropertyNames())
        {
            if (secondTestEntityExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateSecondTestEntityExactlyOneCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityExactlyOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteSecondTestEntityExactlyOneByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class SecondTestEntityExactlyOnesController : SecondTestEntityExactlyOnesControllerBase
{
    public SecondTestEntityExactlyOnesController(IMediator mediator)
        : base(mediator)
    {}
}