// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace {{codeGeneratorState.DomainNameSpace}};
public partial class {{className}}:{{className}}Base
{

}
{{- if entity.Persistence.Create.RaiseEvents }}
/// <summary>
/// Record for {{entity.Name}} created event.
/// </summary>
public record {{entity.Name}}Created({{entity.Name}} {{entity.Name}}) : IDomainEvent;
{{- end}}

{{- if entity.Persistence.Update.RaiseEvents }}
/// <summary>
/// Record for {{entity.Name}} updated event.
/// </summary>
public record {{entity.Name}}Updated({{entity.Name}} {{entity.Name}}) : IDomainEvent;
{{- end}}

{{- if entity.Persistence.Delete.RaiseEvents }}
/// <summary>
/// Record for {{entity.Name}} deleted event.
/// </summary>
public record {{entity.Name}}Deleted({{entity.Name}} {{entity.Name}}) : IDomainEvent;
{{- end}}

/// <summary>
/// {{entity.Description}}.
/// </summary>
public abstract class {{className}}Base{{ if !entity.IsOwnedEntity }} : {{if entity.Persistence?.IsAudited}}AuditableEntityBase, IEntityConcurrent{{else}}EntityBase, IEntityConcurrent{{end}}{{else}} : EntityBase, IOwnedEntity{{end}}
{
{{- for key in entity.Keys }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
    {{ if key.Type == "EntityId" -}}
    public {{SingleKeyTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = null!;
    {{- # Navigation Property }}

    public virtual {{key.EntityIdTypeOptions.Entity}} {{key.EntityIdTypeOptions.Entity}} { get; set; } = null!;

    {{- else if key.Type == "Nuid" -}}
	{{- prefix = key.NuidTypeOptions.Prefix | object.default entity.Name + key.NuidTypeOptions.Separator -}}
    {{- codeGeneratorNuidGetter = "Nuid.From(\""+prefix+"\" + string.Join(\""+key.NuidTypeOptions.Separator +"\", "+ (key.NuidTypeOptions.PropertyNames | array.join "," @(do; ret $0 + ".Value.ToString()"; end)) +"))" -}}
    public {{key.Type}} {{key.Name}} {get; set;} = null!;

	public virtual void Ensure{{ key.Name}}()
	{
		if({{key.Name}} is null)
		{
			{{key.Name}} = {{codeGeneratorNuidGetter}};
		}
		else
		{
			var currentNuid = {{codeGeneratorNuidGetter}};
			if({{key.Name}} != currentNuid)
			{
				throw new NoxNuidTypeException("Immutable nuid property {{key.Name}} value is different since it has been initialized");
			}
		}
	}

    {{- else -}}

    public Nox.Types.{{key.Type}} {{key.Name}} { get; set; } = null!;
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}

    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    {{ if attribute.Type == "Formula" -}}
    public {{attribute.FormulaTypeOptions.Returns}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}}
{ 
    get { return {{attribute.FormulaTypeOptions.Expression}}; }
    private set { }
}
    {{- else -}}
    public Nox.Types.{{attribute.Type}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } = null!;
    {{- end}}
{{- end }}
{{- ######################################### Relationships###################################################### -}}
{{- for relationship in entity.Relationships }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{relationship.Name}} { get; set; } = new();
    {{- else}}
    public virtual {{relationship.Entity}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Name}} { get; set; } = null!;
    {{- if relationship.ShouldGenerateForeignOnThisSide}}

    /// <summary>
    /// Foreign key for relationship {{relationship.Relationship}} to entity {{relationship.Entity}}
    /// </summary>
    public Nox.Types.{{relationship.Related.Entity.Keys[0].Type}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Name}}Id { get; set; } = null!;
    {{- end}}
    {{-end}}

    public virtual void CreateRefTo{{relationship.Entity}}{{relationship.Name}}({{relationship.Entity}} related{{relationship.Entity}})
    {
        {{- if relationship.WithSingleEntity }}
        {{relationship.Name}} = related{{relationship.Entity}};
        {{- else}}
        {{relationship.Name}}.Add(related{{relationship.Entity}});
        {{- end }}
    }
{{- end }}
{{- for relationship in entity.OwnedRelationships #TODO how to reuse as partial template?}}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{relationship.EntityPlural}} { get; set; } = new();
    {{- if (relationship.EntityPlural) != relationship.Name}}

    public List<{{relationship.Entity}}> {{relationship.Name}} => {{relationship.EntityPlural}};
    {{- end}}
    {{- else}}
     public virtual {{relationship.Entity}}{{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.Entity}} { get; set; } = null!;
    {{-end}}
{{- end }}

{{ if !entity.IsOwnedEntity ~}}
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
{{ end ~}}
}