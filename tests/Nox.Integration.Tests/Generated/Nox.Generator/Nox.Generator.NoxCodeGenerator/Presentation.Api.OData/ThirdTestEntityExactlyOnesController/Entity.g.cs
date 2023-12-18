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

public partial class ThirdTestEntityExactlyOnesController : ThirdTestEntityExactlyOnesControllerBase
{
    public ThirdTestEntityExactlyOnesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class ThirdTestEntityExactlyOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public ThirdTestEntityExactlyOnesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ThirdTestEntityExactlyOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetThirdTestEntityExactlyOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<ThirdTestEntityExactlyOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<ThirdTestEntityExactlyOneDto>> Post([FromBody] ThirdTestEntityExactlyOneCreateDto thirdTestEntityExactlyOne)
    {
        if(thirdTestEntityExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateThirdTestEntityExactlyOneCommand(thirdTestEntityExactlyOne, _cultureCode));

        var item = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<ThirdTestEntityExactlyOneDto>> Put([FromRoute] System.String key, [FromBody] ThirdTestEntityExactlyOneUpdateDto thirdTestEntityExactlyOne)
    {
        if(thirdTestEntityExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateThirdTestEntityExactlyOneCommand(key, thirdTestEntityExactlyOne, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<ThirdTestEntityExactlyOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<ThirdTestEntityExactlyOnePartialUpdateDto> thirdTestEntityExactlyOne)
    {
        if(thirdTestEntityExactlyOne is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<ThirdTestEntityExactlyOnePartialUpdateDto>(thirdTestEntityExactlyOne);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateThirdTestEntityExactlyOneCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteThirdTestEntityExactlyOneByIdCommand(new List<ThirdTestEntityExactlyOneKeyDto> { new ThirdTestEntityExactlyOneKeyDto(key) }, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}