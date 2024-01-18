// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{codeGenConventions.PersistenceNameSpace}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Queries;

public partial record  {{className}}({{primaryKeys}}) : IRequest <IQueryable<{{entity.Name}}LocalizedDto>>;

internal partial class {{className}}Handler:{{className}}HandlerBase
{
    public  {{className}}Handler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class {{className}}HandlerBase:  QueryBase<IQueryable<{{entity.Name}}LocalizedDto>>, IRequestHandler<{{className}}, IQueryable<{{entity.Name}}LocalizedDto>>
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
            );
        return Task.FromResult(OnResponse(query));
    }
}