﻿// Generated
{{- cultureCode = ToLowerFirstChar codeGeneratorState.LocalizationCultureField}}
#nullable enable
using Microsoft.AspNetCore.Mvc;

using DtoNameSpace = {{codeGeneratorState.DtoNameSpace}};
using ApplicationQueriesNameSpace = {{codeGeneratorState.ApplicationQueriesNameSpace}};
using ApplicationCommandsNameSpace = {{codeGeneratorState.ApplicationNameSpace}}.Commands;

namespace {{ codeGeneratorState.ODataNameSpace }};

public abstract partial class {{ entity.PluralName }}ControllerBase
{    
    {{- for enumAtt in enumerationAttributes }}
    [HttpGet("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>> Get{{Pluralize (enumAtt.Attribute.Name)}}NonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query(_cultureCode));                        
        return Ok(result);        
    }
    
    {{- if (enumAtt.Attribute.EnumerationTypeOptions.IsLocalized) }}
    {{-}}
    [HttpGet("{{solution.Infrastructure.Endpoints.ApiRoutePrefix}}/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}Localized")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>> Get{{Pluralize (enumAtt.Attribute.Name)}}LocalizedNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery());                        
        return Ok(result);        
    }

    [HttpDelete("{{solution.Infrastructure.Endpoints.ApiRoutePrefix}}/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}Localized/{%{{}%}{{cultureCode}}{%{}}%}")]
    public virtual async Task<ActionResult> Delete{{Pluralize (enumAtt.Attribute.Name)}}LocalizedNonConventional([FromRoute] System.String {{cultureCode}})
    {            
        var result = await _mediator.Send(new ApplicationCommandsNameSpace.Delete{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsCommand(Nox.Types.CultureCode.From({{cultureCode}})));                        
        return NoContent();     
    }
    {{-end }}
    {{- end}} 
}
