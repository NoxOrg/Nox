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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefStoreToParentOfStoreCommand request)
    {
		var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetParentOfStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToParentOfStore(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefStoreToParentOfStoreCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetParentOfStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToParentOfStore(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefStoreToParentOfStoreCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToParentOfStore();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToParentOfStoreCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToParentOfStoreCommand
{
	public AppDbContext DbContext { get; }

	public RefStoreToParentOfStoreCommandHandlerBase(
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
		var keyId = Dto.StoreMetadata.CreateId(entityKeyDto.keyId);		
		return await DbContext.Stores.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Store?> GetParentOfStore(StoreKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.StoreMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Stores.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, StoreEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}