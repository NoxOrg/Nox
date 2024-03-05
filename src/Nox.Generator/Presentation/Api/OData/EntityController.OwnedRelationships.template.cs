// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using ApplicationCommandsNameSpace = {{codeGenConventions.ApplicationNameSpace}}.Commands;

namespace {{ codeGenConventions.ODataNameSpace }};

public abstract partial class {{ entity.PluralName }}ControllerBase
{
    {{- if entity.OwnedRelationships != null }}
        {{- for ownedRelationship in entity.OwnedRelationships }}                
            {{- ownedRelationshipName = GetNavigationPropertyName entity ownedRelationship }}
            {{- if ownedRelationship.Relationship == "ZeroOrMany" }}
            
    [HttpDelete("{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}")]
    public async Task<IActionResult> Delete{{entity.Name}}Owned{{ownedRelationship.EntityPlural}}({{ primaryKeysRoute }})
    {
        await Task.CompletedTask;
        return NoContent();
    }
            
            {{- else if ownedRelationship.Relationship == "ZeroOrOne" }}
            
    [HttpDelete("{{entity.PluralName}}/{key}/{{ownedRelationship.Entity}}")]
    public async Task<IActionResult> Delete{{entity.Name}}Owned{{ownedRelationship.Entity}}({{ primaryKeysRoute }})
    {
        await Task.CompletedTask;
        return NoContent();
    }
            {{- end }}
        {{- end }}
    {{- end }}
}
