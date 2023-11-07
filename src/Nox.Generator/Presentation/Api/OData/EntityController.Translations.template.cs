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
using {{codeGeneratorState.ApplicationNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.ApplicationNameSpace}}.Queries;
using {{codeGeneratorState.ApplicationNameSpace}}.Commands;
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{ codeGeneratorState.ODataNameSpace }};

public abstract partial class {{ entity.PluralName }}ControllerBase
{
    //Endpoint: POST /api/<entity>/{key}/<Entity>Localized/{culturecode}
    // This endpoint should receive a request body of type <Entity>LocalizedDto containing the
    // new data for localization. There's no need to create a separate DTO;
    // we'll use the existing DTO for this purpose.
    // [HttpPost("api/{{entity.PluralName}}/{key}/{{entity.Name}}Localized/{{culturecode}}")]
    // public virtual async Task<ActionResult<{{entity.Name}}LocalizedDto>> Create{{entity.Name}}Localized( {{ primaryKeysRoute }}, [FromBody] {{entity.Name}}LocalizedDto {{ToLowerFirstChar entity.Name}}LocalizedDto)
    // {
    //     var result = await _mediator.Send(new ApplicationCommandsNameSpace.Create{{entity.Name}}LocalizedCommand({{ToLowerFirstChar entity.Name}}LocalizedDto));
    //     return Ok(result);
    // }
    
    
    // //Endpoint: PUT /api/<entity>/{key}/<Entity>Localized/{culturecode}
    // // This endpoint should receive a request body of type <Entity>LocalizedDto containing the
    // // new data for localization. There's no need to create a separate update DTO;
    // // we'll use the existing DTO for this purpose.
    // [HttpPut("api/{{entity.PluralName}}/{key}/{{entity.Name}}Localized/{{culturecode}}")]
    // public virtual async Task<ActionResult<DtoNameSpace.{{entity.Name}}LocalizedDto>> Update{{entity.Name}}Localized(
    //     Nox.Types.Guid key,
    //     Nox.Types.CultureCode culturecode,
    //     DtoNameSpace.{{entity.Name}}LocalizedDto {{ToLowerFirstChar entity.Name}}LocalizedDto)
    // {
    //     var result = await _mediator.Send(new ApplicationCommandsNameSpace.Update{{entity.Name}}LocalizedCommand(
    //         key,
    //         culturecode,
    //         {{ToLowerFirstChar entity.Name}}LocalizedDto
    //     ));
    //     return Ok(result);
    // }
}
