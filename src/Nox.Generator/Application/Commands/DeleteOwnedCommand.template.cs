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
{{- if isSingleRelationship }}
public partial record Delete{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, System.Guid? Etag) : IRequest <bool>;
{{ else }}
public partial record Delete{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}KeyDto EntityKeyDto, System.Guid? Etag) : IRequest <bool>;
{{- end }}

internal partial class Delete{{relationshipName}}For{{parent.Name}}CommandHandler : Delete{{relationshipName}}For{{parent.Name}}CommandHandlerBase
{
	public Delete{{relationshipName}}For{{parent.Name}}CommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class Delete{{relationshipName}}For{{parent.Name}}CommandHandlerBase : CommandBase<Delete{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}Entity>, IRequestHandler <Delete{{relationshipName}}For{{parent.Name}}Command, bool>
{
	public IRepository Repository { get; }

	public Delete{{relationshipName}}For{{parent.Name}}CommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(Delete{{relationshipName}}For{{parent.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>({{parent.Keys | array.size}});
		{{- for key in parent.Keys }}
		keys.Add(Dto.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}}));
		{{- end }}
		{{if entity.IsLocalized -}}
		var parentEntity = await Repository.FindAndIncludeAsync<{{codeGenConventions.DomainNameSpace}}.{{parent.Name}}, {{codeGenConventions.DomainNameSpace}}.{{entity.Name}}, {{codeGenConventions.DomainNameSpace}}.{{entity.Name}}Localized>(keys.ToArray(), p => p.{{relationshipName}}, p => p.Localized{{entity.PluralName}}, cancellationToken);
		{{ else -}}
		var parentEntity = await Repository.FindAndIncludeAsync<{{codeGenConventions.DomainNameSpace}}.{{parent.Name}}>(keys.ToArray(), p => p.{{relationshipName}}, cancellationToken);
		{{ end -}}
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("{{parent.Name}}",  "{{parent.Keys | keysToString}}");
		}
		
		{{- if isSingleRelationship }}				
		var entity = parentEntity.{{relationshipName}};
		if (entity == null)
		{
			throw new EntityNotFoundException("{{parent.Name}}.{{relationshipName}}",  String.Empty);
		}

		parentEntity.Delete{{relationshipName}}(entity);
		
		{{ else }}		
		{{- for key in entity.Keys }}
		var owned{{key.Name}} = Dto.{{entity.Name}}Metadata.Create{{key.Name}}(request.EntityKeyDto.key{{key.Name}});
		{{- end }}
		var entity = parentEntity.{{relationshipName}}.SingleOrDefault(x => {{ownedKeysFindQuery}});
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}.{{relationshipName}}",  $"{{keysToString entity.Keys 'owned'}}");
		}
		parentEntity.Delete{{relationshipName}}(entity);		
		{{- end }}
		
		parentEntity.Etag = request.Etag ?? System.Guid.Empty;
		await OnCompletedAsync(request, entity);
		Repository.Update(parentEntity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}