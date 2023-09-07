﻿using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using AutoFixture.AutoMoq;
using Nox.Types;

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
            var result = await _oDataFixture.PostAsync<StoreOwnerCreateDto, StoreOwnerKeyDto>(StoreOwnersControllerName, createDto);
            var queryResult = await _oDataFixture.GetAsync<StoreOwnerDto>($"{StoreOwnersControllerName}/{result!.keyId}");

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<StoreOwnerKeyDto>();

            queryResult.Should().NotBeNull();
            queryResult!.StreetAddress!.Should().BeEquivalentTo(expectedStreetAddressDto);
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
            var result = await _oDataFixture.PostAsync<StoreOwnerCreateDto, StoreOwnerKeyDto>(StoreOwnersControllerName, createDto);
            var queryResult = await _oDataFixture.GetAsync<StoreOwnerDto>($"{StoreOwnersControllerName}/{result!.keyId}");

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<StoreOwnerKeyDto>();

            queryResult.Should().NotBeNull();
            queryResult!.StreetAddress!.Should().BeEquivalentTo(expectedStreetAddressDto);
        }

        [Theory]
        [InlineData(null!, "KT16 0RS")]
        [InlineData("3000 Hillswood Business Park", null!)]
        public async Task Post_StreetAddressRequiredFieldsNoSet_IsNotCreated(string addressLine1, string postalCode)
        {
            // Arrange
            var createDto = new StoreOwnerCreateDto
            {
                Id = "002",
                Name = _fixture.Create<string>(),
                StreetAddress = new StreetAddressDto(
                    StreetNumber: null!,
                    AddressLine1: addressLine1,
                    AddressLine2: null!,
                    Route: null!,
                    Locality: null!,
                    Neighborhood: null!,
                    AdministrativeArea1: null!,
                    AdministrativeArea2: null!,
                    PostalCode: postalCode,
                    CountryId: CountryCode.GB),
            };

            // Act
            var result = await _oDataFixture.PostAsync(StoreOwnersControllerName, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
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
            var result = await _oDataFixture.PostAsync(StoreOwnersControllerName, createDto);

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
            var result = await _oDataFixture.PostAsync(StoreOwnersControllerName, createDto);

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
            var result = await _oDataFixture.PostAsync(StoreOwnersControllerName, createDto);

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}