// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using {{codeGeneratorState.ODataNameSpace}};

namespace {{codeGeneratorState.DomainNameSpace}};

public record Get{{entity.PluralName}}Query() : IRequest<IQueryable<O{{entity.Name}}>>;

public class Get{{entity.PluralName}}Handler : IRequestHandler<Get{{entity.PluralName}}Query, IQueryable<O{{entity.Name}}>>
{
    public  Get{{entity.PluralName}}Handler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<O{{entity.Name}}>> Handle(Get{{entity.PluralName}}Query request, CancellationToken cancellationToken)
    {
        return Task.FromResult((IQueryable<O{{entity.Name}}>)DataDbContext.{{entity.PluralName}});
    }
}