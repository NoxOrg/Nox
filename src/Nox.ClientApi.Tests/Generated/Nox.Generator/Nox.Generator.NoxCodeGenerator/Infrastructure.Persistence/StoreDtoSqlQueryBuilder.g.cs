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
		var statusEnumQuery = new Query("StoresStatuses")
			.Select("StoresStatuses.Id")
			.Select("StoresStatuses.Name")
			.As("StoresStatuses");
		
		var entityQuery = new Query("Stores")
			.Select("Stores.Id")
			.Select("Stores.Name")
			.Select("Stores.Address")
			.Select("Stores.Location")
			.Select("Stores.OpeningDay")
			.Select("Stores.Status")
			.Select("StoresStatuses.Name as StatusName")
			.Select("Stores.StoreOwnerId")
			.Select("Stores.Etag")
			.LeftJoin(statusEnumQuery, j => j.On("StoresStatuses.Id", "Stores.Status"));

		return _sqlCompiler.Compile(entityQuery).ToString().Replace("##OPEN##", "[").Replace("##CLOSE##", "]");
	}
}