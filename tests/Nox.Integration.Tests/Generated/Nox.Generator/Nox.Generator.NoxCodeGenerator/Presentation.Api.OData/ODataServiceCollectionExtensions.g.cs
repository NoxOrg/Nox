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

        builder.EntitySet<TestEntityZeroOrOneDto>("TestEntityZeroOrOnes");
		builder.EntityType<TestEntityZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrOneDto>().ContainsOptional(e => e.SecondTestEntityZeroOrOne);
        builder.ComplexType<TestEntityZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<SecondTestEntityZeroOrOneDto>("SecondTestEntityZeroOrOnes");
		builder.EntityType<SecondTestEntityZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityZeroOrOneDto>().ContainsOptional(e => e.TestEntityZeroOrOne);
        builder.ComplexType<SecondTestEntityZeroOrOneUpdateDto>();
        builder.EntityType<SecondTestEntityZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<SecondTestEntityZeroOrOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityWithNuidDto>("TestEntityWithNuids");
		builder.EntityType<TestEntityWithNuidDto>().HasKey(e => new { e.Id });
        builder.ComplexType<TestEntityWithNuidUpdateDto>();
        builder.EntityType<TestEntityWithNuidDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityWithNuidDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityOneOrManyDto>("TestEntityOneOrManies");
		builder.EntityType<TestEntityOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOneOrManyDto>().ContainsMany(e => e.SecondTestEntityOneOrManies);
        builder.ComplexType<TestEntityOneOrManyUpdateDto>();
        builder.EntityType<TestEntityOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOneOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<SecondTestEntityOneOrManyDto>("SecondTestEntityOneOrManies");
		builder.EntityType<SecondTestEntityOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityOneOrManyDto>().ContainsMany(e => e.TestEntityOneOrManies);
        builder.ComplexType<SecondTestEntityOneOrManyUpdateDto>();
        builder.EntityType<SecondTestEntityOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<SecondTestEntityOneOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityZeroOrManyDto>("TestEntityZeroOrManies");
		builder.EntityType<TestEntityZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrManyDto>().ContainsMany(e => e.SecondTestEntityZeroOrManies);
        builder.ComplexType<TestEntityZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<SecondTestEntityZeroOrManyDto>("SecondTestEntityZeroOrManies");
		builder.EntityType<SecondTestEntityZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityZeroOrManyDto>().ContainsMany(e => e.TestEntityZeroOrManies);
        builder.ComplexType<SecondTestEntityZeroOrManyUpdateDto>();
        builder.EntityType<SecondTestEntityZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<SecondTestEntityZeroOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<ThirdTestEntityOneOrManyDto>("ThirdTestEntityOneOrManies");
		builder.EntityType<ThirdTestEntityOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<ThirdTestEntityOneOrManyDto>().ContainsMany(e => e.ThirdTestEntityZeroOrManies);
        builder.ComplexType<ThirdTestEntityOneOrManyUpdateDto>();
        builder.EntityType<ThirdTestEntityOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ThirdTestEntityOneOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<ThirdTestEntityZeroOrManyDto>("ThirdTestEntityZeroOrManies");
		builder.EntityType<ThirdTestEntityZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<ThirdTestEntityZeroOrManyDto>().ContainsMany(e => e.ThirdTestEntityOneOrManies);
        builder.ComplexType<ThirdTestEntityZeroOrManyUpdateDto>();
        builder.EntityType<ThirdTestEntityZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ThirdTestEntityZeroOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<ThirdTestEntityExactlyOneDto>("ThirdTestEntityExactlyOnes");
		builder.EntityType<ThirdTestEntityExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<ThirdTestEntityExactlyOneDto>().ContainsRequired(e => e.ThirdTestEntityZeroOrOne);
        builder.ComplexType<ThirdTestEntityExactlyOneUpdateDto>();
        builder.EntityType<ThirdTestEntityExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ThirdTestEntityExactlyOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<ThirdTestEntityZeroOrOneDto>("ThirdTestEntityZeroOrOnes");
		builder.EntityType<ThirdTestEntityZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<ThirdTestEntityZeroOrOneDto>().ContainsOptional(e => e.ThirdTestEntityExactlyOne);
        builder.ComplexType<ThirdTestEntityZeroOrOneUpdateDto>();
        builder.EntityType<ThirdTestEntityZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ThirdTestEntityZeroOrOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityExactlyOneDto>("TestEntityExactlyOnes");
		builder.EntityType<TestEntityExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityExactlyOneDto>().ContainsRequired(e => e.SecondTestEntityExactlyOne);
        builder.ComplexType<TestEntityExactlyOneUpdateDto>();
        builder.EntityType<TestEntityExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityExactlyOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<SecondTestEntityExactlyOneDto>("SecondTestEntityExactlyOnes");
		builder.EntityType<SecondTestEntityExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityExactlyOneDto>().ContainsRequired(e => e.TestEntityExactlyOne);
        builder.ComplexType<SecondTestEntityExactlyOneUpdateDto>();
        builder.EntityType<SecondTestEntityExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<SecondTestEntityExactlyOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityZeroOrOneToZeroOrManyDto>("TestEntityZeroOrOneToZeroOrManies");
		builder.EntityType<TestEntityZeroOrOneToZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrOneToZeroOrManyDto>().ContainsOptional(e => e.TestEntityZeroOrManyToZeroOrOne);
        builder.ComplexType<TestEntityZeroOrOneToZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityZeroOrOneToZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrOneToZeroOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityZeroOrManyToZeroOrOneDto>("TestEntityZeroOrManyToZeroOrOnes");
		builder.EntityType<TestEntityZeroOrManyToZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrManyToZeroOrOneDto>().ContainsMany(e => e.TestEntityZeroOrOneToZeroOrManies);
        builder.ComplexType<TestEntityZeroOrManyToZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityZeroOrManyToZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrManyToZeroOrOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityExactlyOneToOneOrManyDto>("TestEntityExactlyOneToOneOrManies");
		builder.EntityType<TestEntityExactlyOneToOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityExactlyOneToOneOrManyDto>().ContainsRequired(e => e.TestEntityOneOrManyToExactlyOne);
        builder.ComplexType<TestEntityExactlyOneToOneOrManyUpdateDto>();
        builder.EntityType<TestEntityExactlyOneToOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityExactlyOneToOneOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityOneOrManyToExactlyOneDto>("TestEntityOneOrManyToExactlyOnes");
		builder.EntityType<TestEntityOneOrManyToExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOneOrManyToExactlyOneDto>().ContainsMany(e => e.TestEntityExactlyOneToOneOrManies);
        builder.ComplexType<TestEntityOneOrManyToExactlyOneUpdateDto>();
        builder.EntityType<TestEntityOneOrManyToExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOneOrManyToExactlyOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityExactlyOneToZeroOrManyDto>("TestEntityExactlyOneToZeroOrManies");
		builder.EntityType<TestEntityExactlyOneToZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityExactlyOneToZeroOrManyDto>().ContainsRequired(e => e.TestEntityZeroOrManyToExactlyOne);
        builder.ComplexType<TestEntityExactlyOneToZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityExactlyOneToZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityExactlyOneToZeroOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityZeroOrManyToExactlyOneDto>("TestEntityZeroOrManyToExactlyOnes");
		builder.EntityType<TestEntityZeroOrManyToExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrManyToExactlyOneDto>().ContainsMany(e => e.TestEntityExactlyOneToZeroOrManies);
        builder.ComplexType<TestEntityZeroOrManyToExactlyOneUpdateDto>();
        builder.EntityType<TestEntityZeroOrManyToExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrManyToExactlyOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityOneOrManyToZeroOrManyDto>("TestEntityOneOrManyToZeroOrManies");
		builder.EntityType<TestEntityOneOrManyToZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOneOrManyToZeroOrManyDto>().ContainsMany(e => e.TestEntityZeroOrManyToOneOrManies);
        builder.ComplexType<TestEntityOneOrManyToZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityOneOrManyToZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOneOrManyToZeroOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityZeroOrManyToOneOrManyDto>("TestEntityZeroOrManyToOneOrManies");
		builder.EntityType<TestEntityZeroOrManyToOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrManyToOneOrManyDto>().ContainsMany(e => e.TestEntityOneOrManyToZeroOrManies);
        builder.ComplexType<TestEntityZeroOrManyToOneOrManyUpdateDto>();
        builder.EntityType<TestEntityZeroOrManyToOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrManyToOneOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityZeroOrOneToOneOrManyDto>("TestEntityZeroOrOneToOneOrManies");
		builder.EntityType<TestEntityZeroOrOneToOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrOneToOneOrManyDto>().ContainsOptional(e => e.TestEntityOneOrManyToZeroOrOne);
        builder.ComplexType<TestEntityZeroOrOneToOneOrManyUpdateDto>();
        builder.EntityType<TestEntityZeroOrOneToOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrOneToOneOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityOneOrManyToZeroOrOneDto>("TestEntityOneOrManyToZeroOrOnes");
		builder.EntityType<TestEntityOneOrManyToZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOneOrManyToZeroOrOneDto>().ContainsMany(e => e.TestEntityZeroOrOneToOneOrManies);
        builder.ComplexType<TestEntityOneOrManyToZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityOneOrManyToZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOneOrManyToZeroOrOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityZeroOrOneToExactlyOneDto>("TestEntityZeroOrOneToExactlyOnes");
		builder.EntityType<TestEntityZeroOrOneToExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityZeroOrOneToExactlyOneDto>().ContainsOptional(e => e.TestEntityExactlyOneToZeroOrOne);
        builder.ComplexType<TestEntityZeroOrOneToExactlyOneUpdateDto>();
        builder.EntityType<TestEntityZeroOrOneToExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityZeroOrOneToExactlyOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityExactlyOneToZeroOrOneDto>("TestEntityExactlyOneToZeroOrOnes");
		builder.EntityType<TestEntityExactlyOneToZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityExactlyOneToZeroOrOneDto>().ContainsRequired(e => e.TestEntityZeroOrOneToExactlyOne);
        builder.ComplexType<TestEntityExactlyOneToZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityExactlyOneToZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityExactlyOneToZeroOrOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityOwnedRelationshipExactlyOneDto>("TestEntityOwnedRelationshipExactlyOnes");
		builder.EntityType<TestEntityOwnedRelationshipExactlyOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOwnedRelationshipExactlyOneDto>().ContainsRequired(e => e.SecondTestEntityOwnedRelationshipExactlyOne).AutoExpand = true;
        builder.ComplexType<TestEntityOwnedRelationshipExactlyOneUpdateDto>();
        builder.EntityType<TestEntityOwnedRelationshipExactlyOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOwnedRelationshipExactlyOneDto>().Ignore(e => e.Etag);

		builder.EntityType<SecondTestEntityOwnedRelationshipExactlyOneDto>().HasKey(e => new {  });
        builder.ComplexType<SecondTestEntityOwnedRelationshipExactlyOneUpdateDto>();

        builder.EntitySet<TestEntityOwnedRelationshipZeroOrOneDto>("TestEntityOwnedRelationshipZeroOrOnes");
		builder.EntityType<TestEntityOwnedRelationshipZeroOrOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOwnedRelationshipZeroOrOneDto>().ContainsOptional(e => e.SecondTestEntityOwnedRelationshipZeroOrOne).AutoExpand = true;
        builder.ComplexType<TestEntityOwnedRelationshipZeroOrOneUpdateDto>();
        builder.EntityType<TestEntityOwnedRelationshipZeroOrOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOwnedRelationshipZeroOrOneDto>().Ignore(e => e.Etag);

		builder.EntityType<SecondTestEntityOwnedRelationshipZeroOrOneDto>().HasKey(e => new {  });
        builder.ComplexType<SecondTestEntityOwnedRelationshipZeroOrOneUpdateDto>();

        builder.EntitySet<TestEntityOwnedRelationshipOneOrManyDto>("TestEntityOwnedRelationshipOneOrManies");
		builder.EntityType<TestEntityOwnedRelationshipOneOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOwnedRelationshipOneOrManyDto>().ContainsMany(e => e.SecondTestEntityOwnedRelationshipOneOrManies).AutoExpand = true;
        builder.ComplexType<TestEntityOwnedRelationshipOneOrManyUpdateDto>();
        builder.EntityType<TestEntityOwnedRelationshipOneOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOwnedRelationshipOneOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<SecondTestEntityOwnedRelationshipOneOrManyDto>("SecondTestEntityOwnedRelationshipOneOrManies");
		builder.EntityType<SecondTestEntityOwnedRelationshipOneOrManyDto>().HasKey(e => new { e.Id });
        builder.ComplexType<SecondTestEntityOwnedRelationshipOneOrManyUpdateDto>();

        builder.EntitySet<TestEntityOwnedRelationshipZeroOrManyDto>("TestEntityOwnedRelationshipZeroOrManies");
		builder.EntityType<TestEntityOwnedRelationshipZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityOwnedRelationshipZeroOrManyDto>().ContainsMany(e => e.SecondTestEntityOwnedRelationshipZeroOrManies).AutoExpand = true;
        builder.ComplexType<TestEntityOwnedRelationshipZeroOrManyUpdateDto>();
        builder.EntityType<TestEntityOwnedRelationshipZeroOrManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityOwnedRelationshipZeroOrManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<SecondTestEntityOwnedRelationshipZeroOrManyDto>("SecondTestEntityOwnedRelationshipZeroOrManies");
		builder.EntityType<SecondTestEntityOwnedRelationshipZeroOrManyDto>().HasKey(e => new { e.Id });
        builder.ComplexType<SecondTestEntityOwnedRelationshipZeroOrManyUpdateDto>();

        builder.EntitySet<TestEntityTwoRelationshipsOneToOneDto>("TestEntityTwoRelationshipsOneToOnes");
		builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().ContainsRequired(e => e.TestRelationshipOne);
        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().ContainsRequired(e => e.TestRelationshipTwo);
        builder.ComplexType<TestEntityTwoRelationshipsOneToOneUpdateDto>();
        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityTwoRelationshipsOneToOneDto>().Ignore(e => e.Etag);

        builder.EntitySet<SecondTestEntityTwoRelationshipsOneToOneDto>("SecondTestEntityTwoRelationshipsOneToOnes");
		builder.EntityType<SecondTestEntityTwoRelationshipsOneToOneDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToOneDto>().ContainsOptional(e => e.TestRelationshipOneOnOtherSide);
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToOneDto>().ContainsOptional(e => e.TestRelationshipTwoOnOtherSide);
        builder.ComplexType<SecondTestEntityTwoRelationshipsOneToOneUpdateDto>();

        builder.EntitySet<TestEntityTwoRelationshipsManyToManyDto>("TestEntityTwoRelationshipsManyToManies");
		builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().ContainsMany(e => e.TestRelationshipOne);
        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().ContainsMany(e => e.TestRelationshipTwo);
        builder.ComplexType<TestEntityTwoRelationshipsManyToManyUpdateDto>();
        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityTwoRelationshipsManyToManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<SecondTestEntityTwoRelationshipsManyToManyDto>("SecondTestEntityTwoRelationshipsManyToManies");
		builder.EntityType<SecondTestEntityTwoRelationshipsManyToManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityTwoRelationshipsManyToManyDto>().ContainsMany(e => e.TestRelationshipOneOnOtherSide);
        builder.EntityType<SecondTestEntityTwoRelationshipsManyToManyDto>().ContainsMany(e => e.TestRelationshipTwoOnOtherSide);
        builder.ComplexType<SecondTestEntityTwoRelationshipsManyToManyUpdateDto>();

        builder.EntitySet<TestEntityTwoRelationshipsOneToManyDto>("TestEntityTwoRelationshipsOneToManies");
		builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().ContainsMany(e => e.TestRelationshipOne);
        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().ContainsMany(e => e.TestRelationshipTwo);
        builder.ComplexType<TestEntityTwoRelationshipsOneToManyUpdateDto>();
        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityTwoRelationshipsOneToManyDto>().Ignore(e => e.Etag);

        builder.EntitySet<SecondTestEntityTwoRelationshipsOneToManyDto>("SecondTestEntityTwoRelationshipsOneToManies");
		builder.EntityType<SecondTestEntityTwoRelationshipsOneToManyDto>().HasKey(e => new { e.Id });
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToManyDto>().ContainsOptional(e => e.TestRelationshipOneOnOtherSide);
        builder.EntityType<SecondTestEntityTwoRelationshipsOneToManyDto>().ContainsOptional(e => e.TestRelationshipTwoOnOtherSide);
        builder.ComplexType<SecondTestEntityTwoRelationshipsOneToManyUpdateDto>();

        builder.EntitySet<TestEntityForTypesDto>("TestEntityForTypes");
		builder.EntityType<TestEntityForTypesDto>().HasKey(e => new { e.Id });
        builder.ComplexType<TestEntityForTypesUpdateDto>();
        builder.EntityType<TestEntityForTypesDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityForTypesDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityForUniqueConstraintsDto>("TestEntityForUniqueConstraints");
		builder.EntityType<TestEntityForUniqueConstraintsDto>().HasKey(e => new { e.Id });
        builder.ComplexType<TestEntityForUniqueConstraintsUpdateDto>();

        builder.EntitySet<TestEntityLocalizationDto>("TestEntityLocalizations");
		builder.EntityType<TestEntityLocalizationDto>().HasKey(e => new { e.Id });
        builder.ComplexType<TestEntityLocalizationUpdateDto>();
        builder.EntityType<TestEntityLocalizationDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<TestEntityLocalizationDto>().Ignore(e => e.Etag);

        builder.EntitySet<TestEntityForAutoNumberUsagesDto>("TestEntityForAutoNumberUsages");
		builder.EntityType<TestEntityForAutoNumberUsagesDto>().HasKey(e => new { e.Id });
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
