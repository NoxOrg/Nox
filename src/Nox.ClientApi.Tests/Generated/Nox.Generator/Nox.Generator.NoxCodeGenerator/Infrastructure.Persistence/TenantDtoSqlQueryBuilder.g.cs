// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class TenantDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public TenantDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "Tenant";

	public string Build()
	{
		var query = TenantQuery();
		return CompileToSqlString(query);
	}
	
	private static Query TenantQuery()
	{
		return new Query("Tenants")
			.Select("Tenants.Id")
			.Select("Tenants.Name")
			.Select("Tenants.Status")
			.Select("TenantsStatuses.Name as StatusName")
			.Select("Tenants.Etag")
			.LeftJoin(StatusEnumQuery(), j => j.On("TenantsStatuses.Id", "Tenants.Status"));
	}
	
	private static Query StatusEnumQuery()
	{
		return new Query("TenantsStatuses")
			.Select("TenantsStatuses.Id")
			.Select("TenantsStatuses.Name")
			.As("TenantsStatuses");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");
	}
}