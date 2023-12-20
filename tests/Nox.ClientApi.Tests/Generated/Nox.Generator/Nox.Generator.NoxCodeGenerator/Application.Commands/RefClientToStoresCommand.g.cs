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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefClientToStoresCommand request)
    {
		var entity = await GetClient(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToStores(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefClientToStoresCommand request)
    {
		var entity = await GetClient(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Store>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetStore(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Store", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Stores).LoadAsync();
		entity.UpdateRefToStores(relatedEntities);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefClientToStoresCommand request)
    {
        var entity = await GetClient(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToStores(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefClientToStoresCommand request)
    {
        var entity = await GetClient(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Client",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.Stores).LoadAsync();
		entity.DeleteAllRefToStores();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefClientToStoresCommandHandlerBase<TRequest> : CommandBase<TRequest, ClientEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefClientToStoresCommand
{
	public AppDbContext DbContext { get; }

	public RefClientToStoresCommandHandlerBase(
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

	protected async Task<ClientEntity?> GetClient(ClientKeyDto entityKeyDto)
	{
		var keyId = ClientApi.Domain.ClientMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Clients.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Store?> GetStore(StoreKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.StoreMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Stores.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, ClientEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}