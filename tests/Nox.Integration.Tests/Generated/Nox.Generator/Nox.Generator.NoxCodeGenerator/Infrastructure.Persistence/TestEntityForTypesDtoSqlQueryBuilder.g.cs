// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace TestWebApp.Infrastructure.Persistence;

public class TestEntityForTypesDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public TestEntityForTypesDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "TestEntityForTypes";

	public string Build()
	{
		var query = TestEntityForTypesQuery();
		return CompileToSqlString(query);
	}
	
	private static Query TestEntityForTypesQuery()
	{
		return new Query("TestEntityForTypes")
			.Select("TestEntityForTypes.Id")
			.Select("TestEntityForTypes.TextTestField")
			.Select("TestEntityForTypes.EnumerationTestField")
			.Select("TestEntityForTypes.NumberTestField")
			.Select("TestEntityForTypes.MoneyTestField_Amount")
			.Select("TestEntityForTypes.MoneyTestField_CurrencyCode")
			.Select("TestEntityForTypes.CountryCode2TestField")
			.Select("TestEntityForTypes.StreetAddressTestField")
			.Select("TestEntityForTypes.CurrencyCode3TestField")
			.Select("TestEntityForTypes.DayOfWeekTestField")
			.Select("TestEntityForTypes.JwtTokenTestField")
			.Select("TestEntityForTypes.GeoCoordTestField_Latitude")
			.Select("TestEntityForTypes.GeoCoordTestField_Longitude")
			.Select("TestEntityForTypes.AreaTestField")
			.Select("TestEntityForTypes.TimeZoneCodeTestField")
			.Select("TestEntityForTypes.BooleanTestField")
			.Select("TestEntityForTypes.CountryCode3TestField")
			.Select("TestEntityForTypes.CountryNumberTestField")
			.Select("TestEntityForTypes.CurrencyNumberTestField")
			.Select("TestEntityForTypes.DateTimeTestField")
			.Select("TestEntityForTypes.DateTimeRangeTestField")
			.Select("TestEntityForTypes.DistanceTestField")
			.Select("TestEntityForTypes.EmailTestField")
			.Select("TestEntityForTypes.EncryptedTextTestField")
			.Select("TestEntityForTypes.GuidTestField")
			.Select("TestEntityForTypes.HashedTextTestField")
			.Select("TestEntityForTypes.InternetDomainTestField")
			.Select("TestEntityForTypes.IpAddressV4TestField")
			.Select("TestEntityForTypes.IpAddressV6TestField")
			.Select("TestEntityForTypes.JsonTestField")
			.Select("TestEntityForTypes.LengthTestField")
			.Select("TestEntityForTypes.MacAddressTestField")
			.Select("TestEntityForTypes.MonthTestField")
			.Select("TestEntityForTypes.PasswordTestField")
			.Select("TestEntityForTypes.PercentageTestField")
			.Select("TestEntityForTypes.PhoneNumberTestField")
			.Select("TestEntityForTypes.TemperatureTestField")
			.Select("TestEntityForTypes.TranslatedTextTestField")
			.Select("TestEntityForTypes.UriTestField")
			.Select("TestEntityForTypes.VolumeTestField")
			.Select("TestEntityForTypes.WeightTestField")
			.Select("TestEntityForTypes.YearTestField")
			.Select("TestEntityForTypes.CultureCodeTestField")
			.Select("TestEntityForTypes.LanguageCodeTestField")
			.Select("TestEntityForTypes.YamlTestField")
			.Select("TestEntityForTypes.DateTimeDurationTestField")
			.Select("TestEntityForTypes.TimeTestField")
			.Select("TestEntityForTypes.VatNumberTestField")
			.Select("TestEntityForTypes.DateTestField")
			.Select("TestEntityForTypes.MarkdownTestField")
			.Select("TestEntityForTypes.FileTestField")
			.Select("TestEntityForTypes.ColorTestField")
			.Select("TestEntityForTypes.UrlTestField")
			.Select("TestEntityForTypes.DateTimeScheduleTestField")
			.Select("TestEntityForTypes.UserTestField")
			.Select("TestEntityForTypes.FormulaTestField")
			.Select("TestEntityForTypes.AutoNumberTestField")
			.Select("TestEntityForTypes.HtmlTestField")
			.Select("TestEntityForTypes.ImageTestField")
			.Select("TestEntityForTypesEnumerationTestFields.Name as EnumerationTestFieldName")
			.Select("TestEntityForTypes.DeletedAtUtc")
			.Select("TestEntityForTypes.Etag")
			.LeftJoin(EnumerationTestFieldEnumQuery(), j => j.On("TestEntityForTypesEnumerationTestFields.Id", "TestEntityForTypes.EnumerationTestField"));
	}
	
	private static Query EnumerationTestFieldEnumQuery()
	{
		return new Query("TestEntityForTypesEnumerationTestFields")
			.Select("TestEntityForTypesEnumerationTestFields.Id")
			.ForSqlServer(q => q.SelectRaw("COALESCE([TestEntityForTypesEnumerationTestFieldsLocalized].[Name], (N'[' + COALESCE([TestEntityForTypesEnumerationTestFields].[Name], N'')) + N']') AS [Name]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"TestEntityForTypesEnumerationTestFieldsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"TestEntityForTypesEnumerationTestFields\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"TestEntityForTypesEnumerationTestFieldsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"TestEntityForTypesEnumerationTestFields\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.LeftJoin(EnumerationTestFieldLocalizedEnumQuery(), j => j.On("TestEntityForTypesEnumerationTestFieldsLocalized.Id", "TestEntityForTypesEnumerationTestFields.Id"))
			.As("TestEntityForTypesEnumerationTestFields");
	}
	
	private static Query EnumerationTestFieldLocalizedEnumQuery()
	{ 
		return new Query("TestEntityForTypesEnumerationTestFieldsLocalized")
			.Select("TestEntityForTypesEnumerationTestFieldsLocalized.Id")
			.Select("TestEntityForTypesEnumerationTestFieldsLocalized.Name")
			.Where("TestEntityForTypesEnumerationTestFieldsLocalized.CultureCode", "##LANG##")
			.As("TestEntityForTypesEnumerationTestFieldsLocalized");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");;
	}
}