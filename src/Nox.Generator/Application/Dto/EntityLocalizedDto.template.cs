{{- func attributeType(attribute)
   ret IsNoxTypeSimpleType attribute.Type ? (SinglePrimitiveTypeForKey attribute) : (attribute.Type + "Dto")
end -}}
// Generated
 
#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace {{codeGeneratorState.ApplicationNameSpace }}.Dto;

/// <summary>
/// {{entity.Description}} Localized DTO.
/// </summary>
internal partial class {{className}}
{
{{- for key in entity.Keys }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
{{- if key.Type == "EntityId" -}}
    public {{SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity}} {{key.Name}} { get; set; } = default!;
{{- else }}
    public {{SinglePrimitiveTypeForKey key}} {{key.Name}} { get; set; } = default!;
{{- end}}
{{ end }}
    public System.String {{codeGeneratorState.LocalizationCultureField}} { get; set; } = null!;
{{- for attribute in entityAttributesToLocalize }}
{{ if attribute.Type == "Text" }}
    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    public {{attributeType attribute}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; }{{if attribute.IsRequired}} = default!;{{end}}
{{- end }}
{{- end }}
}