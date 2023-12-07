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

		var localizedOwnershipEnumQuery = new Query("WorkplacesOwnershipsLocalized")
			.Select("WorkplacesOwnershipsLocalized.Id")
			.Select("WorkplacesOwnershipsLocalized.Name")
			.Where("WorkplacesOwnershipsLocalized.CultureCode", "##LANG##")
			.As("WorkplacesOwnershipsLocalized");
		
		var ownershipEnumQuery = new Query("WorkplacesOwnerships")
			.Select("WorkplacesOwnerships.Id")
			.ForSqlServer(q => q.SelectRaw("COALESCE([WorkplacesOwnershipsLocalized].[Name], (N'[' + COALESCE([WorkplacesOwnerships].[Name], N'')) + N']') AS [Name]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"WorkplacesOwnershipsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"WorkplacesOwnerships\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"WorkplacesOwnershipsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"WorkplacesOwnerships\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.LeftJoin(localizedOwnershipEnumQuery, j => j.On("WorkplacesOwnershipsLocalized.Id", "WorkplacesOwnerships.Id"))
			.As("WorkplacesOwnerships");

		var typeEnumQuery = new Query("WorkplacesTypes")
			.Select("WorkplacesTypes.Id")
			.Select("WorkplacesTypes.Name")
			.As("WorkplacesTypes");
		
		var entityQuery = new Query("Workplaces")
			.Select("Workplaces.Id")
			.Select("Workplaces.Name")
			.Select("Workplaces.ReferenceNumber")
			.Select("Workplaces.Greeting")
			.Select("Workplaces.Ownership")
			.Select("Workplaces.Type")
			.ForSqlServer(q => q.SelectRaw("COALESCE([WorkplacesLocalized].[Description], (N'[' + COALESCE([Workplaces].[Description], N'')) + N']') AS [Description]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"WorkplacesLocalized\".\"Description\", ('##OPEN##' || COALESCE(\"Workplaces\".\"Description\", '')) || '##CLOSE##') AS \"Description\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"WorkplacesLocalized\".\"Description\", ('##OPEN##' || COALESCE(\"Workplaces\".\"Description\", '')) || '##CLOSE##') AS \"Description\""))
			.Select("WorkplacesOwnerships.Name as OwnershipName")
			.Select("WorkplacesTypes.Name as TypeName")
			.Select("Workplaces.CountryId")
			.Select("Workplaces.Etag")
			.LeftJoin(localizedEntityQuery, j => j.On("WorkplacesLocalized.Id", "Workplaces.Id"))
			.LeftJoin(ownershipEnumQuery, j => j.On("WorkplacesOwnerships.Id", "Workplaces.Ownership"))
			.LeftJoin(typeEnumQuery, j => j.On("WorkplacesTypes.Id", "Workplaces.Type"));

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}