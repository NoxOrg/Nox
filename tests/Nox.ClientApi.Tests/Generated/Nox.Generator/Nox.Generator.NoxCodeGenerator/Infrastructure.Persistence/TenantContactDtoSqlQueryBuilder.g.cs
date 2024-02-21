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
			.ForSqlServer(q => q.SelectRaw("COALESCE([TenantContactsLocalized].[Description], CASE WHEN [TenantContacts].[Description] IS NULL THEN N'' ELSE N'[' + [TenantContacts].[Description] + N']' END) AS [Description]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"TenantContactsLocalized\".\"Description\",CASE WHEN \"TenantContacts\".\"Description\" IS NULL THEN '' ELSE '##OPEN##' || \"TenantContacts\".\"Description\" || '##CLOSE##' END) AS \"Description\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"TenantContactsLocalized\".\"Description\",CASE WHEN \"TenantContacts\".\"Description\" IS NULL THEN '' ELSE '##OPEN##' || \"TenantContacts\".\"Description\" || '##CLOSE##' END) AS \"Description\""))
			.LeftJoin(TenantContactLocalizedQuery(), j => j.On("TenantContactsLocalized.TenantId", "TenantContacts.TenantId"));
	}
	
	private static Query TenantContactLocalizedQuery()
	{
		return new Query("TenantContactsLocalized")
			.Select("TenantContactsLocalized.TenantId")
			.Select("TenantContactsLocalized.Description")
			.Where("TenantContactsLocalized.CultureCode", "##LANG##")
			.As("TenantContactsLocalized");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");
	}
}