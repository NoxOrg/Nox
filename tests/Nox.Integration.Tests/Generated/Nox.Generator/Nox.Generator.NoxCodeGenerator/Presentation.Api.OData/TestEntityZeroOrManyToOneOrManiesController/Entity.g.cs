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

public partial class TestEntityZeroOrManyToOneOrManiesController : TestEntityZeroOrManyToOneOrManiesControllerBase
{
    public TestEntityZeroOrManyToOneOrManiesController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityZeroOrManyToOneOrManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityZeroOrManyToOneOrManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrManyToOneOrManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityZeroOrManyToOneOrManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrManyToOneOrManyDto>> Post([FromBody] TestEntityZeroOrManyToOneOrManyCreateDto testEntityZeroOrManyToOneOrMany)
    {
        if(testEntityZeroOrManyToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyToOneOrManyCommand(testEntityZeroOrManyToOneOrMany, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrManyToOneOrManyDto>> Put([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyToOneOrManyUpdateDto testEntityZeroOrManyToOneOrMany)
    {
        if(testEntityZeroOrManyToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityZeroOrManyToOneOrManyCommand(key, testEntityZeroOrManyToOneOrMany, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrManyToOneOrManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityZeroOrManyToOneOrManyPartialUpdateDto> testEntityZeroOrManyToOneOrMany)
    {
        if(testEntityZeroOrManyToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityZeroOrManyToOneOrManyPartialUpdateDto>(testEntityZeroOrManyToOneOrMany);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityZeroOrManyToOneOrManyCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTestEntityZeroOrManyToOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityZeroOrManyToOneOrManyByIdCommand(new List<TestEntityZeroOrManyToOneOrManyKeyDto> { new TestEntityZeroOrManyToOneOrManyKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("TestEntityZeroOrManyToOneOrMany", $"{key.ToString()}");
        }

        return NoContent();
    }
}