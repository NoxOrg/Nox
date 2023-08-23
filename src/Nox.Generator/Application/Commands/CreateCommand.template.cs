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

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;
public record Create{{entity.Name}}Command({{entity.Name}}CreateDto EntityDto) : IRequest<{{entity.Name}}KeyDto>;

public partial class Create{{entity.Name}}CommandHandler: CommandBase<Create{{entity.Name}}Command>, IRequestHandler <Create{{entity.Name}}Command, {{entity.Name}}KeyDto>
{
	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }
	public IEntityFactory<{{entity.Name}}CreateDto,{{entity.Name}}> EntityFactory { get; }

	public Create{{entity.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<{{entity.Name}}CreateDto,{{entity.Name}}> entityFactory): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public async Task<{{entity.Name}}KeyDto> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		OnExecuting(request, cancellationToken);

		var entityToCreate = EntityFactory.CreateEntity(request.EntityDto);

		{{- for key in entity.Keys ~}}
		{{- if key.Type == "Nuid" }}
		entityToCreate.Ensure{{key.Name}}();
		{{- end }}
		{{- end }}
	
		DbContext.{{entity.PluralName}}.Add(entityToCreate);
		await DbContext.SaveChangesAsync();
		return new {{entity.Name}}KeyDto({{primaryKeysQuery}});
	}
}