// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class CountryDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public CountryDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "Country";

	public string Build()
	{
		var localizedContinentEnumQuery = new Query("CountriesContinentsLocalized")
			.Select("CountriesContinentsLocalized.Id")
			.Select("CountriesContinentsLocalized.Name")
			.Where("CountriesContinentsLocalized.CultureCode", "##LANG##")
			.As("CountriesContinentsLocalized");
		
		var continentEnumQuery = new Query("CountriesContinents")
			.Select("CountriesContinents.Id")
			.ForSqlServer(q => q.SelectRaw("COALESCE([CountriesContinentsLocalized].[Name], (N'[' + COALESCE([CountriesContinents].[Name], N'')) + N']') AS [Name]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"CountriesContinentsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"CountriesContinents\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"CountriesContinentsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"CountriesContinents\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.LeftJoin(localizedContinentEnumQuery, j => j.On("CountriesContinentsLocalized.Id", "CountriesContinents.Id"))
			.As("CountriesContinents");
		
		var entityQuery = new Query("Countries")
			.Select("Countries.Id")
			.Select("Countries.Name")
			.Select("Countries.Population")
			.Select("Countries.CountryDebt")
			.Select("Countries.CapitalCityLocation")
			.Select("Countries.FirstLanguageCode")
			.Select("Countries.ShortDescription")
			.Select("Countries.CountryIsoNumeric")
			.Select("Countries.CountryIsoAlpha3")
			.Select("Countries.GoogleMapsUrl")
			.Select("Countries.StartOfWeek")
			.Select("Countries.Continent")
			.Select("CountriesContinents.Name as ContinentName")
			.Select("Countries.Etag")
			.LeftJoin(continentEnumQuery, j => j.On("CountriesContinents.Id", "Countries.Continent"));

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}