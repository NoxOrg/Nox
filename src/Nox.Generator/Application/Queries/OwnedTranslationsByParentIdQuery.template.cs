// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using {{codeGenConventions.ApplicationNameSpace}}.Dto;

namespace {{codeGenConventions.ApplicationNameSpace}}.Queries;

public record  {{className}}({{primaryKeys}}) : IRequest <IQueryable<{{entity.Name}}LocalizedDto>>;

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

    public virtual Task<IQueryable<{{entity.Name}}LocalizedDto>> Handle({{className}} request, CancellationToken cancellationToken)
    {    
        {{ if isWithMultiEntity -}}
        
        var ownedEntityIds = ReadOnlyRepository.Query<{{parentEntity.Name}}Dto>()
            .Include(e => e.{{entity.Name}}s)
            .Where(r =>
                    r.{{parentEntityKeyName}}.Equals(request.key{{parentEntityKeyName}})
            ).SelectMany(e => e.{{entity.Name}}s.Select(c => c.{{entityKeyName}}));

var query = ReadOnlyRepository.Query<{{entity.Name}}LocalizedDto>()
   .Where(r =>
        ownedEntityIds.Contains(r.{{entityKeyName}})
   );
        
        {{- else -}}
        var query = ReadOnlyRepository.Query<{{entity.Name}}LocalizedDto>()
            .Where(r =>
                r.{{parentEntity.Name}}{{parentEntityKeyName}}.Equals(request.key{{parentEntityKeyName}})
            );
        
        {{- end }}
        
        return Task.FromResult(OnResponse(query));
    }
}