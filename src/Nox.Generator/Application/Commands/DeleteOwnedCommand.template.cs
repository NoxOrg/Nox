{{- relationshipName = GetNavigationPropertyName parent relationship }}﻿
﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;
{{- if isSingleRelationship }}
public partial record Delete{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto) : IRequest <bool>;
{{ else }}
public partial record Delete{{relationshipName}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}KeyDto EntityKeyDto) : IRequest <bool>;
{{- end }}

internal partial class Delete{{relationshipName}}For{{parent.Name}}CommandHandler : Delete{{relationshipName}}For{{parent.Name}}CommandHandlerBase
{
	public Delete{{relationshipName}}For{{parent.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class Delete{{relationshipName}}For{{parent.Name}}CommandHandlerBase : CommandBase<Delete{{relationshipName}}For{{parent.Name}}Command, {{entity.Name}}Entity>, IRequestHandler <Delete{{relationshipName}}For{{parent.Name}}Command, bool>
{
	public AppDbContext DbContext { get; }

	public Delete{{relationshipName}}For{{parent.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(Delete{{relationshipName}}For{{parent.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		{{- for key in parent.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}});
		{{- end }}
		var parentEntity = await DbContext.{{parent.PluralName}}.FindAsync({{parentKeysFindQuery}});
		if (parentEntity == null)
		{
			return false;
		}

		{{- if isSingleRelationship }}
		await DbContext.Entry(parentEntity).Reference(e => e.{{relationshipName}}).LoadAsync(cancellationToken);
		var entity = parentEntity.{{relationshipName}};
		if (entity == null)
		{
			return false;
		}

		parentEntity.DeleteRefTo{{relationshipName}}(entity);

		await OnCompletedAsync(request, entity);

		{{ else }}
		await DbContext.Entry(parentEntity).Collection(p => p.{{relationshipName}}).LoadAsync(cancellationToken);
		{{- for key in entity.Keys }}
		var owned{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(request.EntityKeyDto.key{{key.Name}});
		{{- end }}
		var entity = parentEntity.{{relationshipName}}.SingleOrDefault(x => {{ownedKeysFindQuery}});
		if (entity == null)
		{
			return false;
		}
		parentEntity.{{relationshipName}}.Remove(entity);
		await OnCompletedAsync(request, entity);

		{{- end }}
		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}