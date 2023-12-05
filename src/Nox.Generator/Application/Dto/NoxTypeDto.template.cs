// Generated

#nullable enable
using Nox.Types;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

{{~ for noxType in compoundTypes ~}}
[Owned]
public class {{noxType.NoxType}}Dto: I{{noxType.NoxType}}, IWritable{{noxType.NoxType}}, INoxCompoundTypeDto
{    
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public {{noxType.NoxType}}Dto(){ } 
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public {{noxType.NoxType}}Dto(            
            {{- for component in noxType.Components -}}
            {{component.UnderlyingType}} {{ToLowerFirstChar component.Name}}{{if !for.last}},{{end}}
            {{- end -}}
    )
    {
        {{~ for component in noxType.Components ~}}
            {{component.Name}} = {{ToLowerFirstChar component.Name}};
        {{~ end ~}}
    }
    {{~ for component in noxType.Components ~}}
    public {{component.UnderlyingType}}{{ if !component.IsRequired}}?{{end}} {{component.Name}} { get;set;}
    {{~ end ~}}

#region UpdateFromDictionary
    public static void UpdateFromDictionary({{noxType.NoxType}}Dto {{ToLowerFirstChar noxType.NoxType}}, Dictionary<string, dynamic> updatedProperties)
    {
        {{- for component in noxType.Components }}
        if (updatedProperties.TryGetValue("{{component.Name}}", out var updated{{component.Name}}))
        {
            {{- if component.IsRequired }}
            if (updated{{component.Name}} == null) throw new ArgumentException("Property '{{component.Name}}' can't be null.");
            {{- end }}
            {{ToLowerFirstChar noxType.NoxType}}.{{component.Name}} = updated{{component.Name}};
        }
        {{- end }}
    }
#endregion

}
{{~ end ~}}