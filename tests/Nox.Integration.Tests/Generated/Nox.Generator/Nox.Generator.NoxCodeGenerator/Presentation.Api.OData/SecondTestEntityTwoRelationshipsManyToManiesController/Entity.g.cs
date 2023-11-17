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

public partial class SecondTestEntityTwoRelationshipsManyToManiesController : SecondTestEntityTwoRelationshipsManyToManiesControllerBase
{
    public SecondTestEntityTwoRelationshipsManyToManiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class SecondTestEntityTwoRelationshipsManyToManiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public SecondTestEntityTwoRelationshipsManyToManiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityTwoRelationshipsManyToManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<SecondTestEntityTwoRelationshipsManyToManyDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsManyToManyDto>> Post([FromBody] SecondTestEntityTwoRelationshipsManyToManyCreateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateSecondTestEntityTwoRelationshipsManyToManyCommand(secondTestEntityTwoRelationshipsManyToMany, _cultureCode));

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsManyToManyDto>> Put([FromRoute] System.String key, [FromBody] SecondTestEntityTwoRelationshipsManyToManyUpdateDto secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityTwoRelationshipsManyToManyCommand(key, secondTestEntityTwoRelationshipsManyToMany, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<SecondTestEntityTwoRelationshipsManyToManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<SecondTestEntityTwoRelationshipsManyToManyUpdateDto> secondTestEntityTwoRelationshipsManyToMany)
    {
        if (!ModelState.IsValid || secondTestEntityTwoRelationshipsManyToMany is null)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in secondTestEntityTwoRelationshipsManyToMany.GetChangedPropertyNames())
        {
            if (secondTestEntityTwoRelationshipsManyToMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateSecondTestEntityTwoRelationshipsManyToManyCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetSecondTestEntityTwoRelationshipsManyToManyByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteSecondTestEntityTwoRelationshipsManyToManyByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}