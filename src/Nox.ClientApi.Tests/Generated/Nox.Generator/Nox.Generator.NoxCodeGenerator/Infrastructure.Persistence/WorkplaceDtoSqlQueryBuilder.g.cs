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
		var query = WorkplaceQuery();
		return CompileToSqlString(query);
	}
	
	private static Query WorkplaceQuery()
	{
		return new Query("Workplaces")
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
			.Select("Workplaces.DeletedAtUtc")
			.Select("Workplaces.Etag")
			.LeftJoin(WorkplaceLocalizedQuery(), j => j.On("WorkplacesLocalized.Id", "Workplaces.Id"))
			.LeftJoin(OwnershipEnumQuery(), j => j.On("WorkplacesOwnerships.Id", "Workplaces.Ownership"))
			.LeftJoin(TypeEnumQuery(), j => j.On("WorkplacesTypes.Id", "Workplaces.Type"));
	}
	
	private static Query WorkplaceLocalizedQuery()
	{
		return new Query("WorkplacesLocalized")
			.Select("WorkplacesLocalized.Id")
			.Select("WorkplacesLocalized.Description")
			.Where("WorkplacesLocalized.CultureCode", "##LANG##")
			.As("WorkplacesLocalized");
	}
	
	private static Query OwnershipEnumQuery()
	{
		return new Query("WorkplacesOwnerships")
			.Select("WorkplacesOwnerships.Id")
			.ForSqlServer(q => q.SelectRaw("COALESCE([WorkplacesOwnershipsLocalized].[Name], (N'[' + COALESCE([WorkplacesOwnerships].[Name], N'')) + N']') AS [Name]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"WorkplacesOwnershipsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"WorkplacesOwnerships\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"WorkplacesOwnershipsLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"WorkplacesOwnerships\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.LeftJoin(OwnershipLocalizedEnumQuery(), j => j.On("WorkplacesOwnershipsLocalized.Id", "WorkplacesOwnerships.Id"))
			.As("WorkplacesOwnerships");
	}
	
	private static Query OwnershipLocalizedEnumQuery()
	{ 
		return new Query("WorkplacesOwnershipsLocalized")
			.Select("WorkplacesOwnershipsLocalized.Id")
			.Select("WorkplacesOwnershipsLocalized.Name")
			.Where("WorkplacesOwnershipsLocalized.CultureCode", "##LANG##")
			.As("WorkplacesOwnershipsLocalized");
	}
	
	private static Query TypeEnumQuery()
	{
		return new Query("WorkplacesTypes")
			.Select("WorkplacesTypes.Id")
			.Select("WorkplacesTypes.Name")
			.As("WorkplacesTypes");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");;
	}
}