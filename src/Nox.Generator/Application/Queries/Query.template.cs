// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.ODataNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public record Get{{entity.PluralName}}Query() : IRequest<IQueryable<{{entity.Name}}Dto>>;

public class Get{{entity.PluralName}}QueryHandler : IRequestHandler<Get{{entity.PluralName}}Query, IQueryable<{{entity.Name}}Dto>>
{
    public  Get{{entity.PluralName}}QueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<{{entity.Name}}Dto>> Handle(Get{{entity.PluralName}}Query request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<{{entity.Name}}Dto>)DataDbContext.{{entity.PluralName}}{{if (entity.Persistence?.IsAudited ?? true)}}
            .Where(r => r.DeletedAtUtc == null){{end}}
            .AsNoTracking();
        return Task.FromResult(item);
    }
}