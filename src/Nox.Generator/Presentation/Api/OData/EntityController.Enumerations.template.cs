// Generated

{{- cultureCode = ToLowerFirstChar codeGenConventions.LocalizationCultureField}}
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

    [HttpDelete("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}Localized/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult> Delete{{Pluralize (enumAtt.Attribute.Name)}}LocalizedNonConventional([FromRoute] System.String {{cultureCode}})
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom({{cultureCode}}, out var {{cultureCode}}Value));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.Delete{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsCommand({{cultureCode}}Value!));                        
        return NoContent();     
    }

    [HttpPut("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}Localized")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}>>> Put{{Pluralize (enumAtt.Attribute.Name)}}LocalizedNonConventional([FromBody] EnumerationLocalizedListDto<DtoNameSpace.{{enumAtt.EntityDtoNameForLocalizedEnumeration}}> {{ToLowerFirstChar enumAtt.EntityDtoNameForLocalizedEnumeration}}s)
    {   
        
        if ({{ToLowerFirstChar enumAtt.EntityDtoNameForLocalizedEnumeration}}s is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new ApplicationCommandsNameSpace.Upsert{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsCommand({{ToLowerFirstChar enumAtt.EntityDtoNameForLocalizedEnumeration}}s.Items));                        
        return Ok(result);       
    }
   
    {{-end }}
    {{- end}} 
}
