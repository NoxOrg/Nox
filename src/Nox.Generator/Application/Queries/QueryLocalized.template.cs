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

public class Get{{entity.PluralName}}Query : IRequest<IQueryable<{{entity.Name}}Dto>>
{
    public CultureCode CultureCode { get; set; }

    public Get{{entity.PluralName}}Query(CultureCode cultureCode)
    {
        CultureCode = cultureCode;
    }
};

internal partial class Get{{entity.PluralName}}QueryHandler: Get{{entity.PluralName}}QueryHandlerBase
{
    public Get{{entity.PluralName}}QueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {

    }
}

internal abstract class Get{{entity.PluralName}}QueryHandlerBase : QueryBase<IQueryable<{{entity.Name}}Dto>>, IRequestHandler<Get{{entity.PluralName}}Query, IQueryable<{{entity.Name}}Dto>>
{
    public  Get{{entity.PluralName}}QueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<{{entity.Name}}Dto>> Handle(Get{{entity.PluralName}}Query request, CancellationToken cancellationToken)
    {
        var cultureCode = request.CultureCode.Value;

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
        {{attribute.Name}} = {{if attribute.IsLocalized}}itemLocalized.{{attribute.Name}} ?? "[" + item.{{attribute.Name}} + "]"{{else}}item.{{attribute.Name}}{{end}},
        {{- end }}
        {{- for rel in entity.Relationships }}
        {{ if rel.ShouldGenerateForeignOnThisSide}}{{rel.Name}}Id = item.{{rel.Name}}Id,{{- end }}
        {{- end }}
        Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString().Replace($"WHERE @__{nameof(cultureCode)}_0", $"WHERE '{cultureCode}'");

        IQueryable<{{entity.Name}}Dto> getItemsQuery =
            from item in DataDbContext.{{entity.PluralName}}.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));
    }
}