
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

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Commands;

public abstract record RefCurrencyToCountriesCommand(CurrencyKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCurrencyToCountriesCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCurrencyToCountriesCommand(EntityKeyDto);

internal partial class CreateRefCurrencyToCountriesCommandHandler
	: RefCurrencyToCountriesCommandHandlerBase<CreateRefCurrencyToCountriesCommand>
{
	public CreateRefCurrencyToCountriesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(CreateRefCurrencyToCountriesCommand request)
    {
		var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.CreateRefToCountries(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region UpdateRefTo

public partial record UpdateRefCurrencyToCountriesCommand(CurrencyKeyDto EntityKeyDto, List<CountryKeyDto> RelatedEntitiesKeysDtos)
	: RefCurrencyToCountriesCommand(EntityKeyDto);

internal partial class UpdateRefCurrencyToCountriesCommandHandler
	: RefCurrencyToCountriesCommandHandlerBase<UpdateRefCurrencyToCountriesCommand>
{
	public UpdateRefCurrencyToCountriesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(UpdateRefCurrencyToCountriesCommand request)
    {
		var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntities = new List<Cryptocash.Domain.Country>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCountry(keyDto);
			if (relatedEntity == null)
			{
				return false;
			}
			relatedEntities.Add(relatedEntity);
		}

		await DbContext.Entry(entity).Collection(x => x.Countries).LoadAsync();
		entity.UpdateRefToCountries(relatedEntities);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion UpdateRefTo

#region DeleteRefTo

public record DeleteRefCurrencyToCountriesCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCurrencyToCountriesCommand(EntityKeyDto);

internal partial class DeleteRefCurrencyToCountriesCommandHandler
	: RefCurrencyToCountriesCommandHandlerBase<DeleteRefCurrencyToCountriesCommand>
{
	public DeleteRefCurrencyToCountriesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteRefCurrencyToCountriesCommand request)
    {
        var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}

		var relatedEntity = await GetCountry(request.RelatedEntityKeyDto);
		if (relatedEntity == null)
		{
			return false;
		}

		entity.DeleteRefToCountries(relatedEntity);

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCurrencyToCountriesCommand(CurrencyKeyDto EntityKeyDto)
	: RefCurrencyToCountriesCommand(EntityKeyDto);

internal partial class DeleteAllRefCurrencyToCountriesCommandHandler
	: RefCurrencyToCountriesCommandHandlerBase<DeleteAllRefCurrencyToCountriesCommand>
{
	public DeleteAllRefCurrencyToCountriesCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution)
	{ }

	protected override async Task<bool> ExecuteAsync(DeleteAllRefCurrencyToCountriesCommand request)
    {
        var entity = await GetCurrency(request.EntityKeyDto);
		if (entity == null)
		{
			return false;
		}
		await DbContext.Entry(entity).Collection(x => x.Countries).LoadAsync();
		entity.DeleteAllRefToCountries();

		return await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCurrencyToCountriesCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToCountriesCommand
{
	public AppDbContext DbContext { get; }

	public RefCurrencyToCountriesCommandHandlerBase(
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

	protected async Task<CurrencyEntity?> GetCurrency(CurrencyKeyDto entityKeyDto)
	{
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(entityKeyDto.keyId);
		return await DbContext.Currencies.FindAsync(keyId);
	}

	protected async Task<Cryptocash.Domain.Country?> GetCountry(CountryKeyDto relatedEntityKeyDto)
	{
		var relatedKeyId = Cryptocash.Domain.CountryMetadata.CreateId(relatedEntityKeyDto.keyId);
		return await DbContext.Countries.FindAsync(relatedKeyId);
	}

	protected async Task<bool> SaveChangesAsync(TRequest request, CurrencyEntity entity)
	{
		await OnCompletedAsync(request, entity);
		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return false;
		}
		return true;
	}
}