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
		var statusEnumQuery = new Query("TenantsStatuses")
			.Select("TenantsStatuses.Id")
			.Select("TenantsStatuses.Name")
			.As("TenantsStatuses");
		
		var entityQuery = new Query("Tenants")
			.Select("Tenants.Id")
			.Select("Tenants.Name")
			.Select("Tenants.Status")
			.Select("TenantsStatuses.Name as StatusName")
			.Select("Tenants.Etag")
			.LeftJoin(statusEnumQuery, j => j.On("TenantsStatuses.Id", "Tenants.Status"));

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}