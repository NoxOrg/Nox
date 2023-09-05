// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace }}.Dto;

/// <summary>
/// {{entity.Description}}.
/// </summary>
public partial class {{className}} : {{entity.Name}}UpdateDto
{
{{- for key in entity.Keys }}
    {{- if key.Type == "Nuid" || key.Type == "DatabaseNumber" || key.Type == "DatabaseGuid" -}}
    {{ continue; -}}
    {{- end }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
    [Required(ErrorMessage = "{{key.Name}} is required")]
    {{ if key.Type == "EntityId" -}}
    public {{SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = default!;
    {{- else -}}
    public {{SinglePrimitiveTypeForKey key}} {{key.Name}} { get; set; } = default!;
    {{- end}}
{{- end }}

    public {{codeGeneratorState.DomainNameSpace}}.{{ entity.Name }} ToEntity()
    {
        var entity = new {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}();
        {{- for key in entity.Keys }}
            {{- if key.Type == "Nuid" || key.Type == "DatabaseNumber" || key.Type == "DatabaseGuid" -}}
                {{ continue; -}}
            {{- end }}
        entity.{{key.Name}} = {{ entity.Name }}.Create{{ key.Name }}({{ key.Name }});
        {{- end }}
        {{- for attribute in entity.Attributes }}
            {{- if !IsNoxTypeReadable attribute.Type -}}
                {{ continue; }}
            {{- end}}
            {{- if attribute.Type == "Formula" -}}
                {{ continue; }}
            {{- end}}
        {{- if !attribute.IsRequired }}
        if ({{ attribute.Name }} is not null)
    {{- if IsNoxTypeSimpleType attribute.Type -}}
        entity.{{ attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{ entity.Name }}.Create{{ attribute.Name }}({{attribute.Name}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>());
    {{- else -}}
        entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{ entity.Name }}.Create{{ attribute.Name }}({{attribute.Name}}.NonNullValue<{{attribute.Type}}Dto>());
    {{- end}}

        {{- else }}
        entity.{{attribute.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{ entity.Name }}.Create{{ attribute.Name }}({{ attribute.Name }});
        {{- end }}
        {{- end }}

        {{- for relationship in entity.Relationships }}
            {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        //entity.{{relationship.EntityPlural}} = {{relationship.EntityPlural}}.Select(dto => dto.ToEntity()).ToList();
            {{- else}}
        //entity.{{relationship.Entity}} = {{relationship.Entity}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}}.ToEntity();
            {{-end}}
        {{- end }}

        {{- for relationship in entity.OwnedRelationships }}
            {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        //entity.{{relationship.EntityPlural}} = {{relationship.EntityPlural}}.Select(dto => dto.ToEntity()).ToList();
            {{- else}}
        //entity.{{relationship.Entity}} = {{relationship.Entity}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}}.ToEntity();
            {{-end}}
        {{- end }}
        return entity;
    }
}