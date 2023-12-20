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

public partial class TestEntityZeroOrOneToOneOrManiesController : TestEntityZeroOrOneToOneOrManiesControllerBase
{
    public TestEntityZeroOrOneToOneOrManiesController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityZeroOrOneToOneOrManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityZeroOrOneToOneOrManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrOneToOneOrManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityZeroOrOneToOneOrManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrOneToOneOrManyDto>> Post([FromBody] TestEntityZeroOrOneToOneOrManyCreateDto testEntityZeroOrOneToOneOrMany)
    {
        if(testEntityZeroOrOneToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrOneToOneOrManyCommand(testEntityZeroOrOneToOneOrMany, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrOneToOneOrManyDto>> Put([FromRoute] System.String key, [FromBody] TestEntityZeroOrOneToOneOrManyUpdateDto testEntityZeroOrOneToOneOrMany)
    {
        if(testEntityZeroOrOneToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityZeroOrOneToOneOrManyCommand(key, testEntityZeroOrOneToOneOrMany, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrOneToOneOrManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityZeroOrOneToOneOrManyPartialUpdateDto> testEntityZeroOrOneToOneOrMany)
    {
        if(testEntityZeroOrOneToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityZeroOrOneToOneOrManyPartialUpdateDto>(testEntityZeroOrOneToOneOrMany);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityZeroOrOneToOneOrManyCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTestEntityZeroOrOneToOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityZeroOrOneToOneOrManyByIdCommand(new List<TestEntityZeroOrOneToOneOrManyKeyDto> { new TestEntityZeroOrOneToOneOrManyKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("TestEntityZeroOrOneToOneOrMany", $"{key.ToString()}");
        }

        return NoContent();
    }
}