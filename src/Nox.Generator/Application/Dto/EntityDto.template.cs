// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
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
public partial class {{className}} 
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
    public {{entity.KeysFlattenComponentsType[key.Name]}} {{key.Name}} { get; set; } = default!; 
    {{- end}}
{{- end }}
{{- for attribute in entity.Attributes }}

    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    {{ if componentsInfo[attribute.Name].IsSimpleType -}}
        {{- if attribute.Type == "Formula" -}}
    [NotMapped]
        {{- end -}}
    public {{componentsInfo[attribute.Name].ComponentType}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } {{if attribute.IsRequired}}= default!;{{end}}
    {{- else -}}
    public {{attribute.Type}}Dto{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } {{if attribute.IsRequired}}= default!;{{end}}
    {{- end}}
{{- end }}


{{- if isVersioned #TODO do not expose Deleted on end points??}}
    public bool? Deleted { get; set; }
{{- end}}
}