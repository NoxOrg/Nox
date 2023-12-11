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
		var query = CountryQuery();
		return CompileToSqlString(query);
	}
	
	private static Query CountryQuery()
	{
		return new Query("Countries")
			.Select("Countries.Id")
			.Select("Countries.Name")
			.Select("Countries.Population")
			.Select("Countries.FirstLanguageCode")
			.Select("Countries.ShortDescription")
			.Select("Countries.CountryIsoNumeric")
			.Select("Countries.CountryIsoAlpha3")
			.Select("Countries.GoogleMapsUrl")
			.Select("Countries.StartOfWeek")
			.Select("Countries.Continent")
			.Select("Countries.CountryDebt_Amount")
			.Select("Countries.CountryDebt_CurrencyCode")
			.Select("Countries.CapitalCityLocation_Latitude")
			.Select("Countries.CapitalCityLocation_Longitude")
			.Select("CountriesContinents.Name as ContinentName")
			.Select("Countries.DeletedAtUtc")
			.Select("Countries.Etag")
			.LeftJoin(ContinentEnumQuery(), j => j.On("CountriesContinents.Id", "Countries.Continent"));
	}
	
	private static Query ContinentEnumQuery()
	{
		return new Query("CountriesContinents")
			.Select("CountriesContinents.Id")
			.ForSqlServer(q => q.SelectRaw("COALESCE([CountriesContinentsLocalized].[Name], (N'[' + COALESCE([CountriesContinents].[Name], N'')) + N']') AS [Name]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"CountriesContinentsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"CountriesContinents\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"CountriesContinentsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"CountriesContinents\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.LeftJoin(ContinentLocalizedEnumQuery(), j => j.On("CountriesContinentsLocalized.Id", "CountriesContinents.Id"))
			.As("CountriesContinents");
	}
	
	private static Query ContinentLocalizedEnumQuery()
	{ 
		return new Query("CountriesContinentsLocalized")
			.Select("CountriesContinentsLocalized.Id")
			.Select("CountriesContinentsLocalized.Name")
			.Where("CountriesContinentsLocalized.CultureCode", "##LANG##")
			.As("CountriesContinentsLocalized");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");
	}
}