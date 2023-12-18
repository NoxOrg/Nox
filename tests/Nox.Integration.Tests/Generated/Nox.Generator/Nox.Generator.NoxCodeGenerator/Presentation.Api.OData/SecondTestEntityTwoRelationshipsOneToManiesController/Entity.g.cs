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

public partial class SecondTestEntityTwoRelationshipsOneToManiesController : SecondTestEntityTwoRelationshipsOneToManiesControllerBase
{
    public SecondTestEntityTwoRelationshipsOneToManiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class SecondTestEntityTwoRelationshipsOneToManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public SecondTestEntityTwoRelationshipsOneToManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityTwoRelationshipsOneToManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<SecondTestEntityTwoRelationshipsOneToManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> Post([FromBody] SecondTestEntityTwoRelationshipsOneToManyCreateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if(secondTestEntityTwoRelationshipsOneToMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsOneToManyCommand(secondTestEntityTwoRelationshipsOneToMany, _cultureCode));

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> Put([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsOneToManyUpdateDto secondTestEntityTwoRelationshipsOneToMany)
    {
        if(secondTestEntityTwoRelationshipsOneToMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsOneToManyCommand(key, secondTestEntityTwoRelationshipsOneToMany, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsOneToManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<SecondTestEntityTwoRelationshipsOneToManyPartialUpdateDto> secondTestEntityTwoRelationshipsOneToMany)
    {
        if(secondTestEntityTwoRelationshipsOneToMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<SecondTestEntityTwoRelationshipsOneToManyPartialUpdateDto>(secondTestEntityTwoRelationshipsOneToMany);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateSecondTestEntityTwoRelationshipsOneToManyCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsOneToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsOneToManyByIdCommand(new List<SecondTestEntityTwoRelationshipsOneToManyKeyDto> { new SecondTestEntityTwoRelationshipsOneToManyKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("SecondTestEntityTwoRelationshipsOneToMany", $"{key.ToString()}");
        }

        return NoContent();
    }
}