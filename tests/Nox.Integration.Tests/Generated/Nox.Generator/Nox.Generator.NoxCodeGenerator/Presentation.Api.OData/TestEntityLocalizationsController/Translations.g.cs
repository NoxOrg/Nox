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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Presentation.Api.OData;
         



public abstract partial class TestEntityLocalizationsControllerBase
{
    
    [HttpPut("api/TestEntityLocalizations/{key}/TestEntityLocalizationLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<TestEntityLocalizationLocalizedDto>> PutTestEntityLocalizationLocalized( [FromRoute] System.String key, [FromRoute] System.String cultureCode, [FromBody] TestEntityLocalizationLocalizedUpsertDto testEntityLocalizationLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        var etag = Request.GetDecodedEtagHeader();
        updatedProperties.Add(nameof(testEntityLocalizationLocalizedUpsertDto.TextFieldToLocalize), testEntityLocalizationLocalizedUpsertDto.TextFieldToLocalize.ToValueFromNonNull());
        
        var updatedKey = await _mediator.Send(new PartialUpdateTestEntityLocalizationCommand(key, updatedProperties, Nox.Types.CultureCode.From(cultureCode) , etag));

        if (updatedKey is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetTestEntityLocalizationTranslationsByIdQuery( updatedKey.keyId, cultureCode))).SingleOrDefault();

        return Ok(item);
    }
}