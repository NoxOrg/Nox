// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class LanguageDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public LanguageDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "Language";

	public string Build()
	{
		var query = LanguageQuery();
		return CompileToSqlString(query);
	}
	
	private static Query LanguageQuery()
	{
		return new Query("Languages")
			.Select("Languages.Id")
			.Select("Languages.CountryIsoNumeric")
			.Select("Languages.CountryIsoAlpha3")
			.Select("Languages.Region")
			.ForSqlServer(q => q.SelectRaw("COALESCE([LanguagesLocalized].[Name], (N'[' + COALESCE([Languages].[Name], N'')) + N']') AS [Name]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"LanguagesLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"Languages\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"LanguagesLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"Languages\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.Select("Languages.Etag")
			.LeftJoin(LanguageLocalizedQuery(), j => j.On("LanguagesLocalized.Id", "Languages.Id"));
	}
	
	private static Query LanguageLocalizedQuery()
	{
		return new Query("LanguagesLocalized")
			.Select("LanguagesLocalized.Id")
			.Select("LanguagesLocalized.Name")
			.Where("LanguagesLocalized.CultureCode", "##LANG##")
			.As("LanguagesLocalized");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");
	}
}