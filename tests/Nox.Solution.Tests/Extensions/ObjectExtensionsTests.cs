using Moq;
using Nox.Solution.Tests.FixtureConfig;
using Nox.Solution.Extensions;
using FluentAssertions;
using Nox.Types;

namespace Nox.Solution.Tests.Extensions;

public class ObjectExtensionsTests
{

    [Fact]
    public void Object_ToSource_Generates_Correct_Source()
    {
        // Arrange            
        var textOptions = new TextTypeOptions()
        {
            MaxLength = 16,
            MinLength = 4,
            Casing = TextTypeCasing.Lower,
            IsLocalized = true,
            // IsUnicode = true
        };

        var expectedSource = """
                var textOptions2 = new TextTypeOptions()
                {
                    MinLength = 4,
                    MaxLength = 16,
                    IsUnicode = true,
                    IsLocalized = true,
                    Casing = Nox.Types.TextTypeCasing.Lower,
                };

                """;

        // Act
        var source = textOptions.ToSourceCode(nameof(textOptions)+"2");
            
        // Assert
        source.Should().Be(expectedSource);

    }

    [Fact]
    public void Object_ToSource_Generates_Correct_Source_From_Solution()
    {
        // Arrange
        var noxConfig = new NoxSolutionBuilder()
            .UseYamlFile("./files/sample.solution.nox.yaml")
            .Build();

        // Act
        var source = noxConfig.ToSourceCode("solution");

        // Assert
        Assert.NotNull(noxConfig);
        Assert.NotNull(source);

    }
}

