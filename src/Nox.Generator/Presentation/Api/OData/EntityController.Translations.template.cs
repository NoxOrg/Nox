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

{{- keysRoute = '' -}}
{{- for key in keysForRouting }}
         {{ keysRoute = keysRoute | string.append  "{" + key + "}" + "/" }}
{{ end }}
{{- cultureCode = ToLowerFirstChar codeGeneratorState.LocalizationCultureField}}


public abstract partial class {{ entity.PluralName }}ControllerBase
{
    //Endpoint: POST /api/<entity>/{key}/<Entity>Localized/{culturecode}
    // This endpoint should receive a request body of type <Entity>LocalizedDto containing the
    // new data for localization. There's no need to create a separate DTO;
    // we'll use the existing DTO for this purpose.
    [HttpPost("api/{{entity.PluralName}}/{{keysRoute}}{{entity.Name}}Localized/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult<{{entity.Name}}LocalizedDto>> Create{{entity.Name}}Localized( {{ primaryKeysRoute }}, [FromRoute] System.String {{cultureCode}}, [FromBody] {{entity.Name}}LocalizedCreateDto {{ToLowerFirstChar entity.Name}}LocalizedCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new Create{{entity.Name}}TranslationsCommand({{ToLowerFirstChar entity.Name}}LocalizedCreateDto, {{primaryKeysQuery}}, {{cultureCode}}));
        var item = (await _mediator.Send(new Get{{entity.Name }}TranslationsByIdQuery( {{ createdKeyPrimaryKeysQuery }}, createdKey.{{codeGeneratorState.LocalizationCultureField}}))).SingleOrDefault();

        return Created(item);
    }
    
    
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
