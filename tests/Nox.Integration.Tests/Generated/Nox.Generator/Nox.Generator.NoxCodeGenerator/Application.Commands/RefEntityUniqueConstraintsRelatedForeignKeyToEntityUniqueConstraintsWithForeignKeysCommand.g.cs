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

using TestWebApp.Domain;
using TestWebApp.Application.Dto;
using Dto = TestWebApp.Application.Dto;
using EntityUniqueConstraintsRelatedForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey;

namespace TestWebApp.Application.Commands;

public abstract record RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsWithForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto);

internal partial class CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetEntityUniqueConstraintsRelatedForeignKey(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await Getrelatesto2(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToEntityUniqueConstraintsWithForeignKeys(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto, List<EntityUniqueConstraintsWithForeignKeyKeyDto> RelatedEntitiesKeysDtos)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto);

internal partial class UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetEntityUniqueConstraintsRelatedForeignKey(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await Getrelatesto2(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("EntityUniqueConstraintsWithForeignKey", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToEntityUniqueConstraintsWithForeignKeys(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsWithForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto);

internal partial class DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetEntityUniqueConstraintsRelatedForeignKey(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await Getrelatesto2(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("EntityUniqueConstraintsWithForeignKey", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToEntityUniqueConstraintsWithForeignKeys(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityUniqueConstraintsRelatedForeignKeyKeyDto EntityKeyDto)
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand(EntityKeyDto);

internal partial class DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler
	: RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand>
{
	public DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetEntityUniqueConstraintsRelatedForeignKey(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToEntityUniqueConstraintsWithForeignKeys();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase<TRequest> : CommandBase<TRequest, EntityUniqueConstraintsRelatedForeignKeyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommand
{
	public IRepository Repository { get; }

	public RefEntityUniqueConstraintsRelatedForeignKeyToEntityUniqueConstraintsWithForeignKeysCommandHandlerBase(
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

	protected async Task<EntityUniqueConstraintsRelatedForeignKeyEntity?> GetEntityUniqueConstraintsRelatedForeignKey(EntityUniqueConstraintsRelatedForeignKeyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<EntityUniqueConstraintsRelatedForeignKey>(keys.ToArray(), x => x.EntityUniqueConstraintsWithForeignKeys, cancellationToken);
	}

	protected async Task<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey?> Getrelatesto2(EntityUniqueConstraintsWithForeignKeyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<EntityUniqueConstraintsWithForeignKey>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, EntityUniqueConstraintsRelatedForeignKeyEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}