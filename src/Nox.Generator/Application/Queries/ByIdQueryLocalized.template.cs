// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.PersistenceNameSpace}};
using Nox.Presentation.Api;
using Nox.Solution;
using Nox.Types;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public partial record {{className}}(CultureCode cultureCode, {{primaryKeys}}) : IRequest <IQueryable<{{entity.Name}}Dto>>;

internal partial class {{className}}Handler : {{className}}HandlerBase
{
    public {{className}}Handler(DtoDbContext dataDbContext) : base(dataDbContext)
    {

    }
}

internal abstract class {{className}}HandlerBase:  QueryBase<IQueryable<{{entity.Name}}Dto>>, IRequestHandler<{{className}}, IQueryable<{{entity.Name}}Dto>>
{
    protected {{className}}HandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<{{entity.Name}}Dto>> Handle({{className}} request, CancellationToken cancellationToken)
    {
        var cultureCode = request.cultureCode.Value;

        IQueryable<{{entity.Name}}Dto> linqQueryBuilder =
            from item in DataDbContext.{{entity.PluralName}}.Where(r =>
            {{- for key in entity.Keys }}
                r.{{key.Name}}.Equals(request.key{{key.Name}}){{if !for.last}} &&{{end}}
            {{- end -}}
            ).AsNoTracking()
            {{- if entity.IsLocalized }}
            join itemLocalizedFromJoin in DataDbContext.{{GetEntityNameForLocalizedType entity.PluralName}} on cultureCode equals itemLocalizedFromJoin.{{codeGeneratorState.LocalizationCultureField}} into joinedData
            from itemLocalized in joinedData.Where(l => item.{{entity.Keys[0].Name}} == l.{{entity.Keys[0].Name}}).DefaultIfEmpty()
            {{- end }}
            {{- for rel in entity.OwnedRelationships -}}
            {{- if rel.Related.Entity.IsLocalized && rel.WithSingleEntity }}
            join itemLocalized{{rel.Name}}FromJoin in DataDbContext.{{GetEntityNameForLocalizedType rel.Related.Entity.PluralName}} on cultureCode equals itemLocalized{{rel.Name}}FromJoin.{{codeGeneratorState.LocalizationCultureField}} into joinedData{{rel.Name}}
            join itemLocalized{{rel.Name}} in joinedData{{rel.Name}}.Where(l => item.{{GetNavigationPropertyName entity rel}}.{{entity.Keys[0].Name}} == l.{{entity.Keys[0].Name}}).DefaultIfEmpty()
            {{- end }}
            {{- end }}
            select new {{entity.Name}}Dto()
            {
                {{- for key in entity.Keys }}
                {{key.Name}} = item.{{key.Name}},
                {{- end }}
                {{- for attribute in entity.Attributes }}
                {{attribute.Name}} = {{if attribute.IsLocalized}}itemLocalized.{{attribute.Name}} ?? "[" + item.{{attribute.Name}} + "]"{{else}}item.{{attribute.Name}}{{end}},
                {{- end }}
                {{- for rel in entity.Relationships }}
                {{- if rel.WithSingleEntity }}
                {{- end }}
                {{- end }}
                {{- for rel in entity.OwnedRelationships -}}
                {{- if rel.Related.Entity.IsLocalized && rel.WithSingleEntity }}
                {{GetNavigationPropertyName entity rel}} = new {{rel.Related.Entity.Name}}Dto()
                {
                    {{- for key in entity.Keys }}
                    {{key.Name}} = item.{{key.Name}},
                    {{- end }}
                    {{- for attribute in rel.Related.Entity.Attributes }}
                    {{attribute.Name}} = {{if attribute.IsLocalized}}itemLocalized.{{attribute.Name}} ?? "[" + item.{{attribute.Name}} + "]"{{else}}item.{{attribute.Name}}{{end}},
                    {{- end }}
                },
                {{- end }}
                {{- if rel.Related.Entity.IsLocalized && rel.WithMultiEntity }}
                {{GetNavigationPropertyName entity rel}} =
                    (from item{{rel.Name}} in item.{{GetNavigationPropertyName entity rel}}
                    join item{{rel.Name}}Localized in DataDbContext.{{GetEntityNameForLocalizedType rel.Related.Entity.PluralName}} 
                        on new { {{entity.Keys[0].Name}} = item{{rel.Name}}.{{entity.Keys[0].Name}}, {{codeGeneratorState.LocalizationCultureField}} = cultureCode } 
                        equals new { {{entity.Keys[0].Name}} = item{{rel.Name}}Localized.{{entity.Keys[0].Name}}, {{codeGeneratorState.LocalizationCultureField}} = item{{rel.Name}}Localized.{{codeGeneratorState.LocalizationCultureField}} } 
                        into  item{{rel.Name}}LocalizedJoinedData
                    from  item{{rel.Name}}Localized in item{{rel.Name}}LocalizedJoinedData.DefaultIfEmpty()
                    select new {{rel.Related.Entity.Name}}Dto()
                    {
                        {{- for key in rel.Related.Entity.Keys }}
                        {{key.Name}} = item{{rel.Name}}.{{key.Name}},
                        {{- end }}
                        {{- for attribute in rel.Related.Entity.Attributes }}
                        {{attribute.Name}} = {{if attribute.IsLocalized}}item{{rel.Name}}Localized.{{attribute.Name}} ?? "[" + item{{rel.Name}}.{{attribute.Name}} + "]"{{else}}item{{rel.Name}}.{{attribute.Name}}{{end}},
                        {{- end }}
                    }).ToList(),
                {{- end }}
                {{- end }}
                {{- for rel in entity.Relationships }}
                    {{- if rel.WithSingleEntity && rel.IsForeignKeyOnThisSide }}
	                {{- relationshipName = GetNavigationPropertyName entity rel }}
                {{relationshipName}}Id = item.{{relationshipName}}Id,
                    {{- end }}
                {{- end }}
                Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString();

        IQueryable<{{entity.Name}}Dto> getItemsQuery =
            from item in DataDbContext.{{entity.PluralName}}.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));
    }
}