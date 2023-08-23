// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
{{- if (entity.Persistence?.IsAudited ?? true)}}
using Nox.Abstractions;
{{- end}}
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Delete{{entity.Name }}ByIdCommand({{primaryKeys}}) : IRequest<bool>;

public class Delete{{entity.Name}}ByIdCommandHandler: CommandBase<Delete{{entity.Name }}ByIdCommand>, IRequestHandler<Delete{{entity.Name}}ByIdCommand, bool>
{
	{{- if (entity.Persistence?.IsAudited ?? true)}}
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;
	{{- end}}

	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }

	public Delete{{entity.Name}}ByIdCommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution, 
		IServiceProvider serviceProvider
		{{- if (entity.Persistence?.IsAudited ?? true) -}},
		IUserProvider userProvider,
		ISystemProvider systemProvider
		{{- end -}}): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		{{- if (entity.Persistence?.IsAudited ?? true)}}
		_userProvider = userProvider;
		_systemProvider = systemProvider;
		{{- end }}
	}

	public async Task<bool> Handle(Delete{{entity.Name}}ByIdCommand request, CancellationToken cancellationToken)
	{
		{{- for key in entity.Keys }}
		{{- keyType = SingleTypeForKey key }}
		var key{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}},{{keyType}}>("{{key.Name}}", request.key{{key.Name}});
		{{- end }}

		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysQuery}});
		if (entity == null{{if (entity.Persistence?.IsAudited ?? true)}} || entity.IsDeleted.Value == true{{end}})
		{
			return false;
		}

		{{- if (entity.Persistence?.IsAudited ?? true) }}
		var deletedBy = _userProvider.GetUser();
		var deletedVia = _systemProvider.GetSystem();
		entity.Deleted(deletedBy, deletedVia);
		{{- else -}}
		DbContext.{{entity.PluralName}}.Remove(entity);
		{{- end}}
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}