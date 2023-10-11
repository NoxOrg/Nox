// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using {{codeGeneratorState.ApplicationNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Queries;
using {{codeGeneratorState.ApplicationNameSpace}}.Commands;

using Nox.Types;

namespace {{ codeGeneratorState.ODataNameSpace }};

public abstract partial class {{ entity.PluralName }}ControllerBase
{
    {{- for query in entity.Queries}}
    /// <summary>
    /// {{ EnsureEndsWith query.Description "." }}
    /// </summary>
    protected readonly {{query.Name}}QueryBase _{{ ToLowerFirstChar query.Name }};
    {{- end -}}

    {{- for query in entity.Queries -}}
    {{ inputParams = [] -}}
    {{- for parameter in query.RequestInput -}}
        {{- if parameter.Type == "EntityId" -}}
            {{ inputParams = inputParams | array.add parameter.EntityIdTypeOptions.Entity + " " + parameter.Name -}}
        {{- else }}
            {{ inputParams = inputParams | array.add parameter.Type + " " + parameter.Name -}}
        {{- end -}}
    {{- end }}
    /// <summary>
    /// {{ EnsureEndsWith query.Description "." }}
    /// </summary>
    [HttpGet("{{ query.Name }}")]
    public async Task<IResult> {{ query.Name }}Async({{ inputParams | array.join ", " }})
    {
        var result = await _{{ ToLowerFirstChar query.Name }}.ExecuteAsync({{ query.RequestInput | array.map "Name" | array.join ", " }});
        return Results.Ok(result);
    }
    {{- end }}
}
