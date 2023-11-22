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

public partial record DeleteAll{{GetNavigationPropertyName parent relationship}}For{{parent.Name}}Command({{parent.Name}}KeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAll{{GetNavigationPropertyName parent relationship}}For{{parent.Name}}CommandHandler : DeleteAll{{GetNavigationPropertyName parent relationship}}For{{parent.Name}}CommandHandlerBase
{
	public DeleteAll{{GetNavigationPropertyName parent relationship}}For{{parent.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAll{{GetNavigationPropertyName parent relationship}}For{{parent.Name}}CommandHandlerBase : CommandBase<DeleteAll{{GetNavigationPropertyName parent relationship}}For{{parent.Name}}Command, {{entity.Name}}Entity>, IRequestHandler <DeleteAll{{GetNavigationPropertyName parent relationship}}For{{parent.Name}}Command, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAll{{GetNavigationPropertyName parent relationship}}For{{parent.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAll{{GetNavigationPropertyName parent relationship}}For{{parent.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		{{- for key in parent.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{parent.Name}}Metadata.Create{{key.Name}}(request.ParentKeyDto.key{{key.Name}});
		{{- end }}
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.{{parent.PluralName}}.FindAsync({{parentKeysFindQuery}});
			if (parentEntity == null)
			{
				return false;
			}

			{{- relationshipName = GetNavigationPropertyName parent relationship }}
			var related = parentEntity.{{relationshipName}};
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				{{- if (entity.Persistence?.IsAudited ?? true) }}
				DbContext.Entry(relatedEntity).State = EntityState.Deleted;
				{{-else-}}
				DbContext.{{relationship.EntityPlural}}.Remove(relatedEntity);
				{{- end}}
				await OnCompletedAsync(request, relatedEntity);
			}
			
			await trx.CommitAsync();
			
			var result = await DbContext.SaveChangesAsync(cancellationToken);
			if (result < 1)
			{
				return false;
			}

			return true;
		}
		catch
		{
			await trx.RollbackAsync();
			return false;
		}
	}
}