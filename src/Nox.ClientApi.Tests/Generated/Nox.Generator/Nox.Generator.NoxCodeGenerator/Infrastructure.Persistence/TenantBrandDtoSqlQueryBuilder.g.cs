// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class TenantBrandDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public TenantBrandDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "TenantBrand";

	public string Build()
	{
		var localizedEntityQuery = new Query("TenantBrandsLocalized")
			.Select("TenantBrandsLocalized.Id")
			.Select("TenantBrandsLocalized.Description")
			.Where("TenantBrandsLocalized.CultureCode", "##LANG##")
			.As("TenantBrandsLocalized");
		var entityQuery = new Query("TenantBrands")
			.Select("TenantBrands.Id")
			.Select("TenantBrands.Name")
			.ForSqlServer(q => q.SelectRaw("COALESCE([TenantBrandsLocalized].[Description], (N'[' + COALESCE([TenantBrands].[Description], N'')) + N']') AS [Description]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"TenantBrandsLocalized\".\"Description\", ('##OPEN##' || COALESCE(\"TenantBrands\".\"Description\", '')) || '##CLOSE##') AS \"Description\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"TenantBrandsLocalized\".\"Description\", ('##OPEN##' || COALESCE(\"TenantBrands\".\"Description\", '')) || '##CLOSE##') AS \"Description\""))
			.Select("TenantBrands.TenantId")
			.LeftJoin(localizedEntityQuery, j => j.On("TenantBrandsLocalized.Id", "TenantBrands.Id"));

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}