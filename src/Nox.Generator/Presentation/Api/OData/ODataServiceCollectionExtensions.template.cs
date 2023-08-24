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
        {{- if !entity.IsOwnedEntity }}

        builder.EntitySet<{{entity.Name}}Dto>("{{entity.PluralName}}");
        {{- end }}
        {{- if entity.OwnedRelationships != null }}
            {{- for ownedRelationship in entity.OwnedRelationships }}
        builder.EntityType<{{entity.Name}}Dto>().ContainsMany(e => e.{{ownedRelationship.Related.Entity.PluralName}}).AutoExpand = true;
            {{- end }}
        {{- end }}

        builder.EntityType<{{entity.Name}}Dto>();
        builder.EntityType<{{entity.Name}}KeyDto>();
        {{- if entity.Persistence?.IsAudited ~}}

        builder.EntityType<{{entity.Name}}Dto>().Ignore(e => e.DeletedAtUtc);

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
