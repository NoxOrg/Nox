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

public abstract partial class {{className}}Base
{  
    
    [HttpPut("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{keysRoute}}{{entity.PluralName}}Localized/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult<{{entity.Name}}LocalizedDto>> Put{{entity.Name}}Localized( {{ primaryKeysRoute }}, [FromRoute] System.String {{cultureCode}}, [FromBody] {{entity.Name}}LocalizedUpsertDto {{ToLowerFirstChar entity.Name}}LocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{ primaryKeysQuery }}))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            return NotFound();
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
       
        {{- for attribute in localizedAttributes }}
        updatedProperties.Add(nameof({{ToLowerFirstChar entity.Name}}LocalizedUpsertDto.{{attribute.Name}}), {{ToLowerFirstChar entity.Name}}LocalizedUpsertDto.{{attribute.Name}}.ToValueFromNonNull());
        {{- end }}
        
        var updatedKey = await _mediator.Send(new PartialUpdate{{ entity.Name }}Command({{ primaryKeysQuery }}, updatedProperties, Nox.Types.CultureCode.From({{cultureCode}}) , etag));

        var item = (await _mediator.Send(new Get{{entity.Name }}TranslationsByIdQuery( {{ updatedKeyPrimaryKeysQuery }}, Nox.Types.CultureCode.From({{cultureCode}})))).SingleOrDefault();

        return Ok(item);
    }


    [HttpGet("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{keysRoute}}{{entity.PluralName}}Localized/")]
    public virtual async Task<ActionResult<IQueryable<{{entity.Name}}LocalizedDto>>> Get{{entity.Name}}LocalizedNonConventional( {{ primaryKeysRoute }})
    {
        var result = (await _mediator.Send(new Get{{entity.Name}}TranslationsQuery({{ primaryKeysQuery }})));
            
        return Ok(result);
    }
}