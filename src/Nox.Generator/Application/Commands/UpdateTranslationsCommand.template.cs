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
public record Update{{entity.Name}}TranslationsCommand({{entity.Name}}LocalizedUpdateDto {{entity.Name}}LocalizedUpdateDto, {{keys}}System.String {{codeGeneratorState.LocalizationCultureField}}, System.Guid? Etag) : IRequest<{{entity.Name}}LocalizedKeyDto>;

internal partial class Update{{entity.Name}}TranslationsCommandHandler : Update{{entity.Name}}TranslationsCommandHandlerBase
{
	public Update{{entity.Name}}TranslationsCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}LocalizedCreateDto, {{entity.Name}}LocalizedUpdateDto> entityLocalizedFactory)
		: base(dbContext, noxSolution, entityLocalizedFactory)
	{
	}
}


internal abstract class Update{{entity.Name}}TranslationsCommandHandlerBase : CommandBase<Update{{entity.Name}}TranslationsCommand, {{entity.Name}}LocalizedEntity>, IRequestHandler <Update{{entity.Name}}TranslationsCommand, {{entity.Name}}LocalizedKeyDto?>
{
	protected readonly AppDbContext DbContext;
	protected readonly IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}LocalizedCreateDto, {{entity.Name}}LocalizedUpdateDto> EntityLocalizedFactory;
	

	public Update{{entity.Name}}TranslationsCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}LocalizedCreateDto, {{entity.Name}}LocalizedUpdateDto> entityLocalizedFactory)
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityLocalizedFactory = entityLocalizedFactory;
	}

	public virtual async Task<{{entity.Name}}LocalizedKeyDto?> Handle(Update{{entity.Name}}TranslationsCommand command, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(command);
		
		{{- for key in entity.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(command.{{key.Name}});
		{{- end }}
		
		var culture = Nox.Types.CultureCode.From(command.{{codeGeneratorState.LocalizationCultureField}});
		
		var entityLocalizedToUpdate = await DbContext.{{entity.PluralName}}Localized.FindAsync({{primaryKeysFindQuery}}, culture);
		if (entityLocalizedToUpdate == null)
		{
			return null;
		}
		
		EntityLocalizedFactory.UpdateLocalizedEntity(entityLocalizedToUpdate, command.{{entity.Name}}LocalizedUpdateDto);
		
		entityLocalizedToUpdate.Etag = command.Etag.HasValue ? command.Etag.Value : System.Guid.Empty;
		await OnCompletedAsync(command, entityLocalizedToUpdate);
		
		DbContext.Entry(entityLocalizedToUpdate).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}
		
		
		await DbContext.SaveChangesAsync();
		
		
		return new {{entity.Name}}LocalizedKeyDto({{primaryKeysQuery}}, entityLocalizedToUpdate.{{codeGeneratorState.LocalizationCultureField}}.Value);
	}
}