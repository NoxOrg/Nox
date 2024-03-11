// Generated

#nullable enable

namespace {{codeGenConventions.ApplicationNameSpace}}.Integration.CustomTransform;
{{func getCSharpDataType(targetType)
    case targetType
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
public sealed class {{className}}
{
    {{- for map in transformation.Mapping }}
    public virtual {{ getCSharpDataType map.Value.TargetType }}? {{ map.Key | string.capitalize }} { get; set; }
    {{- end }}
}