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

using ClientApi.Infrastructure.Persistence;
using ClientApi.Domain;
using ClientApi.Application.Dto;
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefStoreToClientsCommand request)
    {
		var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetClient(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Client",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToClients(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefStoreToClientsCommand request)
    {
		var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Client>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetClient(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Client", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Clients).LoadAsync();
		entity.UpdateRefToClients(relatedEntities);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefStoreToClientsCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetClient(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Client", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToClients(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefStoreToClientsCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.Clients).LoadAsync();
		entity.DeleteAllRefToClients();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToClientsCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToClientsCommand
{
	public AppDbContext DbContext { get; }

	public RefStoreToClientsCommandHandlerBase(
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

	protected async Task<StoreEntity?> GetStore(StoreKeyDto entityKeyDto)
	{
		var keyId = ClientApi.Domain.StoreMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Stores.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Client?> GetClient(ClientKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.ClientMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Clients.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, StoreEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			throw new DatabaseSaveException();
		}
		return true;
	}
}