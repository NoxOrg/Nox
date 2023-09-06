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
public partial class {{className}} 
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
   
{{- for attribute in entity.Attributes }}    
    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    {{- if attribute.IsRequired}}
    [Required(ErrorMessage = "{{attribute.Name}} is required")]
    {{ end}}
    {{ if componentsInfo[attribute.Name].IsSimpleType -}}
    public {{componentsInfo[attribute.Name].ComponentType}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- else -}}
    public {{attribute.Type}}Dto{{- if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- end}}
{{- end }}

{{- for relationship in entity.Relationships}}
    {{- if relationship.WithSingleEntity && relationship.ShouldGenerateForeignOnThisSide}}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{ if relationship.Relationship == "ExactlyOne" }}[Required(ErrorMessage = "{{relationship.Name}} is required")]{{-end}}
    public System.{{relationship.ForeignKeyPrimitiveType}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Name}}Id { get; set; } = default!;
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships #TODO how to reuse as partial template?}}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}CreateDto> {{relationship.EntityPlural}} { get; set; } = new();
    {{- else}}
    public virtual {{relationship.Entity}}CreateDto{{- if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Entity}} { get; set; } = null!;
    {{-end}}
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
        entity.{{relationship.EntityPlural}} = {{relationship.EntityPlural}}.Select(dto => dto.ToEntity()).ToList();
            {{- else}}
        entity.{{relationship.Entity}} = {{relationship.Entity}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}}.ToEntity();
            {{-end}}
        {{- end }}
        return entity;
    }
}