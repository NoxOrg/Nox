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

public abstract partial class TestEntityTwoRelationshipsManyToManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    public TestEntityTwoRelationshipsManyToManiesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<TestEntityTwoRelationshipsManyToManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> Post([FromBody] TestEntityTwoRelationshipsManyToManyCreateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsManyToManyCommand(testEntityTwoRelationshipsManyToMany));

        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> Put([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsManyToManyUpdateDto testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityTwoRelationshipsManyToManyCommand(key, testEntityTwoRelationshipsManyToMany, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityTwoRelationshipsManyToManyDto> testEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in testEntityTwoRelationshipsManyToMany.GetChangedPropertyNames())
        {
            if (testEntityTwoRelationshipsManyToMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsManyToManyCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class TestEntityTwoRelationshipsManyToManiesController : TestEntityTwoRelationshipsManyToManiesControllerBase
{
    public TestEntityTwoRelationshipsManyToManiesController(IMediator mediator)
        : base(mediator)
    {}
}