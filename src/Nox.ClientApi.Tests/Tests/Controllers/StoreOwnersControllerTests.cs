using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using AutoFixture.AutoMoq;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoreOwnersControllerTests 
    {
        private const string StoreOwnersControllerName = "api/storeowners";
        private readonly Fixture _fixture;
        private readonly ODataFixture _oDataFixture;

        public StoreOwnersControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
            _oDataFixture = _fixture.Create<ODataFixture>();
        }

        [Fact]
        public async Task Post_WhenNullId_ReturnsBadRequest()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            // Act
            var result = await _oDataFixture.PostAsync(StoreOwnersControllerName, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Post_WhenInvalidId_ReturnsInternalServerError()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "1",//min is 3 characters
                Name = _fixture.Create<string>(),
            };

            // Act
            var result = await _oDataFixture.PostAsync(StoreOwnersControllerName, createDto);

            // Assert
            // represent a nox type exception
            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
        [Fact]
        public async Task Post_WhenValidId_ReturnCreated()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "001",
                Name = _fixture.Create<string>(),
            };

            // Act
            var result = await _oDataFixture.PostAsync(StoreOwnersControllerName, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }


        [Fact]
        public async Task Post_VatNumberIsCreated()
        {
            // Arrange
            var expectedVatNumber = "515714941";
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                VatNumber = new VatNumberDto(expectedVatNumber, Nox.Types.CountryCode.PT)
            };

            // Act
            var result = await _oDataFixture.PostAsync<StoreOwnerCreateDto, StoreOwnerKeyDto>(StoreOwnersControllerName, createDto);
            var queryResult = await _oDataFixture.GetAsync<StoreOwnerDto>($"{StoreOwnersControllerName}/{result!.keyId}");

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreOwnerKeyDto>();

            queryResult.Should().NotBeNull();
            queryResult!.VatNumber!.Number.Should().Be(expectedVatNumber);
        }
    }
}