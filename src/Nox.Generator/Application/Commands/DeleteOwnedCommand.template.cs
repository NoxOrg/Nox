﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;
{{- if isSingleRelationship }}
public record Delete{{entity.Name}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto) : IRequest <bool>;
{{ else }}
public record Delete{{entity.Name}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}KeyDto EntityKeyDto) : IRequest <bool>;
{{- end }}

public partial class Delete{{entity.Name}}For{{parent.Name}}CommandHandler: CommandBase<Delete{{entity.Name}}For{{parent.Name}}Command, {{entity.Name}}>, IRequestHandler <Delete{{entity.Name}}For{{parent.Name}}Command, bool>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }

	public Delete{{entity.Name}}For{{parent.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(Delete{{entity.Name}}For{{parent.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		{{- for key in parent.Keys }}
		var key{{key.Name}} = CreateNoxTypeForKey<{{parent.Name}},Nox.Types.{{SingleTypeForKey key}}>("{{key.Name}}", request.ParentKeyDto.key{{key.Name}});
		{{- end }}
		var parentEntity = await DbContext.{{parent.PluralName}}.FindAsync({{parentKeysFindQuery}});
		if (parentEntity == null)
		{
			return false;
		}		

		{{- if isSingleRelationship }}
		var entity = parentEntity.{{relationship.Name}};
		if (entity == null)
		{
			return false;
		}

		parentEntity.{{relationship.Name}} = null;

		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		{{ else }}
		{{- for key in entity.Keys }}
		var owned{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}},Nox.Types.{{SingleTypeForKey key}}>("{{key.Name}}", request.EntityKeyDto.key{{key.Name}});
		{{- end }}
		var entity = parentEntity.{{relationship.Name}}.SingleOrDefault(x => {{ownedKeysFindQuery}});
		if (entity == null)
		{
			return false;
		}
		parentEntity.{{relationship.Name}}.Remove(entity);
		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Deleted;
		{{- end }}
	
		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}