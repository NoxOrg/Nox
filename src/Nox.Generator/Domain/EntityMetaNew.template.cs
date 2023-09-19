// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace {{codeGeneratorState.DomainNameSpace}};
{{ func factorial(n)
    if n <= 1
        ret 1
    else
        ret n * factorial(n - 1)
    end
end}}
{{func writeProperty(property)
        
    $assignOp =" = "
    if property.Name == ""  
        $assignOp = ""
    end    
        
    $result = ""
    if property.Type == ""
        $result = property.Name + $assignOp + 'null,'
    else if property.Type == "Uri"
        $result = property.Name + $assignOp + 'new System.Uri('+property.Value+'),'
    else if property.Type == "Guid"
        $result = property.Name + $assignOp + 'new System.Guid('+property.Value+'),'
    else if property.Type == "DateTime"
        $result = property.Name + $assignOp + 'new System.DateTime(year: '+property.Value.Year+', month: '+property.Value.Month+', day: '+property.Value.Day+', hour: '+property.Value.Hour+', minute: '+property.Value.Minute+', second: '+property.Value.Second+', millisecond: '+property.Value.Millisecond+'),'
    else if property.Type == "DateTimeOffset"
        $result = property.Name + $assignOp + 'new System.DateTimeOffset(year: '+property.Value.Year+', month: '+property.Value.Month+', day: '+property.Value.Day+', hour: '+property.Value.Hour+', minute: '+property.Value.Minute+', second: '+property.Value.Second+', millisecond: '+property.Value.Millisecond+', new System.TimeSpan('+property.Value.Offset.Ticks+')),'
    else if property.Type == "TimeSpan"
        $result = property.Name + $assignOp + 'new System.TimeSpan(ticks: '+property.Value.Ticks+' ),'
    else if property.Type == "SimpleType"
        $result = property.Name + $assignOp + property.Value+','
    else if property.Type == "Enum"
        $result = property.Name + $assignOp + property.Value+','
    else if property.Type == "String"
        $result = property.Name + $assignOp + '"' + property.Value + '",'
    else if property.Type == "Array"
        $result = property.Name+ $assignOp + 'new '+property.Value.ElementTypeName+'[]\n{'
        $itemsCode = ""
        for item in property.Value.Properties
            $itemsCode +='\n'
            $itemsCode +='    ' + writeProperty(item)
        end
        $result += $itemsCode + '\n},'
    else if property.Type == "IList"
        $result = property.Name+ $assignOp + 'new System.Collections.Generic.List<'+property.Value.ElementTypeName+'>()\n{'
        $itemsCode = ""
        for item in property.Value.Properties
            $itemsCode +='\n'
            $itemsCode +='    ' + writeProperty(item)
        end
        $result += $itemsCode + '\n},'
    else if property.Type == "IDictionary"
        $result = property.Name+ $assignOp + 'new System.Collections.Generic.Dictionary<'+ property.Value.KeyTypeName +','+ property.Value.ValueTypeName +'>()\n{'
        $itemsCode = ""
        for item in property.Value.Properties
            $itemsCode +='\n'
            $itemsCode +='    ' + writeProperty(item)
        end
            $result += $itemsCode + '\n},'
    else
        $result= property.Name+ $assignOp + 'new '+property.Type+'()\n{'
        $itemsCode = ""
        for item in property.Value.Properties
            $itemsCode +='\n'
            $itemsCode +='    ' + writeProperty(item)
        end
            $result += $itemsCode + '\n},'    
    end
    
    ret $result
        
end}}
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
            {{ writeProperty(property) }}
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