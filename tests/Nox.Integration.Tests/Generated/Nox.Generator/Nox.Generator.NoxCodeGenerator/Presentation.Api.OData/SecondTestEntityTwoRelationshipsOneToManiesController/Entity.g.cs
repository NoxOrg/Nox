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

public abstract partial class SecondTestEntityTwoRelationshipsOneToManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    public SecondTestEntityTwoRelationshipsOneToManiesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> Post([FromBody] SecondTestEntityTwoRelationshipsOneToManyCreateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToManyCommand(secondTestEntityTwoRelationshipsOneToMany));

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> Put([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToManyUpdateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToManyCommand(key, secondTestEntityTwoRelationshipsOneToMany, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<SecondTestEntityTwoRelationshipsOneToManyDto> secondTestEntityTwoRelationshipsOneToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in secondTestEntityTwoRelationshipsOneToMany.GetChangedPropertyNames())
        {
            if (secondTestEntityTwoRelationshipsOneToMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class SecondTestEntityTwoRelationshipsOneToManiesController : SecondTestEntityTwoRelationshipsOneToManiesControllerBase
{
    public SecondTestEntityTwoRelationshipsOneToManiesController(IMediator mediator)
        : base(mediator)
    {}
}