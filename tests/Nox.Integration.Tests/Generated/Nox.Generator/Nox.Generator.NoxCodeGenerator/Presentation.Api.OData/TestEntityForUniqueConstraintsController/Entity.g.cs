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

using System;
using System.Net.Http.Headers;
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Presentation.Api.OData;

public partial class TestEntityForUniqueConstraintsController : TestEntityForUniqueConstraintsControllerBase
{
    public TestEntityForUniqueConstraintsController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityForUniqueConstraintsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityForUniqueConstraintsControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityForUniqueConstraintsDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityForUniqueConstraintsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityForUniqueConstraintsDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityForUniqueConstraintsByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityForUniqueConstraintsDto>> Post([FromBody] TestEntityForUniqueConstraintsCreateDto testEntityForUniqueConstraints)
    {
        if(testEntityForUniqueConstraints is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityForUniqueConstraintsCommand(testEntityForUniqueConstraints, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityForUniqueConstraintsByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityForUniqueConstraintsDto>> Put([FromRoute] System.String key, [FromBody] TestEntityForUniqueConstraintsUpdateDto testEntityForUniqueConstraints)
    {
        if(testEntityForUniqueConstraints is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityForUniqueConstraintsCommand(key, testEntityForUniqueConstraints, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityForUniqueConstraintsByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityForUniqueConstraintsDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityForUniqueConstraintsPartialUpdateDto> testEntityForUniqueConstraints)
    {
        if(testEntityForUniqueConstraints is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityForUniqueConstraintsPartialUpdateDto>(testEntityForUniqueConstraints);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityForUniqueConstraintsCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityForUniqueConstraintsByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityForUniqueConstraintsByIdCommand(new List<TestEntityForUniqueConstraintsKeyDto> { new TestEntityForUniqueConstraintsKeyDto(key) }, etag));

        return NoContent();
    }
}