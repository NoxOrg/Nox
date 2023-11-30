// Generated

#nullable enable
using Nox.Types;
using Microsoft.EntityFrameworkCore;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

{{~ for noxType in compoundTypes ~}}
[Owned]
public class {{noxType.NoxType}}Dto: I{{noxType.NoxType}}, IWritable{{noxType.NoxType}}
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
}
{{~ end ~}}