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
using StoreLicenseEntity = ClientApi.Domain.StoreLicense;

namespace ClientApi.Application.Commands;

public abstract record RefStoreLicenseToStoreCommand(StoreLicenseKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreLicenseToStoreCommand(StoreLicenseKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToStoreCommand(EntityKeyDto);

internal partial class CreateRefStoreLicenseToStoreCommandHandler
	: RefStoreLicenseToStoreCommandHandlerBase<CreateRefStoreLicenseToStoreCommand>
{
	public CreateRefStoreLicenseToStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefStoreLicenseToStoreCommand request)
    {
		var entity = await GetStoreLicense(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToStore(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefStoreLicenseToStoreCommand(StoreLicenseKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreLicenseToStoreCommand(EntityKeyDto);

internal partial class DeleteRefStoreLicenseToStoreCommandHandler
	: RefStoreLicenseToStoreCommandHandlerBase<DeleteRefStoreLicenseToStoreCommand>
{
	public DeleteRefStoreLicenseToStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefStoreLicenseToStoreCommand request)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStore(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToStore(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreLicenseToStoreCommand(StoreLicenseKeyDto EntityKeyDto)
	: RefStoreLicenseToStoreCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreLicenseToStoreCommandHandler
	: RefStoreLicenseToStoreCommandHandlerBase<DeleteAllRefStoreLicenseToStoreCommand>
{
	public DeleteAllRefStoreLicenseToStoreCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefStoreLicenseToStoreCommand request)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToStore();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreLicenseToStoreCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToStoreCommand
{
	public AppDbContext DbContext { get; }

	public RefStoreLicenseToStoreCommandHandlerBase(
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

	protected async Task<StoreLicenseEntity?> GetStoreLicense(StoreLicenseKeyDto entityKeyDto)
	{
		var keyId = ClientApi.Domain.StoreLicenseMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.StoreLicenses.FindAsync(keyId);
	}

	protected async Task<ClientApi.Domain.Store?> GetStore(StoreKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.StoreMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Stores.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, StoreLicenseEntity entity)
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