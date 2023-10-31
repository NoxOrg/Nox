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

using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public partial class TestEntityOneOrManyToZeroOrOnesController : TestEntityOneOrManyToZeroOrOnesControllerBase
{
    public TestEntityOneOrManyToZeroOrOnesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityOneOrManyToZeroOrOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityOneOrManyToZeroOrOnesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = Nox.Types.CultureCode.From(httpLanguageProvider.GetLanguage());
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOneOrManyToZeroOrOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<TestEntityOneOrManyToZeroOrOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrOneDto>> Post([FromBody] TestEntityOneOrManyToZeroOrOneCreateDto testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyToZeroOrOneCommand(testEntityOneOrManyToZeroOrOne, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityOneOrManyToZeroOrOneUpdateDto testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityOneOrManyToZeroOrOneCommand(key, testEntityOneOrManyToZeroOrOne, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityOneOrManyToZeroOrOneDto> testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in testEntityOneOrManyToZeroOrOne.GetChangedPropertyNames())
        {
            if (testEntityOneOrManyToZeroOrOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityOneOrManyToZeroOrOneCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityOneOrManyToZeroOrOneByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}