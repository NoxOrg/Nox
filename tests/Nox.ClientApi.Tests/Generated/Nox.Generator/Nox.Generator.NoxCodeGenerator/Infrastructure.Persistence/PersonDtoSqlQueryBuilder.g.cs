// Generated
#nullable enable

using Nox.Types.EntityFramework.Abstractions;

using SqlKata;
using SqlKata.Compilers;
using SqlKata.Extensions;

namespace ClientApi.Infrastructure.Persistence;

public class PersonDtoSqlQueryBuilder : IEntityDtoSqlQueryBuilder
{
	private readonly Compiler _sqlCompiler;

	public PersonDtoSqlQueryBuilder(Compiler sqlCompiler)
	{
		_sqlCompiler = sqlCompiler;
	}

	public string EntityName => "Person";

	public string Build()
	{
		var query = PersonQuery();
		return CompileToSqlString(query);
	}
	
	private static Query PersonQuery()
	{
		return new Query("People")
			.Select("People.Id")
			.Select("People.UserName")
			.Select("People.FirstName")
			.Select("People.LastName")
			.Select("People.TenantId")
			.Select("People.TenantBrandId")
			.Select("People.PrimaryEmailAddress")
			.Select("People.SecondaryEmailAddress")
			.Select("People.PhoneNumber")
			.Select("People.PrefferedLanguage")
			.Select("People.Status")
			.Select("People.Type")
			.Select("People.UserProfileId")
			.Select("People.PreferredLoginMethod")
			.Select("People.HCountryIsoCode")
			.Select("People.HAcceptedTerms")
			.Select("People.HEnablePasswordLess")
			.Select("People.HPrimaryEmailAddressVerified")
			.Select("PeopleStatuses.Name as StatusName")
			.Select("PeoplePreferredLoginMethods.Name as PreferredLoginMethodName")
			.Select("People.DeletedAtUtc")
			.Select("People.Etag")
			.LeftJoin(StatusEnumQuery(), j => j.On("PeopleStatuses.Id", "People.Status"))
			.LeftJoin(PreferredLoginMethodEnumQuery(), j => j.On("PeoplePreferredLoginMethods.Id", "People.PreferredLoginMethod"));
	}
	
	private static Query StatusEnumQuery()
	{
		return new Query("PeopleStatuses")
			.Select("PeopleStatuses.Id")
			.Select("PeopleStatuses.Name")
			.As("PeopleStatuses");
	}
	
	private static Query PreferredLoginMethodEnumQuery()
	{
		return new Query("PeoplePreferredLoginMethods")
			.Select("PeoplePreferredLoginMethods.Id")
			.Select("PeoplePreferredLoginMethods.Name")
			.As("PeoplePreferredLoginMethods");
	}

	private string CompileToSqlString(Query query)
	{
		return _sqlCompiler.Compile(query)
			.ToString();
	}
}