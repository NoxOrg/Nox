{{- relatedEntities = entity.Relationships | array.map "Entity" }}
{{- func fieldFactoryName 
    ret (string.downcase $0 + "Factory")
end -}}
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
	private readonly {{codeGeneratorState.Solution.Name}}DbContext _dbContext;
	private readonly IEntityFactory<{{entity.Name}},{{entity.Name}}CreateDto> _entityFactory;
	{{- for relatedEntity in relatedEntities }}
    private readonly IEntityFactory<{{relatedEntity}},{{relatedEntity}}CreateDto> _{{fieldFactoryName relatedEntity}};
    {{- end }}

	public Create{{entity.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,
		NoxSolution noxSolution,
		{{- for relatedEntity in relatedEntities }}
        IEntityFactory<{{relatedEntity}},{{relatedEntity}}CreateDto> {{fieldFactoryName relatedEntity}},
        {{- end }}
        IEntityFactory<{{entity.Name}},{{entity.Name}}CreateDto> entityFactory,
		IServiceProvider serviceProvider): base(noxSolution, serviceProvider)
	{
		_dbContext = dbContext;
		_entityFactory = entityFactory;
		{{- for relatedEntity in relatedEntities }}        
        _{{fieldFactoryName relatedEntity}} = {{fieldFactoryName relatedEntity}};
        {{- end }}
	}

	public async Task<{{entity.Name}}KeyDto> Handle(Create{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);

		var entityToCreate = _entityFactory.CreateEntity(request.EntityDto);

	{{- for relationship in entity.Relationships }}
		{{- if relationship.WithSingleEntity }}
		if(request.EntityDto.{{relationship.Name}} is not null)
		{ 
			var relatedEntity = _{{fieldFactoryName relationship.Entity}}.CreateEntity(request.EntityDto.{{relationship.Name}});
			entityToCreate.CreateRefTo{{relationship.Entity}}(relatedEntity);
		}		
		{{- else}}
		foreach(var relatedCreateDto in request.EntityDto.{{relationship.Name}})
		{
			var relatedEntity = _{{fieldFactoryName relationship.Entity}}.CreateEntity(relatedCreateDto);
			entityToCreate.CreateRefTo{{relationship.Entity}}(relatedEntity);
		}
		{{-end}}
	{{- end }}
					
		OnCompleted(request, entityToCreate);
		_dbContext.{{entity.PluralName}}.Add(entityToCreate);
		await _dbContext.SaveChangesAsync();
		return new {{entity.Name}}KeyDto({{primaryKeysQuery}});
	}
}