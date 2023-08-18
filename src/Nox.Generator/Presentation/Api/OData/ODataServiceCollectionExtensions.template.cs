// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Nox.Lib;
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ODataNameSpace}};

public static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        {{ hasKeyForCompoundKeys -}}
        
        {{- for entity in solution.Domain.Entities }}

        builder.EntitySet<{{entity.Name}}Dto>("{{entity.PluralName}}");
        builder.EntityType<{{entity.Name}}KeyDto>();
        {{- if entity.Persistence?.IsVersioned ~}}

        builder.EntityType<{{entity.Name}}Dto>().Ignore(e => e.Deleted);

        {{- end }}
        {{- end }}

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
