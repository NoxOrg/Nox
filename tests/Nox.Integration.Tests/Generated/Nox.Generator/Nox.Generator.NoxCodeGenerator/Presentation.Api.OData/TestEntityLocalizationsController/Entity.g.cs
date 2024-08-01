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

public partial class TestEntityLocalizationsController : TestEntityLocalizationsControllerBase
{
    public TestEntityLocalizationsController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityLocalizationsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityLocalizationsControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityLocalizationDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityLocalizationsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityLocalizationDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityLocalizationByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityLocalizationDto>> Post([FromBody] TestEntityLocalizationCreateDto testEntityLocalization)
    {
        if(testEntityLocalization is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityLocalizationCommand(testEntityLocalization, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityLocalizationByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityLocalizationDto>> Put([FromRoute] System.String key, [FromBody] TestEntityLocalizationUpdateDto testEntityLocalization)
    {
        if(testEntityLocalization is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityLocalizationCommand(key, testEntityLocalization, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityLocalizationByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityLocalizationDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityLocalizationPartialUpdateDto> testEntityLocalization)
    {
        if(testEntityLocalization is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityLocalizationPartialUpdateDto>(testEntityLocalization);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityLocalizationCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityLocalizationByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityLocalizationByIdCommand(new List<TestEntityLocalizationKeyDto> { new TestEntityLocalizationKeyDto(key) }, etag));

        return NoContent();
    }
}