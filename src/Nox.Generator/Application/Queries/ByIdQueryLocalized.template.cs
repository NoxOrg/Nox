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

public record {{className}}(CultureCode cultureCode, {{primaryKeys}}) : IRequest <IQueryable<{{entity.Name}}Dto>>;

internal partial class {{className}}Handler : {{className}}HandlerBase
{
    public  {{className}}Handler(DtoDbContext dataDbContext) : base(dataDbContext)
    {

    }
}

internal abstract class {{className}}HandlerBase:  QueryBase<IQueryable<{{entity.Name}}Dto>>, IRequestHandler<{{className}}, IQueryable<{{entity.Name}}Dto>>
{
    public  {{className}}HandlerBase(DtoDbContext dataDbContext)
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
	    {{- relationshipName = GetRelationshipPublicName entity rel }}
        {{relationshipName}}Id = item.{{relationshipName}}Id,
        {{- end }}
        Etag = item.Etag
            };

        var sqlStatement = linqQueryBuilder.ToQueryString()
            .Replace("DECLARE", "-- DECLARE")
            .Replace($"= @__{nameof(request)}_{nameof(request.keyId)}_0", $"= '{request.keyId}'")
            .Replace($"WHERE @__{nameof(cultureCode)}_1", $"WHERE '{cultureCode}'");

        IQueryable<{{entity.Name}}Dto> getItemsQuery =
            from item in DataDbContext.{{entity.PluralName}}.FromSqlRaw(sqlStatement)
            select item;

        return Task.FromResult(OnResponse(getItemsQuery));
    }
}