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
    {{- if ownedRelationships != null }}
        {{- for ownedRelationship in ownedRelationships }}                
            {{- ownedRelationshipName = ownedRelationship.OwnedRelationshipName }}
            {{- if ownedRelationship.Deletable}}
                {{- if ownedRelationship.Relationship == "ZeroOrMany" }}
            
    [HttpDelete("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}")]
    public virtual async Task<IActionResult> Delete{{entity.Name}}AllOwned{{ownedRelationship.EntityPlural}}NonConventional({{ primaryKeysRoute }})
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAll{{ownedRelationshipName}}For{{entity.Name}}Command(new {{entity.Name}}KeyDto({{ primaryKeysQuery }}), etag));
        return NoContent();
    }
                {{- end }}
                {{- if ownedRelationship.Relationship == "ZeroOrOne" }}
            
    [HttpDelete("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{key}/{{ownedRelationship.Entity}}")]
    public virtual async Task<IActionResult> Delete{{entity.Name}}AllOwned{{ownedRelationship.Entity}}NonConventional({{ primaryKeysRoute }})
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAll{{ownedRelationshipName}}For{{entity.Name}}Command(new {{entity.Name}}KeyDto({{ primaryKeysQuery }}), etag));
        return NoContent();
    }
                {{- end }}
                {{- if ownedRelationship.Relationship == "ZeroOrMany" || ownedRelationship.Relationship == "OneOrMany" }}
    [HttpDelete("{{solution.Presentation.ApiConfiguration.ApiRoutePrefix}}/{{entity.PluralName}}/{key}/{{ownedRelationship.EntityPlural}}/{relatedKey}")]
    public virtual async Task<IActionResult> Delete{{entity.Name}}Owned{{ownedRelationship.Entity}}NonConventional({{ primaryKeysRoute }}, {{ ownedRelationship.primaryKeysRoute }})
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.Delete{{ownedRelationshipName}}For{{entity.Name}}Command(new {{entity.Name}}KeyDto({{ primaryKeysQuery }}), new {{ownedRelationship.Entity}}KeyDto({{ ownedRelationship.primaryKeysQuery }}), etag));
        return NoContent();
    }
                {{- end }}
            {{- end }}
        {{- end }}
    {{- end }}
}
