// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;
using Nox.Exceptions;

using {{codeGenConventions.ApplicationNameSpace}}.Dto;

namespace {{codeGenConventions.ApplicationNameSpace}}.Queries;

public record  {{className}}({{parentPrimaryKeyProperty}}{{ if isWithMultiEntity -}},{{primaryKeyProperty}}{{end}}) : IRequest <IQueryable<{{entity.Name}}LocalizedDto>>;

internal partial class {{className}}Handler:{{className}}HandlerBase
{
    public  {{className}}Handler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class {{className}}HandlerBase:  QueryBase<IQueryable<{{entity.Name}}LocalizedDto>>, IRequestHandler<{{className}}, IQueryable<{{entity.Name}}LocalizedDto>>
{
    public  {{className}}HandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual {{ if isWithMultiEntity }}async{{ end }} Task<IQueryable<{{entity.Name}}LocalizedDto>> Handle({{className}} request, CancellationToken cancellationToken)
    {    
        {{ if isWithMultiEntity -}}
        
        var parentEntity = await ReadOnlyRepository.Query<{{parentEntity.Name}}Dto>()
            .Include(e => e.{{entity.Name}}s)
            .Where(r =>
                    r.{{parentEntityKeyName}}.Equals(request.{{parentKeyName}})
                    && r.{{entity.Name}}s.Any(e => e.{{entityKeyName}}.Equals(request.{{keyName}}))
            ).FirstOrDefaultAsync();
if (parentEntity is null)
{
    EntityNotFoundException.ThrowIfNull(parentEntity, "{{parentEntity.Name}}", request.{{parentKeyName}}.ToString());
}

var query = ReadOnlyRepository.Query<{{entity.Name}}LocalizedDto>()
   .Where(r =>
        r.{{entityKeyName}}.Equals(request.{{keyName}}) 
   );
   

return OnResponse(query);
        {{- else -}}
        var query = ReadOnlyRepository.Query<{{entity.Name}}LocalizedDto>()
            .Where(r =>
                r.{{parentEntity.Name}}{{parentEntityKeyName}}.Equals(request.{{parentKeyName}})
            );
        
        return  Task.FromResult(OnResponse(query));
        {{- end }}
        
    }
}