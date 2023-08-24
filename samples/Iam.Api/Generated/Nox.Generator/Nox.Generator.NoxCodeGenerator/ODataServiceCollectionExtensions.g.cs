// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Nox.Lib;
using IamApi.Application.Dto;

namespace IamApi.Presentation.Api.OData;

public static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntityType<UserIamDto>().HasKey(e => new { e.Id });
        builder.EntityType<RoleDto>().HasKey(e => new { e.Id });
        builder.EntityType<UserContactSelectionDto>().HasKey(e => new { e.Id });
        builder.EntityType<ApplicationIAMDto>().HasKey(e => new { e.Id });
        builder.EntityType<EmailAddressDto>().HasKey(e => new { e.Email });
        builder.EntityType<PhoneDto>().HasKey(e => new { e.PhoneNumber });


        builder.EntitySet<UserIamDto>("UserIams");
        builder.EntityType<UserIamKeyDto>();
        builder.EntityType<UserIamDto>().ContainsMany(e => e.UserContactSelections).AutoExpand = true;
        builder.EntityType<UserIamDto>().ContainsOptional(e => e.EmailAddress).AutoExpand = true;
        builder.EntityType<UserIamDto>().ContainsOptional(e => e.Phone).AutoExpand = true;

        builder.EntityType<UserIamDto>();
        builder.EntityType<UserIamDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<RoleDto>("Roles");
        builder.EntityType<RoleKeyDto>();

        builder.EntityType<RoleDto>();
        builder.EntityType<RoleDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<UserContactSelectionDto>();

        builder.EntitySet<ApplicationIAMDto>("ApplicationIAMs");
        builder.EntityType<ApplicationIAMKeyDto>();

        builder.EntityType<ApplicationIAMDto>();
        builder.EntityType<ApplicationIAMDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<EmailAddressDto>();

        builder.EntityType<PhoneDto>();

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
                    var routeOptions = options.AddRouteComponents("api", builder.GetEdmModel(), service => service.AddSingleton<IODataSerializerProvider, NoxODataSerializerProvider>()).RouteOptions;
                    routeOptions.EnableKeyInParenthesis = false;
                }
            );
    }
}
