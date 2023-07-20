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

    public {{key.Type}} {{key.Name}} 
    {
        get => {{CodeGeneratorPrivateFieldName key}} ?? {{CodeGeneratorNuidGetter key}};
        private set 
        {
            var actualNuid = {{CodeGeneratorNuidGetter key}};
            if (value is null)
            {
                {{CodeGeneratorPrivateFieldName key}} = actualNuid;
            }
            else if (value is not null && {{CodeGeneratorPrivateFieldName key}} is null)
            {
                {{CodeGeneratorPrivateFieldName key}} = value;
            }
            else if (value is not null && {{CodeGeneratorPrivateFieldName key}} is not null && {{CodeGeneratorPrivateFieldName key}} != value)
            {
                throw new InvalidOperationException("Nuid has diffrent value than it has been generated.");
            }
        }
    }

    private {{key.Type}} {{CodeGeneratorPrivateFieldName key}} = null!;    

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