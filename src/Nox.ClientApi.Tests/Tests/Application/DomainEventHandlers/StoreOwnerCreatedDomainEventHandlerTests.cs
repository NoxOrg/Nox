using ClientApi.Application.Dto;
using ClientApi.Tests.Controllers;
using FluentAssertions;
using Xunit.Abstractions;

namespace ClientApi.Tests.Application.DomainEventHandlers;

public class StoreOwnerCreatedDomainEventHandlerTests: NoxWebApiTestBase
{
    
    public StoreOwnerCreatedDomainEventHandlerTests(ITestOutputHelper testOutput, NoxTestContainerService containerService, bool enableMessagingTests = false)  
        : base(testOutput, containerService, enableMessagingTests)
    {
    }
    
    [Fact]
    public async Task Domain_Event_Handler_Should_Create_Default_Note_When_It_Is_Empty()
    {
        var expectedNote = "Store owner created at " + DateTime.Now.ToString("yyyy-MM-dd)");
        // Arrange
        var createDto = new StoreOwnerCreateDto
        {
            Id = "001",
            Name = "Test Store Owner"
        };

        // Act
        var result = await PostAsync<StoreOwnerCreateDto,StoreOwnerDto> (Endpoints.StoreOwnersUrl, createDto);

        //Assert
        result.Should().NotBeNull();
        result!.Notes.Should().Be(expectedNote);
    }
    
    [Fact]
    public async Task Domain_Event_Handler_Should_Not_Change_Note_When_It_Is_Not_Empty()
    {
        const string expectedNote = "Test Note";
        // Arrange
        var createDto = new StoreOwnerCreateDto
        {
            Id = "001",
            Name = "Test Store Owner",
            Notes = expectedNote
        };

        // Act
        var result = await PostAsync<StoreOwnerCreateDto,StoreOwnerDto> (Endpoints.StoreOwnersUrl, createDto);

        //Assert
        result.Should().NotBeNull();
        result!.Notes.Should().Be(expectedNote);
    }

    
}