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
using CryptocashIntegration.Application;
using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Application.Queries;
using CryptocashIntegration.Application.Commands;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Presentation.Api.OData;

public partial class CountryJsonToTablesController : CountryJsonToTablesControllerBase
{
    public CountryJsonToTablesController(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class CountryJsonToTablesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public CountryJsonToTablesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryJsonToTableDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountryJsonToTablesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<CountryJsonToTableDto>> Get([FromRoute] System.Int32 key)
    {
        var result = await _mediator.Send(new GetCountryJsonToTableByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<CountryJsonToTableDto>> Post([FromBody] CountryJsonToTableCreateDto countryJsonToTable)
    {
        if(countryJsonToTable is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateCountryJsonToTableCommand(countryJsonToTable, _cultureCode));

        var item = (await _mediator.Send(new GetCountryJsonToTableByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<CountryJsonToTableDto>> Put([FromRoute] System.Int32 key, [FromBody] CountryJsonToTableUpdateDto countryJsonToTable)
    {
        if(countryJsonToTable is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryJsonToTableCommand(key, countryJsonToTable, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCountryJsonToTableByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<CountryJsonToTableDto>> Patch([FromRoute] System.Int32 key, [FromBody] Delta<CountryJsonToTablePartialUpdateDto> countryJsonToTable)
    {
        if(countryJsonToTable is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CountryJsonToTablePartialUpdateDto>(countryJsonToTable);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateCountryJsonToTableCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCountryJsonToTableByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int32 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCountryJsonToTableByIdCommand(new List<CountryJsonToTableKeyDto> { new CountryJsonToTableKeyDto(key) }, etag));

        return NoContent();
    }
}