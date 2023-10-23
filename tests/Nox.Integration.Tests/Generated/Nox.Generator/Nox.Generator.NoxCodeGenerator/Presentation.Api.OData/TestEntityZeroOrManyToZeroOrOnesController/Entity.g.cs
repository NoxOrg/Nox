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

public abstract partial class TestEntityZeroOrManyToZeroOrOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    public TestEntityZeroOrManyToZeroOrOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrManyToZeroOrOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<TestEntityZeroOrManyToZeroOrOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrManyToZeroOrOneDto>> Post([FromBody] TestEntityZeroOrManyToZeroOrOneCreateDto testEntityZeroOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyToZeroOrOneCommand(testEntityZeroOrManyToZeroOrOne));

        var item = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrManyToZeroOrOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyToZeroOrOneUpdateDto testEntityZeroOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityZeroOrManyToZeroOrOneCommand(key, testEntityZeroOrManyToZeroOrOne, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrManyToZeroOrOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityZeroOrManyToZeroOrOneDto> testEntityZeroOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in testEntityZeroOrManyToZeroOrOne.GetChangedPropertyNames())
        {
            if (testEntityZeroOrManyToZeroOrOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityZeroOrManyToZeroOrOneCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityZeroOrManyToZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityZeroOrManyToZeroOrOneByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class TestEntityZeroOrManyToZeroOrOnesController : TestEntityZeroOrManyToZeroOrOnesControllerBase
{
    public TestEntityZeroOrManyToZeroOrOnesController(IMediator mediator)
        : base(mediator)
    {}
}