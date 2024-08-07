﻿// Generated

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
using CryptocashIntegration.Application;
using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Application.Queries;
using CryptocashIntegration.Application.Commands;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Presentation.Api.OData;

public partial class CountryProcToTablesController : CountryProcToTablesControllerBase
{
    public CountryProcToTablesController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class CountryProcToTablesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public CountryProcToTablesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryProcToTableDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountryProcToTablesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<CountryProcToTableDto>> Get([FromRoute] System.Int32 key)
    {
        var result = await _mediator.Send(new GetCountryProcToTableByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<CountryProcToTableDto>> Post([FromBody] CountryProcToTableCreateDto countryProcToTable)
    {
        if(countryProcToTable is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateCountryProcToTableCommand(countryProcToTable, _cultureCode));

        var item = (await _mediator.Send(new GetCountryProcToTableByIdQuery(createdKey.keyCountryId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<CountryProcToTableDto>> Put([FromRoute] System.Int32 key, [FromBody] CountryProcToTableUpdateDto countryProcToTable)
    {
        if(countryProcToTable is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryProcToTableCommand(key, countryProcToTable, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCountryProcToTableByIdQuery(updatedKey.keyCountryId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<CountryProcToTableDto>> Patch([FromRoute] System.Int32 key, [FromBody] Delta<CountryProcToTablePartialUpdateDto> countryProcToTable)
    {
        if(countryProcToTable is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CountryProcToTablePartialUpdateDto>(countryProcToTable);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateCountryProcToTableCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCountryProcToTableByIdQuery(updatedKey.keyCountryId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int32 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCountryProcToTableByIdCommand(new List<CountryProcToTableKeyDto> { new CountryProcToTableKeyDto(key) }, etag));

        return NoContent();
    }
}