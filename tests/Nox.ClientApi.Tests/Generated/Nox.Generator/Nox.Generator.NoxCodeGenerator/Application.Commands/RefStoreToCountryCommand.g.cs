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

public abstract record RefStoreToCountryCommand(StoreKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreToCountryCommand(StoreKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefStoreToCountryCommand(EntityKeyDto);

internal partial class CreateRefStoreToCountryCommandHandler
	: RefStoreToCountryCommandHandlerBase<CreateRefStoreToCountryCommand>
{
	public CreateRefStoreToCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefStoreToCountryCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryOfTheStore(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCountry(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefStoreToCountryCommand(StoreKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefStoreToCountryCommand(EntityKeyDto);

internal partial class DeleteRefStoreToCountryCommandHandler
	: RefStoreToCountryCommandHandlerBase<DeleteRefStoreToCountryCommand>
{
	public DeleteRefStoreToCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefStoreToCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryOfTheStore(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCountry(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefStoreToCountryCommand(StoreKeyDto EntityKeyDto)
	: RefStoreToCountryCommand(EntityKeyDto);

internal partial class DeleteAllRefStoreToCountryCommandHandler
	: RefStoreToCountryCommandHandlerBase<DeleteAllRefStoreToCountryCommand>
{
	public DeleteAllRefStoreToCountryCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefStoreToCountryCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetStore(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCountry();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToCountryCommand
{
	public IRepository Repository { get; }

	public RefStoreToCountryCommandHandlerBase(
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
		return await Repository.FindAsync<Store>(keys.ToArray(), cancellationToken);
	}

	protected async Task<ClientApi.Domain.Country?> GetCountryOfTheStore(CountryKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Country>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, StoreEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}