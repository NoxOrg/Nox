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
    public async Task Name_ShouldConvertToUpperCase_OnCrete()
    {
        // Arrange
       
        var countryDto = new CountryCreateDto
        {
            Name = "Türkiye",
            Population = 85000000
        };
        var countryUpdateDto = new CountryUpdateDto
        {
            Name = "Türkiye",
            Population = 85000000
        };

        // Act
        var postResult = await PostAsync<CountryCreateDto, CountryDto>(CountryControllerName, countryDto);
        //Assert
        
        postResult.Should().NotBeNull();
        postResult!.Name.Should().Be("TÜRKIYE");
        
        // Act
        var headers = CreateEtagHeader(postResult.Etag);
        var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{CountryControllerName}/{postResult!.Id}", countryUpdateDto, headers);

        //Assert
        //Since update notification handler not registered, name should not be changed
        putResult.Should().NotBeNull();
        putResult!.Name.Should().Be("Türkiye");
    }
}