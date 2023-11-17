// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Nox.Lib;
using TestWebApp.Application.Dto;
using DtoNameSpace = TestWebApp.Application.Dto;

namespace TestWebApp.Presentation.Api.OData;

internal static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        services.AddNoxOdata(null);
    }
    public static void AddNoxOdata(this IServiceCollection services, Action<ODataModelBuilder>? configure)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntityType<TestEntityZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityWithNuidDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<ThirdTestEntityOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<ThirdTestEntityZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<ThirdTestEntityExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<ThirdTestEntityZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrOneToZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrManyToZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityExactlyOneToOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOneOrManyToExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityExactlyOneToZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrManyToExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOneOrManyToZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrManyToOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrOneToOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOneOrManyToZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrOneToExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityExactlyOneToZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOwnedRelationshipExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityOwnedRelationshipExactlyOneDto>().HasKey(e => new { });
        builder.EntityType<TestEntityOwnedRelationshipZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityOwnedRelationshipZeroOrOneDto>().HasKey(e => new { });
        builder.EntityType<TestEntityOwnedRelationshipOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityOwnedRelationshipOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOwnedRelationshipZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityOwnedRelationshipZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityTwoRelationshipsManyToManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityForTypesDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityForUniqueConstraintsDto>().HasKey(e => new { e.Id });
        builder.EntityType<EntityUniqueConstraintsWithForeignKeyDto>().HasKey(e => new { e.Id });
        builder.EntityType<EntityUniqueConstraintsRelatedForeignKeyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityLocalizationDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityForAutoNumberUsagesDto>().HasKey(e => new { e.Id });

        builder.EntitySet<TestEntityZeroOrOneDto>("TestEntityZeroOrOnes");
        builder.EntityType<TestEntityZeroOrOneDto>().ContainsOptional(e => e.SecondTestEntityZeroOrOne);

        builder.EntityType<TestEntityZeroOrOneDto>();
        builder.ComplexType<TestEntityZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<SecondTestEntityZeroOrOneDto>("SecondTestEntityZeroOrOnes");
        builder.EntityType<SecondTestEntityZeroOrOneDto>().ContainsOptional(e => e.TestEntityZeroOrOne);

        builder.EntityType<SecondTestEntityZeroOrOneDto>();
        builder.ComplexType<SecondTestEntityZeroOrOneUpdateDto>();
        builder.EntityType<SecondTestEntityZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<SecondTestEntityZeroOrOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityWithNuidDto>("TestEntityWithNuids");

        builder.EntityType<TestEntityWithNuidDto>();
        builder.ComplexType<TestEntityWithNuidUpdateDto>();
        builder.EntityType<TestEntityWithNuidDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityWithNuidDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityOneOrManyDto>("TestEntityOneOrManies");
        builder.EntityType<TestEntityOneOrManyDto>().ContainsMany(e => e.SecondTestEntityOneOrManies);

        builder.EntityType<TestEntityOneOrManyDto>();
        builder.ComplexType<TestEntityOneOrManyUpdateDto>();
        builder.EntityType<TestEntityOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOneOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<SecondTestEntityOneOrManyDto>("SecondTestEntityOneOrManies");
        builder.EntityType<SecondTestEntityOneOrManyDto>().ContainsMany(e => e.TestEntityOneOrManies);

        builder.EntityType<SecondTestEntityOneOrManyDto>();
        builder.ComplexType<SecondTestEntityOneOrManyUpdateDto>();
        builder.EntityType<SecondTestEntityOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<SecondTestEntityOneOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityZeroOrManyDto>("TestEntityZeroOrManies");
        builder.EntityType<TestEntityZeroOrManyDto>().ContainsMany(e => e.SecondTestEntityZeroOrManies);

        builder.EntityType<TestEntityZeroOrManyDto>();
        builder.ComplexType<TestEntityZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<SecondTestEntityZeroOrManyDto>("SecondTestEntityZeroOrManies");
        builder.EntityType<SecondTestEntityZeroOrManyDto>().ContainsMany(e => e.TestEntityZeroOrManies);

        builder.EntityType<SecondTestEntityZeroOrManyDto>();
        builder.ComplexType<SecondTestEntityZeroOrManyUpdateDto>();
        builder.EntityType<SecondTestEntityZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<SecondTestEntityZeroOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<ThirdTestEntityOneOrManyDto>("ThirdTestEntityOneOrManies");
        builder.EntityType<ThirdTestEntityOneOrManyDto>().ContainsMany(e => e.ThirdTestEntityZeroOrManies);

        builder.EntityType<ThirdTestEntityOneOrManyDto>();
        builder.ComplexType<ThirdTestEntityOneOrManyUpdateDto>();
        builder.EntityType<ThirdTestEntityOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ThirdTestEntityOneOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<ThirdTestEntityZeroOrManyDto>("ThirdTestEntityZeroOrManies");
        builder.EntityType<ThirdTestEntityZeroOrManyDto>().ContainsMany(e => e.ThirdTestEntityOneOrManies);

        builder.EntityType<ThirdTestEntityZeroOrManyDto>();
        builder.ComplexType<ThirdTestEntityZeroOrManyUpdateDto>();
        builder.EntityType<ThirdTestEntityZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ThirdTestEntityZeroOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<ThirdTestEntityExactlyOneDto>("ThirdTestEntityExactlyOnes");
        builder.EntityType<ThirdTestEntityExactlyOneDto>().ContainsRequired(e => e.ThirdTestEntityZeroOrOne);

        builder.EntityType<ThirdTestEntityExactlyOneDto>();
        builder.ComplexType<ThirdTestEntityExactlyOneUpdateDto>();
        builder.EntityType<ThirdTestEntityExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ThirdTestEntityExactlyOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<ThirdTestEntityZeroOrOneDto>("ThirdTestEntityZeroOrOnes");
        builder.EntityType<ThirdTestEntityZeroOrOneDto>().ContainsOptional(e => e.ThirdTestEntityExactlyOne);

        builder.EntityType<ThirdTestEntityZeroOrOneDto>();
        builder.ComplexType<ThirdTestEntityZeroOrOneUpdateDto>();
        builder.EntityType<ThirdTestEntityZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ThirdTestEntityZeroOrOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityExactlyOneDto>("TestEntityExactlyOnes");
        builder.EntityType<TestEntityExactlyOneDto>().ContainsRequired(e => e.SecondTestEntityExactlyOne);

        builder.EntityType<TestEntityExactlyOneDto>();
        builder.ComplexType<TestEntityExactlyOneUpdateDto>();
        builder.EntityType<TestEntityExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityExactlyOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<SecondTestEntityExactlyOneDto>("SecondTestEntityExactlyOnes");
        builder.EntityType<SecondTestEntityExactlyOneDto>().ContainsRequired(e => e.TestEntityExactlyOne);

        builder.EntityType<SecondTestEntityExactlyOneDto>();
        builder.ComplexType<SecondTestEntityExactlyOneUpdateDto>();
        builder.EntityType<SecondTestEntityExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<SecondTestEntityExactlyOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityZeroOrOneToZeroOrManyDto>("TestEntityZeroOrOneToZeroOrManies");
        builder.EntityType<TestEntityZeroOrOneToZeroOrManyDto>().ContainsOptional(e => e.TestEntityZeroOrManyToZeroOrOne);

        builder.EntityType<TestEntityZeroOrOneToZeroOrManyDto>();
        builder.ComplexType<TestEntityZeroOrOneToZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityZeroOrOneToZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrOneToZeroOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityZeroOrManyToZeroOrOneDto>("TestEntityZeroOrManyToZeroOrOnes");
        builder.EntityType<TestEntityZeroOrManyToZeroOrOneDto>().ContainsMany(e => e.TestEntityZeroOrOneToZeroOrManies);

        builder.EntityType<TestEntityZeroOrManyToZeroOrOneDto>();
        builder.ComplexType<TestEntityZeroOrManyToZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityZeroOrManyToZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrManyToZeroOrOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityExactlyOneToOneOrManyDto>("TestEntityExactlyOneToOneOrManies");
        builder.EntityType<TestEntityExactlyOneToOneOrManyDto>().ContainsRequired(e => e.TestEntityOneOrManyToExactlyOne);

        builder.EntityType<TestEntityExactlyOneToOneOrManyDto>();
        builder.ComplexType<TestEntityExactlyOneToOneOrManyUpdateDto>();
        builder.EntityType<TestEntityExactlyOneToOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityExactlyOneToOneOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityOneOrManyToExactlyOneDto>("TestEntityOneOrManyToExactlyOnes");
        builder.EntityType<TestEntityOneOrManyToExactlyOneDto>().ContainsMany(e => e.TestEntityExactlyOneToOneOrManies);

        builder.EntityType<TestEntityOneOrManyToExactlyOneDto>();
        builder.ComplexType<TestEntityOneOrManyToExactlyOneUpdateDto>();
        builder.EntityType<TestEntityOneOrManyToExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOneOrManyToExactlyOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityExactlyOneToZeroOrManyDto>("TestEntityExactlyOneToZeroOrManies");
        builder.EntityType<TestEntityExactlyOneToZeroOrManyDto>().ContainsRequired(e => e.TestEntityZeroOrManyToExactlyOne);

        builder.EntityType<TestEntityExactlyOneToZeroOrManyDto>();
        builder.ComplexType<TestEntityExactlyOneToZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityExactlyOneToZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityExactlyOneToZeroOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityZeroOrManyToExactlyOneDto>("TestEntityZeroOrManyToExactlyOnes");
        builder.EntityType<TestEntityZeroOrManyToExactlyOneDto>().ContainsMany(e => e.TestEntityExactlyOneToZeroOrManies);

        builder.EntityType<TestEntityZeroOrManyToExactlyOneDto>();
        builder.ComplexType<TestEntityZeroOrManyToExactlyOneUpdateDto>();
        builder.EntityType<TestEntityZeroOrManyToExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrManyToExactlyOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityOneOrManyToZeroOrManyDto>("TestEntityOneOrManyToZeroOrManies");
        builder.EntityType<TestEntityOneOrManyToZeroOrManyDto>().ContainsMany(e => e.TestEntityZeroOrManyToOneOrManies);

        builder.EntityType<TestEntityOneOrManyToZeroOrManyDto>();
        builder.ComplexType<TestEntityOneOrManyToZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityOneOrManyToZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOneOrManyToZeroOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityZeroOrManyToOneOrManyDto>("TestEntityZeroOrManyToOneOrManies");
        builder.EntityType<TestEntityZeroOrManyToOneOrManyDto>().ContainsMany(e => e.TestEntityOneOrManyToZeroOrManies);

        builder.EntityType<TestEntityZeroOrManyToOneOrManyDto>();
        builder.ComplexType<TestEntityZeroOrManyToOneOrManyUpdateDto>();
        builder.EntityType<TestEntityZeroOrManyToOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrManyToOneOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityZeroOrOneToOneOrManyDto>("TestEntityZeroOrOneToOneOrManies");
        builder.EntityType<TestEntityZeroOrOneToOneOrManyDto>().ContainsOptional(e => e.TestEntityOneOrManyToZeroOrOne);

        builder.EntityType<TestEntityZeroOrOneToOneOrManyDto>();
        builder.ComplexType<TestEntityZeroOrOneToOneOrManyUpdateDto>();
        builder.EntityType<TestEntityZeroOrOneToOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrOneToOneOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityOneOrManyToZeroOrOneDto>("TestEntityOneOrManyToZeroOrOnes");
        builder.EntityType<TestEntityOneOrManyToZeroOrOneDto>().ContainsMany(e => e.TestEntityZeroOrOneToOneOrManies);

        builder.EntityType<TestEntityOneOrManyToZeroOrOneDto>();
        builder.ComplexType<TestEntityOneOrManyToZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityOneOrManyToZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOneOrManyToZeroOrOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityZeroOrOneToExactlyOneDto>("TestEntityZeroOrOneToExactlyOnes");
        builder.EntityType<TestEntityZeroOrOneToExactlyOneDto>().ContainsOptional(e => e.TestEntityExactlyOneToZeroOrOne);

        builder.EntityType<TestEntityZeroOrOneToExactlyOneDto>();
        builder.ComplexType<TestEntityZeroOrOneToExactlyOneUpdateDto>();
        builder.EntityType<TestEntityZeroOrOneToExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrOneToExactlyOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityExactlyOneToZeroOrOneDto>("TestEntityExactlyOneToZeroOrOnes");
        builder.EntityType<TestEntityExactlyOneToZeroOrOneDto>().ContainsRequired(e => e.TestEntityZeroOrOneToExactlyOne);

        builder.EntityType<TestEntityExactlyOneToZeroOrOneDto>();
        builder.ComplexType<TestEntityExactlyOneToZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityExactlyOneToZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityExactlyOneToZeroOrOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityOwnedRelationshipExactlyOneDto>("TestEntityOwnedRelationshipExactlyOnes");
        builder.EntityType<TestEntityOwnedRelationshipExactlyOneDto>().ContainsRequired(e => e.SecondTestEntityOwnedRelationshipExactlyOne).AutoExpand = true;

        builder.EntityType<TestEntityOwnedRelationshipExactlyOneDto>();
        builder.ComplexType<TestEntityOwnedRelationshipExactlyOneUpdateDto>();
        builder.EntityType<TestEntityOwnedRelationshipExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOwnedRelationshipExactlyOneDto>().Ignore(e => e.Etag);

        builder.EntityType<SecondTestEntityOwnedRelationshipExactlyOneDto>();
        builder.ComplexType<SecondTestEntityOwnedRelationshipExactlyOneUpdateDto>();
        builder.EntitySet<TestEntityOwnedRelationshipZeroOrOneDto>("TestEntityOwnedRelationshipZeroOrOnes");
        builder.EntityType<TestEntityOwnedRelationshipZeroOrOneDto>().ContainsOptional(e => e.SecondTestEntityOwnedRelationshipZeroOrOne).AutoExpand = true;

        builder.EntityType<TestEntityOwnedRelationshipZeroOrOneDto>();
        builder.ComplexType<TestEntityOwnedRelationshipZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityOwnedRelationshipZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOwnedRelationshipZeroOrOneDto>().Ignore(e => e.Etag);

        builder.EntityType<SecondTestEntityOwnedRelationshipZeroOrOneDto>();
        builder.ComplexType<SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto>();
        builder.EntitySet<TestEntityOwnedRelationshipOneOrManyDto>("TestEntityOwnedRelationshipOneOrManies");
        builder.EntityType<TestEntityOwnedRelationshipOneOrManyDto>().ContainsMany(e => e.SecondTestEntityOwnedRelationshipOneOrMany).AutoExpand = true;

        builder.EntityType<TestEntityOwnedRelationshipOneOrManyDto>();
        builder.ComplexType<TestEntityOwnedRelationshipOneOrManyUpdateDto>();
        builder.EntityType<TestEntityOwnedRelationshipOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOwnedRelationshipOneOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<SecondTestEntityOwnedRelationshipOneOrManyDto>("SecondTestEntityOwnedRelationshipOneOrManies");

        builder.EntityType<SecondTestEntityOwnedRelationshipOneOrManyDto>();
        builder.ComplexType<SecondTestEntityOwnedRelationshipOneOrManyUpdateDto>();
        builder.EntitySet<TestEntityOwnedRelationshipZeroOrManyDto>("TestEntityOwnedRelationshipZeroOrManies");
        builder.EntityType<TestEntityOwnedRelationshipZeroOrManyDto>().ContainsMany(e => e.SecondTestEntityOwnedRelationshipZeroOrMany).AutoExpand = true;

        builder.EntityType<TestEntityOwnedRelationshipZeroOrManyDto>();
        builder.ComplexType<TestEntityOwnedRelationshipZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityOwnedRelationshipZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOwnedRelationshipZeroOrManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<SecondTestEntityOwnedRelationshipZeroOrManyDto>("SecondTestEntityOwnedRelationshipZeroOrManies");

        builder.EntityType<SecondTestEntityOwnedRelationshipZeroOrManyDto>();
        builder.ComplexType<SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto>();
        builder.EntitySet<TestEntityTwoRelationshipsOneToOneDto>("TestEntityTwoRelationshipsOneToOnes");
        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().ContainsRequired(e => e.TestRelationshipOne);
        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().ContainsRequired(e => e.TestRelationshipTwo);

        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>();
        builder.ComplexType<TestEntityTwoRelationshipsOneToOneUpdateDto>();
        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().Ignore(e => e.Etag);
        builder.EntitySet<SecondTestEntityTwoRelationshipsOneToOneDto>("SecondTestEntityTwoRelationshipsOneToOnes");
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToOneDto>().ContainsOptional(e => e.TestRelationshipOneOnOtherSide);
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToOneDto>().ContainsOptional(e => e.TestRelationshipTwoOnOtherSide);

        builder.EntityType<SecondTestEntityTwoRelationshipsOneToOneDto>();
        builder.ComplexType<SecondTestEntityTwoRelationshipsOneToOneUpdateDto>();
        builder.EntitySet<TestEntityTwoRelationshipsManyToManyDto>("TestEntityTwoRelationshipsManyToManies");
        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().ContainsMany(e => e.TestRelationshipOne);
        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().ContainsMany(e => e.TestRelationshipTwo);

        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>();
        builder.ComplexType<TestEntityTwoRelationshipsManyToManyUpdateDto>();
        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<SecondTestEntityTwoRelationshipsManyToManyDto>("SecondTestEntityTwoRelationshipsManyToManies");
        builder.EntityType<SecondTestEntityTwoRelationshipsManyToManyDto>().ContainsMany(e => e.TestRelationshipOneOnOtherSide);
        builder.EntityType<SecondTestEntityTwoRelationshipsManyToManyDto>().ContainsMany(e => e.TestRelationshipTwoOnOtherSide);

        builder.EntityType<SecondTestEntityTwoRelationshipsManyToManyDto>();
        builder.ComplexType<SecondTestEntityTwoRelationshipsManyToManyUpdateDto>();
        builder.EntitySet<TestEntityTwoRelationshipsOneToManyDto>("TestEntityTwoRelationshipsOneToManies");
        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().ContainsMany(e => e.TestRelationshipOne);
        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().ContainsMany(e => e.TestRelationshipTwo);

        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>();
        builder.ComplexType<TestEntityTwoRelationshipsOneToManyUpdateDto>();
        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().Ignore(e => e.Etag);
        builder.EntitySet<SecondTestEntityTwoRelationshipsOneToManyDto>("SecondTestEntityTwoRelationshipsOneToManies");
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToManyDto>().ContainsOptional(e => e.TestRelationshipOneOnOtherSide);
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToManyDto>().ContainsOptional(e => e.TestRelationshipTwoOnOtherSide);

        builder.EntityType<SecondTestEntityTwoRelationshipsOneToManyDto>();
        builder.ComplexType<SecondTestEntityTwoRelationshipsOneToManyUpdateDto>();
        builder.EntitySet<TestEntityForTypesDto>("TestEntityForTypes");

        builder.EntityType<TestEntityForTypesDto>();
        builder.ComplexType<TestEntityForTypesUpdateDto>();
        builder.EntityType<TestEntityForTypesDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityForTypesDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityForUniqueConstraintsDto>("TestEntityForUniqueConstraints");

        builder.EntityType<TestEntityForUniqueConstraintsDto>();
        builder.ComplexType<TestEntityForUniqueConstraintsUpdateDto>();
        builder.EntitySet<EntityUniqueConstraintsWithForeignKeyDto>("EntityUniqueConstraintsWithForeignKeys");
        builder.EntityType<EntityUniqueConstraintsWithForeignKeyDto>().ContainsRequired(e => e.EntityUniqueConstraintsRelatedForeignKey);

        builder.EntityType<EntityUniqueConstraintsWithForeignKeyDto>();
        builder.ComplexType<EntityUniqueConstraintsWithForeignKeyUpdateDto>();
        builder.EntitySet<EntityUniqueConstraintsRelatedForeignKeyDto>("EntityUniqueConstraintsRelatedForeignKeys");
        builder.EntityType<EntityUniqueConstraintsRelatedForeignKeyDto>().ContainsMany(e => e.EntityUniqueConstraintsWithForeignKeys);

        builder.EntityType<EntityUniqueConstraintsRelatedForeignKeyDto>();
        builder.ComplexType<EntityUniqueConstraintsRelatedForeignKeyUpdateDto>();
        builder.EntitySet<TestEntityLocalizationDto>("TestEntityLocalizations");

        builder.EntityType<TestEntityLocalizationDto>();
        builder.ComplexType<TestEntityLocalizationUpdateDto>();
        builder.EntityType<TestEntityLocalizationDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityLocalizationDto>().Ignore(e => e.Etag);
        builder.EntitySet<TestEntityForAutoNumberUsagesDto>("TestEntityForAutoNumberUsages");

        builder.EntityType<TestEntityForAutoNumberUsagesDto>();
        builder.ComplexType<TestEntityForAutoNumberUsagesUpdateDto>(); 
        // Setup Enumeration End Points
        builder.EntityType<TestEntityForTypesDto>()
                            .Collection
                            .Function("TestEntityForTypesEnumerationTestFields")
                            .ReturnsCollection<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>();

        if(configure != null) configure(builder);

        services.AddControllers()
            .AddOData(options =>
                {
                    options.Select()
                        .EnableQueryFeatures(null)
                        .Filter()
                        .OrderBy()
                        .Count()
                        .Expand()
                        .SkipToken()
                        .SetMaxTop(100);
                    var routeOptions = options.AddRouteComponents(Nox.Presentation.Api.OData.ODataApi.GetRoutePrefix("/api/v1"), builder.GetEdmModel(),
                        service => service
                            .AddSingleton<IODataSerializerProvider, NoxODataSerializerProvider>())
                        .RouteOptions;
                    routeOptions.EnableKeyInParenthesis = false;
                }
            );
    }
}
