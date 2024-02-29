// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Net.Http.Headers;
using Nox.Application;
using Nox.Application.Dto;
using Nox.Extensions;
using Nox.Exceptions;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class CountriesControllerBase : ODataController
{

    #region Owned Relationships
    public virtual async Task<ActionResult<CountryTimeZoneDto>> PutToCountryTimeZones([FromODataUri] System.Int64 key, [FromBody] EntityDtoCollection<CountryTimeZoneUpsertDto> collection)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var countryTimeZones = (collection ?? new EntityDtoCollection<CountryTimeZoneUpsertDto>()).Value;
        var updatedKeys = await _mediator.Send(new UpdateCountryTimeZonesForCountryCommand(new CountryKeyDto(key), countryTimeZones, _cultureCode, etag));

        var children = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault()?.CountryTimeZones.Where(e => updatedKeys.Any(k => e.Id.Value == k.keyId));

        return Ok(children);
    }
    #endregion
}