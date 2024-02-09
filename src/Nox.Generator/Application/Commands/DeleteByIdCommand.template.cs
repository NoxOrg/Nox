{{- func keyName
	ret ("key" + $0)
end -}}
{{- func keysQuery(keyNames)	
	ret (keyNames | array.each @keyName | array.join ", ")
end -}}

{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = ("{" + prefix + name + ".ToString()}")	
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Domain;
using Nox.Exceptions;
using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.DtoNameSpace}};
using Dto = {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

public partial record Delete{{entity.Name }}ByIdCommand(IEnumerable<{{entity.Name}}KeyDto> KeyDtos{{ if !entity.IsOwnedEntity }}, System.Guid? Etag{{end}}) : IRequest<bool>;

internal partial class Delete{{entity.Name}}ByIdCommandHandler : Delete{{entity.Name}}ByIdCommandHandlerBase
{
	public Delete{{entity.Name}}ByIdCommandHandler(
        IRepository repository,
		NoxSolution noxSolution) : base(repository, noxSolution)
	{
	}
}
internal abstract class Delete{{entity.Name}}ByIdCommandHandlerBase : CommandCollectionBase<Delete{{entity.Name}}ByIdCommand, {{entity.Name}}Entity>, IRequestHandler<Delete{{entity.Name}}ByIdCommand, bool>
{
	public IRepository Repository { get; }

	public Delete{{entity.Name}}ByIdCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
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
			var key{{key.Name}} = Dto.{{entity.Name}}Metadata.Create{{key.Name}}(keyDto.key{{key.Name}});
			{{- end }}		

			var entity = await Repository.FindAsync<{{entity.Name}}Entity>({{entity.Keys | array.map "Name" | keysQuery}});
			if (entity == null{{if (entity.Persistence?.IsAudited ?? true)}} || entity.IsDeleted == true{{end}})
			{
				throw new EntityNotFoundException("{{entity.Name}}",  $"{{entity.Keys | keysToString}}");
			}
			{{- if !entity.IsOwnedEntity }}
			entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
			{{- end }}

			entities.Add(entity);			
		}

		Repository.DeleteRange<{{entity.Name}}Entity>(entities);
		await OnCompletedAsync(request, entities);
		await Repository.SaveChangesAsync(cancellationToken);
		return true;
	}
}