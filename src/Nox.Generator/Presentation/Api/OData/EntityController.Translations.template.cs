{{- func keyNameWithPrefix(name, prefix = "key")	
    ret ("{" + prefix + name + ".ToString()}")
end -}}
{{- func keysToString(keys)
    if keys.size > 1
	    ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
    else
        ret "{key.ToString()}"
    end
end -}}
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
using Nox.Exceptions;

using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using {{codeGenConventions.ApplicationNameSpace}};
using System.Threading.Tasks;
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{codeGenConventions.ApplicationNameSpace}}.Queries;
using {{codeGenConventions.ApplicationNameSpace}}.Commands;
using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.PersistenceNameSpace}};

namespace {{ codeGenConventions.ODataNameSpace }};

{{- keysRoute = '' -}}
{{- for key in keysForRouting }}
         {{ keysRoute = keysRoute | string.append  "{" + key + "}" + "/" }}
{{ end }}
{{- cultureCode = ToLowerFirstChar codeGenConventions.LocalizationCultureField}}

public abstract partial class {{className}}Base
{  
    {{- if entity.IsLocalized }}
    [HttpPut("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{keysRoute}}Languages/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult<{{entity.Name}}LocalizedDto>> Put{{entity.Name}}Localized( {{ primaryKeysRoute }}, [FromRoute] System.String {{cultureCode}}, [FromBody] {{entity.Name}}LocalizedUpsertDto {{ToLowerFirstChar entity.Name}}LocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{ primaryKeysQuery }}))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            throw new EntityNotFoundException("{{entity.Name}}", $"{{entity.Keys | keysToString}}");
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
       
        {{- for attribute in localizedAttributes }}
        updatedProperties.Add(nameof({{ToLowerFirstChar entity.Name}}LocalizedUpsertDto.{{attribute.Name}}), {{ToLowerFirstChar entity.Name}}LocalizedUpsertDto.{{attribute.Name}}.ToValueFromNonNull());
        {{- end }}
        
        var updatedKey = await _mediator.Send(new PartialUpdate{{ entity.Name }}Command({{ primaryKeysQuery }}, updatedProperties, Nox.Types.CultureCode.From({{cultureCode}}) , etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("{{entity.Name}}", $"{{entity.Keys | keysToString}}");
        }
        var item = (await _mediator.Send(new Get{{entity.Name }}TranslationsByIdQuery( {{ updatedKeyPrimaryKeysQuery }}, Nox.Types.CultureCode.From({{cultureCode}})))).SingleOrDefault();

        return Ok(item);
    }

    [HttpDelete("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{keysRoute}}{{entity.PluralName}}Localized/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult<{{entity.Name}}LocalizedDto>> Delete{{entity.Name}}Localized( {{ primaryKeysRoute }}, [FromRoute] System.String {{cultureCode}})
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom({{cultureCode}}, out var cultureCodeValue));
               
        await _mediator.Send(new Delete{{ entity.Name }}TranslationCommand({{ primaryKeysQuery }}, cultureCodeValue!));

        return NoContent();
    }

    [HttpGet("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{keysRoute}}Languages/")]
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<{{entity.Name}}LocalizedDto>>> Get{{entity.Name}}LanguagesNonConventional( {{ primaryKeysRoute }})
    {
        var result = (await _mediator.Send(new Get{{entity.Name}}TranslationsQuery({{ primaryKeysQuery }})));
            
        return Ok(result);
    }
    {{~ end ~}}
    {{- for localizedRelationship in ownedLocalizedRelationships }}
    [HttpPut("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{keysRoute}}{{GetNavigationPropertyName entity localizedRelationship.OwnedEntity.OwningRelationship}}Localized/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult<{{GetEntityDtoNameForLocalizedType localizedRelationship.OwnedEntity.Name}}>> Put{{localizedRelationship.OwnedEntity.Name}}Localized( {{ primaryKeysRoute }}, [FromRoute] System.String {{ cultureCode}}, [FromBody] {{ GetEntityUpsertDtoNameForLocalizedType localizedRelationship.OwnedEntity.Name}} {{ToLowerFirstChar localizedRelationship.OwnedEntity.Name}}LocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{ primaryKeysQuery }}))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            throw new EntityNotFoundException("{{entity.Name}}", $"{{entity.Keys | keysToString}}");
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
       
        {{- for attribute in localizedRelationship.LocalizedAttributes }}
        updatedProperties.Add(nameof({{ToLowerFirstChar localizedRelationship.OwnedEntity.Name}}LocalizedUpsertDto.{{attribute.Name}}), {{ToLowerFirstChar localizedRelationship.OwnedEntity.Name}}LocalizedUpsertDto.{{attribute.Name}}.ToValueFromNonNull());
        {{- end }}

        {{- if localizedRelationship.IsWithMultiEntity }}
        var updatedKey = await _mediator.Send(new PartialUpdate{{GetNavigationPropertyName entity localizedRelationship.OwnedEntity.OwningRelationship}}For{{entity.Name}}Command(
            new {{entity.Name}}KeyDto({{primaryKeysQuery}}),
            new {{localizedRelationship.OwnedEntity.Name}}KeyDto({{localizedRelationship.OwnedEntityKeysQuery}}),
            updatedProperties, Nox.Types.CultureCode.From(cultureCode), etag));
        {{- else}}
        var updatedKey = await _mediator.Send(new PartialUpdate{{GetNavigationPropertyName entity localizedRelationship.OwnedEntity.OwningRelationship}}For{{entity.Name}}Command(
            new {{entity.Name}}KeyDto({{primaryKeysQuery}}),
            updatedProperties, Nox.Types.CultureCode.From(cultureCode), etag));
        {{- end}}

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("{{entity.Name}}", $"{{entity.Keys | keysToString}}");
        }

        var item = (await _mediator.Send(new Get{{localizedRelationship.OwnedEntity.Name}}TranslationsByIdQuery( {{ localizedRelationship.UpdatedKeyPrimaryKeysQuery }}, Nox.Types.CultureCode.From({{cultureCode}})))).SingleOrDefault();

        return Ok(item);
    }

    [HttpDelete("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{keysRoute}}{{if localizedRelationship.IsWithMultiEntity}}{{localizedRelationship.OwnedEntity.PluralName}}{{else}}{{localizedRelationship.OwnedEntity.Name}}{{end}}Localized/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult<{{GetEntityDtoNameForLocalizedType localizedRelationship.OwnedEntity.Name}}>> Delete{{localizedRelationship.OwnedEntity.Name}}Localized( {{ primaryKeysRoute }}, [FromRoute] System.String {{ cultureCode}})
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom({{cultureCode}}, out var {{cultureCode}}Value));

        await _mediator.Send(new Delete{{GetNavigationPropertyName entity localizedRelationship.OwnedEntity.OwningRelationship}}TranslationsFor{{entity.Name}}Command({{ primaryKeysQuery }}, Nox.Types.CultureCode.From({{cultureCode}})));

        return NoContent();
    }
    {{- end }}
}