using ClientApi.Application.Commands;
using ClientApi.Application.Dto;
using FluentAssertions;
using Nox.Application.Exceptions;
using Xunit.Abstractions;

namespace ClientApi.Tests.Application.CommandHandlers;

public class UpsertCountriesContinentsTranslationsCommandHandlerTests : NoxWebApiTestBase
{
    public UpsertCountriesContinentsTranslationsCommandHandlerTests(ITestOutputHelper testOutput, TestDatabaseContainerService testDatabaseService) 
        : base(testOutput, testDatabaseService)
    {
    }
    
    [Fact]
    public async Task WhenUnsupportedCulture_ShouldThrowCultureCodeNotSupportedException()
    {
        // Arrange
        var command = new UpsertCountriesContinentsTranslationsCommand(
        
            new List<CountryContinentLocalizedDto>
            {
                new() {Id = 1, CultureCode = "tr-TR", Name = "Avrupa"},
                new() {Id = 2, CultureCode = "tr-TR", Name = "Asya"},
                new() {Id = 3, CultureCode = "tr-TR", Name = "Afrika"},
                new() {Id = 4, CultureCode = "tr-TR", Name = "Amerika"},
                new() {Id = 5, CultureCode = "tr-TR", Name = "Okyanusya"},
            }
        );
        
        // Act
        var action = () => Mediator.Send(command);

        // Assert
        await action.Should().ThrowAsync<CultureCodeNotSupportedException>();
    }
    
    [Fact]
    public async Task WhenCultureCodeMismatch_ShouldThrowCultureCodeMismatchException()
    {
        // Arrange
        var command = new UpsertCountriesContinentsTranslationsCommand(
        
            new List<CountryContinentLocalizedDto>
            {
                new() {Id = 1, CultureCode = "en-US", Name = "Europe"},
                new() {Id = 2, CultureCode = "fr-FR", Name = "Asie"},
                new() {Id = 3, CultureCode = "en-US", Name = "Africa"},
                new() {Id = 4, CultureCode = "fr-FR", Name = "Amérique"},
                new() {Id = 5, CultureCode = "en-US", Name = "Oceania"},
            }
        );
        
        // Act
        var action = () => Mediator.Send(command);

        // Assert
        await action.Should().ThrowAsync<CultureCodeMismatchException>();
    }
    
    [Fact]
    public async Task WhenIdsContainsInvalidId_ShouldThrowInvalidEnumIdsException()
    {
        // Arrange
        var command = new UpsertCountriesContinentsTranslationsCommand(
        
            new List<CountryContinentLocalizedDto>
            {
                new() {Id = 1, CultureCode = "en-US", Name = "Europe"},
                new() {Id = 2, CultureCode = "en-US", Name = "Asia"},
                new() {Id = 3, CultureCode = "en-US", Name = "Africa"},
                new() {Id = 4, CultureCode = "en-US", Name = "America"},
                new() {Id = 15, CultureCode = "en-US", Name = "Oceania"},
            }
        );
        
        // Act
        var action = () => Mediator.Send(command);

        // Assert
        await action.Should().ThrowAsync<InvalidEnumIdsException>();
    }
    
}