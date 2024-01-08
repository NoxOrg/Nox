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

public abstract record RefStoreToCountryCommand(StoreKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefStoreToCountryCommand(StoreKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefStoreToCountryCommand(EntityKeyDto);

internal partial class CreateRefStoreToCountryCommandHandler
	: RefStoreToCountryCommandHandlerBase<CreateRefStoreToCountryCommand>
{
	public CreateRefStoreToCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefStoreToCountryCommand request)
    {
		var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefStoreToCountryCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCountry(relatedEntity);

		return await SaveChangesAsync(request, entity);
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
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefStoreToCountryCommand request)
    {
        var entity = await GetStore(request.EntityKeyDto);
		if (entity == null)
		{
			throw new EntityNotFoundException("Store",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCountry();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefStoreToCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, StoreEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefStoreToCountryCommand
{
	public AppDbContext DbContext { get; }

	public RefStoreToCountryCommandHandlerBase(
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

	protected async Task<ClientApi.Domain.Country?> GetCountry(CountryKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = ClientApi.Domain.CountryMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, StoreEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}