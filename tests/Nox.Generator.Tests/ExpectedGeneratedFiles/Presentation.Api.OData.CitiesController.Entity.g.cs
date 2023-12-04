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
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Presentation.Api.OData;

public partial class CitiesController : CitiesControllerBase
{
    public CitiesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class CitiesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public CitiesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CityDto>>> Get()
    {
        var result = await _mediator.Send(new GetCitiesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<CityDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetCityByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<CityDto>> Post([FromBody] CityCreateDto city)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateCityCommand(city, _cultureCode));

        var item = (await _mediator.Send(new GetCityByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<CityDto>> Put([FromRoute] System.String key, [FromBody] CityUpdateDto city)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCityCommand(key, city, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetCityByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<CityDto>> Patch([FromRoute] System.String key, [FromBody] Delta<CityUpdateDto> city)
    {
        if (!ModelState.IsValid || city is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in city.GetChangedPropertyNames())
        {
            if (city.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateCityCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetCityByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

}