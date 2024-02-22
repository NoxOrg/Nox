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
		var query = TenantBrandQuery();
		return CompileToSqlString(query);
	}
	
	private static Query TenantBrandQuery()
	{
		return new Query("TenantBrands")
			.Select("TenantBrands.Id")
			.Select("TenantBrands.Name")
			.ForSqlServer(q => q.SelectRaw("COALESCE([TenantBrandsLocalized].[Description], CASE WHEN [TenantBrands].[Description] IS NULL THEN N'' ELSE N'[' + [TenantBrands].[Description] + N']' END) AS [Description]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"TenantBrandsLocalized\".\"Description\",CASE WHEN \"TenantBrands\".\"Description\" IS NULL THEN '' ELSE '##OPEN##' || \"TenantBrands\".\"Description\" || '##CLOSE##' END) AS \"Description\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"TenantBrandsLocalized\".\"Description\",CASE WHEN \"TenantBrands\".\"Description\" IS NULL THEN '' ELSE '##OPEN##' || \"TenantBrands\".\"Description\" || '##CLOSE##' END) AS \"Description\""))
			.Select("TenantBrands.TenantId")
			.LeftJoin(TenantBrandLocalizedQuery(), j => j.On("TenantBrandsLocalized.Id", "TenantBrands.Id"));
	}
	
	private static Query TenantBrandLocalizedQuery()
	{
		return new Query("TenantBrandsLocalized")
			.Select("TenantBrandsLocalized.Id")
			.Select("TenantBrandsLocalized.Description")
			.Where("TenantBrandsLocalized.CultureCode", "##LANG##")
			.As("TenantBrandsLocalized");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");
	}
}