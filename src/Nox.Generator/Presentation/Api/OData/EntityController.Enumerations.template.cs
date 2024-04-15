// Generated

{{- cultureCode = ToLowerFirstChar codeGenConventions.LocalizationCultureField -}}
#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;

using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = {{codeGenConventions.DtoNameSpace}};
using ApplicationQueriesNameSpace = {{codeGenConventions.ApplicationQueriesNameSpace}};
using ApplicationCommandsNameSpace = {{codeGenConventions.ApplicationNameSpace}}.Commands;

namespace {{ codeGenConventions.ODataNameSpace }};

public abstract partial class {{ entity.PluralName }}ControllerBase
{    
    {{- for enumAtt in enumerationAttributes }}
    
    {{- entityRoute = enumAtt.EntityPluralName -}}
    {{- if enumAtt.IsSingleOwnedEntity }}
        {{entityRoute = entity.PluralName | string.append "/" + enumAtt.EntityName}}
    {{- else if enumAtt.IsMultiOwnedEntity }}
        {{entityRoute = entity.PluralName | string.append "/" + enumAtt.EntityPluralName}}
    {{- end -}}
    
    {{- if !enumAtt.IsSingleOwnedEntity && !enumAtt.IsMultiOwnedEntity }}
    [HttpGet("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entityRoute}}/{{Pluralize (enumAtt.Attribute.Name)}}")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>> Get{{enumAtt.EntityName}}{{Pluralize (enumAtt.Attribute.Name)}}NonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.Get{{(enumAtt.EntityPluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query(_cultureCode));                        
        return Ok(result);        
    }
    
    {{- if (enumAtt.Attribute.EnumerationTypeOptions.IsLocalized) }}
    [EnableQuery]
    [HttpGet("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entityRoute}}/{{Pluralize (enumAtt.Attribute.Name)}}/Languages")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>>> Get{{enumAtt.EntityName}}{{Pluralize (enumAtt.Attribute.Name)}}LanguagesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.Get{{(enumAtt.EntityPluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery());                        
        return Ok(result);        
    }
    {{- end -}}
    {{- end }} 
    {{- if (enumAtt.Attribute.EnumerationTypeOptions.IsLocalized) }}
    [HttpPut("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entityRoute}}/{{Pluralize (enumAtt.Attribute.Name)}}/{%{{}%}relatedKey{%{}}%}/Languages/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult<DtoNameSpace.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>> Put{{enumAtt.EntityName}}{{Pluralize (enumAtt.Attribute.Name)}}LocalizedNonConventional([FromRoute] System.Int32 relatedKey,[FromRoute] System.String {{cultureCode}}, [FromBody] DtoNameSpace.{{enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}} {{ToLowerFirstChar enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}})
    {   
        if ({{ToLowerFirstChar enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}} is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var upsertedKeyDto = await _mediator.Send(new ApplicationCommandsNameSpace.Upsert{{(enumAtt.EntityPluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), {{ToLowerFirstChar enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}}, Nox.Types.CultureCode.From({{cultureCode}})));                        
        var result = (await _mediator.Send(new ApplicationQueriesNameSpace.Get{{(enumAtt.EntityPluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery())).SingleOrDefault(x => x.Id == upsertedKeyDto.Id && x.CultureCode == upsertedKeyDto.{{cultureCode}});
        return Ok(result);       
    }

    [HttpDelete("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entityRoute}}/{{Pluralize (enumAtt.Attribute.Name)}}/{%{{}%}relatedKey{%{}}%}/Languages/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult> Delete{{enumAtt.EntityName}}{{Pluralize (enumAtt.Attribute.Name)}}LocalizedNonConventional([FromRoute] System.Int32 relatedKey, [FromRoute] System.String {{cultureCode}})
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom({{cultureCode}}, out var {{cultureCode}}Value));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.Delete{{(enumAtt.EntityPluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), {{cultureCode}}Value!));                        
        return NoContent();     
    }
    {{- end -}} 
    {{- end }} 
}