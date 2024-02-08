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
using Nox.Domain;
using Nox.Types;
using Nox.Exceptions;

using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using Dto = {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{entity.Name}}Entity = {{codeGenConventions.DomainNameSpace}}.{{entity.Name}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Commands;

public abstract record Ref{{entity.Name}}To{{relationshipName}}Command({{entity.Name}}KeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRef{{entity.Name}}To{{relationshipName}}Command({{entity.Name}}KeyDto EntityKeyDto, {{relatedEntity.Name}}KeyDto RelatedEntityKeyDto)
	: Ref{{entity.Name}}To{{relationshipName}}Command(EntityKeyDto);

internal partial class CreateRef{{entity.Name}}To{{relationshipName}}CommandHandler
	: Ref{{entity.Name}}To{{relationshipName}}CommandHandlerBase<CreateRef{{entity.Name}}To{{relationshipName}}Command>
{
	public CreateRef{{entity.Name}}To{{relationshipName}}CommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRef{{entity.Name}}To{{relationshipName}}Command request, CancellationToken cancellationToken)
    {
		var entity = await Get{{entity.Name}}(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys 'request.EntityKeyDto.key'}}");
		}

		var relatedEntity = await Get{{relationship.Name}}(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("{{relatedEntity.Name}}",  $"{{keysToString relatedEntity.Keys 'request.RelatedEntityKeyDto.key'}}");
		}

		entity.CreateRefTo{{relationshipName}}(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRef{{entity.Name}}To{{relationshipName}}Command request, CancellationToken cancellationToken)
    {
		var entity = await Get{{entity.Name}}(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys 'request.EntityKeyDto.key'}}");
		}

		var relatedEntities = new List<{{codeGenConventions.DomainNameSpace}}.{{relatedEntity.Name}}>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await Get{{relationship.Name}}(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("{{relatedEntity.Name}}", $"{{keysToString relatedEntity.Keys 'keyDto.key'}}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefTo{{relationshipName}}(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRef{{entity.Name}}To{{relationshipName}}Command request, CancellationToken cancellationToken)
    {
        var entity = await Get{{entity.Name}}(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys 'request.EntityKeyDto.key'}}");
		}

		var relatedEntity = await Get{{relationship.Name}}(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("{{relatedEntity.Name}}", $"{{keysToString relatedEntity.Keys 'request.RelatedEntityKeyDto.key'}}");
		}

		entity.DeleteRefTo{{relationshipName}}(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRef{{entity.Name}}To{{relationshipName}}Command request, CancellationToken cancellationToken)
    {
        var entity = await Get{{entity.Name}}(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("{{entity.Name}}",  $"{{keysToString entity.Keys 'request.EntityKeyDto.key'}}");
		}
		entity.DeleteAllRefTo{{relationshipName}}();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class Ref{{entity.Name}}To{{relationshipName}}CommandHandlerBase<TRequest> : CommandBase<TRequest, {{entity.Name}}Entity>,
	IRequestHandler <TRequest, bool> where TRequest : Ref{{entity.Name}}To{{relationshipName}}Command
{
	public IRepository Repository { get; }

	public Ref{{entity.Name}}To{{relationshipName}}CommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution)
		: base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		await ExecuteAsync(request, cancellationToken);
		return true;
	}

	protected abstract Task ExecuteAsync(TRequest request, CancellationToken cancellationToken);

	protected async Task<{{entity.Name}}Entity?> Get{{entity.Name}}({{entity.Name}}KeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>({{entity.Keys | array.size}});
		{{- for key in entity.Keys }}
		keys.Add(Dto.{{entity.Name}}Metadata.Create{{key.Name}}(entityKeyDto.key{{key.Name}}));
		{{- end }}
		{{- if relationship.WithSingleEntity }}		
		return await Repository.FindAsync<{{codeGenConventions.DomainNameSpace}}.{{entity.Name}}>(keys.ToArray(), cancellationToken);
		{{- else }}
		{{- navigationName = GetNavigationPropertyName entity relationship }}
		return await Repository.FindAndIncludeAsync<{{codeGenConventions.DomainNameSpace}}.{{entity.Name}}>(keys.ToArray(), x => x.{{navigationName}}, cancellationToken);
		{{- end }}
	}

	protected async Task<{{codeGenConventions.DomainNameSpace}}.{{relatedEntity.Name}}?> Get{{relationship.Name}}({{relatedEntity.Name}}KeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>({{relatedEntity.Keys | array.size}});
		{{- for key in relatedEntity.Keys }}
		keys.Add(Dto.{{relatedEntity.Name}}Metadata.Create{{key.Name}}(relatedEntityKeyDto.key{{key.Name}}));
		{{- end }}
		return await Repository.FindAsync<{{codeGenConventions.DomainNameSpace}}.{{relatedEntity.Name}}>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, {{entity.Name}}Entity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}