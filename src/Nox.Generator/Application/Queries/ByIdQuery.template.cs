// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{codeGenConventions.PersistenceNameSpace}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Queries;

public partial record Get{{entity.Name }}ByIdQuery({{primaryKeys}}) : IRequest <IQueryable<{{entity.Name}}Dto>>;

internal partial class Get{{entity.Name}}ByIdQueryHandler:Get{{entity.Name}}ByIdQueryHandlerBase
{
    public Get{{entity.Name}}ByIdQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class Get{{entity.Name}}ByIdQueryHandlerBase:  QueryBase<IQueryable<{{entity.Name}}Dto>>, IRequestHandler<Get{{entity.Name}}ByIdQuery, IQueryable<{{entity.Name}}Dto>>
{
    public  Get{{entity.Name}}ByIdQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<{{entity.Name}}Dto>> Handle(Get{{entity.Name}}ByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = ReadOnlyRepository.Query<{{entity.Name}}Dto>()
            {{- for ownedRelationship in entity.OwnedRelationships }}
            .Include(e => e.{{GetNavigationPropertyName entity ownedRelationship}})
            {{- end }}
            .Where(r =>
            {{- for key in entity.Keys }}
                r.{{key.Name}}.Equals(request.key{{key.Name}}){{if !for.last}} &&{{end}}
            {{- end -}}
            );
        return Task.FromResult(OnResponse(query));
    }
}