// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.ODataNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public record Get{{entity.Name }}ByIdQuery({{primaryKeys}}) : IRequest<{{entity.Name}}Dto?>;

public class Get{{entity.Name}}ByIdQueryHandler: IRequestHandler<Get{{entity.Name}}ByIdQuery, {{entity.Name}}Dto?>
{
    public  Get{{entity.Name}}ByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<{{entity.Name}}Dto?> Handle(Get{{entity.Name}}ByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.{{entity.PluralName}}
            .AsNoTracking()
            .SingleOrDefault(r =>                  
            {{- for key in entity.Keys }}
                r.{{key.Name}}.Equals(request.key{{key.Name}}) && 
            {{- end -}}
            {{- if (entity.Persistence?.IsAudited ?? true)}}
                !(r.IsDeleted == true)
            {{- else}}
                true
            {{end -}}
            );
        return Task.FromResult(item);
    }
}