// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Nox.Lib;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Presentation.Api.OData;

public static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntityType<CustomerDto>().HasKey(e => new { e.Id });
        builder.EntityType<EmployeeDto>().HasKey(e => new { e.Id });


        builder.EntitySet<CustomerDto>("Customers");
        builder.EntityType<CustomerKeyDto>();

        builder.EntityType<CustomerDto>();
        builder.EntityType<CustomerDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<EmployeeDto>("Employees");
        builder.EntityType<EmployeeKeyDto>();

        builder.EntityType<EmployeeDto>();
        builder.EntityType<EmployeeDto>().Ignore(e => e.DeletedAtUtc);

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
