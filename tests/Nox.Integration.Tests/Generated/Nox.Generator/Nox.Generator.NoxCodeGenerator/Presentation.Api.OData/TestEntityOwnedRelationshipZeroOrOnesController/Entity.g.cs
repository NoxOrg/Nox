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

public abstract partial class TestEntityOwnedRelationshipZeroOrOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    public TestEntityOwnedRelationshipZeroOrOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOwnedRelationshipZeroOrOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<TestEntityOwnedRelationshipZeroOrOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityOwnedRelationshipZeroOrOneDto>> Post([FromBody] TestEntityOwnedRelationshipZeroOrOneCreateDto testEntityOwnedRelationshipZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityOwnedRelationshipZeroOrOneCommand(testEntityOwnedRelationshipZeroOrOne));

        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityOwnedRelationshipZeroOrOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityOwnedRelationshipZeroOrOneUpdateDto testEntityOwnedRelationshipZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityOwnedRelationshipZeroOrOneCommand(key, testEntityOwnedRelationshipZeroOrOne, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityOwnedRelationshipZeroOrOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityOwnedRelationshipZeroOrOneDto> testEntityOwnedRelationshipZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in testEntityOwnedRelationshipZeroOrOne.GetChangedPropertyNames())
        {
            if (testEntityOwnedRelationshipZeroOrOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityOwnedRelationshipZeroOrOneCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityOwnedRelationshipZeroOrOneByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class TestEntityOwnedRelationshipZeroOrOnesController : TestEntityOwnedRelationshipZeroOrOnesControllerBase
{
    public TestEntityOwnedRelationshipZeroOrOnesController(IMediator mediator)
        : base(mediator)
    {}
}