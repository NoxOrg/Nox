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
using StoreOwnerEntity = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application.Commands;

public abstract record RefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreOwnerToStoresCommand(EntityKeyDto);

internal partial class CreateRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<CreateRefStoreOwnerToStoresCommand>
{
	public CreateRefStoreOwnerToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefStoreOwnerToStoresCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStoreOwner(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreOwner",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStores(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToStores(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, List<StoreKeyDto> RelatedEntitiesKeysDtos)
	: RefStoreOwnerToStoresCommand(EntityKeyDto);

internal partial class UpdateRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<UpdateRefStoreOwnerToStoresCommand>
{
	public UpdateRefStoreOwnerToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefStoreOwnerToStoresCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStoreOwner(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreOwner",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Store>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetStores(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Store", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToStores(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreOwnerToStoresCommand(EntityKeyDto);

internal partial class DeleteRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<DeleteRefStoreOwnerToStoresCommand>
{
	public DeleteRefStoreOwnerToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefStoreOwnerToStoresCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStoreOwner(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreOwner",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStores(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToStores(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreOwnerToStoresCommand(StoreOwnerKeyDto EntityKeyDto)
	: RefStoreOwnerToStoresCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreOwnerToStoresCommandHandler
	: RefStoreOwnerToStoresCommandHandlerBase<DeleteAllRefStoreOwnerToStoresCommand>
{
	public DeleteAllRefStoreOwnerToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefStoreOwnerToStoresCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStoreOwner(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreOwner",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToStores();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreOwnerToStoresCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreOwnerEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreOwnerToStoresCommand
{
	public IRepository Repository { get; }

	public RefStoreOwnerToStoresCommandHandlerBase(
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

	protected async Task<StoreOwnerEntity?> GetStoreOwner(StoreOwnerKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreOwnerMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<StoreOwner>(keys.ToArray(), x => x.Stores, cancellationToken);
	}

	protected async Task<ClientApi.Domain.Store?> GetStores(StoreKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Store>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, StoreOwnerEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}