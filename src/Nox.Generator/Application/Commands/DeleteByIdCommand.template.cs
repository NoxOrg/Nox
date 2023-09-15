// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{entity.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Delete{{entity.Name }}ByIdCommand({{primaryKeys}}{{ if !entity.IsOwnedEntity }}, System.Guid? Etag{{end}}) : IRequest<bool>;

public class Delete{{entity.Name}}ByIdCommandHandler: CommandBase<Delete{{entity.Name}}ByIdCommand,{{entity.Name}}>, IRequestHandler<Delete{{entity.Name}}ByIdCommand, bool>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }

	public Delete{{entity.Name}}ByIdCommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(Delete{{entity.Name}}ByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		{{- for key in entity.Keys }}
		{{- keyType = SingleTypeForKey key }}
		var key{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}},Nox.Types.{{keyType}}>("{{key.Name}}", request.key{{key.Name}});
		{{- end }}

		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysQuery}});
		if (entity == null{{if (entity.Persistence?.IsAudited ?? true)}} || entity.IsDeleted.Value == true{{end}})
		{
			return false;
		}
		{{- if !entity.IsOwnedEntity }}

		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		{{- end }}

		OnCompleted(request, entity);
		
		{{- if (entity.Persistence?.IsAudited ?? true) }}
		DbContext.Entry(entity).State = EntityState.Deleted;
		{{-else-}}
		DbContext.{{entity.PluralName}}.Remove(entity);
		{{- end}}
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}