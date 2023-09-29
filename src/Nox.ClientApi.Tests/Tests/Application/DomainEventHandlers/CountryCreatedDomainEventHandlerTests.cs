using ClientApi.Application.DomainEventHandlers;
using ClientApi.Application.Dto;
using FluentAssertions;
using Xunit.Abstractions;

namespace ClientApi.Tests.Application.DomainEventHandlers;

public class CountryCreatedDomainEventHandlerTests : NoxWebApiTestBase
{
    private const string CountryControllerName = "api/countries";
    
    public CountryCreatedDomainEventHandlerTests(ITestOutputHelper testOutputHelper, 
        NoxTestContainerService containerService, 
        bool enableMessagingTests = false) : base(testOutputHelper, containerService, enableMessagingTests)
    {
    }
    
    [Fact]
    public async Task Post_Country_ShouldInvokeCountryCreatedDomainEventHandler()
    {
        // Arrange
       
        var countryDto = new CountryCreateDto
        {
            Name = "Turkiye",
            Population = 85000000
        };

        var handledEventCountBeforeEvent = CountryCreatedDomainEventHandler.HandledEventCount;
        
        // Act
        var postResult = await PostAsync<CountryCreateDto, CountryDto>(CountryControllerName, countryDto);
        //Assert
        
        postResult.Should().NotBeNull();
        postResult!.Name.Should().Be("Turkiye");
        var handledEventCountAfterEvent = CountryCreatedDomainEventHandler.HandledEventCount;
        handledEventCountAfterEvent.Should().BeGreaterThan(handledEventCountBeforeEvent);
        
       
    }
}