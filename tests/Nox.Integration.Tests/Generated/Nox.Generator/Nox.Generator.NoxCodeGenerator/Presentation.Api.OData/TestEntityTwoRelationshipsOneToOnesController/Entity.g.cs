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

public partial class TestEntityTwoRelationshipsOneToOnesController : TestEntityTwoRelationshipsOneToOnesControllerBase
{
    public TestEntityTwoRelationshipsOneToOnesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityTwoRelationshipsOneToOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityTwoRelationshipsOneToOnesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityTwoRelationshipsOneToOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsOneToOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> Post([FromBody] TestEntityTwoRelationshipsOneToOneCreateDto testEntityTwoRelationshipsOneToOne)
    {
        if(testEntityTwoRelationshipsOneToOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsOneToOneCommand(testEntityTwoRelationshipsOneToOne, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsOneToOneUpdateDto testEntityTwoRelationshipsOneToOne)
    {
        if(testEntityTwoRelationshipsOneToOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityTwoRelationshipsOneToOneCommand(key, testEntityTwoRelationshipsOneToOne, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityTwoRelationshipsOneToOnePartialUpdateDto> testEntityTwoRelationshipsOneToOne)
    {
        if(testEntityTwoRelationshipsOneToOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityTwoRelationshipsOneToOnePartialUpdateDto>(testEntityTwoRelationshipsOneToOne);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsOneToOneCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityTwoRelationshipsOneToOneByIdCommand(new List<TestEntityTwoRelationshipsOneToOneKeyDto> { new TestEntityTwoRelationshipsOneToOneKeyDto(key) }, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}