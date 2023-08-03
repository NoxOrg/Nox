// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using {{codeGeneratorState.ODataNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public record Get{{entity.PluralName}}Query() : IRequest<IQueryable<O{{entity.Name}}>>;

public class Get{{entity.PluralName}}QueryHandler : IRequestHandler<Get{{entity.PluralName}}Query, IQueryable<O{{entity.Name}}>>
{
    public  Get{{entity.PluralName}}QueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<O{{entity.Name}}>> Handle(Get{{entity.PluralName}}Query request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<O{{entity.Name}}>)DataDbContext.{{entity.PluralName}}{{if (entity.Persistence?.IsVersioned ?? true)}}.Where(r => !(r.Deleted == true)){{end}};
        return Task.FromResult(item);
    }
}