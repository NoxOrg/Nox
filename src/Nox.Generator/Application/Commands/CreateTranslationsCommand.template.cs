{{- func fieldFactoryName
	ret ($0 + "Factory")
end -}}
{{- func relatedKeyName
	ret ("relatedKey" + $0)
end -}}
{{- func keysQuery(keyNames)	
	ret (keyNames | array.each @relatedKeyName | array.join ", ")
end -}}
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
{{- if (entity.Persistence?.IsAudited ?? true)}}
using Nox.Abstractions;
{{- end}}
using Nox.Types;
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

{{- keys = '' -}}
{{- for key in entity.Keys }}
	{{- if key.Type == "EntityId" -}}
		{{ keys = keys | string.append (SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity) + " " + key.Name + ", " }}
	{{- else }}
		{{ keys = keys | string.append (SinglePrimitiveTypeForKey key) + " " + key.Name + ", "  }}
	{{- end}}
{{ end }}
public record Create{{entity.Name}}TranslationsCommand({{entity.Name}}LocalizedCreateDto {{entity.Name}}LocalizedCreateDto, {{keys}}System.String {{codeGeneratorState.LocalizationCultureField}}) : IRequest<{{entity.Name}}LocalizedKeyDto>;

internal partial class Create{{entity.Name}}TranslationsCommandHandler : Create{{entity.Name}}TranslationsCommandHandlerBase
{
	public Create{{entity.Name}}TranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}LocalizedCreateDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityLocalizedFactory)
	{
	}
}


internal abstract class Create{{entity.Name}}TranslationsCommandHandlerBase : CommandBase<Create{{entity.Name}}TranslationsCommand, {{entity.Name}}LocalizedEntity>, IRequestHandler <Create{{entity.Name}}TranslationsCommand, {{entity.Name}}LocalizedKeyDto>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}LocalizedCreateDto> EntityLocalizedFactory;
	

	public Create{{entity.Name}}TranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}LocalizedCreateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<{{entity.Name}}LocalizedKeyDto> Handle(Create{{entity.Name}}TranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		{{- for key in entity.Keys }}
		command.{{entity.Name}}LocalizedCreateDto.{{key.Name}} = command.{{key.Name}};
		{{- end }}
		command.{{entity.Name}}LocalizedCreateDto.{{codeGeneratorState.LocalizationCultureField}} = command.{{codeGeneratorState.LocalizationCultureField}};
		var entityLocalizedToCreate = EntityLocalizedFactory.CreateLocalizedEntity(command.{{entity.Name}}LocalizedCreateDto);
		await OnCompletedAsync(command, entityLocalizedToCreate);
		DbContext.{{entity.PluralName}}Localized.Add(entityLocalizedToCreate);
		await DbContext.SaveChangesAsync();
		return new {{entity.Name}}LocalizedKeyDto({{primaryKeysQuery}}, entityLocalizedToCreate.{{codeGeneratorState.LocalizationCultureField}}.Value);
	}
}