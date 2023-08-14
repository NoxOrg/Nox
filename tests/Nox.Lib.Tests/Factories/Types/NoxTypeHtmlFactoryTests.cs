using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeHtmlFactoryTests
{
    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        NoxTypeHtmlFactory sut = new NoxTypeHtmlFactory(noxSolution);
        var value = "<html><body>plain text</body></html>";

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(value);
    }


    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WithInvalidData_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeHtmlFactory(noxSolution);
        string value = "invalid html";

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("Value", "A Nox Html type requires opening and closing 'html' tags to be valid.")
            });
    }
}