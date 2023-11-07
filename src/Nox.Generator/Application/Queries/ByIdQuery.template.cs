// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public partial record Get{{entity.Name }}ByIdQuery({{primaryKeys}}) : IRequest <IQueryable<{{entity.Name}}Dto>>;

internal partial class Get{{entity.Name}}ByIdQueryHandler:Get{{entity.Name}}ByIdQueryHandlerBase
{
    public  Get{{entity.Name}}ByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class Get{{entity.Name}}ByIdQueryHandlerBase:  QueryBase<IQueryable<{{entity.Name}}Dto>>, IRequestHandler<Get{{entity.Name}}ByIdQuery, IQueryable<{{entity.Name}}Dto>>
{
    public  Get{{entity.Name}}ByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<{{entity.Name}}Dto>> Handle(Get{{entity.Name}}ByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.{{entity.PluralName}}
            .AsNoTracking()
            .Where(r =>
            {{- for key in entity.Keys }}
                r.{{key.Name}}.Equals(request.key{{key.Name}}){{if !for.last}} &&{{end}}
            {{- end -}}
            );
        return Task.FromResult(OnResponse(query));
    }
}