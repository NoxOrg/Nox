// Generated

#nullable enable

using Nox.Integration.Abstractions.Interfaces;

namespace {{codeGenConventions.ApplicationNameSpace}}.Integration.CustomTransform;
{{-func getCSharpDataType(sourceType)
    case sourceType
        when "Integer"
            ret "System.Int32"
        when "Double"
            ret "System.Double"
        when "Bool"
            ret "System.Boolean"
        when "String"
            ret "System.String"
        when "Date"
            ret "System.DateOnly"
        when "Time"
            ret "System.TimeOnly"
        when "DateTime"
            ret "System.DateTime"
        when "Guid"
            ret "System.Guid"
        else
            ret "unknown"
    end 
end}}

{{-func getNonNullValue(sourceType)
   case sourceType
       when "String"
           ret " = String.Empty;"
       else
            ret ""
   end             
end}}

public sealed class {{className}}: INoxTransformDto
{
    {{- for map in transformation.Mapping }}
    {{if (map.Source) }}public {{ getCSharpDataType map.Source.Type }}{{ if !map.IsRequired}}?{{end}} {{ map.Source.Name | string.capitalize }} { get; set; }{{ if map.IsRequired }}{{ getNonNullValue map.Source.Type }}{{ end }}{{ end }}
{{- end }}
}