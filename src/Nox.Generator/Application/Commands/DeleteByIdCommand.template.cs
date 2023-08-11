// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Delete{{entity.Name }}ByIdCommand({{primaryKeys}}) : IRequest<bool>;

public class Delete{{entity.Name}}ByIdCommandHandler: CommandBase, IRequestHandler<Delete{{entity.Name }}ByIdCommand, bool>
{
    public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }

    public  Delete{{entity.Name}}ByIdCommandHandler(
        {{codeGeneratorState.Solution.Name}}DbContext dbContext,
        NoxSolution noxSolution, 
        IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
    {
        DbContext = dbContext;
    }    

    public async Task<bool> Handle(Delete{{entity.Name}}ByIdCommand request, CancellationToken cancellationToken)
    {
    {{- for key in entity.Keys }}
        var key{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}},{{key.Type}}>("{{key.Name}}", request.key{{key.Name}});
    {{- end }}

        var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysQuery}});
        if (entity == null{{if (entity.Persistence?.IsVersioned ?? true)}} || entity.Deleted == true{{end}})
        {
            return false;
        }

        {{ if (entity.Persistence?.IsVersioned ?? true) -}}
        entity.Delete();
        {{- else -}}
        DbContext.{{entity.PluralName}}.Remove(entity);
        {{- end}}
        await DbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}