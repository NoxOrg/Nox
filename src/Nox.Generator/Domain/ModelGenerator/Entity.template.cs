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
    public {{NoxGetSimpleKeyTypeForEntity key.EntityTypeOptions.Entity}} {{ CodeGeneratorStateGetForeignKeyPropertyName key}} { get; set; } = null!;
    {{- # Navigation Property }}

    public virtual {{key.EntityTypeOptions.Entity}} {{key.Name}} { get; set; } = null!;

    {{- else if key.Type == "Nuid" -}}
    {{- codeGeneratorNuidGetter = "Nuid.From(string.Join(\""+key.NuidTypeOptions.Separator +"\", "+ (key.NuidTypeOptions.PropertyNames | array.join "," @(do; ret $0 + ".Value.ToString()"; end)) +"))" -}}
    public {{key.Type}} {{key.Name}} {get; private set;}

	public void Persist{{ key.Name}}()
	{
		if(key.Name == null)
		{
			key.Name = Nuid.From(Name.Value.ToString());
		}
		else
		{
			var currentNuid = {{codeGeneratorNuidGetter}};
			if(Id != currentNuid)
			{
				throw new ApplicationException("Immutable nuid property {{key.Name}} value is different since it has been initialized");
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
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{Pluralize relationship.Entity}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{Pluralize relationship.Entity}} { get; set; } = new();
    {{- if Pluralize relationship.Entity != relationship.Name}}
    
    public List<{{relationship.Entity}}> {{relationship.Name}} => {{Pluralize relationship.Entity}};
    {{- end}}
    {{- else}}

    public virtual {{relationship.Entity}} {{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{Pluralize relationship.Entity}} { get; set; } = null!;
    {{-end}}
{{- end }}
{{- for relationship in entity.OwnedRelationships #TODO how to reuse as partail templaye?}}
    /// <summary>
    /// {{entity.Name}} {{relationship.Description}} {{relationship.Relationship}} {{Pluralize relationship.Entity}}
    /// </summary>
    {{- if relationship.Relationship == "ZeroOrMany" || relationship.Relationship == "OneOrMany"}}
    public virtual List<{{relationship.Entity}}> {{Pluralize relationship.Entity}} { get; set; } = new();
    {{- if (Pluralize relationship.Entity) != relationship.Name}}
    
    public List<{{relationship.Entity}}> {{relationship.Name}} => {{Pluralize relationship.Entity}};
    {{- end}}
    {{- else}}

    public virtual {{relationship.Entity}} {{if relationship.Relationship == "ZeroOrOne"}}?{{end}} {{Pluralize relationship.Entity}} { get; set; } = null!;
    {{-end}}
{{- end }}
}