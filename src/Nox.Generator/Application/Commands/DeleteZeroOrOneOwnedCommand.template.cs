{{- relationshipName = GetNavigationPropertyName parent relationship }}﻿

{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = (prefix + name)	
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using Dto = {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

public partial record {{className}}({{parent.Name}}KeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;


internal partial class {{className}}Handler : {{className}}HandlerBase
{
	public {{className}}Handler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class {{className}}HandlerBase : CommandBase<{{className}}, {{entity.Name}}Entity>, IRequestHandler <{{className}}, bool>
{
	public IRepository Repository { get; }

	public {{className}}HandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle({{className}} request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>({{parent.Keys | array.size}});
		{{- for key in parent.Keys }}
		keys.Add(Dto.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}}));
		{{- end }}
		
		var parentEntity = await Repository.FindAndIncludeAsync<{{codeGenConventions.DomainNameSpace}}.{{parent.Name}}>(keys.ToArray(), p => p.{{relationshipName}}, cancellationToken);
		EntityNotFoundException.ThrowIfNull(parentEntity, "{{parent.Name}}", "{{keysToString parent.Keys 'parentKey' }}");
		
		if(parentEntity.{{relationshipName}} is not null)
		{
			Repository.DeleteOwned(parentEntity.{{relationshipName}}!);
			await OnCompletedAsync(request, parentEntity.{{relationshipName}}!);
		}
		
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}