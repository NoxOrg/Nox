// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

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
        {{- for property in entityMetaData.OptionProperties }}
        {{ if property.Type == "" }}
        {{property.Name}} = null,
        {{ else if property.Type == "Uri" }}
        {{property.Name}} = new System.Uri({{property.Value}}),
        {{ else if property.Type == "Guid" }}
        {{property.Name}} = new System.Guid({{property.Value}}),
        {{ else if property.Type == "DateTime" }}
        {{property.Name}} = new System.DateTime(year: {{property.Value.Year}}, month: {{property.Value.Month}}, day: {{property.Value.Day}}, hour: {{property.Value.Hour}}, minute: {{property.Value.Minute}}, second: {{property.Value.Second}}, millisecond: {{property.Value.Millisecond}}),
        {{ else if property.Type == "DateTimeOffset" }}
        {{property.Name}} = new System.DateTimeOffset(year: {{property.Value.Year}}, month: {{property.Value.Month}}, day: {{property.Value.Day}}, hour: {{property.Value.Hour}}, minute: {{property.Value.Minute}}, second: {{property.Value.Second}}, millisecond: {{property.Value.Millisecond}}, new System.TimeSpan({{property.Value.Offset.Ticks}})),
        {{ else if property.Type == "TimeSpan" }}
        {{property.Name}} = new System.TimeSpan(ticks: {{property.Value.Ticks}} ),
        {{ else if property.Type == "SimpleType" }}
        {{property.Name}} = {{property.Value}},
        {{ else if property.Type == "Enum" }}
        {{property.Name}} = {{property.Value}},
        {{ else if property.Type == "String" }}
        {{property.Name}} = "{{property.Value}}",
        {{ else }}
        //TODO: Add support for {{property.Type}}
        {{ end }}
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
}