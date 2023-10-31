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

public partial class TestEntityZeroOrManyToExactlyOnesController : TestEntityZeroOrManyToExactlyOnesControllerBase
{
    public TestEntityZeroOrManyToExactlyOnesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityZeroOrManyToExactlyOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityZeroOrManyToExactlyOnesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = Nox.Types.CultureCode.From(httpLanguageProvider.GetLanguage());
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrManyToExactlyOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<TestEntityZeroOrManyToExactlyOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrManyToExactlyOneDto>> Post([FromBody] TestEntityZeroOrManyToExactlyOneCreateDto testEntityZeroOrManyToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrManyToExactlyOneCommand(testEntityZeroOrManyToExactlyOne, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrManyToExactlyOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityZeroOrManyToExactlyOneUpdateDto testEntityZeroOrManyToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityZeroOrManyToExactlyOneCommand(key, testEntityZeroOrManyToExactlyOne, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityZeroOrManyToExactlyOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityZeroOrManyToExactlyOneDto> testEntityZeroOrManyToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in testEntityZeroOrManyToExactlyOne.GetChangedPropertyNames())
        {
            if (testEntityZeroOrManyToExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityZeroOrManyToExactlyOneCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityZeroOrManyToExactlyOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityZeroOrManyToExactlyOneByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}