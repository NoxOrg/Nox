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
		var query = TestEntityLocalizationQuery();
		return CompileToSqlString(query);
	}
	
	private static Query TestEntityLocalizationQuery()
	{
		return new Query("TestEntityLocalizations")
			.Select("TestEntityLocalizations.Id")
			.Select("TestEntityLocalizations.NumberField")
			.ForSqlServer(q => q.SelectRaw("COALESCE([TestEntityLocalizationsLocalized].[TextFieldToLocalize], (N'[' + COALESCE([TestEntityLocalizations].[TextFieldToLocalize], N'')) + N']') AS [TextFieldToLocalize]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"TestEntityLocalizationsLocalized\".\"TextFieldToLocalize\", ('##OPEN##' || COALESCE(\"TestEntityLocalizations\".\"TextFieldToLocalize\", '')) || '##CLOSE##') AS \"TextFieldToLocalize\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"TestEntityLocalizationsLocalized\".\"TextFieldToLocalize\", ('##OPEN##' || COALESCE(\"TestEntityLocalizations\".\"TextFieldToLocalize\", '')) || '##CLOSE##') AS \"TextFieldToLocalize\""))
			.Select("TestEntityLocalizations.DeletedAtUtc")
			.Select("TestEntityLocalizations.Etag")
			.LeftJoin(TestEntityLocalizationLocalizedQuery(), j => j.On("TestEntityLocalizationsLocalized.Id", "TestEntityLocalizations.Id"));
	}
	
	private static Query TestEntityLocalizationLocalizedQuery()
	{
		return new Query("TestEntityLocalizationsLocalized")
			.Select("TestEntityLocalizationsLocalized.Id")
			.Select("TestEntityLocalizationsLocalized.TextFieldToLocalize")
			.Where("TestEntityLocalizationsLocalized.CultureCode", "##LANG##")
			.As("TestEntityLocalizationsLocalized");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");;
	}
}