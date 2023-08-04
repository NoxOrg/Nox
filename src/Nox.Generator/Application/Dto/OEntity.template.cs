// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using AutoMapper;
using MediatR;
using Nox.Types;
using Nox.Domain;
using {{codeGeneratorState.DataTransferObjectsNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Dto;

/// <summary>
/// {{entity.Description}}.
/// </summary>
[AutoMap(typeof({{entity.Name}}CreateDto))]
public partial class {{className}} : {{if isVersioned}}AuditableEntityBase{{else}}EntityBase{{end}}
{
{{- for key in entity.Keys }}

    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
    {{ if key.Type == "Entity" -}}
    public {{SimpleKeyTypeForEntity key.EntityTypeOptions.Entity}} {{key.EntityTypeOptions.Entity}}Id { get; set; } = null!;
    {{- # Navigation Property }}
    public virtual {{key.EntityTypeOptions.Entity}} {{key.Name}} { get; set; } = null!;
    {{- else -}}
    public {{keysFlattenComponentsTypeName[key.Name]}} {{key.Name}} { get; set; } = null!; 
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}

    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    public {{keysFlattenComponentsTypeName[attribute.Name]}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } {{if attribute.IsRequired}}= default!;{{end}}
{{- end }}
{{- ######################################### Relationships###################################################### -}}
{{- for relationship in entity.Relationships }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<O{{relationship.Entity}}> {{relationship.EntityPlural}} { get; set; } = new();
    {{- if relationship.EntityPlural != relationship.Name}}

    public List<O{{relationship.Entity}}> {{relationship.Name}} => {{relationship.EntityPlural}};
    {{- end}}
    {{- else}}
    public virtual O{{relationship.Entity}} {{if relationship.Relationship == "ZeroOrOne"}}?{{end}}{{relationship.Entity}} { get; set; } = null!;
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships #TODO how to reuse as partial template?}}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
	[AutoExpand]
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{relationship.EntityPlural}} { get; set; } = new();
    {{- if (relationship.EntityPlural) != relationship.Name}}
    
    public List<O{{relationship.Entity}}> {{relationship.Name}} => {{relationship.EntityPlural}};
    {{- end}}
    {{- else}}
    public virtual O{{relationship.Entity}} {{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.EntityPlural}} { get; set; } = null!;
    {{-end}}
{{- end }}
}