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

public partial class TestEntityOneOrManiesController : TestEntityOneOrManiesControllerBase
{
    public TestEntityOneOrManiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityOneOrManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityOneOrManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOneOrManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityOneOrManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityOneOrManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityOneOrManyDto>> Post([FromBody] TestEntityOneOrManyCreateDto testEntityOneOrMany)
    {
        if(testEntityOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyCommand(testEntityOneOrMany, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityOneOrManyDto>> Put([FromRoute] System.String key, [FromBody] TestEntityOneOrManyUpdateDto testEntityOneOrMany)
    {
        if(testEntityOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityOneOrManyCommand(key, testEntityOneOrMany, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityOneOrManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityOneOrManyPartialUpdateDto> testEntityOneOrMany)
    {
        if(testEntityOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityOneOrManyPartialUpdateDto>(testEntityOneOrMany);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityOneOrManyCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityOneOrManyByIdCommand(new List<TestEntityOneOrManyKeyDto> { new TestEntityOneOrManyKeyDto(key) }, etag));

        return NoContent();
    }
}