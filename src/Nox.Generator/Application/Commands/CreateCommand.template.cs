﻿// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
{{- if (entity.Persistence?.IsAudited ?? true)}}
using Nox.Abstractions;
{{- end}}
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;
public record Create{{entity.Name}}Command({{entity.Name}}CreateDto EntityDto) : IRequest<{{entity.Name}}KeyDto>;

public partial class Create{{entity.Name}}CommandHandler: CommandBase<Create{{entity.Name}}Command,{{entity.Name}}>, IRequestHandler <Create{{entity.Name}}Command, {{entity.Name}}KeyDto>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }
	public IEntityFactory<{{entity.Name}}CreateDto,{{entity.Name}}> EntityFactory { get; }
{{- for r in entity.OwnedRelationships}}	
	public IEntityFactory<{{r.Related.Entity.Name}}Dto,{{r.Related.Entity.Name}}> {{r.Related.Entity.Name}}EntityFactory { get; }
{{- end }}

	public Create{{entity.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
	{{- for r in entity.OwnedRelationships}}	
		IEntityFactory<{{r.Related.Entity.Name}}Dto,{{r.Related.Entity.Name}}> entityFactory{{r.Related.Entity.Name}},
	{{- end }}
		IEntityFactory<{{entity.Name}}CreateDto,{{entity.Name}}> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	{{- for r in entity.OwnedRelationships}}	
		{{r.Related.Entity.Name}}EntityFactory = entityFactory{{r.Related.Entity.Name}};
	{{- end }}
	}

	public async Task<{{entity.Name}}KeyDto> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		{{- for key in entity.Keys ~}}
		{{- if key.Type == "Nuid" }}
		entityToCreate.Ensure{{key.Name}}();
		{{- end }}
		{{- end }}

		{{- for r in entity.OwnedRelationships}}
		{{- if r.WithSingleEntity}} {{ continue; }} {{ end }}
		foreach(var ownedEntity in request.EntityDto.{{r.Related.Entity.PluralName}})
		{
			entityToCreate.{{r.Related.Entity.PluralName}}.Add(
				{{r.Related.Entity.Name}}EntityFactory.CreateEntity(ownedEntity)
				);
		}
		{{- end }}
	
		OnCompleted(entityToCreate);
		DbContext.{{entity.PluralName}}.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new {{entity.Name}}KeyDto({{primaryKeysQuery}});
	}
}