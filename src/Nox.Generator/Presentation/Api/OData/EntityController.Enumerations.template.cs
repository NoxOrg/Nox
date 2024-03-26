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
    [HttpGet("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{Pluralize (enumAtt.Attribute.Name)}}")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>> Get{{Pluralize (enumAtt.Attribute.Name)}}NonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query(_cultureCode));                        
        return Ok(result);        
    }
    
    {{- if (enumAtt.Attribute.EnumerationTypeOptions.IsLocalized) }}
    {{-}}
    [EnableQuery]
    [HttpGet("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{Pluralize (enumAtt.Attribute.Name)}}/Languages")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>>> Get{{Pluralize (enumAtt.Attribute.Name)}}LanguagesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery());                        
        return Ok(result);        
    }

    [HttpDelete("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{Pluralize (enumAtt.Attribute.Name)}}/{%{{}%}relatedKey{%{}}%}/Languages/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult> Delete{{Pluralize (enumAtt.Attribute.Name)}}LocalizedNonConventional([FromRoute] System.Int32 relatedKey, [FromRoute] System.String {{cultureCode}})
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom({{cultureCode}}, out var {{cultureCode}}Value));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.Delete{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), {{cultureCode}}Value!));                        
        return NoContent();     
    }

    [HttpPut("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{Pluralize (enumAtt.Attribute.Name)}}/{%{{}%}relatedKey{%{}}%}/Languages/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult<DtoNameSpace.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>> Put{{Pluralize (enumAtt.Attribute.Name)}}LocalizedNonConventional([FromRoute] System.Int32 relatedKey,[FromRoute] System.String {{cultureCode}}, [FromBody] DtoNameSpace.{{enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}} {{ToLowerFirstChar enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}})
    {   
        
        if ({{ToLowerFirstChar enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}} is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var upsertedKeyDto = await _mediator.Send(new ApplicationCommandsNameSpace.Upsert{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), {{ToLowerFirstChar enumAtt.EntityDtoNameForUpsertLocalizedEnumeration}}, Nox.Types.CultureCode.From({{cultureCode}})));                        
        var result = (await _mediator.Send(new ApplicationQueriesNameSpace.Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery())).SingleOrDefault(x => x.Id == upsertedKeyDto.Id && x.CultureCode == upsertedKeyDto.{{cultureCode}});
        return Ok(result);       
    }
   
    {{-end }}
    {{- end}} 
}
