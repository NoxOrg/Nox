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

public abstract record RefStoreToFranchisesOfStoreCommand(StoreKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreToFranchisesOfStoreCommand(StoreKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreToFranchisesOfStoreCommand(EntityKeyDto);

internal partial class CreateRefStoreToFranchisesOfStoreCommandHandler
	: RefStoreToFranchisesOfStoreCommandHandlerBase<CreateRefStoreToFranchisesOfStoreCommand>
{
	public CreateRefStoreToFranchisesOfStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefStoreToFranchisesOfStoreCommand request)
    {
		var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetFranchisesOfStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToFranchisesOfStore(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefStoreToFranchisesOfStoreCommand(StoreKeyDto EntityKeyDto, List<StoreKeyDto> RelatedEntitiesKeysDtos)
	: RefStoreToFranchisesOfStoreCommand(EntityKeyDto);

internal partial class UpdateRefStoreToFranchisesOfStoreCommandHandler
	: RefStoreToFranchisesOfStoreCommandHandlerBase<UpdateRefStoreToFranchisesOfStoreCommand>
{
	public UpdateRefStoreToFranchisesOfStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefStoreToFranchisesOfStoreCommand request)
    {
		var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Store>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetFranchisesOfStore(keyDto);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Store", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.FranchisesOfStore).LoadAsync();
		entity.UpdateRefToFranchisesOfStore(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefStoreToFranchisesOfStoreCommand(StoreKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreToFranchisesOfStoreCommand(EntityKeyDto);

internal partial class DeleteRefStoreToFranchisesOfStoreCommandHandler
	: RefStoreToFranchisesOfStoreCommandHandlerBase<DeleteRefStoreToFranchisesOfStoreCommand>
{
	public DeleteRefStoreToFranchisesOfStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefStoreToFranchisesOfStoreCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetFranchisesOfStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToFranchisesOfStore(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreToFranchisesOfStoreCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToFranchisesOfStoreCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreToFranchisesOfStoreCommandHandler
	: RefStoreToFranchisesOfStoreCommandHandlerBase<DeleteAllRefStoreToFranchisesOfStoreCommand>
{
	public DeleteAllRefStoreToFranchisesOfStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefStoreToFranchisesOfStoreCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.FranchisesOfStore).LoadAsync();
		entity.DeleteAllRefToFranchisesOfStore();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToFranchisesOfStoreCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToFranchisesOfStoreCommand
{
	public AppDbContext DbContext { get; }

	public RefStoreToFranchisesOfStoreCommandHandlerBase(
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

	protected async Task<ClientApi.Domain.Store?> GetFranchisesOfStore(StoreKeyDto relatedEntityKeyDto)
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