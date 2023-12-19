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

public abstract record RefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefStoreToStoreLicenseCommand(EntityKeyDto);

internal partial class CreateRefStoreToStoreLicenseCommandHandler
	: RefStoreToStoreLicenseCommandHandlerBase<CreateRefStoreToStoreLicenseCommand>
{
	public CreateRefStoreToStoreLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefStoreToStoreLicenseCommand request)
    {
		var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoreLicense(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("StoreLicense",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToStoreLicense(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefStoreToStoreLicenseCommand(EntityKeyDto);

internal partial class DeleteRefStoreToStoreLicenseCommandHandler
	: RefStoreToStoreLicenseCommandHandlerBase<DeleteRefStoreToStoreLicenseCommand>
{
	public DeleteRefStoreToStoreLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefStoreToStoreLicenseCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoreLicense(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("StoreLicense", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToStoreLicense(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToStoreLicenseCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreToStoreLicenseCommandHandler
	: RefStoreToStoreLicenseCommandHandlerBase<DeleteAllRefStoreToStoreLicenseCommand>
{
	public DeleteAllRefStoreToStoreLicenseCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefStoreToStoreLicenseCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToStoreLicense();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToStoreLicenseCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToStoreLicenseCommand
{
	public AppDbContext DbContext { get; }

	public RefStoreToStoreLicenseCommandHandlerBase(
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

	protected async Task<ClientApi.Domain.StoreLicense?> GetStoreLicense(StoreLicenseKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.StoreLicenses.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, StoreEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}