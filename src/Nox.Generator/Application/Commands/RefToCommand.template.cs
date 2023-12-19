{{-relatedEntity = relationship.Related.Entity }}
{{-relationshipName = GetNavigationPropertyName entity relationship }}

{{- func keysToString(keys, prefix = "key")
	keyNameWithPrefix(name) = ("{" + prefix + name + ".ToString()}")
	ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
end -}}

// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
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

public abstract record Ref{{entity.Name}}To{{relationshipName}}Command({{entity.Name}}KeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRef{{entity.Name}}To{{relationshipName}}Command({{entity.Name}}KeyDto EntityKeyDto, {{relatedEntity.Name}}KeyDto RelatedEntityKeyDto)
	: Ref{{entity.Name}}To{{relationshipName}}Command(EntityKeyDto);

internal partial class CreateRef{{entity.Name}}To{{relationshipName}}CommandHandler
	: Ref{{entity.Name}}To{{relationshipName}}CommandHandlerBase<CreateRef{{entity.Name}}To{{relationshipName}}Command>
{
	public CreateRef{{entity.Name}}To{{relationshipName}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRef{{entity.Name}}To{{relationshipName}}Command request)
    {
		var entity = await Get{{entity.Name}}(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys 'request.EntityKeyDto.key'}}");
		}

		var relatedEntity = await Get{{relatedEntity.Name}}(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("{{relatedEntity.Name}}",  $"{{keysToString relatedEntity.Keys 'request.RelatedEntityKeyDto.key'}}");
		}

		entity.CreateRefTo{{relationshipName}}(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

{{- if relationship.WithMultiEntity }}

#region UpdateRefTo

public partial record UpdateRef{{entity.Name}}To{{relationshipName}}Command({{entity.Name}}KeyDto EntityKeyDto, List<{{relatedEntity.Name}}KeyDto> RelatedEntitiesKeysDtos)
	: Ref{{entity.Name}}To{{relationshipName}}Command(EntityKeyDto);

internal partial class UpdateRef{{entity.Name}}To{{relationshipName}}CommandHandler
	: Ref{{entity.Name}}To{{relationshipName}}CommandHandlerBase<UpdateRef{{entity.Name}}To{{relationshipName}}Command>
{
	public UpdateRef{{entity.Name}}To{{relationshipName}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRef{{entity.Name}}To{{relationshipName}}Command request)
    {
		var entity = await Get{{entity.Name}}(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys 'request.EntityKeyDto.key'}}");
		}

		var relatedEntities = new List<{{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await Get{{relatedEntity.Name}}(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("{{relatedEntity.Name}}", $"{{keysToString relatedEntity.Keys 'keyDto.key'}}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.{{relationshipName}}).LoadAsync();
		entity.UpdateRefTo{{relationshipName}}(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo
{{- end }}

#region DeleteRefTo

public record DeleteRef{{entity.Name}}To{{relationshipName}}Command({{entity.Name}}KeyDto EntityKeyDto, {{relatedEntity.Name}}KeyDto RelatedEntityKeyDto)
	: Ref{{entity.Name}}To{{relationshipName}}Command(EntityKeyDto);

internal partial class DeleteRef{{entity.Name}}To{{relationshipName}}CommandHandler
	: Ref{{entity.Name}}To{{relationshipName}}CommandHandlerBase<DeleteRef{{entity.Name}}To{{relationshipName}}Command>
{
	public DeleteRef{{entity.Name}}To{{relationshipName}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRef{{entity.Name}}To{{relationshipName}}Command request)
    {
        var entity = await Get{{entity.Name}}(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys 'request.EntityKeyDto.key'}}");
		}

		var relatedEntity = await Get{{relatedEntity.Name}}(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("{{relatedEntity.Name}}", $"{{keysToString relatedEntity.Keys 'request.RelatedEntityKeyDto.key'}}");
		}

		entity.DeleteRefTo{{relationshipName}}(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRef{{entity.Name}}To{{relationshipName}}Command({{entity.Name}}KeyDto EntityKeyDto)
	: Ref{{entity.Name}}To{{relationshipName}}Command(EntityKeyDto);

internal partial class DeleteAllRef{{entity.Name}}To{{relationshipName}}CommandHandler
	: Ref{{entity.Name}}To{{relationshipName}}CommandHandlerBase<DeleteAllRef{{entity.Name}}To{{relationshipName}}Command>
{
	public DeleteAllRef{{entity.Name}}To{{relationshipName}}CommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRef{{entity.Name}}To{{relationshipName}}Command request)
    {
        var entity = await Get{{entity.Name}}(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys 'request.EntityKeyDto.key'}}");
		}

		{{- if relationship.WithMultiEntity }}
		await DbContext.Entry(entity).Collection(x => x.{{relationshipName}}).LoadAsync();
		{{- end }}
		entity.DeleteAllRefTo{{relationshipName}}();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class Ref{{entity.Name}}To{{relationshipName}}CommandHandlerBase<TRequest> : CommandBase<TRequest, {{entity.Name}}Entity>,
	IRequestHandler <TRequest, bool> where TRequest : Ref{{entity.Name}}To{{relationshipName}}Command
{
	public AppDbContext DbContext { get; }

	public Ref{{entity.Name}}To{{relationshipName}}CommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		return await ExecuteAsync(request);
	}

	protected abstract Task<bool> ExecuteAsync(TRequest request);

	protected async Task<{{entity.Name}}Entity?> Get{{entity.Name}}({{entity.Name}}KeyDto entityKeyDto)
	{
		{{- for key in entity.Keys }}
		var key{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}Metadata.Create{{key.Name}}(entityKeyDto.key{{key.Name}});
		{{- end }}
		return await DbContext.{{entity.PluralName}}.FindAsync({{entityKeysFindQuery}});
	}

	protected async Task<{{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}?> Get{{relatedEntity.Name}}({{relatedEntity.Name}}KeyDto relatedEntityKeyDto)
	{
		{{- for key in relatedEntity.Keys }}
		var relatedKey{{key.Name}} = {{codeGeneratorState.DomainNameSpace}}.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(relatedEntityKeyDto.key{{key.Name}});
		{{- end }}
		return await DbContext.{{relatedEntity.PluralName}}.FindAsync({{relatedEntityKeysFindQuery}});
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, {{entity.Name}}Entity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}