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

public partial class TestEntityTwoRelationshipsManyToManiesController : TestEntityTwoRelationshipsManyToManiesControllerBase
{
    public TestEntityTwoRelationshipsManyToManiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class TestEntityTwoRelationshipsManyToManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public TestEntityTwoRelationshipsManyToManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityTwoRelationshipsManyToManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<TestEntityTwoRelationshipsManyToManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> Post([FromBody] TestEntityTwoRelationshipsManyToManyCreateDto testEntityTwoRelationshipsManyToMany)
    {
        if(testEntityTwoRelationshipsManyToMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsManyToManyCommand(testEntityTwoRelationshipsManyToMany, _cultureCode));

        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> Put([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsManyToManyUpdateDto testEntityTwoRelationshipsManyToMany)
    {
        if(testEntityTwoRelationshipsManyToMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateTestEntityTwoRelationshipsManyToManyCommand(key, testEntityTwoRelationshipsManyToMany, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<TestEntityTwoRelationshipsManyToManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityTwoRelationshipsManyToManyPartialUpdateDto> testEntityTwoRelationshipsManyToMany)
    {
        if(testEntityTwoRelationshipsManyToMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<TestEntityTwoRelationshipsManyToManyPartialUpdateDto>(testEntityTwoRelationshipsManyToMany);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsManyToManyCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsManyToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityTwoRelationshipsManyToManyByIdCommand(new List<TestEntityTwoRelationshipsManyToManyKeyDto> { new TestEntityTwoRelationshipsManyToManyKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("TestEntityTwoRelationshipsManyToMany", $"{key.ToString()}");
        }

        return NoContent();
    }
}