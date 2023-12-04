// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class WorkplaceDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public WorkplaceDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "Workplace";

	public string Build()
	{
		var localizedEntityQuery = new Query("WorkplacesLocalized")
			.Select("WorkplacesLocalized.Id")
			.Select("WorkplacesLocalized.Description")
			.Where("WorkplacesLocalized.CultureCode", "##LANG##")
			.As("WorkplacesLocalized");

		var entityQuery = new Query("Workplaces")
			.Select("Workplaces.Id")
			.Select("Workplaces.Name")
			.Select("Workplaces.ReferenceNumber")
			.Select("Workplaces.Greeting")
			.ForSqlServer(q => q.SelectRaw("COALESCE([WorkplacesLocalized].[Description], (N'[' + COALESCE([Workplaces].[Description], N'')) + N']') AS [Description]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"WorkplacesLocalized\".\"Description\", ('##OPEN##' || COALESCE(\"Workplaces\".\"Description\", '')) || '##CLOSE##') AS \"Description\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"WorkplacesLocalized\".\"Description\", ('##OPEN##' || COALESCE(\"Workplaces\".\"Description\", '')) || '##CLOSE##') AS \"Description\""))
			.Select("Workplaces.CountryId")
			.Select("Workplaces.Etag")
			.LeftJoin(localizedEntityQuery, j => j.On("WorkplacesLocalized.Id", "Workplaces.Id"));

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}