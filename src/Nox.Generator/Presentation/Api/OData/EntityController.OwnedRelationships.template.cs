// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using {{codeGenConventions.ApplicationNameSpace}}.Dto;

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
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAll{{ownedRelationshipName}}For{{entity.Name}}Command(new {{entity.Name}}KeyDto({{ primaryKeysQuery }}), etag));
        return NoContent();
    }
            
            {{- else if ownedRelationship.Relationship == "ZeroOrOne" }}
            
    [HttpDelete("{{entity.PluralName}}/{key}/{{ownedRelationship.Entity}}")]
    public async Task<IActionResult> Delete{{entity.Name}}Owned{{ownedRelationship.Entity}}({{ primaryKeysRoute }})
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAll{{ownedRelationshipName}}For{{entity.Name}}Command(new {{entity.Name}}KeyDto({{ primaryKeysQuery }}), etag));
        return NoContent();
    }
            {{- end }}
        {{- end }}
    {{- end }}
}
