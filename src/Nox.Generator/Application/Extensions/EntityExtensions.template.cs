{{- func attributeType(attribute)
   ret IsNoxTypeSimpleType attribute.Type ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable
using System;
using System.Linq;

using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

internal static class {{className}}
{
    public static {{entity.Name}}Dto ToDto(this {{entity.Name}} entity)
    {
        var dto = new {{entity.Name}}Dto();
{{- for key in entity.Keys }}
        SetIfNotNull(entity?.{{key.Name}}, () => dto.{{key.Name}} = entity!.{{key.Name}}.Value);
{{- end }}
{{- for attribute in entity.Attributes }}
{{- if !IsNoxTypeReadable attribute.Type -}}
    {{ continue; }}
{{- end }}
        SetIfNotNull(entity?.{{attribute.Name}}, () => dto.{{attribute.Name}} = 
    {{- if IsNoxTypeSimpleType attribute.Type -}}
        {{- if attribute.Type == "Time" -}}System.DateTime.Parse(entity!.{{attribute.Name}}!.Value.ToLongTimeString())
        {{- else -}}{{- if attribute.Type == "Formula" -}}entity!.{{attribute.Name}}!.ToString()
        {{- else -}}entity!.{{attribute.Name}}!.Value{{- if attribute.Type == "Url" || attribute.Type == "Uri" -}}.ToString(){{end}}{{- if attribute.Type == "Date"}}.ToDateTime(new System.TimeOnly(0, 0, 0)){{end}}{{- end -}}{{- end -}}
    {{- else -}}entity!.{{attribute.Name}}!.ToDto(){{- end -}});
{{- end }}
{{- for relationship in entity.Relationships }}
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        SetIfNotNull(entity?.{{relationship.Name}}, () => dto.{{relationship.Name}} = entity!.{{relationship.Name}}.Select(e => e.ToDto()).ToList());
    {{- else}}
        {{- if relationship.ShouldGenerateForeignOnThisSide}}
        SetIfNotNull(entity?.{{relationship.Name}}Id, () => dto.{{relationship.Name}}Id = entity!.{{relationship.Name}}Id!.Value);
        {{- end}}
        SetIfNotNull(entity?.{{relationship.Name}}, () => dto.{{relationship.Name}} = entity!.{{relationship.Name}}!.ToDto());
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships }}
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        SetIfNotNull(entity?.{{relationship.Name}}, () => dto.{{relationship.Name}} = entity!.{{relationship.Name}}.Select(e => e.ToDto()).ToList());
    {{- else}}
        SetIfNotNull(entity?.{{relationship.Name}}, () => dto.{{relationship.Name}} = entity!.{{relationship.Name}}!.ToDto());
    {{-end}}
{{- end }}

        return dto;
    }

    private static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }
}