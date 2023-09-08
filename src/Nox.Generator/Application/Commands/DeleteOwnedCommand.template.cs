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
public record Delete{{entity.Name}}Command({{parent.Name}}KeyDto ParentKeyDto, {{entity.Name}}KeyDto EntityKeyDto) : IRequest <bool>;

public partial class Delete{{entity.Name}}CommandHandler: CommandBase<Delete{{entity.Name}}Command, {{entity.Name}}>, IRequestHandler <Delete{{entity.Name}}Command, bool>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }

	public Delete{{entity.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	}

	public async Task<bool> Handle(Delete{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		{{- for key in parent.Keys }}
		var key{{key.Name}} = CreateNoxTypeForKey<{{parent.Name}},{{SingleTypeForKey key}}>("{{key.Name}}", request.ParentKeyDto.key{{key.Name}});
		{{- end }}
		var parentEntity = await DbContext.{{parent.PluralName}}.FindAsync({{parentKeysFindQuery}});
		if (parentEntity == null)
		{
			return false;
		}

		{{- for key in entity.Keys }}
		var owned{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}},{{SingleTypeForKey key}}>("{{key.Name}}", request.EntityKeyDto.key{{key.Name}});
		{{- end }}
		var entity = parentEntity.{{entity.PluralName}}.SingleOrDefault(x => {{ownedKeysFindQuery}});
		if (entity == null)
		{
			return false;
		}

		parentEntity.{{entity.PluralName}}.Remove(entity);
		
		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Deleted;
		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}