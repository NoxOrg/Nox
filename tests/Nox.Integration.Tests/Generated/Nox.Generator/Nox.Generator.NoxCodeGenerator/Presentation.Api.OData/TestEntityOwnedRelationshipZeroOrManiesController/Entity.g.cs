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

public partial class TestEntityOwnedRelationshipZeroOrManiesController : TestEntityOwnedRelationshipZeroOrManiesControllerBase
{
    public TestEntityOwnedRelationshipZeroOrManiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityOwnedRelationshipZeroOrManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityOwnedRelationshipZeroOrManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOwnedRelationshipZeroOrManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<TestEntityOwnedRelationshipZeroOrManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityOwnedRelationshipZeroOrManyDto>> Post([FromBody] TestEntityOwnedRelationshipZeroOrManyCreateDto testEntityOwnedRelationshipZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityOwnedRelationshipZeroOrManyCommand(testEntityOwnedRelationshipZeroOrMany, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityOwnedRelationshipZeroOrManyDto>> Put([FromRoute] System.String key, [FromBody] TestEntityOwnedRelationshipZeroOrManyUpdateDto testEntityOwnedRelationshipZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityOwnedRelationshipZeroOrManyCommand(key, testEntityOwnedRelationshipZeroOrMany, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityOwnedRelationshipZeroOrManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityOwnedRelationshipZeroOrManyUpdateDto> testEntityOwnedRelationshipZeroOrMany)
    {
        if (!ModelState.IsValid || testEntityOwnedRelationshipZeroOrMany is null)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in testEntityOwnedRelationshipZeroOrMany.GetChangedPropertyNames())
        {
            if (testEntityOwnedRelationshipZeroOrMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityOwnedRelationshipZeroOrManyCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipZeroOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityOwnedRelationshipZeroOrManyByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}