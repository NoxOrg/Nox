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
    //Endpoint: POST /api/<entity>/{key}/<Entity>Localized/{culturecode}
    // This endpoint should receive a request body of type <Entity>LocalizedDto containing the
    // new data for localization. There's no need to create a separate DTO;
    // we'll use the existing DTO for this purpose.
    [HttpPost("api/TestEntityLocalizations/{key}/TestEntityLocalizationLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<TestEntityLocalizationLocalizedDto>> CreateTestEntityLocalizationLocalized( [FromRoute] System.String key, [FromRoute] System.String cultureCode, [FromBody] TestEntityLocalizationLocalizedCreateDto testEntityLocalizationLocalizedCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateTestEntityLocalizationTranslationsCommand(testEntityLocalizationLocalizedCreateDto, key, cultureCode));
        var item = (await _mediator.Send(new GetTestEntityLocalizationTranslationsByIdQuery( createdKey.Id, createdKey.CultureCode))).SingleOrDefault();

        return Created(item);
    }
    
    
    // //Endpoint: PUT /api/<entity>/{key}/<Entity>Localized/{culturecode}
    // // This endpoint should receive a request body of type <Entity>LocalizedDto containing the
    // // new data for localization. There's no need to create a separate update DTO;
    // // we'll use the existing DTO for this purpose.
    // [HttpPut("api/TestEntityLocalizations/{key}/TestEntityLocalizationLocalized/")]
    // public virtual async Task<ActionResult<DtoNameSpace.TestEntityLocalizationLocalizedDto>> UpdateTestEntityLocalizationLocalized(
    //     Nox.Types.Guid key,
    //     Nox.Types.CultureCode culturecode,
    //     DtoNameSpace.TestEntityLocalizationLocalizedDto testEntityLocalizationLocalizedDto)
    // {
    //     var result = await _mediator.Send(new ApplicationCommandsNameSpace.UpdateTestEntityLocalizationLocalizedCommand(
    //         key,
    //         culturecode,
    //         testEntityLocalizationLocalizedDto
    //     ));
    //     return Ok(result);
    // }
}
