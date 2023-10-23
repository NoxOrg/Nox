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

public abstract partial class TestEntityForUniqueConstraintsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    public TestEntityForUniqueConstraintsControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityForUniqueConstraintsDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityForUniqueConstraintsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<TestEntityForUniqueConstraintsDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityForUniqueConstraintsByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityForUniqueConstraintsDto>> Post([FromBody] TestEntityForUniqueConstraintsCreateDto testEntityForUniqueConstraints)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityForUniqueConstraintsCommand(testEntityForUniqueConstraints));

        var item = (await _mediator.Send(new GetTestEntityForUniqueConstraintsByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityForUniqueConstraintsDto>> Put([FromRoute] System.String key, [FromBody] TestEntityForUniqueConstraintsUpdateDto testEntityForUniqueConstraints)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityForUniqueConstraintsCommand(key, testEntityForUniqueConstraints, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityForUniqueConstraintsByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityForUniqueConstraintsDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityForUniqueConstraintsDto> testEntityForUniqueConstraints)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in testEntityForUniqueConstraints.GetChangedPropertyNames())
        {
            if (testEntityForUniqueConstraints.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityForUniqueConstraintsCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityForUniqueConstraintsByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityForUniqueConstraintsByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class TestEntityForUniqueConstraintsController : TestEntityForUniqueConstraintsControllerBase
{
    public TestEntityForUniqueConstraintsController(IMediator mediator)
        : base(mediator)
    {}
}