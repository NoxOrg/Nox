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
         



public abstract partial class WorkplacesControllerBase
{
    //Endpoint: POST /api/<entity>/{key}/<Entity>Localized/{culturecode}
    // This endpoint should receive a request body of type <Entity>LocalizedDto containing the
    // new data for localization. There's no need to create a separate DTO;
    // we'll use the existing DTO for this purpose.
    [HttpPost("api/Workplaces/{key}/WorkplaceLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<WorkplaceLocalizedDto>> CreateWorkplaceLocalized( [FromRoute] System.UInt32 key, [FromRoute] System.String cultureCode, [FromBody] WorkplaceLocalizedCreateDto workplaceLocalizedCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateWorkplaceTranslationsCommand(workplaceLocalizedCreateDto, key, cultureCode));
        var item = (await _mediator.Send(new GetWorkplaceTranslationsByIdQuery( createdKey.Id, createdKey.CultureCode))).SingleOrDefault();

        return Created(item);
    }
    
    
    // //Endpoint: PUT /api/<entity>/{key}/<Entity>Localized/{culturecode}
    // // This endpoint should receive a request body of type <Entity>LocalizedDto containing the
    // // new data for localization. There's no need to create a separate update DTO;
    // // we'll use the existing DTO for this purpose.
    // [HttpPut("api/Workplaces/{key}/WorkplaceLocalized/")]
    // public virtual async Task<ActionResult<DtoNameSpace.WorkplaceLocalizedDto>> UpdateWorkplaceLocalized(
    //     Nox.Types.Guid key,
    //     Nox.Types.CultureCode culturecode,
    //     DtoNameSpace.WorkplaceLocalizedDto workplaceLocalizedDto)
    // {
    //     var result = await _mediator.Send(new ApplicationCommandsNameSpace.UpdateWorkplaceLocalizedCommand(
    //         key,
    //         culturecode,
    //         workplaceLocalizedDto
    //     ));
    //     return Ok(result);
    // }
}
