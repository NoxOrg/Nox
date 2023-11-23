// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public partial record Get{{entity.PluralName}}Query() : IRequest<IQueryable<{{entity.Name}}Dto>>;

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
        var item = (IQueryable<{{entity.Name}}Dto>)DataDbContext.{{entity.PluralName}}
            .AsNoTracking()
            {{- for ownedRelationship in entity.OwnedRelationships }}
            .Include(e => e.{{GetNavigationPropertyName entity ownedRelationship}})
            {{- end -}};
       return Task.FromResult(OnResponse(item));
    }
}