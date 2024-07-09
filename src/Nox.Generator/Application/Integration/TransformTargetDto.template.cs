// Generated
#nullable enable

{{if (hasEntity)}}using Nox.Integration.Abstractions.Models;{{ else }}using ETLBox.DataFlow;{{- end}}

namespace {{codeGenConventions.ApplicationNameSpace}}.Integration.CustomTransform;

public sealed class {{className}}: {{if (hasEntity)}}NoxEntityTargetDto{{ else  }}MergeableRow{{end}}
{
    {{- for map in mappingList }}
    public {{ map.DataTypeName }} {{ map.Name | string.capitalize }} { get; set; }{{ map.Default }}
    {{- end }}
}