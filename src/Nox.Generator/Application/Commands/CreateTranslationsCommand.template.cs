{{- func fieldFactoryName
	ret ($0 + "Factory")
end -}}
{{- func relatedKeyName
	ret ("relatedKey" + $0)
end -}}
{{- func keysQuery(keyNames)	
	ret (keyNames | array.each @relatedKeyName | array.join ", ")
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
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Application.Factories;
using Nox.Solution;

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};
using {{entity.Name}}LocalizedEntity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Localized;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public record Create{{entity.Name}}TranslationsCommand({{entity.Name}}LocalizedDto {{entity.Name}}LocalizedDto) : IRequest<{{entity.Name}}LocalizedKeyDto>;

internal partial class Create{{entity.Name}}TranslationsCommandHandler : Create{{entity.Name}}TranslationsCommandHandlerBase
{
	public Create{{entity.Name}}TranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}LocalizedDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityLocalizedFactory)
	{
	}
}


internal abstract class Create{{entity.Name}}TranslationsCommandHandlerBase : CommandBase<Create{{entity.Name}}TranslationsCommand, {{entity.Name}}LocalizedEntity>, IRequestHandler <Create{{entity.Name}}TranslationsCommand, {{entity.Name}}LocalizedKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}LocalizedDto> EntityLocalizedFactory;
	

	public Create{{entity.Name}}TranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}LocalizedDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<{{entity.Name}}LocalizedKeyDto> Handle(Create{{entity.Name}}TranslationsCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var entityLocalizedToCreate = EntityLocalizedFactory.CreateLocalizedEntityFromDto(request.{{entity.Name}}LocalizedDto);
		await OnCompletedAsync(request, entityLocalizedToCreate);
		DbContext.{{entity.PluralName}}Localized.Add(entityLocalizedToCreate);
		await DbContext.SaveChangesAsync();
		return new {{entity.Name}}LocalizedKeyDto({{primaryKeysQuery}}, entityLocalizedToCreate.{{codeGeneratorState.LocalizationCultureField}}.Value);
	}
}