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

public partial class TestEntityForAutoNumberUsagesController : TestEntityForAutoNumberUsagesControllerBase
{
    public TestEntityForAutoNumberUsagesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityForAutoNumberUsagesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityForAutoNumberUsagesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityForAutoNumberUsagesDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityForAutoNumberUsagesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityForAutoNumberUsagesDto>> Get([FromRoute] System.Int64 key)
    {
        var result = await _mediator.Send(new GetTestEntityForAutoNumberUsagesByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityForAutoNumberUsagesDto>> Post([FromBody] TestEntityForAutoNumberUsagesCreateDto testEntityForAutoNumberUsages)
    {
        if(testEntityForAutoNumberUsages is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityForAutoNumberUsagesCommand(testEntityForAutoNumberUsages, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityForAutoNumberUsagesByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityForAutoNumberUsagesDto>> Put([FromRoute] System.Int64 key, [FromBody] TestEntityForAutoNumberUsagesUpdateDto testEntityForAutoNumberUsages)
    {
        if(testEntityForAutoNumberUsages is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityForAutoNumberUsagesCommand(key, testEntityForAutoNumberUsages, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityForAutoNumberUsagesByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityForAutoNumberUsagesDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<TestEntityForAutoNumberUsagesPartialUpdateDto> testEntityForAutoNumberUsages)
    {
        if(testEntityForAutoNumberUsages is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in testEntityForAutoNumberUsages.GetChangedPropertyNames())
        {
            if (testEntityForAutoNumberUsages.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityForAutoNumberUsagesCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetTestEntityForAutoNumberUsagesByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityForAutoNumberUsagesByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}