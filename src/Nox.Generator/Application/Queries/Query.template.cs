// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public record Get{{entity.PluralName}}Query() : IRequest<IQueryable<{{entity.Name}}Dto>>;

public partial class Get{{entity.PluralName}}QueryHandler : QueryBase<IQueryable<{{entity.Name}}Dto>>, IRequestHandler<Get{{entity.PluralName}}Query, IQueryable<{{entity.Name}}Dto>>
{
    public  Get{{entity.PluralName}}QueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<{{entity.Name}}Dto>> Handle(Get{{entity.PluralName}}Query request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<{{entity.Name}}Dto>)DataDbContext.{{entity.PluralName}}{{if (entity.Persistence?.IsAudited ?? true)}}
            .Where(r => r.DeletedAtUtc == null){{end}}
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}