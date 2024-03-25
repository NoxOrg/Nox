// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class WorkplaceAddressDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public WorkplaceAddressDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "WorkplaceAddress";

	public string Build()
	{
		var query = WorkplaceAddressQuery();
		return CompileToSqlString(query);
	}
	
	private static Query WorkplaceAddressQuery()
	{
		return new Query("WorkplaceAddresses")
			.Select("WorkplaceAddresses.Id")
			.ForSqlServer(q => q.SelectRaw("COALESCE([WorkplaceAddressesLocalized].[AddressLine], CASE WHEN [WorkplaceAddresses].[AddressLine] IS NULL THEN N'' ELSE N'[' + [WorkplaceAddresses].[AddressLine] + N']' END) AS [AddressLine]"))
			.ForPostgreSql(q => q.SelectRaw("COALESCE(\"WorkplaceAddressesLocalized\".\"AddressLine\",CASE WHEN \"WorkplaceAddresses\".\"AddressLine\" IS NULL THEN '' ELSE '##OPEN##' || \"WorkplaceAddresses\".\"AddressLine\" || '##CLOSE##' END) AS \"AddressLine\""))
			.ForSqlite(q => q.SelectRaw("COALESCE(\"WorkplaceAddressesLocalized\".\"AddressLine\",CASE WHEN \"WorkplaceAddresses\".\"AddressLine\" IS NULL THEN '' ELSE '##OPEN##' || \"WorkplaceAddresses\".\"AddressLine\" || '##CLOSE##' END) AS \"AddressLine\""))
			.Select("WorkplaceAddresses.WorkplaceId")
			.LeftJoin(WorkplaceAddressLocalizedQuery(), j => j.On("WorkplaceAddressesLocalized.Id", "WorkplaceAddresses.Id"));
	}
	
	private static Query WorkplaceAddressLocalizedQuery()
	{
		return new Query("WorkplaceAddressesLocalized")
			.Select("WorkplaceAddressesLocalized.Id")
			.Select("WorkplaceAddressesLocalized.AddressLine")
			.Where("WorkplaceAddressesLocalized.CultureCode", "##LANG##")
			.As("WorkplaceAddressesLocalized");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");
	}
}