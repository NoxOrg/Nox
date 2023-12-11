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
			.Select("TestEntityForTypes.CountryCode2TestField")
			.Select("TestEntityForTypes.CurrencyCode3TestField")
			.Select("TestEntityForTypes.DayOfWeekTestField")
			.Select("TestEntityForTypes.JwtTokenTestField")
			.Select("TestEntityForTypes.AreaTestField")
			.Select("TestEntityForTypes.TimeZoneCodeTestField")
			.Select("TestEntityForTypes.BooleanTestField")
			.Select("TestEntityForTypes.CountryCode3TestField")
			.Select("TestEntityForTypes.CountryNumberTestField")
			.Select("TestEntityForTypes.CurrencyNumberTestField")
			.Select("TestEntityForTypes.DateTimeTestField")
			.Select("TestEntityForTypes.DistanceTestField")
			.Select("TestEntityForTypes.EmailTestField")
			.Select("TestEntityForTypes.EncryptedTextTestField")
			.Select("TestEntityForTypes.GuidTestField")
			.Select("TestEntityForTypes.InternetDomainTestField")
			.Select("TestEntityForTypes.IpAddressV4TestField")
			.Select("TestEntityForTypes.IpAddressV6TestField")
			.Select("TestEntityForTypes.JsonTestField")
			.Select("TestEntityForTypes.LengthTestField")
			.Select("TestEntityForTypes.MacAddressTestField")
			.Select("TestEntityForTypes.MonthTestField")
			.Select("TestEntityForTypes.PercentageTestField")
			.Select("TestEntityForTypes.PhoneNumberTestField")
			.Select("TestEntityForTypes.TemperatureTestField")
			.Select("TestEntityForTypes.UriTestField")
			.Select("TestEntityForTypes.VolumeTestField")
			.Select("TestEntityForTypes.WeightTestField")
			.Select("TestEntityForTypes.YearTestField")
			.Select("TestEntityForTypes.CultureCodeTestField")
			.Select("TestEntityForTypes.LanguageCodeTestField")
			.Select("TestEntityForTypes.YamlTestField")
			.Select("TestEntityForTypes.DateTimeDurationTestField")
			.Select("TestEntityForTypes.TimeTestField")
			.Select("TestEntityForTypes.DateTestField")
			.Select("TestEntityForTypes.MarkdownTestField")
			.Select("TestEntityForTypes.ColorTestField")
			.Select("TestEntityForTypes.UrlTestField")
			.Select("TestEntityForTypes.DateTimeScheduleTestField")
			.Select("TestEntityForTypes.UserTestField")
			.Select("TestEntityForTypes.FormulaTestField")
			.Select("TestEntityForTypes.AutoNumberTestField")
			.Select("TestEntityForTypes.HtmlTestField")
			.Select("TestEntityForTypes.MoneyTestField_Amount")
			.Select("TestEntityForTypes.MoneyTestField_CurrencyCode")
			.Select("TestEntityForTypes.StreetAddressTestField_StreetNumber")
			.Select("TestEntityForTypes.StreetAddressTestField_AddressLine1")
			.Select("TestEntityForTypes.StreetAddressTestField_AddressLine2")
			.Select("TestEntityForTypes.StreetAddressTestField_Route")
			.Select("TestEntityForTypes.StreetAddressTestField_Locality")
			.Select("TestEntityForTypes.StreetAddressTestField_Neighborhood")
			.Select("TestEntityForTypes.StreetAddressTestField_AdministrativeArea1")
			.Select("TestEntityForTypes.StreetAddressTestField_AdministrativeArea2")
			.Select("TestEntityForTypes.StreetAddressTestField_PostalCode")
			.Select("TestEntityForTypes.StreetAddressTestField_CountryId")
			.Select("TestEntityForTypes.GeoCoordTestField_Latitude")
			.Select("TestEntityForTypes.GeoCoordTestField_Longitude")
			.Select("TestEntityForTypes.DateTimeRangeTestField_Start")
			.Select("TestEntityForTypes.DateTimeRangeTestField_End")
			.Select("TestEntityForTypes.HashedTextTestField_HashText")
			.Select("TestEntityForTypes.HashedTextTestField_Salt")
			.Select("TestEntityForTypes.PasswordTestField_HashedPassword")
			.Select("TestEntityForTypes.PasswordTestField_Salt")
			.Select("TestEntityForTypes.TranslatedTextTestField_CultureCode")
			.Select("TestEntityForTypes.TranslatedTextTestField_Phrase")
			.Select("TestEntityForTypes.VatNumberTestField_Number")
			.Select("TestEntityForTypes.VatNumberTestField_CountryCode")
			.Select("TestEntityForTypes.FileTestField_Url")
			.Select("TestEntityForTypes.FileTestField_PrettyName")
			.Select("TestEntityForTypes.FileTestField_SizeInBytes")
			.Select("TestEntityForTypes.ImageTestField_Url")
			.Select("TestEntityForTypes.ImageTestField_PrettyName")
			.Select("TestEntityForTypes.ImageTestField_SizeInBytes")
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
			.Replace("##CLOSE##", "]");
	}
}