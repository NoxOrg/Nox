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

public abstract record RefStoreToFranchisesOfStoreCommand(StoreKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreToFranchisesOfStoreCommand(StoreKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefStoreToFranchisesOfStoreCommand(EntityKeyDto);

internal partial class CreateRefStoreToFranchisesOfStoreCommandHandler
	: RefStoreToFranchisesOfStoreCommandHandlerBase<CreateRefStoreToFranchisesOfStoreCommand>
{
	public CreateRefStoreToFranchisesOfStoreCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefStoreToFranchisesOfStoreCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetFranchisesOfStore(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToFranchisesOfStore(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefStoreToFranchisesOfStoreCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Store>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetFranchisesOfStore(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Store", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToFranchisesOfStore(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefStoreToFranchisesOfStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetFranchisesOfStore(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToFranchisesOfStore(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefStoreToFranchisesOfStoreCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToFranchisesOfStore();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToFranchisesOfStoreCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToFranchisesOfStoreCommand
{
	public IRepository Repository { get; }

	public RefStoreToFranchisesOfStoreCommandHandlerBase(
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
		return await Repository.FindAndIncludeAsync<ClientApi.Domain.Store>(keys.ToArray(), x => x.FranchisesOfStore, cancellationToken);
	}

	protected async Task<ClientApi.Domain.Store?> GetFranchisesOfStore(StoreKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<ClientApi.Domain.Store>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, StoreEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}