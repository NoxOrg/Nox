{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = ("{" + prefix + name + ".ToString()}")
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;
using FluentValidation;
using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public partial record Update{{entity.Name}}Command({{primaryKeys}}, {{entity.Name}}UpdateDto EntityDto, Nox.Types.CultureCode {{codeGeneratorState.LocalizationCultureField}}{{ if !entity.IsOwnedEntity}}, System.Guid? Etag{{end}}) : IRequest<{{entity.Name}}KeyDto>;

internal partial class Update{{entity.Name}}CommandHandler : Update{{entity.Name}}CommandHandlerBase
{
	public Update{{entity.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}})
		: base(dbContext, noxSolution, {{- for relatedEntity in relatedEntities}}{{fieldFactoryName relatedEntity}}, {{end}}entityFactory{{- if entity.IsLocalized }}, entityLocalizedFactory{{ end -}})
	{
	}
}

internal abstract class Update{{entity.Name}}CommandHandlerBase : CommandBase<Update{{entity.Name}}Command, {{entity.Name}}Entity>, IRequestHandler<Update{{entity.Name}}Command, {{entity.Name}}KeyDto>
{
	public AppDbContext DbContext { get; }
	private readonly IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> _entityFactory;
	{{- if entity.IsLocalized }}
	private readonly IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> _entityLocalizedFactory;
	{{- end }}

	protected Update{{entity.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}})
		: base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
		{{- if entity.IsLocalized }} 
		_entityLocalizedFactory = entityLocalizedFactory;
		{{- end }}
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle(Update{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		{{- for key in entity.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(request.key{{key.Name}});
		{{- end }}

		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysFindQuery}});
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys}}");
		}

		{{- for relationship in entity.OwnedRelationships }}
            {{- navigationName = GetNavigationPropertyName entity relationship }}
			{{- if relationship.WithSingleEntity }}
		await DbContext.Entry(entity).Reference(x => x.{{navigationName}}).LoadAsync(cancellationToken);
			{{- else }}
		await DbContext.Entry(entity).Collection(x => x.{{navigationName}}).LoadAsync(cancellationToken);
			{{- end }}
		{{- end }}

		await _entityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		{{- if !entity.IsOwnedEntity }}
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		{{- end }}
		
		{{- if entity.IsLocalized }}
		await UpdateLocalizationsAsync(entity, request.EntityDto, request.CultureCode);
		{{- end }}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
	{{- if entity.IsLocalized }}

	private async Task UpdateLocalizationsAsync({{entity.Name}}Entity entity, {{entity.Name}}UpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.{{entity.PluralName}}Localized.FirstOrDefaultAsync(x => x.{{entity.Keys[0].Name}} == entity.{{entity.Keys[0].Name}} && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = await _entityLocalizedFactory.CreateLocalizedEntityAsync(entity, cultureCode);
			DbContext.{{entity.PluralName}}Localized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		await _entityLocalizedFactory.UpdateLocalizedEntityAsync(entity, updateDto, cultureCode);
	}
	{{- end}}
}

{{- if (entity.OwnedRelationships | array.size) > 0 }}

public class Update{{entity.Name}}Validator : AbstractValidator<Update{{entity.Name}}Command>
{
    public Update{{entity.Name}}Validator()
    {
		{{- for ownedRelationship in entity.OwnedRelationships }}
			{{- if ownedRelationship.WithMultiEntity }}
				{{- relationshipName = GetNavigationPropertyName entity ownedRelationship }}
				{{- key = ownedRelationship.Related.Entity.Keys | array.first }}
					{{- if key.Type == "Guid" }} {{ continue; }}
					{{- else if IsNoxTypeCreatable key.Type }}
		RuleFor(x => x.EntityDto.{{relationshipName}})
			.ForEach(item => 
			{
				item.Must(owned => owned.{{key.Name}} != null)
					.WithMessage((item, index) => $"{{relationshipName}}[{index}].{{key.Name}} is required.");
			});
					{{- end }}
			{{- end }}
        {{- end }}
    }
}
{{- end }}