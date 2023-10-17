using FluentAssertions;
using Xunit.Abstractions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;

namespace ClientApi.Tests.Application.Dto
{
    [Collection("Sequential")]
    public class CountryDtoValidatorTests : NoxWebApiTestBase
    {
        public CountryDtoValidatorTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
        }

        [Fact]
        public void CountryDto_RequiredFields_ShouldValidate()
        {
            //Arrange
            var countryDto = new CountryDto();
            
            //Act
            var validationResult = countryDto.Validate();

            //Assert
            validationResult.Should().NotBeNull();
            validationResult.Should().ContainKey(nameof(countryDto.Name));
        }

        [Fact]
        public void CountryDto_InvalidFields_ShouldValidate()
        {
            //Arrange
            var countryDto = new CountryDto()
            {
                Name = _fixture.Create<string>().Substring(0, 3),
                Population = 2_000_000_000,
                CountryDebt = new MoneyDto(100, CurrencyCode.USD),
                FirstLanguageCode = "qq",
                CountryIsoNumeric = 111,
                CountryIsoAlpha3 = "qqq",
                GoogleMapsUrl = "invalid_url",
                StartOfWeek = 100
            };

            //Act
            var validationResult = countryDto.Validate();

            //Assert
            validationResult.Should().NotBeNull();
            validationResult.Should().ContainKey(nameof(countryDto.Name));
            validationResult.Should().ContainKey(nameof(countryDto.Population));
            validationResult.Should().ContainKey(nameof(countryDto.CountryDebt));
            validationResult.Should().ContainKey(nameof(countryDto.FirstLanguageCode));
            validationResult.Should().ContainKey(nameof(countryDto.CountryIsoNumeric));
            validationResult.Should().ContainKey(nameof(countryDto.CountryIsoAlpha3));
            validationResult.Should().ContainKey(nameof(countryDto.GoogleMapsUrl));
            validationResult.Should().ContainKey(nameof(countryDto.StartOfWeek));
        }

        [Fact]
        public void CountryDto_ValidFields_ShouldValidate()
        {
            //Arrange
            var countryDto = new CountryDto()
            {
                Name = _fixture.Create<string>().Substring(0, 10),
                Population = 1_000_000,
                CountryDebt = new MoneyDto(200_000, CurrencyCode.USD),
                FirstLanguageCode = "en",
                CountryIsoNumeric = 004,
                CountryIsoAlpha3 = "GBR",
                GoogleMapsUrl = "https://maps.app.goo.gl/WzKrDLDw3mgKe22Q9",
                StartOfWeek = 1
            };

            //Act
            var validationResult = countryDto.Validate();

            //Assert
            validationResult.Should().NotBeNull();
            validationResult.Should().BeEmpty();
        }
    }
}