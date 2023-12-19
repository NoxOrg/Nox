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

public partial class TestEntityExactlyOneToOneOrManiesController : TestEntityExactlyOneToOneOrManiesControllerBase
{
    public TestEntityExactlyOneToOneOrManiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityExactlyOneToOneOrManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityExactlyOneToOneOrManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityExactlyOneToOneOrManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityExactlyOneToOneOrManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityExactlyOneToOneOrManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityExactlyOneToOneOrManyDto>> Post([FromBody] TestEntityExactlyOneToOneOrManyCreateDto testEntityExactlyOneToOneOrMany)
    {
        if(testEntityExactlyOneToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityExactlyOneToOneOrManyCommand(testEntityExactlyOneToOneOrMany, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityExactlyOneToOneOrManyDto>> Put([FromRoute] System.String key, [FromBody] TestEntityExactlyOneToOneOrManyUpdateDto testEntityExactlyOneToOneOrMany)
    {
        if(testEntityExactlyOneToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityExactlyOneToOneOrManyCommand(key, testEntityExactlyOneToOneOrMany, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("TestEntityExactlyOneToOneOrMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityExactlyOneToOneOrManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityExactlyOneToOneOrManyPartialUpdateDto> testEntityExactlyOneToOneOrMany)
    {
        if(testEntityExactlyOneToOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityExactlyOneToOneOrManyPartialUpdateDto>(testEntityExactlyOneToOneOrMany);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityExactlyOneToOneOrManyCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("TestEntityExactlyOneToOneOrMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTestEntityExactlyOneToOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityExactlyOneToOneOrManyByIdCommand(new List<TestEntityExactlyOneToOneOrManyKeyDto> { new TestEntityExactlyOneToOneOrManyKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("TestEntityExactlyOneToOneOrMany", $"{key.ToString()}");
        }

        return NoContent();
    }
}