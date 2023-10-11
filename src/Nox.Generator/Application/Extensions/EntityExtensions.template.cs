﻿{{- func attributeType(attribute)
   ret IsNoxTypeSimpleType attribute.Type ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

internal static class {{className}}
{
    public static {{entity.Name}}Dto ToDto(this {{entity.Name}} entity)
    {
        var dto = new {{entity.Name}}Dto();
{{- for key in entity.Keys }}
        dto.SetIfNotNull(entity?.{{key.Name}}, (dto) => dto.{{key.Name}} = entity!.{{key.Name}}.Value);
{{- end }}
{{- for attribute in entity.Attributes }}
{{- if !IsNoxTypeReadable attribute.Type -}}
    {{ continue; }}
{{- end }}
        dto.SetIfNotNull(entity?.{{attribute.Name}}, (dto) => dto.{{attribute.Name}} = 
    {{- if IsNoxTypeSimpleType attribute.Type -}}
        {{- if attribute.Type == "Time" -}}System.DateTime.Parse(entity!.{{attribute.Name}}!.Value.ToLongTimeString())
        {{- else -}}{{- if attribute.Type == "Formula" -}}entity!.{{attribute.Name}}!.ToString()
        {{- else -}}entity!.{{attribute.Name}}!.Value{{- if attribute.Type == "Url" || attribute.Type == "Uri" -}}.ToString(){{end}}{{- if attribute.Type == "Date"}}.ToDateTime(new System.TimeOnly(0, 0, 0)){{end}}{{- end -}}{{- end -}}
    {{- else -}}entity!.{{attribute.Name}}!.ToDto(){{- end -}});
{{- end }}
{{- for relationship in entity.Relationships }}
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        dto.SetIfNotNull(entity?.{{relationship.Name}}, (dto) => dto.{{relationship.Name}} = entity!.{{relationship.Name}}.Select(e => e.ToDto()).ToList());
    {{- else}}
        {{- if relationship.ShouldGenerateForeignOnThisSide}}
        dto.SetIfNotNull(entity?.{{relationship.Name}}Id, (dto) => dto.{{relationship.Name}}Id = entity!.{{relationship.Name}}Id!.Value);
        {{- end}}
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships }}
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        dto.SetIfNotNull(entity?.{{relationship.Name}}, (dto) => dto.{{relationship.Name}} = entity!.{{relationship.Name}}.Select(e => e.ToDto()).ToList());
    {{- else}}
        dto.SetIfNotNull(entity?.{{relationship.Name}}, (dto) => dto.{{relationship.Name}} = entity!.{{relationship.Name}}!.ToDto());
    {{-end}}
{{- end }}

        return dto;
    }
}