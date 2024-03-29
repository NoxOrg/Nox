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
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using TestWebApp.Application;
using System.Threading.Tasks;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Presentation.Api.OData;
         


public abstract partial class TestEntityLocalizationsControllerBase
{
    [HttpPut("/api/v1/TestEntityLocalizations/{key}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<TestEntityLocalizationLocalizedDto>> PutTestEntityLocalizationLocalized( [FromRoute] System.String key, [FromRoute] System.String cultureCode, [FromBody] TestEntityLocalizationLocalizedUpsertDto testEntityLocalizationLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = (await _mediator.Send(new GetTestEntityLocalizationByIdQuery(key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            throw new EntityNotFoundException("TestEntityLocalization", $"{key.ToString()}");
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(testEntityLocalizationLocalizedUpsertDto.TextFieldToLocalize), testEntityLocalizationLocalizedUpsertDto.TextFieldToLocalize.ToValueFromNonNull());
        
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityLocalizationCommand(key, updatedProperties, Nox.Types.CultureCode.From(cultureCode) , etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("TestEntityLocalization", $"{key.ToString()}");
        }
        var item = (await _mediator.Send(new GetTestEntityLocalizationTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }

    [HttpDelete("/api/v1/TestEntityLocalizations/{key}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<TestEntityLocalizationLocalizedDto>> DeleteTestEntityLocalizationLocalized( [FromRoute] System.String key, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));
               
        await _mediator.Send(new DeleteTestEntityLocalizationTranslationCommand(key, cultureCodeValue!));

        return NoContent();
    }

    [HttpGet("/api/v1/TestEntityLocalizations/{key}/Languages/")]
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityLocalizationLocalizedDto>>> GetTestEntityLocalizationLanguagesNonConventional( [FromRoute] System.String key)
    {
        var result = (await _mediator.Send(new GetTestEntityLocalizationTranslationsQuery(key)));
            
        return Ok(result);
    }

}