{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = ("{" + prefix + name + ".ToString()}")
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}

// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Application.Factories;
using Nox.Solution;
using Nox.Types;
using Nox.Exceptions;

using {{codeGeneratorState.PersistenceNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Commands;

public partial record PartialUpdate{{entity.Name}}Command({{primaryKeys}}, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode{{ if !entity.IsOwnedEntity }}, System.Guid? Etag{{end}}) : IRequest <{{entity.Name}}KeyDto>;

internal partial class PartialUpdate{{entity.Name}}CommandHandler : PartialUpdate{{entity.Name}}CommandHandlerBase
{
	public PartialUpdate{{entity.Name}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}})
		: base(dbContext,noxSolution, entityFactory{{- if entity.IsLocalized }}, entityLocalizedFactory{{ end -}})
	{
	}
}
internal abstract class PartialUpdate{{entity.Name}}CommandHandlerBase : CommandBase<PartialUpdate{{entity.Name}}Command, {{entity.Name}}Entity>, IRequestHandler<PartialUpdate{{entity.Name}}Command, {{entity.Name}}KeyDto>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> EntityFactory { get; }
	{{- if entity.IsLocalized }}
	public IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> EntityLocalizedFactory { get; }
	{{- end }}

	public PartialUpdate{{entity.Name}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<{{entity.Name}}Entity, {{entity.Name}}CreateDto, {{entity.Name}}UpdateDto> entityFactory{{if entity.IsLocalized }},
		IEntityLocalizedFactory<{{entity.Name}}Localized, {{entity.Name}}Entity, {{entity.Name}}UpdateDto> entityLocalizedFactory{{ end -}})
		: base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
		{{- if entity.IsLocalized }} 
		EntityLocalizedFactory = entityLocalizedFactory;
		{{- end }}
	}

	public virtual async Task<{{entity.Name}}KeyDto> Handle(PartialUpdate{{entity.Name}}Command request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		{{- for key in entity.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(request.key{{key.Name}});
		{{- end }}

		var entity = await DbContext.{{entity.PluralName}}.FindAsync({{primaryKeysFindQuery}});
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{entity.Keys | keysToString}}");
		}
		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		{{- if !entity.IsOwnedEntity }}
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		{{- end }}

		{{- if entity.IsLocalized }}
		await PartiallyUpdateLocalizedEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		{{- end }}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new {{entity.Name}}KeyDto({{primaryKeysReturnQuery}});
	}
	{{- if entity.IsLocalized }}

	private async Task PartiallyUpdateLocalizedEntityAsync({{entity.Name}}Entity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
	{
		var entityLocalized = await DbContext.{{entity.PluralName}}Localized.FirstOrDefaultAsync(x => x.{{entity.Keys[0].Name}} == entity.{{entity.Keys[0].Name}} && x.CultureCode == cultureCode);
		if(entityLocalized is null)
		{
			entityLocalized = await EntityLocalizedFactory.CreateLocalizedEntityAsync(entity, cultureCode, copyEntityAttributes: false);
			DbContext.{{entity.PluralName}}Localized.Add(entityLocalized);
		}
		else
		{
			DbContext.Entry(entityLocalized).State = EntityState.Modified;
		}

		await EntityLocalizedFactory.PartialUpdateLocalizedEntityAsync(entity, updatedProperties, cultureCode);
	}
	{{- end }}
}