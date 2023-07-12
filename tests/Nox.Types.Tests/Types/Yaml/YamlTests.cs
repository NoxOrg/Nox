namespace Nox.Types.Tests;

public class YamlTests
{
    private readonly string _fileRoot = "Types/Yaml/Samples";
    private readonly string _validFolder = "Valid";
    private readonly string _invalidFolder = "Invalid";
    [Theory]
    [InlineData("simple.yaml")]
    [InlineData("complex.yaml")]
    [InlineData("complex-object.yaml")]
    
    public void Yaml_Constructor_ReturnsSameValue(string fileName)
    {
        string yamlString = System.IO.File.ReadAllText( Path.Combine(_fileRoot, _validFolder, fileName));
        
        // Arrange & Act
        var yaml = Yaml.From(yamlString);

        // Assert
        Assert.Equal(yamlString, yaml.Value);
    }
    
    
    [Theory]
    [InlineData("simple-invalid.yaml")]
    [InlineData("complex-invalid.yaml")]
    [InlineData("complex-object-invalid.yaml")]
    public void Yaml_Constructor_ThrowsException_WhenInvalidYaml(string fileName)
    {
        string yamlString = System.IO.File.ReadAllText( Path.Combine(_fileRoot,_invalidFolder, fileName));
        
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => Yaml.From(yamlString));

        // Assert
        Assert.Equal($"Could not create a Nox Yaml type with invalid yaml value '{yamlString}'.", exception.Errors.First().ErrorMessage);
    }
}