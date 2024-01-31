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
using EntityUniqueConstraintsWithForeignKeyEntity = TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey;

namespace TestWebApp.Application.Commands;

public abstract record RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsRelatedForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityKeyDto);

internal partial class CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand>
{
	public CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetEntityUniqueConstraintsWithForeignKey(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetrelatestoSingleForeignKey(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToEntityUniqueConstraintsRelatedForeignKey(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto, EntityUniqueConstraintsRelatedForeignKeyKeyDto RelatedEntityKeyDto)
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityKeyDto);

internal partial class DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand>
{
	public DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetEntityUniqueConstraintsWithForeignKey(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetrelatestoSingleForeignKey(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("EntityUniqueConstraintsRelatedForeignKey", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToEntityUniqueConstraintsRelatedForeignKey(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityUniqueConstraintsWithForeignKeyKeyDto EntityKeyDto)
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand(EntityKeyDto);

internal partial class DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler
	: RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand>
{
	public DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetEntityUniqueConstraintsWithForeignKey(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("EntityUniqueConstraintsWithForeignKey",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToEntityUniqueConstraintsRelatedForeignKey();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase<TRequest> : CommandBase<TRequest, EntityUniqueConstraintsWithForeignKeyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommand
{
	public IRepository Repository { get; }

	public RefEntityUniqueConstraintsWithForeignKeyToEntityUniqueConstraintsRelatedForeignKeyCommandHandlerBase(
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

	protected async Task<EntityUniqueConstraintsWithForeignKeyEntity?> GetEntityUniqueConstraintsWithForeignKey(EntityUniqueConstraintsWithForeignKeyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<EntityUniqueConstraintsWithForeignKey>(keys.ToArray(), cancellationToken);
	}

	protected async Task<TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey?> GetrelatestoSingleForeignKey(EntityUniqueConstraintsRelatedForeignKeyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<EntityUniqueConstraintsRelatedForeignKey>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, EntityUniqueConstraintsWithForeignKeyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}