﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
{{- if (entity.Persistence?.IsAudited ?? true)}}
using Nox.Abstractions;
{{- end}}
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Update{{entity.Name}}Command({{primaryKeys}}, {{entity.Name}}UpdateDto EntityDto) : IRequest<{{entity.Name}}KeyDto?>;

public class Update{{entity.Name}}CommandHandler: CommandBase, IRequestHandler<Update{{entity.Name}}Command, {{entity.Name}}KeyDto?>
{
	{{- if (entity.Persistence?.IsAudited ?? true)}}
	private readonly IUserProvider _userProvider;
	private readonly ISystemProvider _systemProvider;
	{{- end}}

	public {{codeGeneratorState.Solution.Name}}DbContext DbContext { get; }    
	public IEntityMapper<{{entity.Name}}> EntityMapper { get; }

	public  Update{{entity.Name}}CommandHandler(
		{{codeGeneratorState.Solution.Name}}DbContext dbContext,        
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<{{entity.Name}}> entityMapper
		{{- if (entity.Persistence?.IsAudited ?? true) -}},
		IUserProvider userProvider,
		ISystemProvider systemProvider
		{{- end -}}): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;        
		EntityMapper = entityMapper;
		{{- if (entity.Persistence?.IsAudited ?? true)}}
		_userProvider = userProvider;
		_systemProvider = systemProvider;
		{{- end }}
	}
	
	public async Task<{{entity.Name}}KeyDto?> Handle(Update{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
	{{- for key in entity.Keys }}
		var key{{key.Name}} = CreateNoxTypeForKey<{{entity.Name}},{{SingleTypeForKey key}}>("{{key.Name}}", request.key{{key.Name}});
	{{- end }}
	
		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysFindQuery}});
		if (entity == null)
		{
			return null;
		}
		EntityMapper.MapToEntity(entity, GetEntityDefinition<{{entity.Name}}>(), request.EntityDto);

    	{{- if (entity.Persistence?.IsAudited ?? true) }}        
		var updatedBy = _userProvider.GetUser();
		var updatedVia = _systemProvider.GetSystem();
		entity.Updated(updatedBy, updatedVia);
		{{- end}}
		
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if(result < 1)
			return null;

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
}