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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefStoreLicenseToStoreCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStoreLicense(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoreWithLicense(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToStore(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefStoreLicenseToStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoreWithLicense(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToStore(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefStoreLicenseToStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStoreLicense(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("StoreLicense",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToStore();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreLicenseToStoreCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreLicenseEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreLicenseToStoreCommand
{
	public IRepository Repository { get; }

	public RefStoreLicenseToStoreCommandHandlerBase(
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

	protected async Task<StoreLicenseEntity?> GetStoreLicense(StoreLicenseKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreLicenseMetadata.CreateId(entityKeyDto.keyId));		
		return await Repository.FindAsync<ClientApi.Domain.StoreLicense>(keys.ToArray(), cancellationToken);
	}

	protected async Task<ClientApi.Domain.Store?> GetStoreWithLicense(StoreKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<ClientApi.Domain.Store>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, StoreLicenseEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}