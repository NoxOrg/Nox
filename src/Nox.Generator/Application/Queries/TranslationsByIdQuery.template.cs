// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public record  {{className}}({{primaryKeys}}, Nox.Types.CultureCode {{codeGeneratorState.LocalizationCultureField}}) : IRequest <IQueryable<{{entity.Name}}LocalizedDto>>;

internal partial class {{className}}Handler:{{className}}HandlerBase
{
    public  {{className}}Handler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class {{className}}HandlerBase:  QueryBase<IQueryable<{{entity.Name}}LocalizedDto>>, IRequestHandler<Get{{entity.Name}}TranslationsByIdQuery, IQueryable<{{entity.Name}}LocalizedDto>>
{
    public  {{className}}HandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<{{entity.Name}}LocalizedDto>> Handle({{className}} request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.{{entity.PluralName}}Localized
            .AsNoTracking()
            .Where(r =>
            {{- for key in entityKeys }}
                r.{{key.Name}}.Equals(request.key{{key.Name}}){{if !for.last}} &&{{end}}
            {{- end -}}
            {{-}}
                && r.CultureCode == request.{{codeGeneratorState.LocalizationCultureField}}.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}