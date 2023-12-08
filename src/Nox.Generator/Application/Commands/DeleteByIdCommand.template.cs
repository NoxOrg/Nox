{{- func keyName
	ret ("key" + $0)
end -}}
{{- func keysQuery(keyNames)	
	ret (keyNames | array.each @keyName | array.join ", ")
end -}}
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.DtoNameSpace}};
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public partial record Delete{{entity.Name }}ByIdCommand(IEnumerable<{{entity.Name}}KeyDto> KeyDtos{{ if !entity.IsOwnedEntity }}, System.Guid? Etag{{end}}) : IRequest<bool>;

internal partial class Delete{{entity.Name}}ByIdCommandHandler : Delete{{entity.Name}}ByIdCommandHandlerBase
{
	public Delete{{entity.Name}}ByIdCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(dbContext, noxSolution)
	{
	}
}
internal abstract class Delete{{entity.Name}}ByIdCommandHandlerBase : CommandCollectionBase<Delete{{entity.Name}}ByIdCommand, {{entity.Name}}Entity>, IRequestHandler<Delete{{entity.Name}}ByIdCommand, bool>
{
	public AppDbContext DbContext { get; }

	public Delete{{entity.Name}}ByIdCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(Delete{{entity.Name}}ByIdCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = request.KeyDtos.ToArray();
		var entities = new List<{{entity.Name}}Entity>(keys.Length);
		foreach(var keyDto in keys)
		{
			{{- for key in entity.Keys }}
			{{- keyType = SingleTypeForKey key }}
			var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(keyDto.key{{key.Name}});
			{{- end }}		

			var entity = await DbContext.{{entity.PluralName}}.FindAsync({{entity.Keys | array.map "Name" | keysQuery}});
			if (entity == null{{if (entity.Persistence?.IsAudited ?? true)}} || entity.IsDeleted == true{{end}})
			{
				return false;
			}
			{{- if !entity.IsOwnedEntity }}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			{{- end }}

			entities.Add(entity);			
		}

		DbContext.RemoveRange(entities);
		await OnCompletedAsync(request, entities);
		await DbContext.SaveChangesAsync(cancellationToken);
		return true;
	}
}