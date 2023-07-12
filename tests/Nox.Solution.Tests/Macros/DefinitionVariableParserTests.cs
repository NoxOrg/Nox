using Nox.Solution.Macros;

namespace Nox.Solution.Tests.Macros;

public class DefinitionVariableParserTests
{
    [Fact]
    public void Should_return_null_when_no_variables_defined()
    {
        var yaml = File.ReadAllText("./files/macros/no-variables.solution.nox.yaml");
        var parser = new DefinitionVariableParser();
        var variables = parser.Parse(yaml);
        Assert.Null(variables);
    }
    
    
    [Theory]
    [InlineData("DATABASE_PROVIDER", "slqServer")]
    [InlineData("DATABASE_SERVER", "localhost")]
    [InlineData("DATABASE_PORT", "5432")]
    public void Should_extract_local_variables_from_yaml(string key, string expectedValue)
    {
        var yaml = File.ReadAllText("./files/macros/variables.solution.nox.yaml");
        var parser = new DefinitionVariableParser();
        var variables = parser.Parse(yaml);
        Assert.NotNull(variables);
        Assert.NotEmpty(variables);
        Assert.Equal(3, variables.Count);
        Assert.True(variables.ContainsKey(key));
        Assert.Equal(expectedValue, variables[key]);
    }
}