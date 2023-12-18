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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Presentation.Api.OData;
         


public abstract partial class TestEntityLocalizationsControllerBase
{  
    
    [HttpPut("/api/v1/TestEntityLocalizations/{key}/TestEntityLocalizationsLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<TestEntityLocalizationLocalizedDto>> PutTestEntityLocalizationLocalized( [FromRoute] System.String key, [FromRoute] System.String cultureCode, [FromBody] TestEntityLocalizationLocalizedUpsertDto testEntityLocalizationLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = (await _mediator.Send(new GetTestEntityLocalizationByIdQuery(key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            return NotFound();
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(testEntityLocalizationLocalizedUpsertDto.TextFieldToLocalize), testEntityLocalizationLocalizedUpsertDto.TextFieldToLocalize.ToValueFromNonNull());
        
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityLocalizationCommand(key, updatedProperties, Nox.Types.CultureCode.From(cultureCode) , etag));

        var item = (await _mediator.Send(new GetTestEntityLocalizationTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }


    [HttpGet("/api/v1/TestEntityLocalizations/{key}/TestEntityLocalizationsLocalized/")]
    public virtual async Task<ActionResult<IQueryable<TestEntityLocalizationLocalizedDto>>> GetTestEntityLocalizationLocalizedNonConventional( [FromRoute] System.String key)
    {
        var result = (await _mediator.Send(new GetTestEntityLocalizationTranslationsQuery(key)));
            
        return Ok(result);
    }
}