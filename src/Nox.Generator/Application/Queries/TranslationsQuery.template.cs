// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using {{codeGenConventions.ApplicationNameSpace}}.Dto;

namespace {{codeGenConventions.ApplicationNameSpace}}.Queries;

public partial record  {{className}}({{primaryKeys}}) : IRequest <IQueryable<{{entity.Name}}LocalizedDto>>;

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
        var query = ReadOnlyRepository.Query<{{entity.Name}}LocalizedDto>()
            .Where(r =>
            {{- for key in entityKeys }}
                r.{{key.Name}}.Equals(request.key{{key.Name}}){{if !for.last}} &&{{end}}
            {{- end -}}
            );
        return Task.FromResult(OnResponse(query));
    }
}