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

public abstract partial class ThirdTestEntityZeroOrOnesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    public ThirdTestEntityZeroOrOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ThirdTestEntityZeroOrOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetThirdTestEntityZeroOrOnesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<ThirdTestEntityZeroOrOneDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<ThirdTestEntityZeroOrOneDto>> Post([FromBody] ThirdTestEntityZeroOrOneCreateDto thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateThirdTestEntityZeroOrOneCommand(thirdTestEntityZeroOrOne));

        var item = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<ThirdTestEntityZeroOrOneDto>> Put([FromRoute] System.String key, [FromBody] ThirdTestEntityZeroOrOneUpdateDto thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateThirdTestEntityZeroOrOneCommand(key, thirdTestEntityZeroOrOne, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<ThirdTestEntityZeroOrOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<ThirdTestEntityZeroOrOneDto> thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in thirdTestEntityZeroOrOne.GetChangedPropertyNames())
        {
            if (thirdTestEntityZeroOrOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateThirdTestEntityZeroOrOneCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteThirdTestEntityZeroOrOneByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class ThirdTestEntityZeroOrOnesController : ThirdTestEntityZeroOrOnesControllerBase
{
    public ThirdTestEntityZeroOrOnesController(IMediator mediator)
        : base(mediator)
    {}
}