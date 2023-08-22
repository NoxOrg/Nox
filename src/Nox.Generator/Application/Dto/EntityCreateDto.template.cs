﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace {{codeGeneratorState.ApplicationNameSpace }}.Dto; 

/// <summary>
/// {{entity.Description}}.
/// </summary>
public partial class {{className}} : {{entity.Name}}UpdateDto
{
{{- for key in entity.Keys }}
    {{- if key.Type == "Nuid" || key.Type == "DatabaseNumber" || keyType == "DatabaseGuid" -}}
    {{ continue; -}}
    {{- end }}
    /// <summary>
    /// {{key.Description}} (Required).
    /// </summary>
    [Required(ErrorMessage = "{{key.Name}} is required")]
    {{ if key.Type == "Entity" -}}
    public {{SingleKeyPrimitiveTypeForEntity key.EntityTypeOptions.Entity}} {{key.Name}} { get; set; } = default!;
    {{- else -}}
    public {{SinglePrimitiveTypeForKey key}} {{key.Name}} { get; set; } = default!;
    {{- end}}
{{- end }}
}