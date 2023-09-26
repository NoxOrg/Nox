using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using ClientApi.Tests.Tests.Models;

namespace ClientApi.Tests.Application.Dto
{
    [Collection("Sequential")]
    public class CountryDtoValidatorTests : NoxIntegrationTestBase
    {
        private const string CountryControllerName = "api/countries";

        public CountryDtoValidatorTests(NoxTestContainerService containerService) : base(containerService)
        {
        }

        [Fact]
        public void CountryDto_ShouldValidate()
        {
            var countryDto = new CountryDto();
            countryDto.Validate();


        }
    }
}