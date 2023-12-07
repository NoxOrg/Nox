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
		var localizedEntityQuery = new Query("TenantContactsLocalized")
			.Select("TenantContactsLocalized.TenantId")
			.Select("TenantContactsLocalized.Description")
			.Where("TenantContactsLocalized.CultureCode", "##LANG##")
			.As("TenantContactsLocalized");
		var entityQuery = new Query("TenantContacts")
			.Select("TenantContacts.TenantId")
			.Select("TenantContacts.Name")
			.Select("TenantContacts.Email")
			.ForSqlServer(q => q.SelectRaw("COALESCE([TenantContactsLocalized].[Description], (N'[' + COALESCE([TenantContacts].[Description], N'')) + N']') AS [Description]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"TenantContactsLocalized\".\"Description\", ('##OPEN##' || COALESCE(\"TenantContacts\".\"Description\", '')) || '##CLOSE##') AS \"Description\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"TenantContactsLocalized\".\"Description\", ('##OPEN##' || COALESCE(\"TenantContacts\".\"Description\", '')) || '##CLOSE##') AS \"Description\""))
			.LeftJoin(localizedEntityQuery, j => j.On("TenantContactsLocalized.TenantId", "TenantContacts.TenantId"));

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}