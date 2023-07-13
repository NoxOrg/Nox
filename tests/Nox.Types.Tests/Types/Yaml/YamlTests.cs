using FluentAssertions;

namespace Nox.Types.Tests;


public class YamlTests
{
    private readonly string _fileRoot = "Types/Yaml/Samples";
    private readonly string _validFolder = "Valid";
    private readonly string _invalidFolder = "Invalid";
    private readonly string _equalFolder = "Equal";
    [Theory]
    [InlineData("simple.yaml")]
    [InlineData("complex.yaml")]
    [InlineData("complex-object.yaml")]
    [InlineData("array.yaml")]
    [InlineData("anchor.yaml")]
    
    public void Yaml_Constructor_ReturnsSameValue(string fileName)
    {
        string yamlString = System.IO.File.ReadAllText( Path.Combine(_fileRoot, _validFolder, fileName));
        
        // Arrange & Act
        var yaml = Yaml.From(yamlString);

        // Assert
        yaml.Value.Should().Be(yamlString);
    }
    
    
    [Theory]
    [InlineData("simple.yaml")]
    [InlineData("simple1.yaml")]
    [InlineData("simple2.yaml")]
    [InlineData("simple3.yaml")]
    [InlineData("complex.yaml")]
    [InlineData("complex-object.yaml")]
    [InlineData("complex-object1.yaml")]
    [InlineData("complex-object2.yaml")]
    [InlineData("array.yaml")]
    [InlineData("anchor.yaml")] //#TODO: Add more tests for Anchor. Anchor needs to be defined before it can be referenced
    public void Yaml_Constructor_ThrowsException_WhenInvalidYaml(string fileName)
    {
        string yamlString = System.IO.File.ReadAllText( Path.Combine(_fileRoot,_invalidFolder, fileName));
        
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => Yaml.From(yamlString));

        // Assert
        exception.Errors.Should().HaveCount(1);
        exception.Errors.First().ErrorMessage.Should().Be($"Could not create a Nox Yaml type with invalid yaml value '{yamlString}'.");
    }
    
    [Theory]
    [InlineData("simple1.1.yaml", "simple1.2.yaml")]
    [InlineData("simple2.1.yaml", "simple2.2.yaml")]
    [InlineData("complex1.1.yaml", "complex1.2.yaml")]
    [InlineData("complex-object1.1.yaml", "complex-object1.2.yaml")]
    [InlineData("array1.1.yaml", "array1.2.yaml")]
    [InlineData("anchor1.1.yaml", "anchor1.2.yaml")]
    public void Yaml_Equals_ReturnsTrue_WhenSameYaml(string fileName1, string fileName2)
    {
        string yamlString1 = System.IO.File.ReadAllText( Path.Combine(_fileRoot, _equalFolder, fileName1));
        string yamlString2 = System.IO.File.ReadAllText( Path.Combine(_fileRoot, _equalFolder, fileName2));
        
        // Arrange & Act
        var yaml1 = Yaml.From(yamlString1);
        var yaml2 = Yaml.From(yamlString2);

        // Assert
        yaml1.Equals(yaml2).Should().BeTrue();
    }
}