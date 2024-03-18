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
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using ClientApi.Application;
using System.Threading.Tasks;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Presentation.Api.OData;
         


public abstract partial class CountriesControllerBase
{
    [HttpPut("/api/v1/Countries/{key}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<CountryLocalizedDto>> PutCountryLocalized( [FromRoute] System.Int64 key, [FromRoute] System.String cultureCode, [FromBody] CountryLocalizedUpsertDto countryLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(countryLocalizedUpsertDto.TestAttForLocalization), countryLocalizedUpsertDto.TestAttForLocalization.ToValueFromNonNull());
        
        var updatedKey = await _mediator.Send(new PartialUpdateCountryCommand(key, updatedProperties, Nox.Types.CultureCode.From(cultureCode) , etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        var item = (await _mediator.Send(new GetCountryTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }

    [HttpDelete("/api/v1/Countries/{key}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<CountryLocalizedDto>> DeleteCountryLocalized( [FromRoute] System.Int64 key, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));
               
        await _mediator.Send(new DeleteCountryTranslationCommand(key, cultureCodeValue!));

        return NoContent();
    }

    [HttpGet("/api/v1/Countries/{key}/Languages/")]
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryLocalizedDto>>> GetCountryLanguagesNonConventional( [FromRoute] System.Int64 key)
    {
        var result = (await _mediator.Send(new GetCountryTranslationsQuery(key)));
            
        return Ok(result);
    }

    [HttpGet("/api/v1/Countries/{key}/CountryLocalNames/Languages")]
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryLocalNameLocalizedDto>>> GetCountryLocalNameLanguagesNonConventional([FromRoute] System.Int64 key)
    {
        var result = (await _mediator.Send(new GetCountryLocalNameTranslationsByParentIdQuery(key)));
        return Ok(result);
    }
    
    [HttpPut("/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<CountryLocalNameLocalizedDto>> PutCountryLocalNameLocalized([FromRoute] System.Int64 key,[FromRoute] System.Int64 relatedKey, [FromRoute] System.String cultureCode, [FromBody] CountryLocalNameLocalizedUpsertDto countryLocalNameLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));
        countryLocalNameLocalizedUpsertDto.Id = relatedKey;
        var etag = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(countryLocalNameLocalizedUpsertDto.Description), countryLocalNameLocalizedUpsertDto.Description.ToValueFromNonNull());
        var updatedKey = await _mediator.Send(new PartialUpdateCountryLocalNamesForCountryCommand(
            new CountryKeyDto(key),
            new CountryLocalNameKeyDto(countryLocalNameLocalizedUpsertDto.Id!.Value),
            updatedProperties, Nox.Types.CultureCode.From(cultureCode), etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Country", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetCountryLocalNameTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }

    [HttpDelete("/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<CountryLocalNameLocalizedDto>> DeleteCountryLocalNameLocalized( [FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        await _mediator.Send(new DeleteCountryLocalNamesTranslationsForCountryCommand(key, relatedKey, Nox.Types.CultureCode.From(cultureCode)));

        return NoContent();
    }
}