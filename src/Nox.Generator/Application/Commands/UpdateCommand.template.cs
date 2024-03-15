{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = (prefix + name)
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}﻿﻿
// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

using Nox.Application.Commands;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Extensions;


using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using Dto = {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

public partial record Update{{entity.Name}}Command({{primaryKeys}}, {{entity.Name}}UpdateDto EntityDto, Nox.Types.CultureCode {{codeGenConventions.LocalizationCultureField}}{{ if !entity.IsOwnedEntity}}, System.Guid? Etag{{end}}) : IRequest<{{entity.Name}}KeyDto>;

internal partial class Update{{entity.Name}}CommandHandler : Update{{entity.Name}}CommandHandlerBase
{
	public Update{{entity.Name}}CommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}

internal abstract class Update{{entity.Name}}CommandHandlerBase : CommandBase<Update{{entity.Name}}Command, {{entity.Name}}Entity>, IRequestHandler<Update{{entity.Name}}Command, {{entity.Name}}KeyDto>
{
	protected IRepository Repository { get; }
	protected IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> EntityFactory { get; }
	protected Update{{entity.Name}}CommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle(Update{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var entity = Repository.Query<{{codeGenConventions.DomainNameSpace}}.{{entity.Name}}>()
			{{- for key in entity.Keys}}
            .Where(x => x.{{key.Name}} == Dto.{{entity.Name}}Metadata.Create{{key.Name}}(request.key{{key.Name}}))
            {{- end }}            
			{{- for relationship in entity.OwnedRelationships }}
            {{- navigationName = GetNavigationPropertyName entity relationship }}
			.Include(e => e.{{navigationName}}){{- if relationship.Related.Entity.IsLocalized -}}.ThenInclude(e => e!.Localized{{relationship.EntityPlural}}){{- end}}
			{{- end }}
			.SingleOrDefault();
		
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  "{{keysToString entity.Keys}}");
		}

		await EntityFactory.UpdateEntityAsync(entity, request.EntityDto, request.CultureCode);

		{{- if !entity.IsOwnedEntity }}
		entity.Etag = request.Etag ?? System.Guid.Empty;
		{{- end }}
		
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();

		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
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