// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using {{codeGenConventions.ApplicationNameSpace}}.Dto;

namespace {{codeGenConventions.ApplicationNameSpace}}.Queries;

public partial record Get{{entity.PluralName}}Query() : IRequest<IQueryable<{{entity.Name}}Dto>>;

internal partial class Get{{entity.PluralName}}QueryHandler: Get{{entity.PluralName}}QueryHandlerBase
{
    public Get{{entity.PluralName}}QueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class Get{{entity.PluralName}}QueryHandlerBase : QueryBase<IQueryable<{{entity.Name}}Dto>>, IRequestHandler<Get{{entity.PluralName}}Query, IQueryable<{{entity.Name}}Dto>>
{
    public  Get{{entity.PluralName}}QueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<{{entity.Name}}Dto>> Handle(Get{{entity.PluralName}}Query request, CancellationToken cancellationToken)
    {
        var query = ReadOnlyRepository.Query<{{entity.Name}}Dto>()
            {{- for ownedRelationship in entity.OwnedRelationships }}
            .Include(e => e.{{GetNavigationPropertyName entity ownedRelationship}})
            {{- end -}};
       return Task.FromResult(OnResponse(query));
    }
}