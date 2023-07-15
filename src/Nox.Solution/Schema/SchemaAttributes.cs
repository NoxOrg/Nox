using System;

namespace Nox.Solution.Schema;

public class RequiredAttribute : Attribute 
{ 
    public RequiredAttribute() 
    { 
    } 
}

public class IgnoreAttribute : Attribute
{
    public IgnoreAttribute()
    {
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class GenerateJsonSchema : Attribute
{
    public string? SchemaName { get; private set; }

    public GenerateJsonSchema(string? schemaName = null)  
    {
        SchemaName = schemaName;
    }
}

public class AdditionalPropertiesAttribute : Attribute 
{ 
    public bool BoolValue { get; private set; }
    public AdditionalPropertiesAttribute(bool boolValue)
    { 
        BoolValue = boolValue;
    } 
}

public class DescriptionAttribute : Attribute 
{ 
    public string Description { get; private set; }

    public DescriptionAttribute(string description) 
    {
        Description = description;
    } 
}

public class TitleAttribute : Attribute 
{
    public string Title { get; private set; }

    public TitleAttribute(string title) 
    {
        Title = title;
    } 
}

public class PatternAttribute : Attribute
{
    public string Value { get; private set; }
    public PatternAttribute(string value)
    {
        Value = value;
    }
}

public class IfEqualsAttribute : Attribute
{
    public string Property { get; private set; }

    public object Value { get; private set; }

    public IfEqualsAttribute(string propertyName, object value)
    {
        Property = propertyName;
        Value = value;
    }
}

