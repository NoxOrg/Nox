using FluentAssertions;
using Newtonsoft.Json.Linq;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;
using System.Security.Claims;
using YamlDotNet.Core.Tokens;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeJwtTokenFactoryTests
{
    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeJwtTokenFactory(noxSolution);
        var value = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(value);

        var claims = entity.GetClaims();

        claims.Should().BeEquivalentTo(new[]
        {
            new Claim("sub", "1234567890", "http://www.w3.org/2001/XMLSchema#string"),
            new Claim("name", "John Doe", "http://www.w3.org/2001/XMLSchema#string"),
            new Claim("iat", "1516239022", "http://www.w3.org/2001/XMLSchema#integer"),
        });
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromNull_ReturnsNull(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeJwtTokenFactory(noxSolution);

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, null);

        // Assert
        entity.Should().BeNull();
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromInvalidString_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeJwtTokenFactory(noxSolution);
        var value = "abc1234";

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .WithMessage("The Nox type validation failed with 1 error(s).")
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox JWT Token type as value {value} does not have a valid JWT format.") });
    }
}
