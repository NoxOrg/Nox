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
        builder.EntityType<ApplicationIAMDto>().HasKey(e => new { e.Id });


        builder.EntitySet<UserIamDto>("UserIams");
        builder.EntityType<UserIamKeyDto>();

        builder.EntityType<UserIamDto>();
        builder.EntityType<UserIamDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<ApplicationIAMDto>("ApplicationIAMs");
        builder.EntityType<ApplicationIAMKeyDto>();

        builder.EntityType<ApplicationIAMDto>();
        builder.EntityType<ApplicationIAMDto>().Ignore(e => e.DeletedAtUtc);

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
