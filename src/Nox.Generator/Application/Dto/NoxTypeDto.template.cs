// Generated

#nullable enable
using Nox.Types;
using Microsoft.EntityFrameworkCore;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

{{~ for noxType in compoundTypes ~}}
{{~ 
        size = noxType.Components | array.size 
        lastName = noxType.Components[size-1].Name
    ~}}
[Owned]
public record {{noxType.NoxType}}Dto: I{{noxType.NoxType}}
{    
    public {{noxType.NoxType}}Dto(            
            {{- for component in noxType.Components -}}
            {{component.UnderlyingType}} {{ToLowerFirstChar component.Name}}{{- if component.Name != lastName -}},{{- end -}}
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
}
{{~ end ~}}