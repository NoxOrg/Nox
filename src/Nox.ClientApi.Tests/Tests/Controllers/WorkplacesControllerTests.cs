using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using System.Net;
using ClientApi.Tests.Tests.Models;
using Xunit.Abstractions;
using ClientApi.Tests.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using static MassTransit.ValidationResultExtensions;

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

        #region GET Ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/workplaces/1/belongstocountry/$ref

        [Fact]
        public async Task Get_RefToRelatedEntity_Success()
        {
            // Arrange
            var dto = new WorkplaceCreateDto
            {
                Name = _fixture.Create<string>(),
            };
            var belongsToCountry = new CountryCreateDto()
            {
                Name = _fixture.Create<string>()
            };

            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, dto);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, belongsToCountry);
            await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/BelongsToCountry/{countryResponse!.Id}/$ref");

            // Act
            var getRefResponse = await GetODataSimpleResponseAsync<ODataReferenceResponse>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/{nameof(WorkplaceDto.BelongsToCountry)}/$ref");

            //Assert
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);

            getRefResponse.Should().NotBeNull();
            getRefResponse!.ODataId!.Should().NotBeNullOrEmpty();
        }

        #endregion GET Ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/workplaces/1/belongstocountry/$ref

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
                BelongsToCountry = new CountryCreateDto()
                {
                    Name = expectedCountryName
                }
            };
            // Act
            var result = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, dto);
            const string oDataRequest = $"$expand={nameof(WorkplaceDto.BelongsToCountry)}";
            var getCountryResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{result!.Id}?{oDataRequest}");

            //Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);

            getCountryResponse.Should().NotBeNull();
            getCountryResponse!.Id.Should().BeGreaterThan(0);
            getCountryResponse!.BelongsToCountry.Should().NotBeNull();
            getCountryResponse!.BelongsToCountry!.Name.Should().Be(expectedCountryName);
        }

        #endregion POST Entity With Related Entity /api/{EntityPluralName} => api/workplaces

        #region POST Create ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/workplaces/1/belongstocountry/1/$ref

        [Fact]
        public async Task Post_CreateRefToBelongsToCountry_Success()
        {
            // Arrange
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };

            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
            var createRefResponse = await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/belongstocountry/{countryResponse!.Id}/$ref");

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.BelongsToCountry)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);

            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.BelongsToCountry.Should().NotBeNull();
            getWorkplaceResponse!.BelongsToCountry!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.BelongsToCountry!.Name.Should().NotBeNull();
        }

        #endregion POST Create ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/workplaces/1/belongstocountry/1/$ref

        #endregion POST

        #region PUT

        #region PUT Update related entity /api/{EntityPluralName}/{EntityKey} => api/workplaces/1

        [Fact]
        public async Task Put_UpdateBelongsToCountry_Success()
        {
            // Arrange
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
            var countryCreateDto1 = new CountryCreateDto { Name = _fixture.Create<string>() };
            var countryCreateDto2 = new CountryCreateDto { Name = _fixture.Create<string>() };

            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var countryResponse1 = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto1);
            var countryResponse2 = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto2);
            await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/belongstocountry/{countryResponse1!.Id}/$ref");

            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}");
            var headers = CreateEtagHeader(getWorkplaceResponse!.Etag);
            await PutAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}",
                new WorkplaceUpdateDto
                {
                    Name = workplaceResponse!.Name,
                    BelongsToCountryId = countryResponse2!.Id
                },
                headers);

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.BelongsToCountry)}";
            getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.BelongsToCountry.Should().NotBeNull();
            getWorkplaceResponse!.BelongsToCountry!.Id.Should().Be(countryResponse2!.Id);
        }

        #endregion

        #endregion

        #region DELETE

        #region DELETE Delete ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/workplaces/1/belongstocountry/1/$ref

        [Fact]
        public async Task Delete_RefToBelongsToCountry_Success()
        {
            // Arrange
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };

            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
            var createRefResponse = await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/belongstocountry/{countryResponse!.Id}/$ref");
            var deleteRefResponse = await DeleteAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/belongstocountry/{countryResponse!.Id}/$ref");

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.BelongsToCountry)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);

            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.BelongsToCountry.Should().BeNull();
            getWorkplaceResponse!.BelongsToCountryId.Should().BeNull();
        }

        #endregion DELETE Delete ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/{RelatedEntityKey}/$ref => api/workplaces/1/belongstocountry/1/$ref

        #region DELETE Delete all ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/workplaces/1/belongstocountry/$ref

        [Fact]
        public async Task Delete_AllRefToBelongsToCountry_Success()
        {
            // Arrange
            var workplaceCreateDto = new WorkplaceCreateDto() { Name = _fixture.Create<string>() };
            var countryCreateDto = new CountryCreateDto { Name = _fixture.Create<string>() };

            // Act
            var workplaceResponse = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, workplaceCreateDto);
            var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, countryCreateDto);
            var createRefResponse = await PostAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/belongstocountry/{countryResponse!.Id}/$ref");
            var deleteRefResponse = await DeleteAsync($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}/belongstocountry/$ref");

            const string oDataRequest = $"$expand={nameof(WorkplaceDto.BelongsToCountry)}";
            var getWorkplaceResponse = await GetODataSimpleResponseAsync<WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{workplaceResponse!.Id}?{oDataRequest}");

            //Assert
            workplaceResponse.Should().NotBeNull();
            workplaceResponse!.Id.Should().BeGreaterThan(0);
            countryResponse.Should().NotBeNull();
            countryResponse!.Id.Should().BeGreaterThan(0);

            getWorkplaceResponse.Should().NotBeNull();
            getWorkplaceResponse!.Id.Should().BeGreaterThan(0);
            getWorkplaceResponse!.BelongsToCountry.Should().BeNull();
            getWorkplaceResponse!.BelongsToCountryId.Should().BeNull();
        }

        #endregion DELETE Delete all ref to related entity /api/{EntityPluralName}/{EntityKey}/{RelationshipName}/$ref => api/workplaces/1/belongstocountry/$ref

        #endregion DELETE

        #endregion RELATIONSHIPS

        #region LOCALIZATIONS

        [Fact]
        public async Task Post_DefaultLanguageDescription_CreateLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "A modern, modestly sized building with parking, just minutes from the Gare de Lyon and Gare d'Austerlitz.",
            };

            var headers = CreateAcceptLanguageHeader("en-US");

            // Act
            var result = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, headers);

            // Need to perform a GET with fr-FR and en-US language to validate the localization

            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);
            result!.Name.Should().Be(createDto.Name);
            result!.Description.Should().Be(createDto.Description);
        }

        [Fact]
        public async Task Post_NotDefaultLanguageDescription_CreateLocalization()
        {
            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "Un immeuble moderne de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };

            var headers = CreateAcceptLanguageHeader("fr-FR");

            // Act
            var result = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto, headers);


            // Need to perform a GET with fr-FR and en-US language to validate the localization

            // Assert
            result.Should().NotBeNull();
            result!.Id.Should().BeGreaterThan(0);
            result!.Name.Should().Be(createDto.Name);
            result!.Description.Should().Be(createDto.Description);
        }

        [Fact]
        public async Task Post_WhenInvokedMultipleTimes_CreatesCorrectLocalizations()
        {
            // Arrange
            var createDto1 = new WorkplaceCreateDto
            {
                Name = "Regus - Dubai BCW Jafza View 18 & 19",
	            Description = "33-storey tower in Jebel Ali Free Zone, located on Sheikh Zayed Road and only a few kilometres from Al Maktoum Airport.",
            };

            var createDto2 = new WorkplaceCreateDto
            {
                Name = "Regus - Paris Gare de Lyon",
                Description = "Un immeuble moderne de taille modeste avec parking, à quelques minutes de la Gare de Lyon et de la Gare d'Austerlitz.",
            };

            // Act
            var result1 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto1, CreateAcceptLanguageHeader("en-US"));

            var result2 = await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto2, CreateAcceptLanguageHeader("fr-FR"));

            // Need to perform a GET with fr-FR and en-US language to validate the localization

            // Assert
            result1!.Name.Should().Be(createDto1.Name);
            result1!.Description.Should().Be(createDto1.Description);

            result2!.Name.Should().Be(createDto2.Name);
            result2!.Description.Should().Be(createDto2.Description);
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

        [Fact]
        public async Task Patch_NotDefaultLanguageDescription_DoesNotCreateNorUpdateLocalization()
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

            var headers = CreateHeaders(
                CreateEtagHeader(postResult?.Etag),
                CreateAcceptLanguageHeader("fr-FR"));

            await PatchAsync<WorkplaceUpdateDto, WorkplaceDto>($"{Endpoints.WorkplacesUrl}/{postResult!.Id}", updateDto, headers);

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

        [Fact]
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

        [Fact]
        public async Task Patch_Description_ShouldUpdateDescriptionOnly()
        {
            // Arrange
            var expectedName = _fixture.Create<string>();
            var expectedDescription = _fixture.Create<string>();

            var createDto = new WorkplaceCreateDto
            {
                Name = expectedName,
                Description = _fixture.Create<string>()
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

            // Arrange
            var createDto = new WorkplaceCreateDto
            {
                Name = nameFixture,
                Description = _fixture.Create<string>(),
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
            localizedWorkplaces![0].Description.Should().StartWith("[");
            localizedWorkplaces![0].Description.Should().EndWith("]");
        }

        // TODO: implement once create command works
        //[Fact]
        //public async Task Get_LocalizedValue_ShouldReturnLocalizationValue()
        //{
        //    var nameFixture = _fixture.Create<string>();

        //    // Arrange
        //    var createDto = new WorkplaceCreateDto
        //    {
        //        Name = nameFixture,
        //        Description = _fixture.Create<string>(),
        //    };

        //    await PostAsync<WorkplaceCreateDto, WorkplaceDto>(Endpoints.WorkplacesUrl, createDto);

        //    var headers = new Dictionary<string, IEnumerable<string>>()
        //    {
        //        { "Accept-Language", new List<string> { $"fr-CH, fr;q=0.9, en;q=0.8, de;q=0.7, *;q=0.5" } }
        //    };

        //    // Act
        //    var localizedWorkplaces = (await GetODataCollectionResponseAsync<IEnumerable<WorkplaceDto>>($"{Endpoints.WorkplacesUrl}", headers))?.ToList();

        //    // Assert
        //    localizedWorkplaces.Should().NotBeNull();
        //    localizedWorkplaces.Should().HaveCount(1);
        //    localizedWorkplaces![0].Description.Should().NotBeNull();
        //    localizedWorkplaces![0].Description.Should().StartWith("[");
        //    localizedWorkplaces![0].Description.Should().EndWith("]");
        //}
    }
}