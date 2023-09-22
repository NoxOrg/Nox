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
        services.AddNoxOdata(null);
    }
    public static void AddNoxOdata(this IServiceCollection services, Action<ODataModelBuilder>? configure)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        {{ hasKeyForCompoundKeys -}}

        {{- for entity in solution.Domain.Entities }}
        {{- if (array.size entity.Keys) > 0 #we can not have entityset without keys}}
        builder.EntitySet<{{entity.Name}}Dto>("{{entity.PluralName}}");
        {{- end }}
        {{- if entity.OwnedRelationships != null }}
            {{- for ownedRelationship in entity.OwnedRelationships }}
                {{- if ownedRelationship.Relationship == "ExactlyOne" }}
        builder.EntityType<{{entity.Name}}Dto>().ContainsRequired(e => e.{{ownedRelationship.Name}}).AutoExpand = true;
                {{- else if ownedRelationship.Relationship == "ZeroOrOne" }}
        builder.EntityType<{{entity.Name}}Dto>().ContainsOptional(e => e.{{ownedRelationship.Name}}).AutoExpand = true;
                {{- else }}
        builder.EntityType<{{entity.Name}}Dto>().ContainsMany(e => e.{{ownedRelationship.Name}}).AutoExpand = true;
                {{- end }}
            {{- end }}
        {{- end }}

        {{- if entity.Relationships != null }}
            {{- for relationship in entity.Relationships  }}
                {{- if relationship.Relationship == "ExactlyOne" }}
        builder.EntityType<{{entity.Name}}Dto>().ContainsRequired(e => e.{{relationship.Name}});
                {{- else if relationship.Relationship == "ZeroOrOne" }}
        builder.EntityType<{{entity.Name}}Dto>().ContainsOptional(e => e.{{relationship.Name}});
                {{- else }}
        builder.EntityType<{{entity.Name}}Dto>().ContainsMany(e => e.{{relationship.Name}});
                {{- end }}
            {{- end }}
        {{- end }}

        builder.EntityType<{{entity.Name}}Dto>();
        {{- if !entity.IsOwnedEntity && entity.Persistence?.IsAudited ~}}

        builder.EntityType<{{entity.Name}}Dto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<{{entity.Name}}Dto>().Ignore(e => e.Etag);

        {{- end }}
        {{- end }}

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
                    var routeOptions = options.AddRouteComponents("api", builder.GetEdmModel(),
                        service => service
                            .AddSingleton<IODataSerializerProvider, NoxODataSerializerProvider>())
                        .RouteOptions;
                    routeOptions.EnableKeyInParenthesis = false;
                }
            );
    }
}
