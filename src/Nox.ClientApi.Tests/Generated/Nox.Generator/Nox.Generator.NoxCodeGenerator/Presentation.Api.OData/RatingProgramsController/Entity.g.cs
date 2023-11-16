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
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Presentation.Api.OData;

public partial class RatingProgramsController : RatingProgramsControllerBase
{
    public RatingProgramsController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class RatingProgramsControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public RatingProgramsControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<RatingProgramDto>>> Get()
    {
        var result = await _mediator.Send(new GetRatingProgramsQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<RatingProgramDto>> Get([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId)
    {
        var result = await _mediator.Send(new GetRatingProgramByIdQuery(keyStoreId, keyId));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<RatingProgramDto>> Post([FromBody] RatingProgramCreateDto ratingProgram)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateRatingProgramCommand(ratingProgram, _cultureCode));

        var item = (await _mediator.Send(new GetRatingProgramByIdQuery(createdKey.keyStoreId, createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<RatingProgramDto>> Put([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId, [FromBody] RatingProgramUpdateDto ratingProgram)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateRatingProgramCommand(keyStoreId, keyId, ratingProgram, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetRatingProgramByIdQuery(updatedKey.keyStoreId, updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<RatingProgramDto>> Patch([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId, [FromBody] Delta<RatingProgramUpdateDto> ratingProgram)
    {
        if (!ModelState.IsValid || ratingProgram is null)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in ratingProgram.GetChangedPropertyNames())
        {
            if (ratingProgram.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateRatingProgramCommand(keyStoreId, keyId, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetRatingProgramByIdQuery(updatedKey.keyStoreId, updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteRatingProgramByIdCommand(keyStoreId, keyId, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}