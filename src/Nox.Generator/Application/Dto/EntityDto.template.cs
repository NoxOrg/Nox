// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using {{codeGeneratorState.DataTransferObjectsNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

public record {{entity.Name}}KeyDto({{primaryKeys}});

/// <summary>
/// {{entity.Description}}.
/// </summary>
public partial class {{className}}
{
{{- for key in entity.Keys }}

    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
    {{ if key.Type == "EntityId" -}}
    public {{SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = default!;
    {{- else -}}
    public {{SinglePrimitiveTypeForKey key}} {{key.Name}} { get; set; } = default!;
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}
    {{- if !IsNoxTypeReadable attribute.Type -}}
        {{ continue; }}
    {{- end}}

    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    {{ if IsNoxTypeSimpleType attribute.Type -}}
        {{- if attribute.Type == "Formula" -}}
    [NotMapped]
        {{- end -}}
    public {{SinglePrimitiveTypeForKey attribute}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- else -}}
    public {{attribute.Type}}Dto{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- end}}
{{- end }}
{{- ######################################### Relationships###################################################### -}}
{{- for relationship in entity.Relationships }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}Dto> {{relationship.EntityPlural}} { get; set; } = new();
    {{- else}}
        {{- if relationship.ShouldGenerateForeignOnThisSide}}
    //EF maps ForeignKey Automatically
    public virtual string {{if relationship.Relationship == "ZeroOrOne"}}?{{end}}{{relationship.Entity}}Id { get; set; } = null!;
        {{- end}}
    public virtual {{relationship.Entity}}Dto {{if relationship.Relationship == "ZeroOrOne"}}?{{end}}{{relationship.Entity}} { get; set; } = null!;
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships #TODO how to reuse as partial template?}}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}Dto> {{relationship.EntityPlural}} { get; set; } = new();
    {{- if (relationship.EntityPlural) != relationship.Name}}

    public List<{{relationship.Entity}}Dto> {{relationship.Name}} => {{relationship.EntityPlural}};
    {{- end}}
    {{- else}}
    public virtual {{relationship.Entity}}Dto {{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.EntityPlural}} { get; set; } = null!;
    {{-end}}
{{- end }}
{{- if entity.Persistence?.IsVersioned == true #TODO do not expose Deleted on end points??}}

    public bool? Deleted { get; set; }

    public {{ entity.Name }} ToEntity()
    {
        var entity = new {{ entity.Name }}();
        {{- for key in entity.Keys }}
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
        entity.{{ attribute.Name}} = {{ entity.Name }}.Create{{ attribute.Name }}({{attribute.Name}}.NonNullValue<{{SinglePrimitiveTypeForKey attribute}}>());
    {{- else -}}
        entity.{{attribute.Name}} = {{ entity.Name }}.Create{{ attribute.Name }}({{attribute.Name}}.NonNullValue<{{attribute.Type}}Dto>());
    {{- end}}

        {{- else }}
        entity.{{attribute.Name}} = {{ entity.Name }}.Create{{ attribute.Name }}({{ attribute.Name }});
        {{- end }}
        {{- end }}
        {{- for relationship in entity.OwnedRelationships }}
            {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
        entity.{{relationship.EntityPlural}} = {{relationship.EntityPlural}}.Select(dto => dto.ToEntity()).ToList();
            {{- else}}
            {{relationship.EntityPlural}} = {{relationship.EntityPlural}}.ToEntity(),
            {{-end}}
        {{- end }}
        return entity;
    }

{{- end}}
}