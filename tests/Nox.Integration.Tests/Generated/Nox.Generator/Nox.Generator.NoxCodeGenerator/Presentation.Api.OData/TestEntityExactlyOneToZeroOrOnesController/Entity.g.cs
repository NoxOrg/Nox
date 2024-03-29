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

public partial class TestEntityExactlyOneToZeroOrOnesController : TestEntityExactlyOneToZeroOrOnesControllerBase
{
    public TestEntityExactlyOneToZeroOrOnesController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityExactlyOneToZeroOrOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityExactlyOneToZeroOrOnesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityExactlyOneToZeroOrOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityExactlyOneToZeroOrOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityExactlyOneToZeroOrOneDto>> Post([FromBody] TestEntityExactlyOneToZeroOrOneCreateDto testEntityExactlyOneToZeroOrOne)
    {
        if(testEntityExactlyOneToZeroOrOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneToZeroOrOneCommand(testEntityExactlyOneToZeroOrOne, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityExactlyOneToZeroOrOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityExactlyOneToZeroOrOneUpdateDto testEntityExactlyOneToZeroOrOne)
    {
        if(testEntityExactlyOneToZeroOrOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityExactlyOneToZeroOrOneCommand(key, testEntityExactlyOneToZeroOrOne, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityExactlyOneToZeroOrOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityExactlyOneToZeroOrOnePartialUpdateDto> testEntityExactlyOneToZeroOrOne)
    {
        if(testEntityExactlyOneToZeroOrOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityExactlyOneToZeroOrOnePartialUpdateDto>(testEntityExactlyOneToZeroOrOne);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityExactlyOneToZeroOrOneCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityExactlyOneToZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityExactlyOneToZeroOrOneByIdCommand(new List<TestEntityExactlyOneToZeroOrOneKeyDto> { new TestEntityExactlyOneToZeroOrOneKeyDto(key) }, etag));

        return NoContent();
    }
}