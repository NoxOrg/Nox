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
			.Select("Stores.OpeningDay")
			.Select("Stores.Status")
			.Select("Stores.Address_StreetNumber")
			.Select("Stores.Address_AddressLine1")
			.Select("Stores.Address_AddressLine2")
			.Select("Stores.Address_Route")
			.Select("Stores.Address_Locality")
			.Select("Stores.Address_Neighborhood")
			.Select("Stores.Address_AdministrativeArea1")
			.Select("Stores.Address_AdministrativeArea2")
			.Select("Stores.Address_PostalCode")
			.Select("Stores.Address_CountryId")
			.Select("Stores.Location_Latitude")
			.Select("Stores.Location_Longitude")
			.Select("StoresStatuses.Name as StatusName")
			.Select("Stores.CountryId")
			.Select("Stores.StoreOwnerId")
			.Select("Stores.ParentOfStoreId")
			.Select("Stores.DeletedAtUtc")
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
			.ToString();
	}
}