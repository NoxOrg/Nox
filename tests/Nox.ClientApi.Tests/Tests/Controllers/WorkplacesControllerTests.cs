﻿using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;
using Nox.Application.Dto;
using static MassTransit.ValidationResultExtensions;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class WorkplacesControllerTests : NoxWebApiTestBase
    {
        private readonly EndPointsFixture _endPointFixture;
        public WorkplacesControllerTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
            //TODO receive it on the constructor
            _endPointFixture = new EndPointsFixture(nameof(ClientApi.Domain.Workplace));
        }

        #region RELATIONSHIPS

        #region GET

        #region GET Ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/workplaces/1/Country/$ref

        [Fact]
        public async Task Get_RefToRelatedEntity_Success()
        {
            // Arrange
            var dto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };
            var Country = new CountryCreateDto()
            {
                Name = _fixture.Create<string>()
            };

            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, dto);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, Country);
            await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/Country/{countryResponse!.Id}/$ref");

            // Act
            var getRefResponse = await GetODataSimpleResponseAsync<ODataReferenceResponse>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}/$ref");

            //Assert
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);

            getRefResponse.Should().NotBeNull();
            getRefResponse!.ODataId!.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetRefToCountry_ValidateResponseStatusCode()
        {
            // Arrange
            var dto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };
            var Country = new CountryCreateDto()
            {
                Name = _fixture.Create<string>()
            };

            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, dto);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, Country);

            // Act and Assert
            var workplaceValidIdWithoutCountry = await GetAsync(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}/$ref");
            workplaceValidIdWithoutCountry!.StatusCode.Should().Be(HttpStatusCode.OK);

            var workplaceInvalidIdWithoutCountry = await GetAsync(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id+1}/{nameof(WorkplaceDto.Country)}/$ref");
            workplaceInvalidIdWithoutCountry!.StatusCode.Should().Be(HttpStatusCode.NotFound);

            await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/Country/{countryResponse!.Id}/$ref");

            var workplaceValidIdWithCountry = await GetODataSimpleResponseAsync<ODataReferenceResponse?>(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}/$ref");
            workplaceValidIdWithCountry!.Should().NotBeNull();

            var workplaceInvalidIdWithCountry = await GetAsync(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id + 1}/{nameof(WorkplaceDto.Country)}/$ref");
            workplaceInvalidIdWithCountry!.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        #endregion GET Ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/workplaces/1/Country/$ref

        #region GET Related Entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName} => api/workplaces/1/Country

        [Fact]
        public async Task Get_WorkplaceCountry_Success()
        {
            // Arrange
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto { Name = _fixture.Create<string>() });
            var headers = CreateEtagHeader(workplaceResponse!.Etag);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}",
                new CountryCreateDto() { Name = _fixture.Create<string>() },
                headers);

            // Act
            const string oDataRequest = $"$expand={nameof(CountryDto.Workplaces)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<CountryDto>(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}?{oDataRequest}");

            //Assert
            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().Be(countryResponse!.Id);
            getCountryResponse!.Workplaces.Should().NotBeNull();
            getCountryResponse!.Workplaces.Should().HaveCount(1);
            getCountryResponse!.Workplaces!.First().Id.Should().Be(workplaceResponse!.Id);
        }

        [Fact]
        public async Task Get_WorkplaceCountry_WhenNoRelatedCountry_NotFound()
        {
            // Arrange
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto { Name = _fixture.Create<string>() });

            // Act
            var getCountryResponse = await GetAsync(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}");

            //Assert
            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_WorkplaceCountry_InvalidWorkplaceId_NotFound()
        {
            // Act
            var getCountryResponse = await GetAsync(
                $"{Endpoints.WorkplacesUrl}/{1}/{nameof(WorkplaceDto.Country)}");

            //Assert
            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        #endregion

        #endregion GET

        #region POST

        #region POST Entity With Related Entity /api/{EntityPluralName} => api/workplaces

        [Fact(Skip = "We are not allowing to related entity or entities on post, avoid circular dependency on dto and edge cases")]
        public async Task Post_WithSingleRelatedEntity_Success()
        {
            // Arrange
            var expectedCountryName = _fixture.Create<string>();
            var dto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
                Country = new CountryCreateDto()
                {
                    Name = expectedCountryName
                }
            };
            // Act
            var result = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, dto);
            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{result!.Id}?{oDataRequest}");

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.Country.Should().NotBeNull();
            getCountryResponse!.Country!.Name.Should().Be(expectedCountryName);
        }

        #endregion POST Entity With Related Entity /api/{EntityPluralName} => api/workplaces

        #region POST Create ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/workplaces/1/Country/1/$ref

        [Fact]
        public async Task Post_CreateRefToCountry_Success()
        {
            // Arrange
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };

            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
            var createRefResponse = await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/Country/{countryResponse!.Id}/$ref");

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);

            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.Country.Should().NotBeNull();
            getWorkplaceResponse!.Country!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.Country!.Name.Should().NotBeNull();
        }

        #endregion POST Create ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/workplaces/1/Country/1/$ref

        #region POST Related Entity TO Entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName} => api/workplaces/1/Country

        [Fact]
        public async Task Post_CountryToWorkplaces_Success()
        {
            // Arrange
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto { Name = _fixture.Create<string>() });

            // Act
            var headers = CreateEtagHeader(workplaceResponse!.Etag);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}",
                new CountryCreateDto() { Name = _fixture.Create<string>() },
                headers);

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            countryResponse.Should().NotBeNull();
            countryResponse!.Name.Should().NotBeNull();

            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.CountryId.Should().Be(countryResponse!.Id);
            getWorkplaceResponse!.Country.Should().NotBeNull();
            getWorkplaceResponse!.Country!.Id.Should().Be(countryResponse!.Id);
        }

        #endregion

        #endregion POST

        #region PUT

        #region PUT Update related entity /api/{EntityPluralName}/{EntityKey} => api/workplaces/1

        [Fact(Skip = "NOX-237")]
        public async Task Put_UpdateCountry_Success()
        {
            // Arrange
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
            var countryCreateDto1 = new CountryCreateDto { Name = _fixture.Create<string>() };
            var countryCreateDto2 = new CountryCreateDto { Name = _fixture.Create<string>() };

            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var countryResponse1 = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto1);
            var countryResponse2 = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto2);
            await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/Country/{countryResponse1!.Id}/$ref");

            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}");
            var headers = CreateEtagHeader(getWorkplaceResponse!.Etag);
            await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}",
                new WorkplaceUpdateDto
                {
                    Name = workplaceResponse!.Name,
                    //CountryId = countryResponse2!.Id
                },
                headers);

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
            getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.Country.Should().NotBeNull();
            getWorkplaceResponse!.Country!.Id.Should().Be(countryResponse2!.Id);
        }

        #endregion

        #region PUT to Related Entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName} => api/workplaces/1/Country

        [Fact]
        public async Task Put_CountryToWorkplaces_Success()
        {
            // Arrange
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto { Name = _fixture.Create<string>() });

            var postToCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}",
                new CountryCreateDto() { Name = _fixture.Create<string>() });

            var expectedName = _fixture.Create<string>();

            // Act
            var headers = CreateEtagHeader(postToCountryResponse!.Etag);
            var putToCountryResponse = await PutAsync<CountryUpdateDto, CountryDto>(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}",
                new CountryUpdateDto()
                {
                    Name = expectedName
                },
                headers);

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            putToCountryResponse.Should().NotBeNull();
            putToCountryResponse!.Id.Should().Be(postToCountryResponse!.Id);
            putToCountryResponse!.Name.Should().Be(expectedName);

            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.CountryId.Should().Be(postToCountryResponse!.Id);
            getWorkplaceResponse!.Country.Should().NotBeNull();
            getWorkplaceResponse!.Country!.Id.Should().Be(postToCountryResponse!.Id);
            getWorkplaceResponse!.Country!.Name.Should().Be(expectedName);
        }

        #endregion

        #endregion

        #region DELETE

        #region DELETE Delete ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/workplaces/1/Country/1/$ref

        [Fact]
        public async Task Delete_RefToCountry_Success()
        {
            // Arrange
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };

            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
            var createRefResponse = await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/Country/{countryResponse!.Id}/$ref");
            var deleteRefResponse = await DeleteAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/Country/{countryResponse!.Id}/$ref");

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);

            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.Country.Should().BeNull();
            getWorkplaceResponse!.CountryId.Should().BeNull();
        }

        #endregion DELETE Delete ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/workplaces/1/Country/1/$ref

        #region DELETE Delete all ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/workplaces/1/Country/$ref

        [Fact]
        public async Task Delete_AllRefToCountry_Success()
        {
            // Arrange
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };

            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
            var createRefResponse = await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/Country/{countryResponse!.Id}/$ref");
            var deleteRefResponse = await DeleteAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/Country/$ref");

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);

            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.Country.Should().BeNull();
            getWorkplaceResponse!.CountryId.Should().BeNull();
        }

        #endregion DELETE Delete all ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/workplaces/1/Country/$ref

        #region DELETE Related Entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName} => api/workplaces/1/Country

        [Fact(Skip = "DeleteBehavior.ClientSetNull needs to be verified")]
        public async Task Delete_Country_Success()
        {
            // Arrange
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto { Name = _fixture.Create<string>() });

            // Act
            var postToCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}",
                new CountryCreateDto() { Name = _fixture.Create<string>() });

            var headers = CreateEtagHeader(postToCountryResponse!.Etag);
            var deleteCountryResponse = await DeleteAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}", headers);

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");
            var getCountryResponse = await GetAsync($"{Endpoints.CountriesUrl}/{postToCountryResponse!.Id}");

            //Assert
            deleteCountryResponse.Should().NotBeNull();
            deleteCountryResponse!.StatusCode.Should().Be(HttpStatusCode.NoContent);

            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.CountryId.Should().BeNull();
            getWorkplaceResponse!.Country!.Should().BeNull();

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        #endregion

        #endregion DELETE

        #endregion RELATIONSHIPS

        #region LOCALIZATIONS

        [Fact]
        public async Task Post_DefaultLanguageDescription_CreatesLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "A modern, modestly sized building with parking, just minutes from the Gare de Lyon and Gare d'Austerlitz.",
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, CreateAcceptLanguageHeader("en-US"));

            var result = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", CreateAcceptLanguageHeader("en-US")))?.ToList();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result![0].Id.Should().Be(postResult!.Id);
            result![0].Name.Should().Be(createDto.Name);
            result![0].Description.Should().Be(createDto.Description);
        }

        [Fact]
        public async Task Post_NotDefaultLanguageDescription_CreatesLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "Un immeuble moderne de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, CreateAcceptLanguageHeader("fr-FR"));            

            var result = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", CreateAcceptLanguageHeader("en-US")))?.ToList();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result![0].Id.Should().Be(postResult!.Id);
            result![0].Name.Should().Be(createDto.Name);
            result![0].Description.Should().Be("[" + createDto.Description + "]");
        }

        [Fact]
        public async Task WhenPutNotDefaultLanguageDescription_ReturnsNotDefautLanguage()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "Default Language",
            };
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            var updatDto = new WorkplaceUpdateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "fr-Fr Language",
            };

            var headers = CreateHeaders(
               CreateEtagHeader(postResult!.Etag),
               CreateAcceptLanguageHeader("fr-FR"));

            // Act

            var putResult = await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updatDto, headers);
            var getResult = (await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}"));

            // Assert
            putResult!.Description.Should().Be(updatDto.Description);
            postResult!.Description.Should().Be(createDto.Description);

            putResult.Etag.Should().Be(getResult!.Etag);
            postResult.Etag.Should().NotBe(putResult.Etag);

        }

        [Fact]
        public async Task Post_WhenInvokedMultipleTimes_CreatesCorrectLocalizations()
        {
            // Arrange
            var createDto1 = new WorkplaceCreateDto
            {
                Name = "Regus - Chertsey Hillswood Business Park",
                Description = "The offices are ideal for those companies wanting immediate, available Wembley serviced offices.",
            };

            var createDto2 = new WorkplaceCreateDto
            {
                Name = "Regus - Dubai BCW Jafza View 18 & 19",
                Description = "برج مكون من 33 طابقا في المنطقة الحرة بجبل علي، ويقع على شارع الشيخ زايد وعلى بعد بضعة كيلومترات فقط من مطار آل مكتوم.",
            };

            var createDto3 = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "Un immeuble moderne de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };

            // Act
            var postResult1 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto1);
            var postResult2 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}?lang=ar-SA", createDto2);
            var postResult3 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}?lang=fr-FR", createDto3, CreateAcceptLanguageHeader("en-US"));

            var enResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}?lang=en-US"))?.ToList();
            var arResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}?lang=ar-SA"))?.ToList();
            var frResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}?lang=fr-FR", CreateAcceptLanguageHeader("en-US")))?.ToList();

            // Assert
            enResult.Should().NotBeNull();
            enResult.Should().HaveCount(3);
            var enWorkplace = enResult!.First(x => x.Id == postResult1!.Id);
            enWorkplace.Name.Should().Be(createDto1.Name);
            enWorkplace.Description.Should().Be(createDto1.Description);

            arResult.Should().NotBeNull();
            arResult.Should().HaveCount(3);
            var arWorkplace = arResult!.First(x => x.Id == postResult2!.Id);
            arWorkplace.Name.Should().Be(createDto2.Name);
            arWorkplace.Description.Should().Be(createDto2.Description);

            frResult.Should().NotBeNull();
            frResult.Should().HaveCount(3);
            var frWorkplace = frResult!.First(x => x.Id == postResult3!.Id);
            frWorkplace.Name.Should().Be(createDto3.Name);
            frWorkplace.Description.Should().Be(createDto3.Description);
        }

        [Fact]
        public async Task Put_DefaultLanguageDescription_UpdatesLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "A modern, modestly sized building with parking.",
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "A modern, modestly sized building with parking, just minutes from the Gare de Lyon and Gare d'Austerlitz.",
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, CreateAcceptLanguageHeader("en-US"));

            var headers = CreateHeaders(
                CreateEtagHeader(postResult!.Etag),
                CreateAcceptLanguageHeader("en-US"));

            await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers);

            var enResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", CreateAcceptLanguageHeader("en-US")))?.ToList();

            // Assert
            enResult.Should().NotBeNull();
            enResult.Should().HaveCount(1);
            enResult![0].Id.Should().Be(postResult.Id);
            enResult![0].Name.Should().Be(createDto.Name);
            enResult![0].Description.Should().Be(updateDto.Description);
        }

        [Fact]
        public async Task Put_NotDefaultLanguageDescription_CreatesLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "A modern, modestly sized building with parking, just minutes from the Gare de Lyon and Gare d'Austerlitz.",
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "Un immeuble moderne de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, CreateAcceptLanguageHeader("en-US"));
            await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}?lang=fr-FR", updateDto, CreateEtagHeader(postResult!.Etag));

            var enResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", CreateAcceptLanguageHeader("en-US")))?.ToList();
            var frResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}?lang=fr-FR", CreateAcceptLanguageHeader("en-US")))?.ToList();

            // Assert
            enResult.Should().NotBeNull();
            enResult.Should().HaveCount(1);
            enResult![0].Id.Should().Be(postResult!.Id);
            enResult![0].Name.Should().Be(createDto.Name);
            enResult![0].Description.Should().Be(createDto.Description);

            frResult.Should().NotBeNull();
            frResult.Should().HaveCount(1);
            frResult![0].Id.Should().Be(postResult.Id);
            frResult![0].Name.Should().Be(createDto.Name);
            frResult![0].Description.Should().Be(updateDto.Description);
        }

        [Fact]
        public async Task Put_NotDefaultLanguageDescriptionIsSetToNull_UpdatesLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "A modern, modestly sized building with parking, just minutes from the Gare de Lyon and Gare d'Austerlitz.",
            };

            var update1Dto = new WorkplaceUpdateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "Un immeuble moderne de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };

            var update2Dto = new WorkplaceUpdateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = null,
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, CreateAcceptLanguageHeader("en-US"));

            var headers1 = CreateHeaders(
                CreateEtagHeader(postResult!.Etag),
                CreateAcceptLanguageHeader("fr-FR"));

            var putResult1 = await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", update1Dto, headers1);

            var headers2 = CreateHeaders(
                CreateEtagHeader(putResult1!.Etag),
                CreateAcceptLanguageHeader("fr-FR"));

            await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", update2Dto, headers2);

            var enResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", CreateAcceptLanguageHeader("en-US")))?.ToList();
            var frResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", CreateAcceptLanguageHeader("fr-FR")))?.ToList();

            // Assert
            enResult.Should().NotBeNull();
            enResult.Should().HaveCount(1);
            enResult![0].Id.Should().Be(postResult.Id);
            enResult![0].Name.Should().Be(createDto.Name);
            enResult![0].Description.Should().Be(createDto.Description);

            frResult.Should().NotBeNull();
            frResult.Should().HaveCount(1);
            frResult![0].Id.Should().Be(postResult.Id);
            frResult![0].Name.Should().Be(createDto.Name);
            frResult![0].Description.Should().Be("[" + createDto.Description + "]");
        }

        [Fact]
        public async Task Patch_DefaultLanguageDescription_UpdatesLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "A modern, modestly sized building with parking.",
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Description = "A modern, modestly sized building with parking, just minutes from the Gare de Lyon and Gare d'Austerlitz.",
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, CreateAcceptLanguageHeader("en-US"));

            var headers = CreateHeaders(
                CreateEtagHeader(postResult!.Etag),
                CreateAcceptLanguageHeader("en-US"));

            await PatchAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers);

            var enResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", CreateAcceptLanguageHeader("en-US")))?.ToList();

            // Assert
            enResult.Should().NotBeNull();
            enResult.Should().HaveCount(1);
            enResult![0].Id.Should().Be(postResult.Id);
            enResult![0].Name.Should().Be(createDto.Name);
            enResult![0].Description.Should().Be(updateDto.Description);
        }

        [Fact]
        public async Task Patch_NotDefaultLanguageDescription_UpdatesLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "A modern, modestly sized building with parking, just minutes from the Gare de Lyon and Gare d'Austerlitz.",
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Description = "Un immeuble moderne de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, CreateAcceptLanguageHeader("en-US"));
            await PatchAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}?lang=fr-FR", updateDto, CreateEtagHeader(postResult!.Etag));

            var enResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", CreateAcceptLanguageHeader("en-US")))?.ToList();
            var frResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}?lang=fr-FR", CreateAcceptLanguageHeader("en-US")))?.ToList();

            // Assert
            enResult.Should().NotBeNull();
            enResult.Should().HaveCount(1);
            enResult![0].Id.Should().Be(postResult!.Id);
            enResult![0].Name.Should().Be(createDto.Name);
            enResult![0].Description.Should().Be(createDto.Description);

            frResult.Should().NotBeNull();
            frResult.Should().HaveCount(1);
            frResult![0].Id.Should().Be(postResult.Id);
            frResult![0].Name.Should().Be(createDto.Name);
            frResult![0].Description.Should().Be(updateDto.Description);
        }

        [Fact]
        public async Task Put_NewLanguageDescription_CreatesLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "Un immeuble moderne de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };


            var upsertDto = new WorkplaceLocalizedUpsertDto
            {
                Description = "Gare de Lyon ve Gare d'Austerlitz'e birkaç dakika uzaklıkta, otoparkı olan mütevazı büyüklükte modern bir bina.",
            };



            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, CreateAcceptLanguageHeader("fr-FR"));

            var result = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", CreateAcceptLanguageHeader("en-US")))?.ToList();

            var headers = CreateHeaders(
                CreateEtagHeader(postResult!.Etag),
                CreateAcceptLanguageHeader("en-US"));

            var localizedDto = await PutAsync<WorkplaceLocalizedUpsertDto, WorkplaceLocalizedDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}/Languages/tr-TR", upsertDto, headers, false);
            var localizations = (await GetResponseAsync<IEnumerable<WorkplaceLocalizedDto>>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}/Languages"))?.ToList();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result![0].Id.Should().Be(postResult!.Id);
            result![0].Name.Should().Be(createDto.Name);
            result![0].Description.Should().Be("[" + createDto.Description + "]");
            localizedDto.Should().NotBeNull();
            localizedDto!.Id.Should().Be(postResult!.Id);
            localizedDto!.Description.Should().Be(upsertDto.Description);

            localizations.Should().NotBeNull();
            localizations.Should().HaveCount(2);
            localizations.Should().ContainSingle(l => l.Id == postResult!.Id && l.CultureCode == "fr-FR" && l.Description == createDto.Description);
            localizations.Should().ContainSingle(l => l.Id == postResult!.Id && l.CultureCode == "tr-TR" && l.Description == upsertDto.Description);
        }

        [Fact]
        public async Task Put_CreateWorkplaceLocalization_Success()
        {
            var newWorkplace = await CreateWorkplaceAndGetId();
            var cultureCode = "ar-SA";
            var upsertDto = new WorkplaceLocalizedUpsertDto
            {
                Description = "الوصف المترجم باللغة الإنجليزية."
            };


            var headers = CreateHeaders(
                CreateAcceptLanguageHeader(cultureCode));

            var putResult = await PutAsync<WorkplaceLocalizedUpsertDto, WorkplaceLocalizedDto>(
                $"{Endpoints.WorkplacesUrl}/{newWorkplace.Id}/Languages/{cultureCode}",
                upsertDto,
                headers, false);

            putResult.Should().NotBeNull();
            putResult!.Id.Should().Be(newWorkplace.Id);
            putResult.CultureCode.Should().Be(cultureCode);
            putResult.Description.Should().Be(upsertDto.Description);
        }

        [Fact]
        public async Task Get_RetrieveWorkplaceLocalizations_Success()
        {
            var newWorkplace = await CreateWorkplaceAndGetId();

            var localizations = (await GetResponseAsync<IEnumerable<WorkplaceLocalizedDto>>(
                $"{Endpoints.WorkplacesUrl}/{newWorkplace.Id}/Languages",
                CreateAcceptLanguageHeader("en-US")))?.ToList();


            localizations.Should().NotBeNull();
            localizations.Should().NotBeEmpty();
            localizations.Should().Contain(l => l.Id == newWorkplace.Id);
        }

        [Fact] 
        public async Task GetOwnedEntityLocalizations_WithIrregularPluralName_Success()
        {
            var createDto = new WorkplaceCreateDto
            {
                Name = "Example Workplace",
                Description = "Description of Example Workplace.",
                WorkplaceAddresses = new List<WorkplaceAddressUpsertDto> { new WorkplaceAddressUpsertDto { AddressLine = "123 Main St", Id = System.Guid.NewGuid()  } }
            };

            var workplace = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(
                Endpoints.WorkplacesUrl,
                createDto,
                CreateAcceptLanguageHeader("en-US"));

            var upsertWorkplaceAddressLocalization = new WorkplaceAddressLocalizedUpsertDto
            {
                Id = createDto.WorkplaceAddresses[0].Id,
                AddressLine = "123 R. principale",
            };

            await PutAsync<WorkplaceAddressLocalizedUpsertDto, WorkplaceAddressLocalizedDto>(
                $"{Endpoints.WorkplacesUrl}/{workplace!.Id}/WorkplaceAddresses/{createDto.WorkplaceAddresses![0].Id}/Languages/fr-FR",
                upsertWorkplaceAddressLocalization, null, false);

            // Act
            var workplaceAddressesLocalizations = await GetResponseAsync<List<WorkplaceAddressLocalizedDto>>(
                $"{Endpoints.WorkplacesUrl}/{workplace!.Id}/WorkplaceAddresses/{createDto.WorkplaceAddresses![0].Id}/Languages",
                CreateAcceptLanguageHeader("fr-FR"));

            // Assert
            workplaceAddressesLocalizations.Should().NotBeNull();
            workplaceAddressesLocalizations.Should().HaveCount(2);
            workplaceAddressesLocalizations.Should().Contain(x => x.CultureCode == "en-US");
            workplaceAddressesLocalizations!.First(x => x.CultureCode == "en-US").AddressLine.Should().Be("123 Main St");
            workplaceAddressesLocalizations!.First(x => x.CultureCode == "fr-FR").AddressLine.Should().Be("123 R. principale");
        }

        [Fact]
        public async Task Get_RetrieveWorkplaceLocalizationsWithODataQueryFilter_Success()
        {
            // Arrange
            var newWorkplace = await CreateWorkplaceAndGetId();

            string frCultureCode = "fr-FR";
            var frUpsertDto = new WorkplaceLocalizedUpsertDto
            {
                Description = "Un immeuble moderne de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };

            var headers = CreateHeaders(
                CreateAcceptLanguageHeader(frCultureCode));

            await PutAsync<WorkplaceLocalizedUpsertDto, WorkplaceLocalizedDto>(
                $"{Endpoints.WorkplacesUrl}/{newWorkplace.Id}/Languages/{frCultureCode}",
                frUpsertDto,
                headers, false);

            var trCultureCode = "tr-TR";
            var trUpsertDto = new WorkplaceLocalizedUpsertDto
            {
                Description = "Gare de Lyon ve Gare d'Austerlitz'e birkaç dakika uzaklıkta, otoparkı olan mütevazı büyüklükte modern bir bina.",
            };

            headers = CreateHeaders(
                CreateAcceptLanguageHeader(trCultureCode));
            
            await PutAsync<WorkplaceLocalizedUpsertDto, WorkplaceLocalizedDto>(
                $"{Endpoints.WorkplacesUrl}/{newWorkplace.Id}/Languages/{trCultureCode}",
                trUpsertDto,
                headers, false);
            
            // Act
            var result = (await GetResponseAsync<IEnumerable<WorkplaceLocalizedDto>>($"{Endpoints.WorkplacesUrl}/{newWorkplace.Id}/Languages?$filter=CultureCode eq '{frCultureCode}'"))?.ToList();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result.Should().ContainSingle(l => l.Id == newWorkplace.Id && l.CultureCode == frCultureCode && l.Description == frUpsertDto.Description);
        }

        [Fact]
        public async Task Put_UpdateWorkplaceLocalization_Success()
        {
            // Create a new workplace and get its ID
            var newWorkplace = await CreateWorkplaceAndGetId();
            var cultureCode = "en-US";
            var initialDescription = "Initial Description";
            var updatedDescription = "Updated Description";

            // Initial localization creation
            var initialUpsertDto = new WorkplaceLocalizedUpsertDto
            {
                Description = initialDescription
            };

            var headers = CreateHeaders(
                CreateAcceptLanguageHeader(cultureCode));

            var initialPutResult = await PutAsync<WorkplaceLocalizedUpsertDto, WorkplaceLocalizedDto>(
                $"{Endpoints.WorkplacesUrl}/{newWorkplace.Id}/Languages/{cultureCode}",
                initialUpsertDto,
                headers, false);

            initialPutResult.Should().NotBeNull();
            initialPutResult!.Description.Should().Be(initialDescription);

            // Update localization
            var upsertDto = new WorkplaceLocalizedUpsertDto
            {
                Description = updatedDescription
            };

            var putResult = await PutAsync<WorkplaceLocalizedUpsertDto, WorkplaceLocalizedDto>(
                $"{Endpoints.WorkplacesUrl}/{newWorkplace.Id}/Languages/{cultureCode}",
                upsertDto,
                headers, false);

            putResult.Should().NotBeNull();
            putResult!.Description.Should().Be(updatedDescription);

            // Get all localizations
            var localizations = (await GetResponseAsync<IEnumerable<WorkplaceLocalizedDto>>(
                $"{Endpoints.WorkplacesUrl}/{newWorkplace.Id}/Languages",
                CreateAcceptLanguageHeader("en-US")))?.ToList();

            localizations.Should().NotBeNull();
            localizations.Should().NotBeEmpty();
            localizations.Should().HaveCount(1);
            localizations.Should().Contain(l => l.Id == newWorkplace.Id);
            localizations.Should().Contain(l => l.Description == updatedDescription);
        }


        private async Task<WorkplaceDto> CreateWorkplaceAndGetId()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Example Workplace",
                Description = "Description of Example Workplace."
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(
                Endpoints.WorkplacesUrl,
                createDto,
                CreateAcceptLanguageHeader("en-US"));

            // Assert
            postResult.Should().NotBeNull();
            postResult!.Id.Should().BePositive(); // Ensures that an ID was assigned

            return postResult;
        }

        [Fact]
        public async Task Delete_DeletingNonDefaultLocalization_DeletesLocalization()
        {
            // Arrange
            var newWorkplace = await CreateWorkplaceAndGetId();
            var cultureCode = "ar-SA";
            var upsertDto = new WorkplaceLocalizedUpsertDto
            {
                Description = "الوصف المترجم باللغة الإنجليزية."
            };

            var headers = CreateHeaders(
                CreateAcceptLanguageHeader(cultureCode));

            await PutAsync<WorkplaceLocalizedUpsertDto, WorkplaceLocalizedDto>(
                $"{Endpoints.WorkplacesUrl}/{newWorkplace.Id}/Languages/{cultureCode}",
                upsertDto,
                headers, false);

            // Act
            var deleteResult = await DeleteAsync($"{Endpoints.WorkplacesUrl}/{newWorkplace!.Id}/Languages/{cultureCode}");
            var arResult = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}?lang={cultureCode}", CreateAcceptLanguageHeader(cultureCode)))?.ToList();

            // Assert
            deleteResult!.StatusCode.Should().Be(HttpStatusCode.NoContent);
            arResult.Should().NotBeNull();

            // Result should be in default culture since ar localization is deleted
            arResult![0]!.Description.Should().Be(newWorkplace.Description);
        }

        [Fact]
        public async Task Delete_DeletingDefaultLocalization_ReturnsBadRequest()
        {
            // Arrange
            var newWorkplace = await CreateWorkplaceAndGetId();

            // Act
            var deleteResult = await DeleteAsync($"{Endpoints.WorkplacesUrl}/{newWorkplace!.Id}/Languages/en-US", false);

            // Assert
            deleteResult!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var response = await deleteResult.Content.ReadFromJsonAsync<ApplicationErrorCodeResponse>();
            response!.Error.Code.Should().Be("bad_request");
        }

        [Fact]
        public async Task Delete_DeletingNonExistentLocalization_ReturnsNotFound()
        {
            // Arrange
            var newWorkplace = await CreateWorkplaceAndGetId();

            // Act
            var deleteResult = await DeleteAsync($"{Endpoints.WorkplacesUrl}/{newWorkplace!.Id}/WorkplacesLocalized/fr-FR", false);

            // Assert
            deleteResult!.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Delete_DeletingForEntityThatDoesntExist_ReturnsNotFound()
        {
            // Arrange
            var id = 123;

            // Act
            var deleteResult = await DeleteAsync($"{Endpoints.WorkplacesUrl}/{id}/WorkplacesLocalized/fr-FR", false);

            // Assert
            deleteResult!.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        #endregion LOCALIZATIONS

        #region ENUMS

        [Fact]
        public async Task CreateWorkplace_WithOwnershipId_ReturnsOwnershipIdAndName()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
                Ownership = 1000,
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            //Assert
            postResult.Should().NotBeNull();
            postResult!.Ownership.Should().Be(1000);
            postResult.OwnershipName.Should().Be("Fully Owned");
        }

        [Fact]
        public async Task CreateWorkplace_WithLocalizedOwnershipId_ReturnsLocalizedOwnershipIdAndName()
        {
            // Arrange
            
            await PutAsync($"{Endpoints.WorkplacesUrl}/Ownerships/1000/Languages/fr-FR", new WorkplaceOwnershipLocalizedUpsertDto()
            {
                Name = "Entièrement possédé"
            });


            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
                Ownership = 1000,
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}?lang=fr-FR", createDto);

            //Assert
            postResult.Should().NotBeNull();
            postResult!.Ownership.Should().Be(1000);
            postResult.OwnershipName.Should().Be("Entièrement possédé");
        }

        [Fact]
        public async Task CreateWorkplace_WithLocalizedOwnershipId_ReturnsOwnershipIdAndName()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
                Ownership = 1000,
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}?lang=fr-FR", createDto);

            //Assert
            postResult.Should().NotBeNull();
            postResult!.Ownership.Should().Be(1000);
            postResult.OwnershipName.Should().Be("[Fully Owned]");
        }

        [Fact]
        public async Task CreateWorkplace_WithTypeId_ReturnsTypeIdAndName()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
                Type = 1000,
            };

            // Act
            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            //Assert
            postResult.Should().NotBeNull();
            postResult!.Type.Should().Be(1000);
            postResult.TypeName.Should().Be("Business Centre");
        }

        #endregion ENUMS

        [Fact]
        public async Task WhenRequestHasInvalidFieldType_ShouldReturnBadRequestInvalid()
        {

            //Act
            var postResult = await PostAsync(Endpoints.WorkplacesUrl, new { CountryId = "aaa" });
            var response = await postResult.Content.ReadFromJsonAsync<ApplicationErrorCodeResponse>();

            //Assert
            postResult.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            response!.Error.Code.Should().Be("bad_request_invalid_field");
        }

        [Fact]
        public async Task Put_Description_ShouldUpdate()
        {
            var nameFixture = _fixture.Create<string>();

            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = nameFixture,
                Description = _fixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                // Name shouldn't change, description should
                Name = nameFixture,
                Description = _fixture.Create<string>(),
            };

            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            var headers = CreateEtagHeader(postResult!.Etag);

            // Act
            var putResult = await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers);

            //Assert
            putResult.Should().NotBeNull();
        }

        [Fact]
        public async Task Patch_Description_ShouldUpdateDescriptionOnly()
        {
            // Arrange
            var expectedName = _fixture.Create<string>();
            var originalDescription = _fixture.Create<string>();
            var expectedDescription = _fixture.Create<string>();

            var createDto = new WorkplaceCreateDto
            {
                Name = expectedName,
                Description = originalDescription
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Description = expectedDescription
            };

            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);
            var headers = CreateEtagHeader(postResult!.Etag);

            // Act
            var patchResult = await PatchAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers);

            //Assert
            patchResult.Should().NotBeNull();
            patchResult!.Name.Should().Be(expectedName);
            patchResult!.Description.Should().Be(expectedDescription);
        }

        [Fact]
        public async Task Deleted_ShouldPerformHardDelete()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            var result = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);
            var headers = CreateEtagHeader(result!.Etag);

            // Act
            await DeleteAsync($"{Endpoints.WorkplacesUrl}/{result!.Id}", headers);
            var queryResult = await GetAsync($"{Endpoints.WorkplacesUrl}/{result!.Id}");

            // Assert

            queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_WithoutEtag_ShouldGetConflictError()
        {
            var nameFixture = _fixture.Create<string>();

            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = nameFixture,
                Description = _fixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                // Name shouldn't change, description should
                Name = nameFixture,
                Description = _fixture.Create<string>(),
            };

            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            var headers = new Dictionary<string, IEnumerable<string>>();

            // Act
            var responseMessage = await PutAsync($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers, false);
            var content = await responseMessage!.Content.ReadAsStringAsync();

            //Assert
            responseMessage
                .Should()
                .HaveStatusCode(HttpStatusCode.PreconditionRequired);

            headers = new()
            {
                { "If-Match", new List<string> { $"\"wrongETag\"" } }
            };

            responseMessage = await PutAsync($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers, false);
            content = await responseMessage!.Content.ReadAsStringAsync();

            responseMessage
                .Should()
                .HaveStatusCode(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        public async Task Get_LocalizedValueNotFound_ShouldReturnDefaultValue()
        {
            var nameFixture = _fixture.Create<string>();
            var testDescription = "TestDescription";

            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = nameFixture,
                Description = testDescription,
            };

            await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            var headers = new Dictionary<string, IEnumerable<string>>()
            {
                { "Accept-Language", new List<string> { $"fr-FR, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5" } }
            };

            // Act
            var localizedWorkplaces = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", headers))?.ToList();

            // Assert
            localizedWorkplaces.Should().NotBeNull();
            localizedWorkplaces.Should().HaveCount(1);
            localizedWorkplaces![0].Description.Should().NotBeNull();
            localizedWorkplaces[0].Description.Should().BeEquivalentTo($"[{testDescription}]");
        }

        [Fact]
        public async Task GetById_LocalizedValueNotFound_ShouldReturnDefaultValue()
        {
            var nameFixture = _fixture.Create<string>();
            var testDescription = "TestDescription";

            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = nameFixture,
                Description = testDescription,
            };

            var createdEntity = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            var headers = new Dictionary<string, IEnumerable<string>>()
            {
                { "Accept-Language", new List<string> { $"fr-FR, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5" } }
            };

            // Act
            var localizedWorkplaces = (await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{createdEntity!.Id}", headers));

            // Assert
            localizedWorkplaces.Should().NotBeNull();
            localizedWorkplaces!.Description.Should().NotBeNull();
            localizedWorkplaces.Description.Should().BeEquivalentTo($"[{testDescription}]");
        }

        [Fact]
        public async Task Get_LocalizedValue_ShouldReturnLocalizationValue()
        {
            var nameFixture = _fixture.Create<string>();
            var descriptionFr = "Test description French";
            var testCulture = "fr-CH";

            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = nameFixture,
                Description = descriptionFr,
            };

            var headers = new Dictionary<string, IEnumerable<string>>()
            {
                { "Accept-Language", new List<string> { $"{testCulture}, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5" } }
            };

            await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, headers);

            // Act
            var localizedWorkplaces = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", headers))?.ToList();

            // Assert
            localizedWorkplaces.Should().NotBeNull();
            localizedWorkplaces.Should().HaveCount(1);
            localizedWorkplaces![0].Description.Should().BeEquivalentTo(descriptionFr);
        }

        [Fact]
        public async Task GetById_LocalizedValue_ShouldReturnLocalizationValue()
        {
            var nameFixture = _fixture.Create<string>();
            var descriptionFr = "Test description French";
            var testCulture = "fr-CH";

            // Arrange
            var headers = new Dictionary<string, IEnumerable<string>>()
            {
                { "Accept-Language", new List<string> { $"{testCulture}, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5" } }
            };

            var createFrDto = new WorkplaceCreateDto
            {
                Name = nameFixture,
                Description = descriptionFr,
            };

            var createdEntity = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createFrDto, headers);

            // Act
            var localizedWorkplace = (await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{createdEntity!.Id}", headers));

            // Assert
            localizedWorkplace.Should().NotBeNull();
            localizedWorkplace!.Description.Should().NotBeNull();
            localizedWorkplace!.Description.Should().BeEquivalentTo(descriptionFr);
        }

        #region Many to Many Relations

        [Fact]
        public async Task Put_UpdateRefWorkplaceToTenants_InManyToManyRelationship_Success()
        {
            // Arrange
            var tenant = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
               new TenantCreateDto() { Name = _fixture.Create<string>() }));
            var workplace = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() });

            // Act
            var headers = CreateEtagHeader(workplace!.Etag);

            await PutAsync(
                _endPointFixture
                .EndPointForEntity
                .WithEntityKey(workplace!.Id)
                .WithRelatedEntity(nameof(ClientApi.Domain.Tenant))
                .WithRefs()
                .BuildUrl(),
                new ReferencesDto<uint>
                {
                    References = new List<uint> { tenant!.Id }
                },
                headers);

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Tenants)}";
            var result = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplace!.Id}?{oDataRequest}");

            //Assert
            result.Should().NotBeNull();
            result!.Tenants.Should().NotBeNull();
            result!.Tenants!.Should().HaveCount(1);
            result!.Tenants!.First().Id.Should().Be(tenant.Id);
        }

        [Fact]
        public async Task WhenCreateWorkPlaceWithMultipleTenants_RelationNeedsToBeCreated()
        {
            // Arrange
            var tenantId1 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            var tenantId2 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto() { Name = _fixture.Create<string>(), TenantsId = new() { tenantId1, tenantId2 } });

            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?$expand={nameof(WorkplaceDto.Tenants)}");

            // Assert
            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Tenants.Should().HaveCount(2);
            getWorkplaceResponse!.Tenants.Should().Contain(t => t.Id == tenantId1);
            getWorkplaceResponse!.Tenants.Should().Contain(t => t.Id == tenantId2);
        }

        [Fact]
        public async Task WhenAddingTenantRelationsToWorkplace_RelationNeedsToBeCreated()
        {
            // Arrange
            var tenantId1 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            var tenantId2 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            var workplaceId = (await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            // Act
            await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceId}/Tenants/{tenantId1}/$ref");
            await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceId}/Tenants/{tenantId2}/$ref");

            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceId}?$expand={nameof(WorkplaceDto.Tenants)}");

            // Assert
            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Tenants.Should().HaveCount(2);
            getWorkplaceResponse!.Tenants.Should().Contain(t => t.Id == tenantId1);
            getWorkplaceResponse!.Tenants.Should().Contain(t => t.Id == tenantId2);
        }

        [Fact]
        public async Task WhenDeletingTenantRelationsFromWorkplace_RelationNeedsToBeDeleted()
        {
            // Arrange
            var tenantId1 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            var tenantId2 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TenantsUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;

            // Act
            var workplace = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl,
                new WorkplaceCreateDto() { Name = _fixture.Create<string>(), TenantsId = new() { tenantId1, tenantId2 } });

            // Act
            await DeleteAsync($"{Endpoints.WorkplacesUrl}/{workplace!.Id}/Tenants/{tenantId1}/$ref");
            await DeleteAsync($"{Endpoints.WorkplacesUrl}/{workplace!.Id}/Tenants/{tenantId2}/$ref");

            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplace.Id}?$expand={nameof(WorkplaceDto.Tenants)}");

            // Assert
            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Tenants.Should().BeEmpty();
        }

        #endregion Many to Many Relations
    }
}