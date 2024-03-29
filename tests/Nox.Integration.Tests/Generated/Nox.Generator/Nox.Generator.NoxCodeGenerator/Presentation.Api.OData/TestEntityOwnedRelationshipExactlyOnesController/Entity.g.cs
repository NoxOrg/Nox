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
using Nox.Exceptions;

using System;
using System.Net.Http.Headers;
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Presentation.Api.OData;

public partial class TestEntityOwnedRelationshipExactlyOnesController : TestEntityOwnedRelationshipExactlyOnesControllerBase
{
    public TestEntityOwnedRelationshipExactlyOnesController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityOwnedRelationshipExactlyOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityOwnedRelationshipExactlyOnesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityOwnedRelationshipExactlyOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityOwnedRelationshipExactlyOneDto>> Post([FromBody] TestEntityOwnedRelationshipExactlyOneCreateDto testEntityOwnedRelationshipExactlyOne)
    {
        if(testEntityOwnedRelationshipExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityOwnedRelationshipExactlyOneCommand(testEntityOwnedRelationshipExactlyOne, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityOwnedRelationshipExactlyOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityOwnedRelationshipExactlyOneUpdateDto testEntityOwnedRelationshipExactlyOne)
    {
        if(testEntityOwnedRelationshipExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityOwnedRelationshipExactlyOneCommand(key, testEntityOwnedRelationshipExactlyOne, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityOwnedRelationshipExactlyOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityOwnedRelationshipExactlyOnePartialUpdateDto> testEntityOwnedRelationshipExactlyOne)
    {
        if(testEntityOwnedRelationshipExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityOwnedRelationshipExactlyOnePartialUpdateDto>(testEntityOwnedRelationshipExactlyOne);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityOwnedRelationshipExactlyOneCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand(new List<TestEntityOwnedRelationshipExactlyOneKeyDto> { new TestEntityOwnedRelationshipExactlyOneKeyDto(key) }, etag));

        return NoContent();
    }
}