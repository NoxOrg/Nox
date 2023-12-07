// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class StoreDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public StoreDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "Store";

	public string Build()
	{
		var query = StoreQuery();
		return CompileToSqlString(query);
	}
	
	private static Query StoreQuery()
	{
		return new Query("Stores")
			.Select("Stores.Id")
			.Select("Stores.Name")
			.Select("Stores.Address")
			.Select("Stores.Location")
			.Select("Stores.OpeningDay")
			.Select("Stores.Status")
			.Select("StoresStatuses.Name as StatusName")
			.Select("Stores.StoreOwnerId")
			.Select("Stores.Etag")
			.LeftJoin(StatusEnumQuery(), j => j.On("StoresStatuses.Id", "Stores.Status"));
	}
	
	private static Query StatusEnumQuery()
	{
		return new Query("StoresStatuses")
			.Select("StoresStatuses.Id")
			.Select("StoresStatuses.Name")
			.As("StoresStatuses");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString()
			.Replace("##OPEN##", "[")
			.Replace("##CLOSE##", "]");
	}
}