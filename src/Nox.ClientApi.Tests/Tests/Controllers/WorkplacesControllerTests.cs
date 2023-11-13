using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;
using ClientApi.Tests.Controllers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ClientApi.Tests.Tests.Controllers
{
    [Collection("Sequential")]
    public class WorkplacesControllerTests : NoxWebApiTestBase
    {
        public WorkplacesControllerTests(ITestOutputHelper testOutput,
            TestDatabaseContainerService containerService)
            : base(testOutput, containerService)
        {
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

        #endregion GET Ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/workplaces/1/Country/$ref

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
            var headers = CreateEtagHeader(workplaceResponse?.Etag);
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

        [Fact]
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
                    CountryId = countryResponse2!.Id
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

            var headers = CreateEtagHeader(workplaceResponse?.Etag);
            var postToCountryResponse = await PostAsync<CountryCreateDto, CountryDto>(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}",
                new CountryCreateDto() { Name = _fixture.Create<string>() },
                headers);

            var expectedName = _fixture.Create<string>();

            // Act
            headers = CreateEtagHeader(postToCountryResponse?.Etag);
            var putToCountryResponse = await PutAsync<CountryUpdateDto>(
                $"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Country)}",
                new CountryUpdateDto()
                {
                    Name = expectedName,
                    WorkplacesId = new List<uint> { workplaceResponse!.Id }
                },
                headers);

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Country)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            putToCountryResponse.Should().NotBeNull();
            putToCountryResponse!.StatusCode.Should().Be(HttpStatusCode.OK);

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
                CreateEtagHeader(postResult?.Etag),
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
            await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}?lang=fr-FR", updateDto, CreateEtagHeader(postResult?.Etag));

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
                CreateEtagHeader(postResult?.Etag),
                CreateAcceptLanguageHeader("fr-FR"));

            var putResult1 = await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", update1Dto, headers1);
            
            var headers2 = CreateHeaders(
                CreateEtagHeader(putResult1?.Etag),
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

        [Fact(Skip="The Patch end point need to be changed from EntityDto to UpdateDto")]
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
                CreateEtagHeader(postResult?.Etag),
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

        [Fact(Skip="The Patch end point need to be changed from EntityDto to UpdateDto")]
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
            await PatchAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}?lang=fr-FR", updateDto, CreateEtagHeader(postResult?.Etag));

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

        #endregion LOCALIZATIONS

        [Fact]
        public async Task Post_ToEntityWithNuid_NuidIsCreated()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Portugal"
            };

            // Act
            var result = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            //Assert
            result.Should().NotBeNull();
            result.Should()
                .BeOfType<WorkplaceDto>()
                .Which.Id.Should().Be(3891835289); // We can pre compute the expected nuid
        }

        [Fact]
        public async Task Put_Name_ShouldFailWithNuidException()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Name = _fixture.Create<string>(),
            };

            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

            var headers = CreateEtagHeader(postResult?.Etag);

            // Act
            var putResult = await PutAsync<WorkplaceUpdateDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers, false);

            //Assert
            var errorMessage = await putResult!.Content.ReadAsStringAsync();
            errorMessage.Should().Contain("Immutable nuid property Id value is different since it has been initialized");
            putResult.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
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

            var headers = CreateEtagHeader(postResult?.Etag);

            // Act
            var putResult = await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers);

            //Assert
            putResult.Should().NotBeNull();
        }

        [Fact(Skip = "The Patch end point need to be changed from EntityDto to UpdateDto")]
        public async Task Patch_Name_ShouldUpdateNameOnly()
        {
            // Arrange
            var expectedName = _fixture.Create<string>();

            var createDto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };

            var updateDto = new WorkplaceUpdateDto
            {
                Name = expectedName
            };

            var postResult = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);
            var headers = CreateEtagHeader(postResult!.Etag);
            // Act

            var patchResult = await PatchAsync<WorkplaceUpdateDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers, false);

            //Assert
            var errorMessage = await patchResult!.Content.ReadAsStringAsync();
            errorMessage.Should().Contain("Immutable nuid property Id value is different since it has been initialized");
            patchResult.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }

        // TODO: FIX THIS TEST ONCE LOCALIZATION IS IMPLEMENTED FOR PATCH
        [Fact(Skip = "The Patch end point need to be changed from EntityDto to UpdateDto")]
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
            var headers = CreateEtagHeader(result?.Etag);

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

            content.Should()
                .Contain("ETag is empty. ETag should be provided via the If-Match HTTP Header.");

            headers = new()
            {
                { "If-Match", new List<string> { $"\"wrongETag\"" } }
            };

            responseMessage = await PutAsync($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers, false);
            content = await responseMessage!.Content.ReadAsStringAsync();

            responseMessage
                .Should()
                .HaveStatusCode(HttpStatusCode.PreconditionFailed);

            content.Should()
                .Contain("ETag is not well-formed.");
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
        public async Task WhenCreateWorkPlaceWithMultipleTenants_RelationNeedsToBeCreated()
        {
            // Arrange
            var tenantId1 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TeanantUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;
            var tenantId2 = (await PostAsync<TenantCreateDto, TenantDto>(Endpoints.TeanantUrl,
                new TenantCreateDto() { Name = _fixture.Create<string>() }))!.Id;
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>(), TenantsId = new() { tenantId1, tenantId2 } };



            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            const string oDataRequest = $"$expand={nameof(WorkplaceDto.Tenants)}";
            
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //TODO Anna when we are able to Get Related Entities
            //var getTenants = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.Tenants)}");

            // Assert
            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Tenants.Should().HaveCount(2);
            getWorkplaceResponse!.Tenants.Should().Contain(t=>t.Id == tenantId1);
            getWorkplaceResponse!.Tenants.Should().Contain(t => t.Id == tenantId2);
        }
        #endregion
    }
}