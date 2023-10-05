// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace }}.Dto;

public partial class {{className}} : {{className}}Base
{

}

/// <summary>
/// {{entity.Description}}.
/// </summary>
public abstract class {{className}}Base : IEntityDto<{{entity.Name}}Entity>
{
{{- for key in entity.Keys }}
    {{- if key.Type == "Nuid" || key.Type == "AutoNumber" -}}
    {{ continue; -}}
    {{- else if key.Type == "Guid" -}}

    /// <summary>
    /// {{key.Description}} (Optional).
    /// </summary>
    {{- else }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
    [Required(ErrorMessage = "{{key.Name}} is required")]
    {{- end }}
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
    public virtual {{componentsInfo[attribute.Name].ComponentType}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- else -}}
    public virtual {{attribute.Type}}Dto{{- if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
    {{- end}}
{{- end }}

{{- for relationship in entity.Relationships}}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.WithSingleEntity }}
    public {{relationship.ForeignKeyPrimitiveType}}? {{relationship.Name}}Id { get; set; } = default!;
    {{#Simplify Avoid complexity by not allowing circular dependency between dtos
    #User Can set a relationship on the creation phase using the id (entity already exists), for single relations}}
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual {{relationship.Entity}}CreateDto? {{relationship.Name}} { get; set; } = default!;
    {{- else }}
    {{#Simplify Avoid complexity by not allowing circular dependency between dtos
    #TODO Allow to set a list of Ids for a *ToMany relations}}
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<{{relationship.Entity}}CreateDto> {{relationship.Name}} { get; set; } = new();
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships #TODO how to reuse as partial template?}}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}CreateDto> {{relationship.Name}} { get; set; } = new();
    {{- else}}
    public virtual {{relationship.Entity}}CreateDto{{- if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Name}} { get; set; } = null!;
    {{-end}}
{{- end }}
}