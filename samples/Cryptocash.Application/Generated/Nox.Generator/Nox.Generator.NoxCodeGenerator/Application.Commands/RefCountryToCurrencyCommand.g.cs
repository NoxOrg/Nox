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
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public abstract record RefCountryToCurrencyCommand(CountryKeyDto EntityKeyDto) : IRequest <bool>;

#region CreateRefTo

public partial record CreateRefCountryToCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefCountryToCurrencyCommand(EntityKeyDto);

internal partial class CreateRefCountryToCurrencyCommandHandler
	: RefCountryToCurrencyCommandHandlerBase<CreateRefCountryToCurrencyCommand>
{
	public CreateRefCountryToCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(CreateRefCountryToCurrencyCommand request, CancellationToken cancellationToken)
    {
		var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryUsedByCurrency(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency",  $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.CreateRefToCurrency(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion CreateRefTo

#region DeleteRefTo

public record DeleteRefCountryToCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefCountryToCurrencyCommand(EntityKeyDto);

internal partial class DeleteRefCountryToCurrencyCommandHandler
	: RefCountryToCurrencyCommandHandlerBase<DeleteRefCountryToCurrencyCommand>
{
	public DeleteRefCountryToCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteRefCountryToCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}

		var relatedEntity = await GetCountryUsedByCurrency(request.RelatedEntityKeyDto, cancellationToken);
		if (relatedEntity == null)
		{
			throw new RelatedEntityNotFoundException("Currency", $"{request.RelatedEntityKeyDto.keyId.ToString()}");
		}

		entity.DeleteRefToCurrency(relatedEntity);

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteRefTo

#region DeleteAllRefTo

public record DeleteAllRefCountryToCurrencyCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCurrencyCommand(EntityKeyDto);

internal partial class DeleteAllRefCountryToCurrencyCommandHandler
	: RefCountryToCurrencyCommandHandlerBase<DeleteAllRefCountryToCurrencyCommand>
{
	public DeleteAllRefCountryToCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution
		)
		: base(repository, noxSolution)
	{ }

	protected override async Task ExecuteAsync(DeleteAllRefCountryToCurrencyCommand request, CancellationToken cancellationToken)
    {
        var entity = await GetCountry(request.EntityKeyDto, cancellationToken);
		if (entity == null)
		{
			throw new EntityNotFoundException("Country",  $"{request.EntityKeyDto.keyId.ToString()}");
		}
		entity.DeleteAllRefToCurrency();

		await SaveChangesAsync(request, entity);
    }
}

#endregion DeleteAllRefTo

internal abstract class RefCountryToCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCurrencyCommand
{
	public IRepository Repository { get; }

	public RefCountryToCurrencyCommandHandlerBase(
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
		return await Repository.FindAsync<Country>(keys.ToArray(), cancellationToken);
	}

	protected async Task<Cryptocash.Domain.Currency?> GetCountryUsedByCurrency(CurrencyKeyDto relatedEntityKeyDto, CancellationToken cancellationToken)
	{
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(relatedEntityKeyDto.keyId));
		return await Repository.FindAsync<Currency>(keys.ToArray(), cancellationToken);
	}

	protected async Task SaveChangesAsync(TRequest request, CountryEntity entity)
	{
		Repository.SetStateModified(entity);
		await OnCompletedAsync(request, entity);		
		await Repository.SaveChangesAsync();
	}
}