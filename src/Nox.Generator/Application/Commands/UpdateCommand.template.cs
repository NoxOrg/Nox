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

public record Update{{entity.Name}}Command({{primaryKeys}}, {{entity.Name}}UpdateDto EntityDto) : IRequest<{{entity.Name}}KeyDto?>;

public class Update{{entity.Name}}CommandHandler: CommandBase<Update{{entity.Name}}Command, {{entity.Name}}>, IRequestHandler<Update{{entity.Name}}Command, {{entity.Name}}KeyDto?>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }
	public IEntityMapper<{{entity.Name}}> EntityMapper { get; }
{{- for r in entity.OwnedRelationships}}
	public IEntityMapper<{{r.Related.Entity.Name}}> {{r.Related.Entity.Name}}EntityMapper { get; }
{{- end }}

	public Update{{entity.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		{{- for r in entity.OwnedRelationships}}	
			IEntityMapper<{{r.Related.Entity.Name}}> entityMapper{{r.Related.Entity.Name}},
		{{- end }}
		IEntityMapper<{{entity.Name}}> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
	{{- for r in entity.OwnedRelationships}}	
		{{r.Related.Entity.Name}}EntityMapper = entityMapper{{r.Related.Entity.Name}};
	{{- end }}
		EntityMapper = entityMapper;
	}
	
	public async Task<{{entity.Name}}KeyDto?> Handle(Update{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		{{- for key in entity.Keys }}
		var key{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}},{{SingleTypeForKey key}}>("{{key.Name}}", request.key{{key.Name}});
		{{- end }}
	
		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysFindQuery}});
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<{{entity.Name}}>(), request.EntityDto);
		
		{{- for r in entity.OwnedRelationships}}
		{{- if r.WithSingleEntity}} {{ continue; }} {{ end }}
		foreach(var ownedEntity in request.EntityDto.{{r.Related.Entity.PluralName}})
		{
			Update{{r.Related.Entity.Name}}(entity, ownedEntity);
		}
		{{- end }}

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}

{{- for r in entity.OwnedRelationships}}
	{{- if r.WithSingleEntity}} {{ continue; }} {{ end }}
	private void Update{{r.Related.Entity.Name}}({{entity.Name}} parent, {{r.Related.Entity.Name}}Dto child)
	{
		{{- for key in r.Related.Entity.Keys }}
		var owned{{key.Name}} = CreateNoxTypeForKey<{{r.Related.Entity.Name}},{{SingleTypeForKey key}}>("{{key.Name}}", child.{{key.Name}});
		{{- end }}

		var entity = parent.{{r.Related.Entity.PluralName}}.SingleOrDefault(x =>
		{{- for key in r.Related.Entity.Keys }}
			x.{{key.Name}}.Equals(owned{{key.Name}}) &&
		{{- end }}
			true);
		if (entity == null)
		{
			return;
		}

		{{r.Related.Entity.Name}}EntityMapper.MapToEntity(entity, GetEntityDefinition<{{r.Related.Entity.Name}}>(), child);		
	}
{{- end }}
}