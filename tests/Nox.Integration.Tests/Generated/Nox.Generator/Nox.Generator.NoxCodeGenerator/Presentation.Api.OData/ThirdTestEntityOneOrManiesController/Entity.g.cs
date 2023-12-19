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

public partial class ThirdTestEntityOneOrManiesController : ThirdTestEntityOneOrManiesControllerBase
{
    public ThirdTestEntityOneOrManiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class ThirdTestEntityOneOrManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public ThirdTestEntityOneOrManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ThirdTestEntityOneOrManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetThirdTestEntityOneOrManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<ThirdTestEntityOneOrManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<ThirdTestEntityOneOrManyDto>> Post([FromBody] ThirdTestEntityOneOrManyCreateDto thirdTestEntityOneOrMany)
    {
        if(thirdTestEntityOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateThirdTestEntityOneOrManyCommand(thirdTestEntityOneOrMany, _cultureCode));

        var item = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<ThirdTestEntityOneOrManyDto>> Put([FromRoute] System.String key, [FromBody] ThirdTestEntityOneOrManyUpdateDto thirdTestEntityOneOrMany)
    {
        if(thirdTestEntityOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateThirdTestEntityOneOrManyCommand(key, thirdTestEntityOneOrMany, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("ThirdTestEntityOneOrMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<ThirdTestEntityOneOrManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<ThirdTestEntityOneOrManyPartialUpdateDto> thirdTestEntityOneOrMany)
    {
        if(thirdTestEntityOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<ThirdTestEntityOneOrManyPartialUpdateDto>(thirdTestEntityOneOrMany);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateThirdTestEntityOneOrManyCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("ThirdTestEntityOneOrMany", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteThirdTestEntityOneOrManyByIdCommand(new List<ThirdTestEntityOneOrManyKeyDto> { new ThirdTestEntityOneOrManyKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("ThirdTestEntityOneOrMany", $"{key.ToString()}");
        }

        return NoContent();
    }
}