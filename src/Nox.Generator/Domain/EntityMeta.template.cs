// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace {{codeGeneratorState.DomainNameSpace}};

/// <summary>
/// Static methods for the {{entity.Name}} class.
/// </summary>
public partial class {{className}}
{
{{- for td in typeDef }}
    {{ if td.OptionsOutput != "" }}
    /// <summary>
    /// Type options for property '{{td.Name}}'
    /// </summary>
    public static {{td.OptionsOutput}}
    {
        {{- for property in td.OptionsProperties }}
            {{property}}
        {{- end }}
    };


    /// <summary>
    /// Factory for property '{{td.Name}}'
    /// </summary>
    public static {{td.Type}} Create{{td.Name}}({{td.InParams}})
        => Nox.Types.{{td.Type}}.From(value, {{td.Name}}TypeOptions);
    {{ else }}
    /// <summary>
    /// Factory for property '{{td.Name}}'
    /// </summary>
    public static Nox.Types.{{td.Type}} Create{{td.Name}}({{td.InParams}})
        => Nox.Types.{{td.Type}}.From(value);
    {{ end }}
{{- end }}
}