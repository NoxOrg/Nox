// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using {{codeGeneratorState.ODataNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Delete{{entity.Name }}ByIdCommand({{entity.KeysFlattenComponentsTypeName[0]}} key) : IRequest<bool>;

public class Delete{{entity.Name}}ByIdCommandHandler: IRequestHandler<Delete{{entity.Name }}ByIdCommand, bool>
{
    public  Delete{{entity.Name}}ByIdCommandHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public async Task<bool> Handle(Delete{{entity.Name}}ByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await DataDbContext.{{entity.PluralName}}.FindAsync(request.key);
        if (entity == null{{if (entity.Persistence?.IsVersioned ?? true)}} || entity.Deleted == true{{end}})
        {
            return false;
        }

        {{ if (entity.Persistence?.IsVersioned ?? true) -}}
        entity.Delete();
        {{- else -}}
        DataDbContext.{{entity.PluralName}}.Remove(entity);
        {{- end}}
        await DataDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}