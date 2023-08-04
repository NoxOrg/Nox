// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace {{codeGeneratorState.DataTransferObjectsNameSpace }};

/// <summary>
/// {{dto.Description}}.
/// </summary>
public partial class {{className}} : IDynamicDto
{
{{- for attribute in dto.Attributes }}
    /// <summary>
    /// {{attribute.Description}} ({{if attribute.IsRequired}}Required{{else}}Optional{{end}}).
    /// </summary>
    public {{attribute.Type}}{{ if !attribute.IsRequired}}?{{end}} {{attribute.Name}} { get; set; } = null!;
{{- end }}
}