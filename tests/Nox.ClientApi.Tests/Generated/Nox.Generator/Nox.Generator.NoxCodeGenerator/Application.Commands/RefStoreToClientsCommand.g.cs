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

public abstract record RefStoreToClientsCommand(StoreKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreToClientsCommand(StoreKeyDto EntityKeyDto, ClientKeyDto RelatedEntityKeyDto)
	: RefStoreToClientsCommand(EntityKeyDto);

internal partial class CreateRefStoreToClientsCommandHandler
	: RefStoreToClientsCommandHandlerBase<CreateRefStoreToClientsCommand>
{
	public CreateRefStoreToClientsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefStoreToClientsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetClientsOfStore(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Client",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToClients(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefStoreToClientsCommand(StoreKeyDto EntityKeyDto, List<ClientKeyDto> RelatedEntitiesKeysDtos)
	: RefStoreToClientsCommand(EntityKeyDto);

internal partial class UpdateRefStoreToClientsCommandHandler
	: RefStoreToClientsCommandHandlerBase<UpdateRefStoreToClientsCommand>
{
	public UpdateRefStoreToClientsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefStoreToClientsCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Client>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetClientsOfStore(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Client", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToClients(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefStoreToClientsCommand(StoreKeyDto EntityKeyDto, ClientKeyDto RelatedEntityKeyDto)
	: RefStoreToClientsCommand(EntityKeyDto);

internal partial class DeleteRefStoreToClientsCommandHandler
	: RefStoreToClientsCommandHandlerBase<DeleteRefStoreToClientsCommand>
{
	public DeleteRefStoreToClientsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefStoreToClientsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetClientsOfStore(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Client", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToClients(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreToClientsCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToClientsCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreToClientsCommandHandler
	: RefStoreToClientsCommandHandlerBase<DeleteAllRefStoreToClientsCommand>
{
	public DeleteAllRefStoreToClientsCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefStoreToClientsCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToClients();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToClientsCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToClientsCommand
{
	public IRepository Repository { get; }

	public RefStoreToClientsCommandHandlerBase(
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
		return await Repository.FindAndIncludeAsync<Store>(keys.ToArray(), x => x.Clients, cancellationToken);
	}

	protected async Task<ClientApi.Domain.Client?> GetClientsOfStore(ClientKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.ClientMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Client>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, StoreEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}