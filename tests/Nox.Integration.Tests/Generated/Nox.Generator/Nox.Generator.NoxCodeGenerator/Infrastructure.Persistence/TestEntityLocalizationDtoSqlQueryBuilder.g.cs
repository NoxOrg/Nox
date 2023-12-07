// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace TestWebApp.Infrastructure.Persistence;

public class TestEntityLocalizationDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public TestEntityLocalizationDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "TestEntityLocalization";

	public string Build()
	{
		var localizedEntityQuery = new Query("TestEntityLocalizationsLocalized")
			.Select("TestEntityLocalizationsLocalized.Id")
			.Select("TestEntityLocalizationsLocalized.TextFieldToLocalize")
			.Where("TestEntityLocalizationsLocalized.CultureCode", "##LANG##")
			.As("TestEntityLocalizationsLocalized");

		var entityQuery = new Query("TestEntityLocalizations")
			.Select("TestEntityLocalizations.Id")
			.Select("TestEntityLocalizations.NumberField")
			.ForSqlServer(q => q.SelectRaw("COALESCE([TestEntityLocalizationsLocalized].[TextFieldToLocalize], (N'[' + COALESCE([TestEntityLocalizations].[TextFieldToLocalize], N'')) + N']') AS [TextFieldToLocalize]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"TestEntityLocalizationsLocalized\".\"TextFieldToLocalize\", ('##OPEN##' || COALESCE(\"TestEntityLocalizations\".\"TextFieldToLocalize\", '')) || '##CLOSE##') AS \"TextFieldToLocalize\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"TestEntityLocalizationsLocalized\".\"TextFieldToLocalize\", ('##OPEN##' || COALESCE(\"TestEntityLocalizations\".\"TextFieldToLocalize\", '')) || '##CLOSE##') AS \"TextFieldToLocalize\""))
			.Select("TestEntityLocalizations.DeletedAtUtc")
			.Select("TestEntityLocalizations.Etag")
			.LeftJoin(localizedEntityQuery, j => j.On("TestEntityLocalizationsLocalized.Id", "TestEntityLocalizations.Id"));

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}