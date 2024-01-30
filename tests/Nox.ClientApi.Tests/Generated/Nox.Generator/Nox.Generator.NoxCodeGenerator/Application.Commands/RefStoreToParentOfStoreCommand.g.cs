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

using ClientApi.Domain;
using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using StoreEntity = ClientApi.Domain.Store;

namespace ClientApi.Application.Commands;

public abstract record RefStoreToParentOfStoreCommand(StoreKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreToParentOfStoreCommand(StoreKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreToParentOfStoreCommand(EntityKeyDto);

internal partial class CreateRefStoreToParentOfStoreCommandHandler
	: RefStoreToParentOfStoreCommandHandlerBase<CreateRefStoreToParentOfStoreCommand>
{
	public CreateRefStoreToParentOfStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefStoreToParentOfStoreCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetParentOfStore(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToParentOfStore(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefStoreToParentOfStoreCommand(StoreKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreToParentOfStoreCommand(EntityKeyDto);

internal partial class DeleteRefStoreToParentOfStoreCommandHandler
	: RefStoreToParentOfStoreCommandHandlerBase<DeleteRefStoreToParentOfStoreCommand>
{
	public DeleteRefStoreToParentOfStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefStoreToParentOfStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetParentOfStore(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToParentOfStore(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreToParentOfStoreCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToParentOfStoreCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreToParentOfStoreCommandHandler
	: RefStoreToParentOfStoreCommandHandlerBase<DeleteAllRefStoreToParentOfStoreCommand>
{
	public DeleteAllRefStoreToParentOfStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefStoreToParentOfStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToParentOfStore();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToParentOfStoreCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToParentOfStoreCommand
{
	public IRepository Repository { get; }

	public RefStoreToParentOfStoreCommandHandlerBase(
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

	protected async Task<StoreEntity?> GetStore(StoreKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<Store>(keys.ToArray(), cancellationToken);
	}

	protected async Task<ClientApi.Domain.Store?> GetParentOfStore(StoreKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Store>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, StoreEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}