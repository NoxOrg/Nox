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

public partial class CountriesController : CountriesControllerBase
{
    public CountriesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class CountriesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public CountriesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider,
        GetCountriesByContinentQueryBase getCountriesByContinent
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
        _getCountriesByContinent = getCountriesByContinent;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<CountryDto>> Get([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new GetCountryByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<CountryDto>> Post([FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));

        var item = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<CountryDto>> Put([FromRoute] System.String key, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryCommand(key, country, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetCountryByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<CountryDto>> Patch([FromRoute] System.String key, [FromBody] Delta<CountryPartialUpdateDto> country)
    {
        if (!ModelState.IsValid || country is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in country.GetChangedPropertyNames())
        {
            if (country.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateCountryCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetCountryByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCountryByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}