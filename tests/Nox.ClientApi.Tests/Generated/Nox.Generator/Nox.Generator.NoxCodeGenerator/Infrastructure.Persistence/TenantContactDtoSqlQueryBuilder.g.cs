// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class TenantContactDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public TenantContactDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "TenantContact";

	public string Build()
	{
		var query = TenantContactQuery();
		return CompileToSqlString(query);
	}
	
	private static Query TenantContactQuery()
	{
		return new Query("TenantContacts")
			.Select("TenantContacts.TenantId")
			.Select("TenantContacts.Name")
			.Select("TenantContacts.Email")
			.Select("TenantContacts.Status")
			.ForSqlServer(q => q.SelectRaw("COALESCE([TenantContactsLocalized].[Description], CASE WHEN [TenantContacts].[Description] IS NULL THEN N'' ELSE N'[' + [TenantContacts].[Description] + N']' END) AS [Description]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"TenantContactsLocalized\".\"Description\",CASE WHEN \"TenantContacts\".\"Description\" IS NULL THEN '' ELSE '##OPEN##' || \"TenantContacts\".\"Description\" || '##CLOSE##' END) AS \"Description\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"TenantContactsLocalized\".\"Description\",CASE WHEN \"TenantContacts\".\"Description\" IS NULL THEN '' ELSE '##OPEN##' || \"TenantContacts\".\"Description\" || '##CLOSE##' END) AS \"Description\""))
			.Select("TenantContactsStatuses.Name as StatusName")
			.LeftJoin(TenantContactLocalizedQuery(), j => j.On("TenantContactsLocalized.TenantId", "TenantContacts.TenantId"))
			.LeftJoin(StatusEnumQuery(), j => j.On("TenantContactsStatuses.Id", "TenantContacts.Status"));
	}
	
	private static Query TenantContactLocalizedQuery()
	{
		return new Query("TenantContactsLocalized")
			.Select("TenantContactsLocalized.TenantId")
			.Select("TenantContactsLocalized.Description")
			.Where("TenantContactsLocalized.CultureCode", "##LANG##")
			.As("TenantContactsLocalized");
	}
	
	private static Query StatusEnumQuery()
	{
		return new Query("TenantContactsStatuses")
			.Select("TenantContactsStatuses.Id")
			.ForSqlServer(q => q.SelectRaw("COALESCE([TenantContactsStatusesLocalized].[Name], (N'[' + COALESCE([TenantContactsStatuses].[Name], N'')) + N']') AS [Name]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"TenantContactsStatusesLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"TenantContactsStatuses\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"TenantContactsStatusesLocalized\".\"Name\", ('##OPEN##' || COALESCE(\"TenantContactsStatuses\".\"Name\", '')) || '##CLOSE##') AS \"Name\""))
			.LeftJoin(StatusLocalizedEnumQuery(), j => j.On("TenantContactsStatusesLocalized.Id", "TenantContactsStatuses.Id"))
			.As("TenantContactsStatuses");
	}
	
	private static Query StatusLocalizedEnumQuery()
	{ 
		return new Query("TenantContactsStatusesLocalized")
			.Select("TenantContactsStatusesLocalized.Id")
			.Select("TenantContactsStatusesLocalized.Name")
			.Where("TenantContactsStatusesLocalized.CultureCode", "##LANG##")
			.As("TenantContactsStatusesLocalized");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");
	}
}