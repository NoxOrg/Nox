// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace {{codeGeneratorState.DomainNameSpace}};

/// <summary>
/// {{entity.Description}}.
/// </summary>
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

    {{- else if key.Type == "Nuid" -}}
	{{- prefix = key.NuidTypeOptions.Prefix | object.default entity.Name + key.NuidTypeOptions.Separator -}}
    {{- codeGeneratorNuidGetter = "Nuid.From(\""+prefix+"\" + string.Join(\""+key.NuidTypeOptions.Separator +"\", "+ (key.NuidTypeOptions.PropertyNames | array.join "," @(do; ret $0 + ".Value.ToString()"; end)) +"))" -}}
    public {{key.Type}} {{key.Name}} {get; private set;} = null!;

	public void Ensure{{ key.Name}}()
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

    public {{key.Type}} {{key.Name}} { get; set; } = null!; 
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}

    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    public {{attribute.Type}}{{if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } = null!;
{{- end }}
{{- ######################################### Relationships###################################################### -}}
{{- for relationship in entity.Relationships }}

    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{relationship.EntityPlural}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{relationship.EntityPlural}} { get; set; } = new();
    {{- if relationship.EntityPlural != relationship.Name}}

    public List<{{relationship.Entity}}> {{relationship.Name}} => {{relationship.EntityPlural}};
    {{- end}}
    {{- else}}
    public virtual {{relationship.Entity}} {{if relationship.Relationship == "ZeroOrOne"}}?{{end}}{{relationship.Entity}} { get; set; } = null!;
    {{-end}}
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
    public virtual {{relationship.Entity}} {{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{relationship.EntityPlural}} { get; set; } = null!;
    {{-end}}
{{- end }}
}