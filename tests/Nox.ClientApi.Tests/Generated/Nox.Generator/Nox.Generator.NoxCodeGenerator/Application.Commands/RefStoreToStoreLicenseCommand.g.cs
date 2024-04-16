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

public abstract record RefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreToStoreLicenseCommand(StoreKeyDto EntityKeyDto, StoreLicenseKeyDto RelatedEntityKeyDto)
	: RefStoreToStoreLicenseCommand(EntityKeyDto);

internal partial class CreateRefStoreToStoreLicenseCommandHandler
	: RefStoreToStoreLicenseCommandHandlerBase<CreateRefStoreToStoreLicenseCommand>
{
	public CreateRefStoreToStoreLicenseCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefStoreToStoreLicenseCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetLicense(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("StoreLicense",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToStoreLicense(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefStoreToStoreLicenseCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetLicense(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("StoreLicense", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToStoreLicense(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefStoreToStoreLicenseCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToStoreLicense();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToStoreLicenseCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToStoreLicenseCommand
{
	public IRepository Repository { get; }

	public RefStoreToStoreLicenseCommandHandlerBase(
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
		return await Repository.FindAsync<ClientApi.Domain.Store>(keys.ToArray(), cancellationToken);
	}

	protected async Task<ClientApi.Domain.StoreLicense?> GetLicense(StoreLicenseKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreLicenseMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<ClientApi.Domain.StoreLicense>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, StoreEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}