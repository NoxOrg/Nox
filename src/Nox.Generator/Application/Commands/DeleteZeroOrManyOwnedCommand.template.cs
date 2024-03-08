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
using {{parent.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{parent.Name}};

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

internal partial class {{className}}HandlerBase : CommandBase<{{className}}, {{parent.Name}}Entity>, IRequestHandler <{{className}}, bool>
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
		
		{{- if entity.IsLocalized }}
		var parentEntity = await Repository.FindAndIncludeAsync<{{codeGenConventions.DomainNameSpace}}.{{parent.Name}}, {{codeGenConventions.DomainNameSpace}}.{{entity.Name}}, {{codeGenConventions.DomainNameSpace}}.{{entity.Name}}Localized>(
			keys.ToArray(), 
			p => p.{{relationshipName}}, 
			l => l.Localized{{entity.PluralName}}, 
			cancellationToken);
		{{ else }}
		var parentEntity = await Repository.FindAndIncludeAsync<{{codeGenConventions.DomainNameSpace}}.{{parent.Name}}>(keys.ToArray(), p => p.{{relationshipName}}, cancellationToken);
		{{- end }}
		EntityNotFoundException.ThrowIfNull(parentEntity, "{{parent.Name}}", "{{keysToString parent.Keys 'parentKey' }}");
		
		Repository.DeleteOwned(parentEntity.{{relationshipName}});
		
		parentEntity.DeleteAllRefTo{{relationshipName}}();
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		
		await OnCompletedAsync(request, parentEntity);
		Repository.Update(parentEntity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}