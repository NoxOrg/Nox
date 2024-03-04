using FluentAssertions;
using ClientApi.Application.Dto;
using AutoFixture;
using Nox.Types;
using System.Net;
using Xunit.Abstractions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using static MassTransit.ValidationResultExtensions;

namespace ClientApi.Tests.Controllers;

[Collection("CountriesControllerTests")]
public partial class CountriesControllerAdHocTests : NoxWebApiTestBase
{
	public CountriesControllerAdHocTests(ITestOutputHelper testOutputHelper,
	TestDatabaseContainerService containerService
	//For Development purposes
	//TestDatabaseInstanceService containerService
	)
	: base(testOutputHelper, containerService)
	{
	}

	[Fact]
	public async Task Post_ReturnsAutoNumberId()
	{
		// Arrange
		var dto = new CountryCreateDto
		{
			Name = _fixture.Create<string>()
		};

		// Act
		var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

		//Assert
		result.Should().NotBeNull();
		result!.Id.Should().BeGreaterThanOrEqualTo(10);
	}

	[Fact]
	public async Task Post_UseODataQuery_ReturnsData()
	{
		// Arrange
		for (var i = 0; i < 5; i++)
		{
			var dto = new CountryCreateDto
			{
				Name = _fixture.Create<string>(),
				Population = 1_000_000 * (i + 1)
			};
			await PostAsync<CountryCreateDto, CountryKeyDto>(Endpoints.CountriesUrl, dto);
		}
		// Act
		const string oDataRequest = "$select=Name&$filter=population lt 3000000&$count=true";
		var results = await GetODataCollectionResponseAsync<IEnumerable<CountryDto>>($"{Endpoints.CountriesUrl}/?{oDataRequest}");

		//Assert
		const int expectedCountryCount = 2;

		results.Should()
			.HaveCount(expectedCountryCount)
				.And
			.AllSatisfy(x => x.Name.Should().NotBeNullOrEmpty())
				.And
			.AllSatisfy(x => x.Population.Should().BeNull());
	}

	[Fact]
	public async Task Post_WithCompoundMoney_ReturnsAutoNumberId()
	{
		// Arrange
		var expectedAmount = 200_000;
		var dto = new CountryCreateDto
		{
			Name = _fixture.Create<string>(),
			CountryDebt = new MoneyDto(expectedAmount, CurrencyCode.AED)
		};

		// Act
		var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
		var queryResult = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

		//Assert
		result.Should().NotBeNull();
		result.Id.Should().BeGreaterThanOrEqualTo(10);

		queryResult.Should().NotBeNull();
		queryResult!.CountryDebt!.Amount.Should().Be(expectedAmount);
	}

	[Fact]
	public async Task Post_NameAndPopulation_ShouldPopulateShortDescription()
	{
		// Arrange
		var dto = new CountryCreateDto
		{
			Name = "Portugal",
			Population = 10350000
		};

		// Act
		var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

		result.Should().NotBeNull();
		result!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
	}

	[Fact]
	public async Task Put_Number_ShouldUpdate()
	{
		var expectedNumber = 50;
		// Arrange
		var createDto = new CountryCreateDto
		{
			Name = _fixture.Create<string>(),
			Population = 1
		};
		var updateDto = new CountryUpdateDto
		{
			Name = _fixture.Create<string>(),
			Population = expectedNumber
		};

		// Act
		var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
		var headers = CreateEtagHeader(postResult!.Etag);
		var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

		//Assert
		putResult!.Population.Should().Be(expectedNumber);
	}

	[Fact]
	public async Task Put_Name_ShouldPopulateShortDescription()
	{
		// Arrange
		var createDto = new CountryCreateDto
		{
			Name = "Portugal123",
			Population = 10350000
		};
		var updateDto = new CountryUpdateDto
		{
			Name = "Portugal",
			Population = 10350000
		};

		// Act
		var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
		var headers = CreateEtagHeader(postResult!.Etag);

		var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

		//Assert
		putResult!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
	}

	[Fact]
	public async Task Put_Population_ShouldPopulateShortDescription()
	{
		// Arrange
		var createDto = new CountryCreateDto
		{
			Name = "Portugal",
			Population = 1,
		};
		var updateDto = new CountryUpdateDto
		{
			Name = "Portugal",
			Population = 10350000
		};
		// Act
		var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
		var headers = CreateEtagHeader(postResult!.Etag);
		var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

		//Assert
		putResult.Should().NotBeNull();
		putResult!.ShortDescription.Should().Be("Portugal has a population of 10350000 people.");
	}

	[Fact]
	public async Task Put_NumberWithoutLatestEtag_ShouldReturnConflict()
	{
		var expectedNumber = 1;
		// Arrange
		var createDto = new CountryCreateDto
		{
			Name = _fixture.Create<string>(),
			Population = 1
		};
		var updateDto = new CountryUpdateDto
		{
			Name = _fixture.Create<string>(),
			Population = 50
		};

		// Act
		var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);

		var updateResult = await PutAsync($"{Endpoints.CountriesUrl}/{result!.Id}", updateDto, false);
		var queryResult = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

		//Assert
		updateResult!.Should().HaveStatusCode(HttpStatusCode.PreconditionRequired);
		queryResult!.Population.Should().Be(expectedNumber);
	}

	[Fact]
	public async Task Patch_Number_ShouldUpdateNumberOnly()
	{
		// Arrange
		var expectedNumber = 50;
		var expectedName = "Portugal";
		var createDto = new CountryCreateDto
		{
			Name = expectedName,
			Population = 1
		};

		var updateDto = new CountryPartialUpdateDto
        {
			Population = expectedNumber
		};

		// Act
		var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
		var headers = CreateEtagHeader(postResult!.Etag);

		var patchResult = await PatchAsync<CountryPartialUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

		//Assert
		patchResult!.Population.Should().Be(expectedNumber);
		patchResult!.Name.Should().Be(expectedName);
	}

	[Fact]
	public async Task Patch_RequiredNameIsMissing_ShouldUpdatePopulation()
	{
		//This test is to verify the case that if the required Name is missing in delta Patch request, it should still update other fields and do not throw BadRequest

		// Arrange
		var expectedPopulation = _fixture.Create<int>();
		var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
			new CountryCreateDto
			{
				Name = _fixture.Create<string>(),
				Population = _fixture.Create<int>()
			});

		// Act            
		var headers = CreateEtagHeader(countryResponse!.Etag);
		var patchResponse = await PatchAsync<CountryPartialUpdateDto, CountryDto>(
			$"{Endpoints.CountriesUrl}/{countryResponse!.Id}",
			new CountryPartialUpdateDto
            {
				Population = expectedPopulation
			},
			headers);

		// Assert
		patchResponse!.Population.Should().Be(expectedPopulation);
		patchResponse!.Name.Should().Be(countryResponse!.Name);
	}

	[Fact]
	public async Task Patch_RequiredName_IsSetToNull_ShouldFail()
	{
		// Arrange
		var countryResponse = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl,
			new CountryCreateDto
			{
				Name = _fixture.Create<string>()
			});

		// Act            
		var headers = CreateEtagHeader(countryResponse!.Etag);
		var patchResponse = await PatchAsync(
			$"{Endpoints.CountriesUrl}/{countryResponse!.Id}",
			new CountryPartialUpdateDto { },
			headers,
			false);

		// Assert
		patchResponse!.StatusCode.Should().Be(HttpStatusCode.BadRequest);
	}

	

	[Fact]
	public async Task Post_IfNoRequireField_ThrowsException()
	{
		// Arrange
		var createDto = new CountryCreateDto
		{
			Population = 1
		};
		// Act
		var result = await PostAsync(Endpoints.CountriesUrl, createDto);

		result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
	}

	[Fact]
	public async Task Deleted_ShouldPerformSoftDelete()
	{
		// Arrange
		var createDto = new CountryCreateDto
		{
			Name = "Portugal",
			Population = 1,
		};

		// Act
		var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
		var headers = CreateEtagHeader(result!.Etag);

		await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}", headers);

		// Assert
		var queryResult = await GetAsync($"{Endpoints.CountriesUrl}/{result!.Id}");

		queryResult.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}

	[Fact]
	public async Task Post_WhenLanguageIsSet_ShouldReturnSuccess()
	{
		var expectedLanguageCode = "pt";
		// Arrange
		var dto = new CountryCreateDto
		{
			Name = _fixture.Create<string>(),
			FirstLanguageCode = expectedLanguageCode
		};

		// Act
		var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

		//Assert
		result.Should().NotBeNull();
		result!.Id.Should().BeGreaterThanOrEqualTo(10);
		result!.FirstLanguageCode.Should().Be(expectedLanguageCode);
	}

	[Fact]
	public async Task Put_WhenLanguageIsSet_ShouldReturnSuccess()
	{
		var createWithLanguage = "pt";
		var updateWithLanguage = "en";
		// Arrange
		var dto = new CountryCreateDto
		{
			Name = _fixture.Create<string>(),
			FirstLanguageCode = createWithLanguage
		};
		var updateDto = new CountryUpdateDto
		{
			Name = _fixture.Create<string>(),
			FirstLanguageCode = updateWithLanguage
		};

		// Act
		var postResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);
		var headers = CreateEtagHeader(postResult!.Etag);
		var putResult = await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{postResult!.Id}", updateDto, headers);

		// Assert
		putResult!.FirstLanguageCode.Should().Be(updateWithLanguage);
	}

	[Fact]
	public async Task Delete_WithoutLatestEtag_ShouldReturnConflict()
	{
		// Arrange
		var createDto = new CountryCreateDto
		{
			Name = "Portugal",
			Population = 1,
		};

		// Act
		var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);

		var deleteResult = await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}", false);
		var queryResult = await GetAsync($"{Endpoints.CountriesUrl}/{result!.Id}");

		// Assert
		deleteResult!.Should().HaveStatusCode(HttpStatusCode.PreconditionRequired);
		queryResult.Should().BeSuccessful();
	}

    [Fact]
    public async Task WhenPutOWnedLocalized_ShouldUpdateOwnedLocalized()
    {
        // Arrange
        var createDtoDefaultLanguage = new CountryCreateDto
        {
            Name = "Portugal",
            Population = 1_000_000,
            CountryDebt = new MoneyDto(200_000, CurrencyCode.USD),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>()
            {
                new CountryLocalNameUpsertDto() { Name = "Iberia", Description = "en-Us1" },
                new CountryLocalNameUpsertDto() { Name = "Lusitania" , Description = "en-Us2"}
            }
        };
        var updateDefaultLanguage = new CountryUpdateDto
        {
            Name = "Germany",
            Population = 1_000_000,
            CountryDebt = new MoneyDto(200_000, CurrencyCode.USD),
            CountryLocalNames = new List<CountryLocalNameUpsertDto>()
            {
                new CountryLocalNameUpsertDto() { Name = "Iberia", Description = "de-DE1" },
                new CountryLocalNameUpsertDto() { Name = "Lusitania" , Description = "de-DE2"}
            }
        };
		
		// Act
		var resultDefault = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDtoDefaultLanguage);      
        var headers = CreateHeaders(new[] { CreateAcceptLanguageHeader("de-DE"), CreateEtagHeader(resultDefault!.Etag) });
        var country = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{resultDefault!.Id}");

		updateDefaultLanguage.CountryLocalNames[0].Id = country!.CountryLocalNames[0].Id;
        updateDefaultLanguage.CountryLocalNames[1].Id = country!.CountryLocalNames[1].Id;

        await PutAsync<CountryUpdateDto, CountryDto>($"{Endpoints.CountriesUrl}/{resultDefault!.Id}", updateDefaultLanguage, headers);

		// Assert        
        var countryDefault = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{resultDefault!.Id}");
        headers = CreateHeaders(new[] { CreateAcceptLanguageHeader("de-DE") });
        var countryGerman = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{resultDefault!.Id}", headers);

		countryDefault!.CountryLocalNames[0].Description.Should().Be("en-Us1");
        countryDefault!.CountryLocalNames[1].Description.Should().Be("en-Us2");

        countryGerman!.CountryLocalNames[0].Description.Should().Be("de-DE1");
        countryGerman!.CountryLocalNames[1].Description.Should().Be("de-DE2");
    }

    [Fact]
	public async Task Delete_WhenTryingToGetOwnedEntities_ReturnsNotFound()
	{
		// Arrange
		var createDto = new CountryCreateDto
		{
			Name = "Portugal",
			Population = 1_000_000,
			CountryDebt = new MoneyDto(200_000, CurrencyCode.USD),
			CountryLocalNames = new List<CountryLocalNameUpsertDto>()
			{
				new CountryLocalNameUpsertDto() { Name = "Iberia" },
				new CountryLocalNameUpsertDto() { Name = "Lusitania"}
			}
		};

		// Act
		var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);
		var headers = CreateEtagHeader(result!.Etag);

		var country = await GetODataSimpleResponseAsync<CountryDto>($"{Endpoints.CountriesUrl}/{result!.Id}");

		await DeleteAsync($"{Endpoints.CountriesUrl}/{result!.Id}", headers);

		// Assert
		var queryResult = await GetAsync($"{Endpoints.CountriesUrl}/{result!.Id}/CountryLocalNames/{country!.CountryLocalNames[0].Id}");

		queryResult.Should().HaveStatusCode(HttpStatusCode.NotFound);
	}

	[Fact]
	public async Task WhenPostWithEnumerationId_ShouldGetEnumerationName()
	{
		// Arrange
		var dto = new CountryCreateDto
		{
			Name = "Portugal",
			Continent = 1
		};

		// Act
		var result = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, dto);

		result.Should().NotBeNull();

		result!.Continent.Should().Be(1);
		result!.ContinentName.Should().Be("Europe");
	}

	[Fact]
	public async Task WhenGetEnumerationValues_ShouldGetTranslatedName()
	{
		// Arrange
		var expectedResult = new[] {
			new CountryContinentDto() { Id = 1, Name = "Europe" },
			new CountryContinentDto() { Id = 2, Name = "Asia" },
			new CountryContinentDto() { Id = 3, Name = "Africa" },
			new CountryContinentDto() { Id = 4, Name = "America" },
			new CountryContinentDto() { Id = 5, Name = "Oceania" }
		};


		// Act
		var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryContinentDto>>($"{Endpoints.CountriesUrl}/Continents"))?.ToList();


		result.Should().NotBeNull();

		result.Should().HaveCount(5);
		result.Should().BeEquivalentTo(expectedResult);


	}

	[Fact]
	public async Task WhenGetEnumerationValuesNotExist_ShouldGetTranslatedNameInBrackets()
	{
		// Arrange
		var expectedResult = new[] {
			new CountryContinentDto() { Id = 1, Name = "[Europe]" },
			new CountryContinentDto() { Id = 2, Name = "[Asia]" },
			new CountryContinentDto() { Id = 3, Name = "[Africa]" },
			new CountryContinentDto() { Id = 4, Name = "[America]" },
			new CountryContinentDto() { Id = 5, Name = "[Oceania]" }
		};

		var headers = CreateHeaders(CreateAcceptLanguageHeader("fr-FR"));
		// Act
		var result = (await GetODataCollectionResponseAsync<IEnumerable<CountryContinentDto>>($"{Endpoints.CountriesUrl}/Continents", headers: headers))?.ToList();


		result.Should().NotBeNull();

		result.Should().HaveCount(5);
		result.Should().BeEquivalentTo(expectedResult);

	}

	/// <summary>
	/// We override PostToCountryLocalNames in CountriesController to set  CustomField on the command
	/// The Command Handler validates if the custom field is properly set
	/// </summary>
	/// <returns></returns>
	[Fact]
	public async Task Post_WithCustomCommandFieldShouldSucced()
	{
		// Arrange
		var createDto = new CountryCreateDto
		{
			Name = "Portugal",
			Population = 1,
		};

		var countryCreatedResult = await PostAsync<CountryCreateDto, CountryDto>(Endpoints.CountriesUrl, createDto);

		// Act
		var headers = CreateEtagHeader(countryCreatedResult!.Etag);
		var countryShortName = new CountryLocalNameUpsertDto() { Name = "ShortName" };
		var countryShortNameResult = await PostAsync($"{Endpoints.CountriesUrl}/{countryCreatedResult!.Id}/{nameof(createDto.CountryLocalNames)}", countryShortName, headers);

		// Assert
		countryShortNameResult!.Should().HaveStatusCode(HttpStatusCode.Created);
	}

	[Fact]
	public async Task CustomCreateCountry_Success()
	{
		var result = await PostAsync($"{Endpoints.CountriesUrl}/CustomCreateCountry",
			new CountryCreateDto
			{
				Name = _fixture.Create<string>()
			});

		result.IsSuccessStatusCode.Should().BeTrue();
	}
}
