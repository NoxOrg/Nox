using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using YamlDotNet.Serialization;
using Nox.Solution.Extensions;

namespace Nox.Solution.Schema;

internal class SchemaProperty
{
    public string? Name { get; private set; }
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public string? Type { get; private set; }
    public string? TypeConst { get; private set; }
    public string? Format { get; private set; }
    public List<string>? Enum { get; private set; }
    public string? Pattern { get; private set; }
    public bool? AdditionalProperties { get; private set; }
    public object? AdditionalPropertiesObject { get; private set; }
    public List<string>? Required { get; private set; }
    public Dictionary<string, SchemaProperty>? Properties { get; private set; }
    public List<SchemaProperty>? AnyOf { get; private set; }
    public SchemaProperty? Items { get; private set; }

    
    public bool IsRequired { get; private set; }
    public bool Ignore { get; private set; }
    public bool SuppressProperties { get; private set; }
    public Type ActualType { get; private set; }
    public Type UnderlyingType { get; private set; }
    public bool IsNullable { get; private set; }
    public bool GenerateSchema { get; private set; }
    public string? SchemaName { get; private set; } 
    public IfEqualsAttribute? Conditional { get; private set; }

    public SchemaProperty(MemberInfo info, Type? type = null)
    {
        ActualType = type ?? (Type)info;

        UnderlyingType = Nullable.GetUnderlyingType(ActualType) ?? ActualType;

        IsNullable = ActualType.IsNullable();

        GenerateSchema = info.GetCustomAttribute<GenerateJsonSchema>(false) != null;

        if (GenerateSchema)
        {
            SchemaName = info.GetCustomAttribute<GenerateJsonSchema>(false)?.SchemaName ?? UnderlyingType.Name.ToCamelCase();
        }

        Name = (info.GetCustomAttribute<YamlMemberAttribute>()?.Alias ?? info.Name).ToCamelCase();
        
        Type = ToJsonSchemaType(UnderlyingType);

        Format = ToJsonSchemaFormat(UnderlyingType);

        Enum = ToEnumValues(UnderlyingType);

        Title = info.GetCustomAttribute<TitleAttribute>(false)?.Title;

        Description = info.GetCustomAttribute<DescriptionAttribute>(false)?.Description;

        Pattern = info.GetCustomAttribute<PatternAttribute>(false)?.Value;

        AdditionalProperties = info.GetCustomAttribute<AdditionalPropertiesAttribute>(false)?.BoolValue;
        
        AdditionalPropertiesObject = ToJsonSchemaAdditionalProperties(UnderlyingType);

        SuppressProperties = AdditionalPropertiesObject is not null;

        IsRequired = info.GetCustomAttribute<RequiredAttribute>(false) != null;
        
        Ignore = info.GetCustomAttribute<IgnoreAttribute>(false) != null;

        Conditional = info.GetCustomAttribute<IfEqualsAttribute>(false);

    }

    public void AddRequired(string propertyName)
    {
        if (Required is null)
        {
            Required = new();
        }
        Required.Add(propertyName);
    }

    public void AddProperty(SchemaProperty schemaProperty)
    {
        if (Properties is null)
        {
            Properties = new();
        }
        Properties.Add(schemaProperty.Name!, schemaProperty);
    }

    public void SetItems(SchemaProperty schemaProperty)
    {
        Items = schemaProperty;
    }

    public void OverridePropertiesWith(SchemaProperty other)
    {
        Type = other.Type ?? Type;

        Format = other.Format ?? Format;
        
        Enum = other.Enum ?? Enum;

        Title = other.Title ?? Title;
        
        Description = other.Description ?? Description;
        
        Pattern = other.Pattern ?? Pattern;
        
        Properties = other.Properties ?? Properties;
        
        AdditionalProperties = other.AdditionalProperties ?? AdditionalProperties;

        AdditionalPropertiesObject = other.AdditionalPropertiesObject ?? AdditionalPropertiesObject;
        
        IsRequired = other.IsRequired || IsRequired;
        
        Required = other.Required ?? Required;
        
        Ignore = other.Ignore || Ignore;

        GenerateSchema = other.GenerateSchema || GenerateSchema;

        SchemaName = other.SchemaName ?? SchemaName;

        Conditional = other.Conditional ?? Conditional;

    }

    public void ProcessConditionals()
    {
        if (Properties is null) return;

        var conditionals = Properties.Where(p => p.Value.Conditional is not null);

        if (conditionals.Count() == 0) return;

        AnyOf = new();

        var nonConditionals = Properties.Where(p => p.Value.Conditional is null);

        var dependentProperties = conditionals.GroupBy(p => p.Value.Conditional!.Property);

        if (dependentProperties.Count() > 1)
        {
            return;
        }

        var dependentFieldName = dependentProperties.First().Key.ToCamelCase();
        var dependentField = nonConditionals.FirstOrDefault(p => p.Key == dependentFieldName).Value;

        if (dependentField is null || dependentField.Enum is null)
        {
            return;
        }

        var enums = dependentField.Enum.ToList();

        foreach (var conditional in conditionals) 
        {
            var sp = new SchemaProperty(ActualType);
            var fieldValue = conditional.Value.Conditional!.Value.ToString()!.ToCamelCase();

            foreach (var nonConditional in nonConditionals)
            {
                SchemaProperty propToAdd;

                if (dependentFieldName == nonConditional.Key)
                {
                    propToAdd = new(nonConditional.Value.UnderlyingType);
                    propToAdd.TypeConst = fieldValue;
                    propToAdd.Name = dependentFieldName;
                    propToAdd.Type = null;
                    propToAdd.Enum = null;
                    propToAdd.IsRequired = true;
                    propToAdd.IsNullable = false;
                    enums.Remove(fieldValue);
                }
                else
                {
                    propToAdd = nonConditional.Value;
                }

                sp.AddProperty(propToAdd);
                
                if (dependentFieldName == nonConditional.Key)
                {
                    sp.AddProperty(conditional.Value);
                }
            }
            
            sp.GenerateSchema = false;
            sp.IsNullable = false;
            sp.IsRequired = true;
            sp.Title = null;
            sp.Description = null;
            sp.Type = null;
            AnyOf.Add(sp);
        }

        var spRest = new SchemaProperty(ActualType);

        foreach (var nonConditional in nonConditionals)
        {
            SchemaProperty propToAdd;

            if (dependentFieldName == nonConditional.Key)
            {
                propToAdd = new(nonConditional.Value.UnderlyingType);
                propToAdd.Name = dependentFieldName;
                propToAdd.Enum = enums;
                propToAdd.IsNullable = false;
                propToAdd.IsRequired = true;
            }
            else
            {
                propToAdd = nonConditional.Value;
            }

            spRest.AddProperty(propToAdd);

        }

        spRest.GenerateSchema = false;
        spRest.IsNullable = false;
        spRest.IsRequired = true;
        spRest.Title = null;
        spRest.Description = null;
        AnyOf.Add(spRest);


        AdditionalProperties = true;
        Properties = null;
    }

    private static string ToJsonSchemaType(Type? type)
    {

        if (type is null)
        {
            return "null";
        }

        if (type == typeof(string))
        {
            return "string";
        }
        else if (type == typeof(bool))
        {
            return "boolean";
        }
        else if (type.IsIntegerType())
        {
            return "integer";
        }
        else if (type.IsDecimalType())
        {
            return "number";
        }
        else if (type == typeof(DateTime))
        {
            return "string";
        }
#if NET6_0_OR_GREATER
        else if (type == typeof(DateOnly))
        {
            return "string";
        }
        else if (type == typeof(TimeOnly))
        {
            return "string";
        }
#endif
        else if (type == typeof(TimeSpan))
        {
            return "string";
        }
        else if (type == typeof(Guid))
        {
            return "string";
        }
        else if (type == typeof(Uri))
        {
            return "string";
        }
        else if (type.IsEnum)
        {
            return "string";
        }
        else if (type.IsDictionary())
        {
            return "object";
        }
        else if (type.IsEnumerable())
        {
            return "array";
        }
        else
        {
            return "object";
        }
    }

    private static string? ToJsonSchemaFormat(Type? type)
    {
        if (type is null)
        {
            return null;
        }

        if (type == typeof(Uri))
        {
            return "uri";
        }
        else if (type == typeof(DateTime))
        {
            return "date-time";
        }
#if NET6_0_OR_GREATER
        else if (type == typeof(DateOnly))
        {
            return "date";
        }
        else if (type == typeof(TimeOnly))
        {
            return "time";
        }
#endif
        else if (type == typeof(TimeSpan))
        {
            return "duration";
        }
        else if (type == typeof(Guid))
        {
            return "uuid";
        }
        return null;
    }

    private static object? ToJsonSchemaAdditionalProperties(Type? type)
    {
        if (type is null)
        {
            return null;
        }

        if (type.IsDictionary())
        {
            return new { Type = "string" };
        }
        return null;
    }

    private static readonly Dictionary<Type, List<string>> _enumCache = new();

    internal static void ClearEnumCache()
    {
        _enumCache.Clear();
    }

    private static List<string>? ToEnumValues(Type? type)
    {
        if (type is null)
        {
            return null;
        }

        if (!type.IsEnum)
        {
            return null;
        }

        if (_enumCache.TryGetValue(type, out var values))
        {
            return values;
        }

        var enumNames = System.Enum.GetNames(type);

        if(enumNames.Length > 1) 
        {
            var firstLength = enumNames[0].Length;
            if (firstLength < 4 && enumNames.All(n => n.Length == firstLength)) // abbreviations or codes probably
            {
                values = enumNames.OrderBy(e => e).ToList();
                _enumCache.Add(type, values);
                return values;
            }
        }

        values = enumNames.Select(n => n.ToCamelCase()).OrderBy(e => e).ToList();
        _enumCache.Add(type, values);
        return values;
    }

}
