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
    
    [HttpPatch("api/{{entity.PluralName}}/{{keysRoute}}{{entity.Name}}Localized/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult<{{entity.Name}}LocalizedDto>> Patch{{entity.Name}}Localized( {{ primaryKeysRoute }}, [FromRoute] System.String {{cultureCode}}, [FromBody] Delta<{{entity.Name}}LocalizedUpsertDto> {{ToLowerFirstChar entity.Name}}LocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        var etag = Request.GetDecodedEtagHeader();
        
        foreach (var propertyName in {{ToLowerFirstChar entity.Name}}LocalizedUpsertDto.GetChangedPropertyNames())
        {
            if ({{ToLowerFirstChar entity.Name}}LocalizedUpsertDto.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }
        var updatedKey = await _mediator.Send(new PartialUpdate{{ entity.Name }}Command({{ primaryKeysQuery }}, updatedProperties, Nox.Types.CultureCode.From({{cultureCode}}) , etag));

        if (updatedKey is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new Get{{entity.Name }}TranslationsByIdQuery( {{ updatedKeyPrimaryKeysQuery }}, {{cultureCode}}))).SingleOrDefault();

        return Ok(item);
    }
}