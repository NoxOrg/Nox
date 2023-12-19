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

public partial class CountryQualityOfLifeIndicesController : CountryQualityOfLifeIndicesControllerBase
{
    public CountryQualityOfLifeIndicesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class CountryQualityOfLifeIndicesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public CountryQualityOfLifeIndicesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryQualityOfLifeIndexDto>>> Get()
    {
        var result = await _mediator.Send(new GetCountryQualityOfLifeIndicesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<CountryQualityOfLifeIndexDto>> Get([FromRoute] System.Int64 keyCountryId, [FromRoute] System.Int64 keyId)
    {
        var result = await _mediator.Send(new GetCountryQualityOfLifeIndexByIdQuery(keyCountryId, keyId));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<CountryQualityOfLifeIndexDto>> Post([FromBody] CountryQualityOfLifeIndexCreateDto countryQualityOfLifeIndex)
    {
        if(countryQualityOfLifeIndex is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateCountryQualityOfLifeIndexCommand(countryQualityOfLifeIndex, _cultureCode));

        var item = (await _mediator.Send(new GetCountryQualityOfLifeIndexByIdQuery(createdKey.keyCountryId, createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<CountryQualityOfLifeIndexDto>> Put([FromRoute] System.Int64 keyCountryId, [FromRoute] System.Int64 keyId, [FromBody] CountryQualityOfLifeIndexUpdateDto countryQualityOfLifeIndex)
    {
        if(countryQualityOfLifeIndex is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryQualityOfLifeIndexCommand(keyCountryId, keyId, countryQualityOfLifeIndex, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCountryQualityOfLifeIndexByIdQuery(updatedKey.keyCountryId, updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<CountryQualityOfLifeIndexDto>> Patch([FromRoute] System.Int64 keyCountryId, [FromRoute] System.Int64 keyId, [FromBody] Delta<CountryQualityOfLifeIndexPartialUpdateDto> countryQualityOfLifeIndex)
    {
        if(countryQualityOfLifeIndex is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CountryQualityOfLifeIndexPartialUpdateDto>(countryQualityOfLifeIndex);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateCountryQualityOfLifeIndexCommand(keyCountryId, keyId, updatedProperties, _cultureCode, etag));

        var item = (await _mediator.Send(new GetCountryQualityOfLifeIndexByIdQuery(updatedKey.keyCountryId, updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 keyCountryId, [FromRoute] System.Int64 keyId)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCountryQualityOfLifeIndexByIdCommand(new List<CountryQualityOfLifeIndexKeyDto> { new CountryQualityOfLifeIndexKeyDto(keyCountryId, keyId) }, etag));

        return NoContent();
    }
}