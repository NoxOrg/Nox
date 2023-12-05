{{- func attributeType(attribute)
   ret IsNoxTypeSimpleType attribute.Type ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

internal static class {{className}}
{
    public static {{entity.Name}}Dto ToDto(this {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}} entity)
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
{{- #Relationships are not expanded when mapping an entity to a dto. Use Query Instead}}	
{{- for relationship in entity.OwnedRelationships }}
	{{- relationshipName = GetNavigationPropertyName entity relationship }}
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        dto.SetIfNotNull(entity?.{{relationshipName}}, (dto) => dto.{{relationshipName}} = entity!.{{relationshipName}}.Select(e => e.ToDto()).ToList());
    {{- else}}
        dto.SetIfNotNull(entity?.{{relationshipName}}, (dto) => dto.{{relationshipName}} = entity!.{{relationshipName}}!.ToDto());
    {{-end}}
{{- end }}

        return dto;
    }
}