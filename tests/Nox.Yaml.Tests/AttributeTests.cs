
using FluentAssertions;
using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Sample.Models;
using System.Reflection;

namespace Nox.Yaml.Tests;

public class AttributeTests
{

    [Fact]
    public void Class_GenerateJsonSchemaAttribute_Equals_True()
    {
        // Arrange

        var type = typeof(SampleClass);

        // Act

        var attr = type.GetCustomAttribute<GenerateJsonSchemaAttribute>();

        // Assert

        attr.Should().NotBeNull();
    }

    [Fact]
    public void Class_TitleAttribute_Equals_Sample_class_title()
    {
        // Arrange

        var type = typeof(SampleClass);

        // Act

        var attr = type.GetCustomAttribute<TitleAttribute>();

        // Assert

        attr?.Title.Should().Be("Sample class title");
    }


    [Fact]
    public void Class_DescriptionAttribute_Equals_Sample_class_description()
    {
        // Arrange

        var type = typeof(SampleClass);

        // Act

        var attr = type.GetCustomAttribute<DescriptionAttribute>();

        // Assert

        attr?.Description.Should().Be("Sample class description");
    }

    [Fact]
    public void Class_AdditionalPropertiesAttribute_Equals_False()
    {
        // Arrange

        var type = typeof(SampleClass);

        // Act

        var attr = type.GetCustomAttribute<AdditionalPropertiesAttribute>();

        // Assert

        attr?.BoolValue.Should().Be(false);
    }

    [Fact]
    public void StringProperty_RequiredAttribute_Equals_True()
    {
        // Arrange

        var type = typeof(SampleClass);

        var prop = type.GetProperty(nameof(SampleClass.SampleString));

        // Act

        var attr = prop?.GetCustomAttribute<RequiredAttribute>();

        // Assert

        attr?.Should().NotBeNull();
    }

    [Fact]
    public void StringProperty_TitleAttribute_Equals_Sample_string_property_title()
    {
        // Arrange

        var type = typeof(SampleClass);

        var prop = type.GetProperty(nameof(SampleClass.SampleString));

        // Act

        var attr = prop?.GetCustomAttribute<TitleAttribute>();

        // Assert

        attr?.Title.Should().Be("Sample string property title");
    }

    [Fact]
    public void StringProperty_DescriptionAttribute_Equals_Sample_string_property_description()
    {
        // Arrange

        var type = typeof(SampleClass);

        var prop = type.GetProperty(nameof(SampleClass.SampleString));

        // Act

        var attr = prop?.GetCustomAttribute<DescriptionAttribute>();

        // Assert

        attr?.Description.Should().Be("Sample string property description");
    }

    [Fact]
    public void StringProperty_PatternAttribute_Equals_VariableRegexPattern()
    {
        // Arrange

        var type = typeof(SampleClass);

        var prop = type.GetProperty(nameof(SampleClass.SampleString));

        // Act

        var attr = prop?.GetCustomAttribute<PatternAttribute>();

        // Assert

        attr?.Value.Should().Be(Constants.YamlVariableRegex);
    }
}