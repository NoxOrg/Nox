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
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Presentation.Api.OData;
         



public abstract partial class CitiesControllerBase
{
    
    [HttpPut("/api/v1/Cities/{key}/CitiesLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<CityLocalizedDto>> PutCityLocalized( [FromRoute] System.String key, [FromRoute] System.String cultureCode, [FromBody] CityLocalizedUpsertDto cityLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = (await _mediator.Send(new GetCityByIdQuery(Nox.Types.CultureCode.From(cultureCode), key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            return NotFound();
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(cityLocalizedUpsertDto.Name), cityLocalizedUpsertDto.Name.ToValueFromNonNull());
        
        var updatedKey = await _mediator.Send(new PartialUpdateCityCommand(key, updatedProperties, Nox.Types.CultureCode.From(cultureCode) , etag));

        if (updatedKey is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetCityTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }


    [HttpGet("/api/v1/Cities/{key}/CitiesLocalized/")]
    public virtual async Task<ActionResult<IQueryable<CityLocalizedDto>>> GetCityLocalizedNonConventional( [FromRoute] System.String key)
    {
        var result = (await _mediator.Send(new GetCityTranslationsQuery(key)));
            
        return Ok(result);
    }
}