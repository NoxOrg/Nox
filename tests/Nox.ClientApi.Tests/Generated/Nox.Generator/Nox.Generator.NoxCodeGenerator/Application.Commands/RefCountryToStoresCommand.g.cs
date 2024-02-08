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
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Commands;

public abstract record RefCountryToStoresCommand(CountryKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCountryToStoresCommand(CountryKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefCountryToStoresCommand(EntityKeyDto);

internal partial class CreateRefCountryToStoresCommandHandler
	: RefCountryToStoresCommandHandlerBase<CreateRefCountryToStoresCommand>
{
	public CreateRefCountryToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCountryToStoresCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoresInTheCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToStores(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCountryToStoresCommand(CountryKeyDto EntityKeyDto, List<StoreKeyDto> RelatedEntitiesKeysDtos)
	: RefCountryToStoresCommand(EntityKeyDto);

internal partial class UpdateRefCountryToStoresCommandHandler
	: RefCountryToStoresCommandHandlerBase<UpdateRefCountryToStoresCommand>
{
	public UpdateRefCountryToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCountryToStoresCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Store>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetStoresInTheCountry(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Store", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToStores(relatedEntities);

		await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCountryToStoresCommand(CountryKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefCountryToStoresCommand(EntityKeyDto);

internal partial class DeleteRefCountryToStoresCommandHandler
	: RefCountryToStoresCommandHandlerBase<DeleteRefCountryToStoresCommand>
{
	public DeleteRefCountryToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCountryToStoresCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoresInTheCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Store", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToStores(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCountryToStoresCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToStoresCommand(EntityKeyDto);

internal partial class DeleteAllRefCountryToStoresCommandHandler
	: RefCountryToStoresCommandHandlerBase<DeleteAllRefCountryToStoresCommand>
{
	public DeleteAllRefCountryToStoresCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCountryToStoresCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToStores();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToStoresCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToStoresCommand
{
	public IRepository Repository { get; }

	public RefCountryToStoresCommandHandlerBase(
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

	protected async Task<CountryEntity?> GetCountry(CountryKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<ClientApi.Domain.Country>(keys.ToArray(), x => x.Stores, cancellationToken);
	}

	protected async Task<ClientApi.Domain.Store?> GetStoresInTheCountry(StoreKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.StoreMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<ClientApi.Domain.Store>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}