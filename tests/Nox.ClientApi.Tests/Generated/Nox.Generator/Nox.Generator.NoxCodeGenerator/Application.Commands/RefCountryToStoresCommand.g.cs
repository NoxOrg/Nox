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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCountryToStoresCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoresInTheCountry(request.RelatedEntityKeyDto);
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

public partial record UpdateRefCountryToStoresCommand(CountryKeyDto EntityKeyDto, List<StoreKeyDto> RelatedEntitiesKeysDtos)
	: RefCountryToStoresCommand(EntityKeyDto);

internal partial class UpdateRefCountryToStoresCommandHandler
	: RefCountryToStoresCommandHandlerBase<UpdateRefCountryToStoresCommand>
{
	public UpdateRefCountryToStoresCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCountryToStoresCommand request)
    {
		var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<ClientApi.Domain.Store>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetStoresInTheCountry(keyDto);
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

public record DeleteRefCountryToStoresCommand(CountryKeyDto EntityKeyDto, StoreKeyDto RelatedEntityKeyDto)
	: RefCountryToStoresCommand(EntityKeyDto);

internal partial class DeleteRefCountryToStoresCommandHandler
	: RefCountryToStoresCommandHandlerBase<DeleteRefCountryToStoresCommand>
{
	public DeleteRefCountryToStoresCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCountryToStoresCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetStoresInTheCountry(request.RelatedEntityKeyDto);
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

public record DeleteAllRefCountryToStoresCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToStoresCommand(EntityKeyDto);

internal partial class DeleteAllRefCountryToStoresCommandHandler
	: RefCountryToStoresCommandHandlerBase<DeleteAllRefCountryToStoresCommand>
{
	public DeleteAllRefCountryToStoresCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCountryToStoresCommand request)
    {
        var entity = await GetCountry(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		await DbContext.Entry(entity).Collection(x => x.Stores).LoadAsync();
		entity.DeleteAllRefToStores();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToStoresCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToStoresCommand
{
	public AppDbContext DbContext { get; }

	public RefCountryToStoresCommandHandlerBase(
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

	protected async Task<CountryEntity?> GetCountry(CountryKeyDto entityKeyDto)
	{
		var keyId = Dto.CountryMetadata.CreateId(entityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
		if(entity is not null)
		{
			await DbContext.Entry(entity).Collection(x => x.Stores).LoadAsync();
		}

		return entity;
	}

	protected async Task<ClientApi.Domain.Store?> GetStoresInTheCountry(StoreKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Dto.StoreMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Stores.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}