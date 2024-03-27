// Generated
#nullable enable

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Nox.Lib;
using ClientApi.Application.Dto;
using DtoNameSpace = ClientApi.Application.Dto;

namespace ClientApi.Presentation.Api.OData;

internal static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        services.AddNoxOdata(null);
    }
    public static void AddNoxOdata(this IServiceCollection services, Action<ODataModelBuilder>? configure)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();
        
        // Odata requires/likes complex type to be registered before entity types and sets
        builder.ComplexType<CountryPartialUpdateDto>();
        builder.ComplexType<CountryLocalNameUpsertDto>();
        builder.ComplexType<CountryBarCodeUpsertDto>();
        builder.ComplexType<RatingProgramPartialUpdateDto>();
        builder.ComplexType<CountryQualityOfLifeIndexPartialUpdateDto>();
        builder.ComplexType<StorePartialUpdateDto>();
        builder.ComplexType<WorkplacePartialUpdateDto>();
        builder.ComplexType<WorkplaceAddressUpsertDto>();
        builder.ComplexType<StoreOwnerPartialUpdateDto>();
        builder.ComplexType<StoreLicensePartialUpdateDto>();
        builder.ComplexType<CurrencyPartialUpdateDto>();
        builder.ComplexType<TenantPartialUpdateDto>();
        builder.ComplexType<TenantBrandUpsertDto>();
        builder.ComplexType<TenantContactUpsertDto>();
        builder.ComplexType<CountryTimeZoneUpsertDto>();
        builder.ComplexType<ClientPartialUpdateDto>();
        builder.ComplexType<HolidayUpsertDto>();
        builder.ComplexType<ReferenceNumberEntityPartialUpdateDto>();
        builder.ComplexType<PersonPartialUpdateDto>();
        builder.ComplexType<UserContactSelectionUpsertDto>();
        builder.ComplexType<EmailAddressUpsertDto>();

        builder.EntitySet<CountryDto>("Countries");
		builder.EntityType<CountryDto>().HasKey(e => new { e.Id });
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryLocalNames).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsOptional(e => e.CountryBarCode).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryTimeZones).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsMany(e => e.Holidays).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsMany(e => e.Workplaces);
        builder.EntityType<CountryDto>().ContainsMany(e => e.Stores);
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CountryDto>().Ignore(e => e.Etag);

        builder.EntitySet<CountryLocalNameDto>("CountryLocalNames");
		builder.EntityType<CountryLocalNameDto>().HasKey(e => new { e.Id });
        builder.EntityType<CountryLocalNameLocalizedDto>().HasKey(e => new { e.Id });

		builder.EntityType<CountryBarCodeDto>().HasKey(e => new {  });

        builder.EntitySet<RatingProgramDto>("RatingPrograms");
		builder.EntityType<RatingProgramDto>().HasKey(e => new { e.StoreId, e.Id });

        builder.EntitySet<CountryQualityOfLifeIndexDto>("CountryQualityOfLifeIndices");
		builder.EntityType<CountryQualityOfLifeIndexDto>().HasKey(e => new { e.CountryId, e.Id });

        builder.EntitySet<StoreDto>("Stores");
		builder.EntityType<StoreDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreDto>().ContainsOptional(e => e.EmailAddress).AutoExpand = true;
        builder.EntityType<StoreDto>().ContainsOptional(e => e.Country);
        builder.EntityType<StoreDto>().ContainsOptional(e => e.StoreOwner);
        builder.EntityType<StoreDto>().ContainsOptional(e => e.StoreLicense);
        builder.EntityType<StoreDto>().ContainsMany(e => e.Clients);
        builder.EntityType<StoreDto>().ContainsOptional(e => e.ParentOfStore);
        builder.EntityType<StoreDto>().ContainsMany(e => e.FranchisesOfStore);
        builder.EntityType<StoreDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<StoreDto>().Ignore(e => e.Etag);

        builder.EntitySet<WorkplaceDto>("Workplaces");
		builder.EntityType<WorkplaceDto>().HasKey(e => new { e.Id });
        builder.EntityType<WorkplaceDto>().ContainsMany(e => e.WorkplaceAddresses).AutoExpand = true;
        builder.EntityType<WorkplaceDto>().ContainsOptional(e => e.Country);
        builder.EntityType<WorkplaceDto>().ContainsMany(e => e.Tenants);
        builder.EntityType<WorkplaceLocalizedDto>().HasKey(e => new { e.Id });
        builder.EntityType<WorkplaceDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<WorkplaceDto>().Ignore(e => e.Etag);

        builder.EntitySet<WorkplaceAddressDto>("WorkplaceAddresses");
		builder.EntityType<WorkplaceAddressDto>().HasKey(e => new { e.Id });
        builder.EntityType<WorkplaceAddressLocalizedDto>().HasKey(e => new { e.Id });

        builder.EntitySet<StoreOwnerDto>("StoreOwners");
		builder.EntityType<StoreOwnerDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreOwnerDto>().ContainsMany(e => e.Stores);
        builder.EntityType<StoreOwnerDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<StoreOwnerDto>().Ignore(e => e.Etag);

        builder.EntitySet<StoreLicenseDto>("StoreLicenses");
		builder.EntityType<StoreLicenseDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreLicenseDto>().ContainsRequired(e => e.Store);
        builder.EntityType<StoreLicenseDto>().ContainsOptional(e => e.DefaultCurrency);
        builder.EntityType<StoreLicenseDto>().ContainsOptional(e => e.SoldInCurrency);
        builder.EntityType<StoreLicenseDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<StoreLicenseDto>().Ignore(e => e.Etag);

        builder.EntitySet<CurrencyDto>("Currencies");
		builder.EntityType<CurrencyDto>().HasKey(e => new { e.Id });
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.StoreLicenseDefault);
        builder.EntityType<CurrencyDto>().ContainsMany(e => e.StoreLicenseSoldIn);
        builder.EntityType<CurrencyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CurrencyDto>().Ignore(e => e.Etag);

        builder.EntitySet<TenantDto>("Tenants");
		builder.EntityType<TenantDto>().HasKey(e => new { e.Id });
        builder.EntityType<TenantDto>().ContainsMany(e => e.TenantBrands).AutoExpand = true;
        builder.EntityType<TenantDto>().ContainsOptional(e => e.TenantContact).AutoExpand = true;
        builder.EntityType<TenantDto>().ContainsMany(e => e.Workplaces);

        builder.EntitySet<TenantBrandDto>("TenantBrands");
		builder.EntityType<TenantBrandDto>().HasKey(e => new { e.Id });
        builder.EntityType<TenantBrandLocalizedDto>().HasKey(e => new { e.Id });

		builder.EntityType<TenantContactDto>().HasKey(e => new {  });
        builder.EntityType<TenantContactLocalizedDto>().HasKey(e => new {  });

        builder.EntitySet<CountryTimeZoneDto>("CountryTimeZones");
		builder.EntityType<CountryTimeZoneDto>().HasKey(e => new { e.Id });

        builder.EntitySet<ClientDto>("Clients");
		builder.EntityType<ClientDto>().HasKey(e => new { e.Id });
        builder.EntityType<ClientDto>().ContainsMany(e => e.Stores);
        builder.EntityType<ClientDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ClientDto>().Ignore(e => e.Etag);

        builder.EntitySet<HolidayDto>("Holidays");
		builder.EntityType<HolidayDto>().HasKey(e => new { e.Id });

        builder.EntitySet<ReferenceNumberEntityDto>("ReferenceNumberEntities");
		builder.EntityType<ReferenceNumberEntityDto>().HasKey(e => new { e.Id });
        builder.EntityType<ReferenceNumberEntityDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<ReferenceNumberEntityDto>().Ignore(e => e.Etag);

        builder.EntitySet<PersonDto>("People");
		builder.EntityType<PersonDto>().HasKey(e => new { e.Id });
        builder.EntityType<PersonDto>().ContainsOptional(e => e.UserContactSelection).AutoExpand = true;
        builder.EntityType<PersonDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<PersonDto>().Ignore(e => e.Etag);

		builder.EntityType<UserContactSelectionDto>().HasKey(e => new {  });

		builder.EntityType<EmailAddressDto>().HasKey(e => new {  }); 
        // Setup Enumeration End Points
        builder.EntityType<CountryDto>()
                            .Collection
                            .Function("Continents")
                            .ReturnsCollection<DtoNameSpace.CountryContinentDto>(); 
        // Setup Enumeration End Points
        builder.EntityType<StoreDto>()
                            .Collection
                            .Function("Statuses")
                            .ReturnsCollection<DtoNameSpace.StoreStatusDto>(); 
        // Setup Enumeration End Points
        builder.EntityType<WorkplaceDto>()
                            .Collection
                            .Function("Ownerships")
                            .ReturnsCollection<DtoNameSpace.WorkplaceOwnershipDto>(); 
        // Setup Enumeration End Points
        builder.EntityType<WorkplaceDto>()
                            .Collection
                            .Function("Types")
                            .ReturnsCollection<DtoNameSpace.WorkplaceTypeDto>(); 
        // Setup Enumeration End Points
        builder.EntityType<TenantDto>()
                            .Collection
                            .Function("Statuses")
                            .ReturnsCollection<DtoNameSpace.TenantStatusDto>(); 
        // Setup Enumeration End Points
        builder.EntityType<TenantBrandDto>()
                            .Collection
                            .Function("Statuses")
                            .ReturnsCollection<DtoNameSpace.TenantBrandStatusDto>(); 
        // Setup Enumeration End Points
        builder.EntityType<TenantContactDto>()
                            .Collection
                            .Function("Statuses")
                            .ReturnsCollection<DtoNameSpace.TenantContactStatusDto>();

       
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
