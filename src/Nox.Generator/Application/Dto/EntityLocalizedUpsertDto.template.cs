{{- func attributeType(attribute)
   ret IsNoxTypeSimpleType attribute.Type ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace {{codeGeneratorState.ApplicationNameSpace }}.Dto;

/// <summary>
/// {{entity.Name}} Localized Upsert DTO.
/// </summary>
public partial class {{className}}
{ 
{{- for attribute in entityAttributesToLocalize }}
    /// <summary>
    /// {{attribute.Description |  string.rstrip}}
    /// </summary>
    /// <remarks>{{if attribute.IsRequired}}Required{{else}}Optional{{end}}.</remarks>
    public {{attributeType attribute}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
{{- end }}
}