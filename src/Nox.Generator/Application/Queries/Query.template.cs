// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.PersistenceNameSpace}};
{{- if entity.ShouldBeLocalized }}using Nox.Presentation.Api;
using Nox.Solution;{{- end }}

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public record Get{{entity.PluralName}}Query() : IRequest<IQueryable<{{entity.Name}}Dto>>;

internal partial class Get{{entity.PluralName}}QueryHandler: Get{{entity.PluralName}}QueryHandlerBase
{
    public Get{{entity.PluralName}}QueryHandler(DtoDbContext dataDbContext{{- if entity.ShouldBeLocalized }},
        NoxSolution solution,
        IHttpLanguageProvider languageProvider{{- end }}): base(dataDbContext{{- if entity.ShouldBeLocalized }},
            solution,
            languageProvider{{- end }})
    {
    
    }
}

internal abstract class Get{{entity.PluralName}}QueryHandlerBase : QueryBase<IQueryable<{{entity.Name}}Dto>>, IRequestHandler<Get{{entity.PluralName}}Query, IQueryable<{{entity.Name}}Dto>>
{
        {{- if entity.ShouldBeLocalized }}private readonly NoxSolution _solution;
        private readonly IHttpLanguageProvider _languageProvider;
{{ end }}
    public  Get{{entity.PluralName}}QueryHandlerBase(DtoDbContext dataDbContext{{- if entity.ShouldBeLocalized }},
        NoxSolution solution,
        IHttpLanguageProvider languageProvider{{- end }})
    {
        DataDbContext = dataDbContext;
        {{- if entity.ShouldBeLocalized }}_solution = solution;
        _languageProvider = languageProvider;{{- end }}
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<{{entity.Name}}Dto>> Handle(Get{{entity.PluralName}}Query request, CancellationToken cancellationToken)
    {
{{- if entity.ShouldBeLocalized }}
        var cultureCode = _languageProvider.GetLanguage();

        if (cultureCode == _solution.Application?.Localization?.DefaultCulture)
        {
{{- end }}
        var item = (IQueryable<{{entity.Name}}Dto>)DataDbContext.{{entity.PluralName}}
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
{{- if entity.ShouldBeLocalized }}
        }

        IQueryable<{{entity.Name}}Dto> linqQueryBuilder =
            from item in DataDbContext.{{entity.PluralName}}.AsNoTracking()
            join itemLocalizedFromJoin in DataDbContext.{{GetEntityNameForLocalizedType entity.PluralName}} on cultureCode equals itemLocalizedFromJoin.{{codeGeneratorState.LocalizationCultureField}} into joinedData
            from itemLocalized in joinedData.Where(l => item.{{entity.Keys[0].Name}} == l.{{entity.Keys[0].Name}}).DefaultIfEmpty()
            select new {{entity.Name}}Dto()
            {
        {{- for key in entity.Keys }}
        {{key.Name}} = item.{{key.Name}},
        {{- end }}
        {{- for attribute in entity.Attributes }}
        {{attribute.Name}} = {{if attribute.ShouldBeLocalized}}itemLocalized.{{attribute.Name}} ?? "[" + item.{{attribute.Name}} + "]"{{else}}item.{{attribute.Name}}{{end}},
        {{- end }}
        {{- for rel in entity.Relationships }}
        {{ if rel.ShouldGenerateForeignOnThisSide}}{{rel.Name}}Id = item.{{rel.Name}}Id,{{- end }}
        {{- end }}
        Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString().Replace($"@__{nameof(cultureCode)}_0", $"'{cultureCode}'");

        IQueryable<{{entity.Name}}Dto> getItemsQuery =
            from item in DataDbContext.{{entity.PluralName}}.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));
{{- end }}
    }
}