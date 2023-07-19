using FluentAssertions;

namespace Nox.Types.Tests;


public class YamlTests
{
    private const string FileRoot = "Types/Yaml/Samples";
    private const string ValidFolder = "Valid";
    private const string InvalidFolder = "Invalid";
    private const string EqualFolder = "Equal";
    private const string InEqualFolder = "Inequal";

    [Theory]
    [InlineData("simple.yaml")]
    [InlineData("complex.yaml")]
    [InlineData("complex-object.yaml")]
    [InlineData("array.yaml")]
    [InlineData("anchor.yaml")]
    
    public void Yaml_Constructor_ReturnsSameValue(string fileName)
    {
        string yamlString = System.IO.File.ReadAllText( Path.Combine(FileRoot, ValidFolder, fileName));
        
        // Arrange & Act
        var yaml = Yaml.From(yamlString);

        // Assert
        yaml.Value.Should().Be(yamlString);
    }
    
    
    [Theory]
    [InlineData("simple.yaml")]
    [InlineData("simple1.yaml")]
    [InlineData("complex.yaml")]
    [InlineData("complex-object.yaml")]
    [InlineData("array.yaml")]
    [InlineData("anchor.yaml")]
    [InlineData("anchor1.yaml")]
    public void Yaml_Constructor_ThrowsException_WhenInvalidYaml(string fileName)
    {
        string yamlString = System.IO.File.ReadAllText( Path.Combine(FileRoot,InvalidFolder, fileName));
        
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => Yaml.From(yamlString));

        // Assert
        exception.Errors.Should().NotHaveCount(0);
            
        exception.Errors.Should().Contain(e=>e.ErrorMessage.Contains($"Could not create a Nox Yaml type with invalid yaml value '{yamlString}'"));
    }
    
    [Theory]
    [InlineData("simple1.1.yaml", "simple1.2.yaml")]
    [InlineData("complex1.1.yaml", "complex1.2.yaml")]
    [InlineData("array1.1.yaml", "array1.2.yaml")]
    [InlineData("anchor1.1.yaml", "anchor1.2.yaml")]
    public void Yaml_Equals_ReturnsTrue_WhenSameYaml(string fileName1, string fileName2)
    {
        string yamlString1 = System.IO.File.ReadAllText( Path.Combine(FileRoot, EqualFolder, fileName1));
        string yamlString2 = System.IO.File.ReadAllText( Path.Combine(FileRoot, EqualFolder, fileName2));
        
        // Arrange & Act
        var yaml1 = Yaml.From(yamlString1);
        var yaml2 = Yaml.From(yamlString2);
    
        // Assert
        yaml1.Equals(yaml2).Should().BeTrue();
    }
    
    [Theory]
    [InlineData("simple1.1.yaml", "simple1.2.yaml")]
    [InlineData("simple2.1.yaml", "simple2.2.yaml")]
    [InlineData("complex1.1.yaml", "complex1.2.yaml")]
    [InlineData("complex-object1.1.yaml", "complex-object1.2.yaml")]
    [InlineData("array1.1.yaml", "array1.2.yaml")]
    [InlineData("anchor1.1.yaml", "anchor1.2.yaml")]
    public void Yaml_Equals_ReturnsFalse_WhenDifferentYaml(string fileName1, string fileName2)
    {
        string yamlString1 = System.IO.File.ReadAllText( Path.Combine(FileRoot, InEqualFolder, fileName1));
        string yamlString2 = System.IO.File.ReadAllText( Path.Combine(FileRoot, InEqualFolder, fileName2));
        
        // Arrange & Act
        var yaml1 = Yaml.From(yamlString1);
        var yaml2 = Yaml.From(yamlString2);

        // Assert
        yaml1.Equals(yaml2).Should().BeFalse();
    }
}