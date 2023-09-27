// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
using System;
using System.Collections.Generic;

namespace {{codeGeneratorState.DomainNameSpace}};

/// <summary>
/// Static methods for the {{entity.Name}} class.
/// </summary>
public partial class {{className}}
{
{{- for entityMetaData in entitiesMetaData }}
    {{ if entityMetaData.HasTypeOptions == true }}
    /// <summary>
    /// Type options for property '{{entityMetaData.Name}}'
    /// </summary>
    public static Nox.Types.{{entityMetaData.Type}}TypeOptions {{entityMetaData.Name}}TypeOptions {get; private set;} = new ()
    {
        {{- for property in entityMetaData.OptionsProperties }}
        {{property}}
        {{- end }}
    };


    /// <summary>
    /// Factory for property '{{entityMetaData.Name}}'
    /// </summary>
    public static Nox.Types.{{entityMetaData.Type}} Create{{entityMetaData.Name}}({{entityMetaData.InParams}})
        => Nox.Types.{{entityMetaData.Type}}.From(value, {{entityMetaData.Name}}TypeOptions);
    {{ else }}
    /// <summary>
    /// Factory for property '{{entityMetaData.Name}}'
    /// </summary>
    public static Nox.Types.{{entityMetaData.Type}} Create{{entityMetaData.Name}}({{entityMetaData.InParams}})
        => Nox.Types.{{entityMetaData.Type}}.From(value);
    {{ end }}
{{- end }}

    {{- for attribute in entity.Attributes }}

        /// <summary>
        /// User Interface for property '{{attribute.Name}}'
        /// </summary>
        public static TypeUserInterface? {{attribute.Name}}UserInterface(NoxSolution solution) 
            => solution.Domain?
                .Entities?.FirstOrDefault(e => e.Name == "{{entity.Name}}")?
                .Attributes?.FirstOrDefault(a => a.Name == "{{attribute.Name}}")?
                .UserInterface;
    {{- end }}
}