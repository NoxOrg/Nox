// Generated

#nullable enable
using Nox.Types;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

internal static class {{className}}
{
{{- for noxType in compoundTypes }}
{{- if noxType.NoxType == "EntityId" -}}
{{ continue; }}
{{ end }}
    public static {{noxType.NoxType}}Dto ToDto(this Nox.Types.{{noxType.NoxType}} {{noxType.NoxType}})
        => new({{- noxType.Components | array.join ", " -}});
{{ end }}
}