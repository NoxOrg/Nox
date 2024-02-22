// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class CountryLocalNameDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public CountryLocalNameDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "CountryLocalName";

	public string Build()
	{
		var query = CountryLocalNameQuery();
		return CompileToSqlString(query);
	}
	
	private static Query CountryLocalNameQuery()
	{
		return new Query("CountryLocalNames")
			.Select("CountryLocalNames.Id")
			.Select("CountryLocalNames.Name")
			.Select("CountryLocalNames.NativeName")
			.ForSqlServer(q => q.SelectRaw("COALESCE([CountryLocalNamesLocalized].[Description], CASE WHEN [CountryLocalNames].[Description] IS NULL THEN N'' ELSE N'[' + [CountryLocalNames].[Description] + N']' END) AS [Description]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"CountryLocalNamesLocalized\".\"Description\",CASE WHEN \"CountryLocalNames\".\"Description\" IS NULL THEN '' ELSE '##OPEN##' || \"CountryLocalNames\".\"Description\" || '##CLOSE##' END) AS \"Description\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"CountryLocalNamesLocalized\".\"Description\",CASE WHEN \"CountryLocalNames\".\"Description\" IS NULL THEN '' ELSE '##OPEN##' || \"CountryLocalNames\".\"Description\" || '##CLOSE##' END) AS \"Description\""))
			.Select("CountryLocalNames.CountryId")
			.LeftJoin(CountryLocalNameLocalizedQuery(), j => j.On("CountryLocalNamesLocalized.Id", "CountryLocalNames.Id"));
	}
	
	private static Query CountryLocalNameLocalizedQuery()
	{
		return new Query("CountryLocalNamesLocalized")
			.Select("CountryLocalNamesLocalized.Id")
			.Select("CountryLocalNamesLocalized.Description")
			.Where("CountryLocalNamesLocalized.CultureCode", "##LANG##")
			.As("CountryLocalNamesLocalized");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");
	}
}