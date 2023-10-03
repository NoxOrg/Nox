using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using AutoFixture.AutoMoq;
using Nox.Types;
using Xunit.Abstractions;
using ClientApi.Application.IntegrationEvents.StoreOwner;
using Nox.Application;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class StoreOwnersControllerTests : NoxWebApiTestBase
    {
        public const string StoreOwnersUrl = "api/storeowners";

        public StoreOwnersControllerTests(ITestOutputHelper testOutput,
            NoxTestContainerService containerService)
            : base(testOutput, containerService)
        {
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
            var result = await PostAsync(StoreOwnersUrl, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_WhenInvalidId_ReturnsBadRequestError()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "1",//min is 3 characters
                Name = _fixture.Create<string>(),
            };

            // Act
            var result = await PostAsync(StoreOwnersUrl, createDto);

            // Assert
            // represent a nox type exception
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
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
            var result = await PostAsync(StoreOwnersUrl, createDto);

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
            var result = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(StoreOwnersUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<StoreOwnerDto>();
            result!.VatNumber!.Number.Should().Be(expectedVatNumber);
        }

        [Fact]
        public async Task Post_StreetAddressAllFieldsSet_IsCreated()
        {
            // Arrange
            var expectedStreetAddressDto = new StreetAddressDto(
                StreetNumber: "3000",
                AddressLine1: "Hillswood Business Park",
                AddressLine2: null!,
                Route: "Hillswood Drive",
                Locality: "Lyne",
                Neighborhood: null!,
                AdministrativeArea1: "England",
                AdministrativeArea2: "Surrey",
                PostalCode: "KT16 0RS",
                CountryId: CountryCode.GB);

            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = expectedStreetAddressDto,
            };

            // Act
            var result = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(StoreOwnersUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<StoreOwnerDto>();
            result!.StreetAddress!.Should().BeEquivalentTo(expectedStreetAddressDto);
        }

        [Fact]
        public async Task Post_StreetAddressOnlyRequiredFieldsSet_IsCreated()
        {
            // Arrange
            var expectedStreetAddressDto = new StreetAddressDto(
                StreetNumber: null!,
                AddressLine1: "3000 Hillswood Business Park",
                AddressLine2: null!,
                Route: null!,
                Locality: null!,
                Neighborhood: null!,
                AdministrativeArea1: null!,
                AdministrativeArea2: null!,
                PostalCode: "KT16 0RS",
                CountryId: CountryCode.GB);

            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = expectedStreetAddressDto,
            };

            // Act
            var result = await PostAsync<StoreOwnerCreateDto, StoreOwnerDto>(StoreOwnersUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<StoreOwnerDto>();
            result!.StreetAddress!.Should().BeEquivalentTo(expectedStreetAddressDto);
        }

        [Fact]
        public async Task Post_StreetAddressAddressLine1NotSet_IsNotCreated()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = new StreetAddressDto(
                    StreetNumber: null!,
                    AddressLine1: null!,
                    AddressLine2: null!,
                    Route: null!,
                    Locality: null!,
                    Neighborhood: null!,
                    AdministrativeArea1: null!,
                    AdministrativeArea2: null!,
                    PostalCode: "KT16 0RS",
                    CountryId: CountryCode.GB),
            };

            // Act
            var result = await PostAsync(StoreOwnersUrl, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_StreetAddressPostalCodeNotSet_IsNotCreated()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = new StreetAddressDto(
                    StreetNumber: null!,
                    AddressLine1: "3000 Hillswood Business Park",
                    AddressLine2: null!,
                    Route: null!,
                    Locality: null!,
                    Neighborhood: null!,
                    AdministrativeArea1: null!,
                    AdministrativeArea2: null!,
                    PostalCode: null!,
                    CountryId: CountryCode.GB),
            };

            // Act
            var result = await PostAsync(StoreOwnersUrl, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_StreetAddressCountryIdNotSet_IsNotCreated()
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = new StreetAddressDto(
                    StreetNumber: null!,
                    AddressLine1: "3000 Hillswood Business Park",
                    AddressLine2: null!,
                    Route: null!,
                    Locality: null!,
                    Neighborhood: null!,
                    AdministrativeArea1: null!,
                    AdministrativeArea2: null!,
                    PostalCode: "KT16 0RS",
                    CountryId: (CountryCode)0),
            };

            // Act
            var result = await PostAsync(StoreOwnersUrl, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}