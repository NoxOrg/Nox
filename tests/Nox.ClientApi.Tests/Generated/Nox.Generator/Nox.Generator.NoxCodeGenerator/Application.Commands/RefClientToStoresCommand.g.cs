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
using ClientEntity = ClientApi.Domain.Client;

namespace ClientApi.Application.Commands;

public abstract record RefClientToStoresCommand(ClientKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefClientToStoresCommand(ClientKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefClientToStoresCommand(EntityKeyDto);

internal partial class CreateRefClientToStoresCommandHandler
	: RefClientToStoresCommandHandlerBase<CreateRefClientToStoresCommand>
{
	public CreateRefClientToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefClientToStoresCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetClient(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetClientOf(request.RelatedEntityKeyDto, cancellationToken);
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

public partial record UpdateRefClientToStoresCommand(ClientKeyDto EntityKeyDto, List<StoreKeyDto> RelatedEntitiesKeysDtos)
	: RefClientToStoresCommand(EntityKeyDto);

internal partial class UpdateRefClientToStoresCommandHandler
	: RefClientToStoresCommandHandlerBase<UpdateRefClientToStoresCommand>
{
	public UpdateRefClientToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefClientToStoresCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetClient(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Store>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetClientOf(keyDto, cancellationToken);
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

public record DeleteRefClientToStoresCommand(ClientKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefClientToStoresCommand(EntityKeyDto);

internal partial class DeleteRefClientToStoresCommandHandler
	: RefClientToStoresCommandHandlerBase<DeleteRefClientToStoresCommand>
{
	public DeleteRefClientToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefClientToStoresCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetClient(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetClientOf(request.RelatedEntityKeyDto, cancellationToken);
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

public record DeleteAllRefClientToStoresCommand(ClientKeyDto EntityKeyDto)
	: RefClientToStoresCommand(EntityKeyDto);

internal partial class DeleteAllRefClientToStoresCommandHandler
	: RefClientToStoresCommandHandlerBase<DeleteAllRefClientToStoresCommand>
{
	public DeleteAllRefClientToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefClientToStoresCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetClient(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToStores();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefClientToStoresCommandHandlerBase<TRequest> : CommandBase<TRequest, ClientEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefClientToStoresCommand
{
	public IRepository Repository { get; }

	public RefClientToStoresCommandHandlerBase(
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

	protected async Task<ClientEntity?> GetClient(ClientKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ClientMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Client>(keys.ToArray(), x => x.Stores, cancellationToken);
	}

	protected async Task<ClientApi.Domain.Store?> GetClientOf(StoreKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Store>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, ClientEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}