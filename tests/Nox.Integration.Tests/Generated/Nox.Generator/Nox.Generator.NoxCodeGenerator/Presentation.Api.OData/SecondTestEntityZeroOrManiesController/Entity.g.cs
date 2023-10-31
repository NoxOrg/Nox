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

public partial class SecondTestEntityZeroOrManiesController : SecondTestEntityZeroOrManiesControllerBase
{
    public SecondTestEntityZeroOrManiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class SecondTestEntityZeroOrManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public SecondTestEntityZeroOrManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = Nox.Types.CultureCode.From(httpLanguageProvider.GetLanguage());
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityZeroOrManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetSecondTestEntityZeroOrManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<SecondTestEntityZeroOrManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<SecondTestEntityZeroOrManyDto>> Post([FromBody] SecondTestEntityZeroOrManyCreateDto secondTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateSecondTestEntityZeroOrManyCommand(secondTestEntityZeroOrMany, _cultureCode));

        var item = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityZeroOrManyDto>> Put([FromRoute] System.String key, [FromBody] SecondTestEntityZeroOrManyUpdateDto secondTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityZeroOrManyCommand(key, secondTestEntityZeroOrMany, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityZeroOrManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<SecondTestEntityZeroOrManyDto> secondTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in secondTestEntityZeroOrMany.GetChangedPropertyNames())
        {
            if (secondTestEntityZeroOrMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateSecondTestEntityZeroOrManyCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityZeroOrManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteSecondTestEntityZeroOrManyByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}