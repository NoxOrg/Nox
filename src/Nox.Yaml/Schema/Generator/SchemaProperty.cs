using Nox.Yaml.Attributes;
using Nox.Yaml.Parser;
using Nox.Yaml.Extensions;
using System.Collections.Concurrent;
using System.Reflection;
using YamlDotNet.Serialization;

namespace Nox.Yaml.Schema.Generator;

/// <summary>
/// JSON schema structure for generating schema files with. Matches schema keywords and 
/// assigns supported JSON schema types and constraints.
/// </summary>
internal class SchemaProperty
{
    #region Properties matching JSON schema keywords
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
    public double? Minimum { get; private set; }
    public double? Maximum { get; private set; }
    #endregion

    #region Properties to support JSON schema generation
    public bool IsRequired { get; private set; }

    public bool IsVariableAllowed { get; private set; }
    public bool Ignore { get; private set; }
    public bool SuppressProperties { get; private set; }
    public Type ActualType { get; private set; }
    public Type UnderlyingType { get; private set; }
    public bool IsNullable { get; private set; }
    public bool GenerateSchema { get; private set; }
    public string? SchemaName { get; private set; }
    public IfEqualsAttribute? Conditional { get; private set; }
    public bool IsAnyOfSchema { get; private set; }

    public ExistInCollectionAttribute? ExistsInCollection { get; private set; } 
    public UniqueItemPropertiesAttribute? UniqueItemProperties { get; private set; } 
    public UniqueChildPropertyAttribute? UniqueChildProperty { get; private set; } 
    #endregion

    /// <summary>
    /// Creates a SchemaProperty based on a supplied Type or <see cref="System.Reflection.MemberInfo"/> instance. 
    /// </summary>
    public SchemaProperty(MemberInfo info, Type? type = null)
    {
        ActualType = type ?? (Type)info;

        UnderlyingType = Nullable.GetUnderlyingType(ActualType) ?? ActualType;

        IsNullable = ActualType.IsNullable();

        GenerateSchema = info.GetCustomAttribute<GenerateJsonSchemaAttribute>(false) != null;

        if (GenerateSchema)
        {
            SchemaName = info.GetCustomAttribute<GenerateJsonSchemaAttribute>(false)?.SchemaName ?? UnderlyingType.Name.ToCamelCase();
        }

        Name = (info.GetCustomAttribute<YamlMemberAttribute>()?.Alias ?? info.Name).ToCamelCase();

        Type = ToJsonSchemaType(UnderlyingType);

        Format = ToJsonSchemaFormat(UnderlyingType);

        Enum = ToEnumValues(UnderlyingType);

        Title = info.GetCustomAttribute<TitleAttribute>(true)?.Title;

        Description = info.GetCustomAttribute<DescriptionAttribute>(true)?.Description;

        Pattern = info.GetCustomAttribute<PatternAttribute>(true)?.Value;

        AdditionalProperties = info.GetCustomAttribute<AdditionalPropertiesAttribute>(true)?.BoolValue;

        AdditionalPropertiesObject = ToJsonSchemaAdditionalProperties(UnderlyingType);

        SuppressProperties = AdditionalPropertiesObject is not null;

        IsRequired = info.GetCustomAttribute<RequiredAttribute>(true) != null;

        Minimum = info.GetCustomAttribute<MinimumAttribute>(true)?.Value;
        
        Maximum = info.GetCustomAttribute<MaximumAttribute>(true)?.Value;

        IsVariableAllowed = info.GetCustomAttribute<AllowVariableAttribute>(true) != null;

        Ignore = info.GetCustomAttribute<IgnoreAttribute>(true) != null || info.GetCustomAttribute<YamlIgnoreAttribute>(true) != null;

        Conditional = info.GetCustomAttribute<IfEqualsAttribute>(true);

        ExistsInCollection = info.GetCustomAttribute<ExistInCollectionAttribute>(true);
        
        UniqueItemProperties = Type.Equals("array") ? info.GetCustomAttribute<UniqueItemPropertiesAttribute>(true) : null;

        UniqueChildProperty = info.GetCustomAttribute<UniqueChildPropertyAttribute>(true);

        IsAnyOfSchema = false;

    }

    /// <summary>
    /// Adds a required property to a SchemaProprty
    /// </summary>
    /// <param name="propertyName">The name of the required property</param>
    private void AddRequired(string propertyName)
    {
        Required ??= new();
        Required.Add(propertyName);
    }

    /// <summary>
    /// Adds a child <see cref="SchemaProperty"/> to a parent <see cref="SchemaProperty"/>.
    /// </summary>
    /// <param name="schemaProperty">The <see cref="SchemaProperty"/> to add.</param>
    public void AddProperty(SchemaProperty schemaProperty, bool forceRequired = false)
    {
        Properties ??= new();
        Properties.Add(schemaProperty.Name!, schemaProperty);

        var isRequired = ((schemaProperty.IsRequired && schemaProperty.Conditional is null) || forceRequired);

        if (isRequired && schemaProperty.Name is not null)
        {
            AddRequired(schemaProperty.Name);
        }
    }

    /// <summary>
    /// Sets the 'Items' keyword to a <see cref="SchemaProperty"/> for arrays and collections.
    /// </summary>
    /// <param name="schemaProperty"></param>
    public void SetItems(SchemaProperty schemaProperty)
    {
        Items = schemaProperty;
    }

    /// <summary>
    /// Sets the 'Pattern' keyword to a <see cref="SchemaProperty"/> for arrays and collections.
    /// </summary>
    /// <param name="pattern"></param>
    public void SetPatternIfNull(string? pattern)
    {
        Pattern ??= pattern;
    }

    /// <summary>
    /// Copies selected properties from another <see cref="SchemaProperty"/>.
    /// </summary>
    /// <param name="other"></param>
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

        Minimum = other.Minimum ?? Minimum;

        Maximum = other.Maximum ?? Maximum;

        Ignore = other.Ignore || Ignore;

        GenerateSchema = other.GenerateSchema || GenerateSchema;

        SchemaName = other.SchemaName ?? SchemaName;

        Conditional = other.Conditional ?? Conditional;

        AnyOf = other.AnyOf ?? AnyOf;

        UniqueChildProperty = other.UniqueChildProperty ?? UniqueChildProperty;

        UniqueItemProperties = other.UniqueItemProperties ?? UniqueItemProperties;

        ExistsInCollection = other.ExistsInCollection ?? ExistsInCollection;

    }

    /// <summary>
    /// Creates an "AnyOf" structure to match conditional Attributes to their constant values.
    /// </summary>
    public void CreateAnyOfFromConditionals()
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
                    propToAdd = new(nonConditional.Value.UnderlyingType)
                    {
                        TypeConst = fieldValue,
                        Name = dependentFieldName,
                        Type = null,
                        Enum = null,
                        IsRequired = true,
                        IsNullable = false
                    };
                    enums.Remove(fieldValue);
                }
                else
                {
                    propToAdd = nonConditional.Value;
                }

                sp.AddProperty(propToAdd);

                if (dependentFieldName == nonConditional.Key)
                {
                    sp.AddProperty(conditional.Value, conditional.Value.IsRequired);
                }
            }

            sp.GenerateSchema = false;
            sp.IsNullable = false;
            sp.IsRequired = true;
            sp.Title = null;
            sp.Description = null;
            sp.Type = null;
            sp.IsAnyOfSchema = true;
            AnyOf.Add(sp);
        }

        // Add default for unused enums

        if (enums.Count > 0)
        {
            var spRest = new SchemaProperty(ActualType);

            foreach (var nonConditional in nonConditionals)
            {
                SchemaProperty propToAdd;

                if (dependentFieldName == nonConditional.Key)
                {
                    propToAdd = new(nonConditional.Value.UnderlyingType)
                    {
                        Name = dependentFieldName,
                        Enum = enums,
                        IsNullable = nonConditional.Value.IsNullable,
                        IsRequired = nonConditional.Value.IsRequired,
                    };
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
            spRest.IsAnyOfSchema = true;
            AnyOf.Add(spRest);
        }

        AdditionalProperties = true;
        Properties = null;
    }

    /// <summary>
    /// Converts a Type to its corresponding JSON schema type
    /// </summary>
    /// <param name="type">The .NET type to convert.</param>
    /// <returns>A JSON schema type as a string.</returns>
    private static string ToJsonSchemaType(Type? type)
    {

        if (type is null) return "null";

        else if (type == typeof(string)) return "string";

        else if (type == typeof(bool)) return "boolean";

        else if (type.IsIntegerType()) return "integer";

        else if (type.IsDecimalType()) return "number";

        else if (type == typeof(DateTime)) return "string";
#if NET6_0_OR_GREATER
        else if (type == typeof(DateOnly))  return "string";

        else if (type == typeof(TimeOnly))  return "string";
#endif
        else if (type == typeof(TimeSpan)) return "string";

        else if (type == typeof(Guid)) return "string";

        else if (type == typeof(Uri)) return "string";

        else if (type.IsEnum) return "string";

        else if (type.IsDictionary()) return "object";

        else if (type.IsEnumerable()) return "array";

        else if (type == typeof(object)) return "any"; 

        return "object";
    }

    /// <summary>
    /// Converts a .NET type to a JSON schema "Format" if applicable.
    /// </summary>
    /// <param name="type">The .NET type to inspect.</param>
    /// <returns></returns>
    private static string? ToJsonSchemaFormat(Type? type)
    {
        if (type is null) return null;

        else if (type == typeof(Uri)) return "uri";

        else if (type == typeof(DateTime)) return "date-time";
#if NET6_0_OR_GREATER
        else if (type == typeof(DateOnly))  return "date";

        else if (type == typeof(TimeOnly))  return "time";
#endif
        else if (type == typeof(TimeSpan)) return "duration";

        else if (type == typeof(Guid)) return "uuid";

        return null;
    }

    /// <summary>
    /// Handles "additionalProperties" JSON schema keyword for Dictionaries
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static object? ToJsonSchemaAdditionalProperties(Type? type)
    {
        if (type is null) return null;

        else if (type.IsDictionary()) return new { Type = "string" };

        return null;
    }

    /// <summary>Cache for enum results</summary>
    private static readonly ConcurrentDictionary<Type, Lazy<string[]>> _enumCache = new();

    /// <summary>
    /// Converts enum values to JSON schema "enums". Converts them to camelCase if they don't look like codes or abbreviations.
    /// </summary>
    /// <param name="type">The .NET enumeration type.</param>
    /// <returns>A list of JSON schema enumerators.</returns>
    private static List<string>? ToEnumValues(Type? type)
    {
        if (type is null ) return null;
        Type? enumType = null;
        if (!type.IsEnum && !IsEnumerableOfEnum(type, out enumType)) return null;
        
        enumType ??= type;
        return _enumCache.GetOrAdd(type,
            key => new Lazy<string[]>(
                () => GetEnumValuesAsStringArray(enumType)
            )).Value.ToList();

    }
    
    private static string[] GetEnumValuesAsStringArray(Type type)
    {
        if (!type.IsEnum)
        {
            throw new ArgumentException("Type must be an enum", nameof(type));
        }

        var hasDisplayName = false;
        var enumNames = System.Enum.GetValues(type).Cast<Enum>().Select(enumValue =>
            {
                var field = type.GetField(enumValue.ToString());
                var attr = field.GetCustomAttribute<DisplayNameAttribute>();
                if (attr == null) return enumValue.ToString();
                hasDisplayName = true;
                return attr.DisplayName;
            })
            .OrderBy(e => e).ToArray();
            
        
        if (enumNames.Length > 1)
        {
            var firstLength = enumNames[0].Length;

            // don't camelCase abbreviations or codes (i.e. enums where all string values are the same length
            // and less than four characters long.

            if (firstLength < 4 && Array.TrueForAll( enumNames,n => n.Length == firstLength))
            {
                return enumNames;
            }
        }
        // Do not camelCase if enum values have a DisplayName attribute
        return hasDisplayName ? enumNames : enumNames.Select(n => n.ToCamelCase()).ToArray();
    }
    
    private static bool IsEnumerableOfEnum(Type type, out Type? enumType)
    {
         enumType = GetEnumerableTypes(type).FirstOrDefault(t => t.IsEnum);
         var result = enumType is not null;
         return result;
    }

    private static IEnumerable<Type> GetEnumerableTypes(Type type)
    {
        if (type is { IsInterface: true, IsGenericType: true }
            && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            yield return type.GetGenericArguments()[0];
        }

        foreach (var intType in type.GetInterfaces())
        {
            if (intType.IsGenericType
                && intType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                yield return intType.GetGenericArguments()[0];
            }
        }
    }


    /// <summary>
    /// Return an enumerator to process child properties of a property based on an existing instance 
    /// of a matching object.
    /// </summary>
    /// <param name="instance">The instance to match the AnyOf subschema and return applicable properties.</param>
    /// <returns>An enumerator of <see cref="SchemaProperty"/></returns>
    public IEnumerable<SchemaProperty> GetChildSchemaProperties(IDictionary<string, (object? Value, YamlLineInfo LineInfo)> instance)
    {
        if (Properties is not null)
        {
            foreach (var property in Properties) yield return property.Value;
        }

        if (Items is not null)
        {
            yield return Items;
        }

        if (AnyOf is not null && AnyOf.Count > 0 && AnyOf[0].Properties is not null)
        {
            var found = false;

            var constPropName = AnyOf[0].Properties!
                .First(kv => kv.Value.TypeConst is not null)
                .Value.Name;

            for (var i = 0; i < AnyOf.Count - 1; i++)
            {
                var property = AnyOf[i];

                if (property.Properties is null) continue;

                var constProp = property.Properties[constPropName!];

                if (constProp is null) continue;

                if (constProp.Name is null) continue;

                if (constProp.TypeConst is string constStr)
                {
                    if (instance.TryGetValue(constProp.Name, out var value))
                    {
                        if (value.Value!.Equals(constStr))
                        {
                            yield return property;
                            found = true;
                            break;
                        }
                    }
                }
            }
            if (!found)
            {
                yield return AnyOf.Last();
            }
        }
    }
}
