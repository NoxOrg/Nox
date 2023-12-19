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
using CryptocashIntegration.Application;
using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Application.Queries;
using CryptocashIntegration.Application.Commands;
using CryptocashIntegration.Domain;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Presentation.Api.OData;

public partial class CountryQueryToCustomTablesController : CountryQueryToCustomTablesControllerBase
{
    public CountryQueryToCustomTablesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class CountryQueryToCustomTablesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public CountryQueryToCustomTablesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryQueryToCustomTableDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountryQueryToCustomTablesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<CountryQueryToCustomTableDto>> Get([FromRoute] System.Int32 key)
    {
        var result = await _mediator.Send(new GetCountryQueryToCustomTableByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<CountryQueryToCustomTableDto>> Post([FromBody] CountryQueryToCustomTableCreateDto countryQueryToCustomTable)
    {
        if(countryQueryToCustomTable is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateCountryQueryToCustomTableCommand(countryQueryToCustomTable, _cultureCode));

        var item = (await _mediator.Send(new GetCountryQueryToCustomTableByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<CountryQueryToCustomTableDto>> Put([FromRoute] System.Int32 key, [FromBody] CountryQueryToCustomTableUpdateDto countryQueryToCustomTable)
    {
        if(countryQueryToCustomTable is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryQueryToCustomTableCommand(key, countryQueryToCustomTable, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCountryQueryToCustomTableByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<CountryQueryToCustomTableDto>> Patch([FromRoute] System.Int32 key, [FromBody] Delta<CountryQueryToCustomTablePartialUpdateDto> countryQueryToCustomTable)
    {
        if(countryQueryToCustomTable is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CountryQueryToCustomTablePartialUpdateDto>(countryQueryToCustomTable);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateCountryQueryToCustomTableCommand(key, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCountryQueryToCustomTableByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int32 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCountryQueryToCustomTableByIdCommand(new List<CountryQueryToCustomTableKeyDto> { new CountryQueryToCustomTableKeyDto(key) }, etag));

        return NoContent();
    }
}