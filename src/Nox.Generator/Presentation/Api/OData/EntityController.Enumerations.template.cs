// Generated

#nullable enable
using Microsoft.AspNetCore.Mvc;

using DtoNameSpace = {{codeGeneratorState.DtoNameSpace}};
using ApplicationQueriesNameSpace = {{codeGeneratorState.ApplicationQueriesNameSpace}};

namespace {{ codeGeneratorState.ODataNameSpace }};

public abstract partial class {{ entity.PluralName }}ControllerBase
{    
    {{- for enumAtt in enumerationAttributes }}
    [HttpGet("api/{{entity.PluralName}}/{{entity.Name}}{{Pluralize (enumAtt.Attribute.Name)}}")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>> Get{{Pluralize (enumAtt.Attribute.Name)}}NonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query());                        
        return Ok(result);        
    }
    {{- end}}
}
