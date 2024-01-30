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

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCurrencyToCountriesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCurrencyUsedByCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCountries(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(UpdateRefCurrencyToCountriesCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntities = new List<Cryptocash.Domain.Country>();
		foreach(var keyDto in request.RelatedEntitiesKeysDtos)
		{
			var relatedEntity = await GetCurrencyUsedByCountry(keyDto, cancellationToken);
			if (relatedEntity == null)
			{
				throw new RelatedEntityNotFoundException("Country", $"{keyDto.keyId.ToString()}");
			}
			relatedEntities.Add(relatedEntity);
		}

		entity.UpdateRefToCountries(relatedEntities);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCurrencyToCountriesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCurrencyUsedByCountry(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Country", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCountries(relatedEntity);

		await SaveChangesAsync(request, entity);
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
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCurrencyToCountriesCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCurrency(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCountries();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCurrencyToCountriesCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToCountriesCommand
{
	public IRepository Repository { get; }

	public RefCurrencyToCountriesCommandHandlerBase(
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

	protected async Task<CurrencyEntity?> GetCurrency(CurrencyKeyDto entityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(entityKeyDto.keyId));
		return await Repository.FindAndIncludeAsync<Currency>(keys.ToArray(), x => x.Countries, cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Country?> GetCurrencyUsedByCountry(CountryKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CountryMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Country>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CurrencyEntity entity)
	{
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}