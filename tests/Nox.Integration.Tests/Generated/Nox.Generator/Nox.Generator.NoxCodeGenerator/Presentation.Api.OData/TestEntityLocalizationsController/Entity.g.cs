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

public partial class TestEntityLocalizationsController : TestEntityLocalizationsControllerBase
{
    public TestEntityLocalizationsController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityLocalizationsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    protected readonly Nox.Presentation.Api.IHttpLanguageProvider _httpLanguageProvider;

    public TestEntityLocalizationsControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _httpLanguageProvider = httpLanguageProvider;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityLocalizationDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityLocalizationsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<TestEntityLocalizationDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityLocalizationByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityLocalizationDto>> Post([FromBody] TestEntityLocalizationCreateDto testEntityLocalization)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityLocalizationCommand(testEntityLocalization));

        var item = (await _mediator.Send(new GetTestEntityLocalizationByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityLocalizationDto>> Put([FromRoute] System.String key, [FromBody] TestEntityLocalizationUpdateDto testEntityLocalization)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityLocalizationCommand(key, testEntityLocalization, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityLocalizationByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityLocalizationDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityLocalizationDto> testEntityLocalization)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in testEntityLocalization.GetChangedPropertyNames())
        {
            if (testEntityLocalization.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityLocalizationCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityLocalizationByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityLocalizationByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}