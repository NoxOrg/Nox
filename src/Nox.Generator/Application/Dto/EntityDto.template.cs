// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using {{codeGeneratorState.DataTransferObjectsNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

public class {{entity.Name}}KeyDto
{    
{{- for key in entity.Keys }}

    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
    {{ if key.Type == "Entity" -}}
    public {{SingleKeyPrimitiveTypeForEntity key.EntityTypeOptions.Entity}} {{key.Name}} { get; set; } = default!;
    {{- else -}}
    public {{SinglePrimitiveTypeForKey key}} {{key.Name}} { get; set; } = default!;
    {{- end}}
{{- end }}
}

/// <summary>
/// {{entity.Description}}.
/// </summary>
public partial class {{className}} : {{entity.Name}}KeyDto
{
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
    {{- else}}
    public virtual {{relationship.Entity}}Dto {{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Entity}} { get; set; } = null!;
    {{-end}}
{{- end }}
{{- if !entity.IsOwnedEntity && entity.Persistence?.IsAudited == true #TODO do not expose DeletedAtUtc on end points??}}

    public System.DateTime? DeletedAtUtc { get; set; }
{{- end}}
}