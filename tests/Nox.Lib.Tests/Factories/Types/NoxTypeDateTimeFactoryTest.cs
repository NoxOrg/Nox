using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeDateTimeFactoryTest
{
    [Theory, AutoMoqData]
    public void CreateNoxType_FromDateDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeDateTimeFactory(noxSolution);
        var value = System.DateTime.UtcNow;

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(value);
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromStringDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeDateTimeFactory(noxSolution);
        var value = "2023-Mar-23";

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.ToString("yyyy-MMM-dd").Should().Be(value);
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromNullDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeDateTimeFactory(noxSolution);

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, null);

        // Assert
        entity.Should().BeNull();
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromInvalidStringDto_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeDateTimeFactory(noxSolution);
        var value = "Invalid Date String";

        // Assert
        sut.Invoking(y => y.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value))
            .Should().Throw<System.ArgumentOutOfRangeException>();
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WhenValueIsInFuture_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var value = System.DateTime.UtcNow.AddDays(-10);
        var sut = new NoxTypeDateTimeFactory(noxSolution);

        var options = new DateTimeTypeOptions() { AllowFutureOnly = true };

        fixture.EntityDefinition.Attributes![0]!.DateTimeTypeOptions = options;
        fixture.EntityDefinition.Attributes![0]!.Name = "DateTimeTypeOptions";

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, "DateTimeTypeOptions", value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .WithMessage("The Nox type validation failed with 1 error(s).")
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DateTime type as value {new DateTimeOffset(value)} is in the past") });
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WhenValueIsLessThanMinValue_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var value = System.DateTime.UtcNow.AddDays(-10);
        var sut = new NoxTypeDateTimeFactory(noxSolution);

        var options = new DateTimeTypeOptions() { MinValue = System.DateTime.UtcNow };

        fixture.EntityDefinition.Attributes![0]!.DateTimeTypeOptions = options;
        fixture.EntityDefinition.Attributes![0]!.Name = "DateTimeTypeOptions";

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, "DateTimeTypeOptions", value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .WithMessage("The Nox type validation failed with 1 error(s).")
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DateTime type as value {new DateTimeOffset(value)} is less than the minimum specified value of {options.MinValue}") });
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WhenValueIsGreaterThanMaxValue_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var value = System.DateTime.UtcNow.AddDays(10);
        var sut = new NoxTypeDateTimeFactory(noxSolution);

        var options = new DateTimeTypeOptions() { MaxValue = System.DateTime.UtcNow };

        fixture.EntityDefinition.Attributes![0]!.DateTimeTypeOptions = options;
        fixture.EntityDefinition.Attributes![0]!.Name = "DateTimeTypeOptions";

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, "DateTimeTypeOptions", value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .WithMessage("The Nox type validation failed with 1 error(s).")
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DateTime type a value {new DateTimeOffset(value)} is greater than the maximum specified value of {options.MaxValue}") });        
    }
}
