
// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Application;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;

public abstract record RefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCurrencyToCurrencyUsedByCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCurrencyToCurrencyUsedByCountryCommandHandler
	: RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<CreateRefCurrencyToCurrencyUsedByCountryCommand>
{
	public CreateRefCurrencyToCurrencyUsedByCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCurrencyToCurrencyUsedByCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCurrencyToCurrencyUsedByCountryCommandHandler
	: RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<DeleteRefCurrencyToCurrencyUsedByCountryCommand>
{
	public DeleteRefCurrencyToCurrencyUsedByCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto)
	: RefCurrencyToCurrencyUsedByCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCurrencyToCurrencyUsedByCountryCommandHandler
	: RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<DeleteAllRefCurrencyToCurrencyUsedByCountryCommand>
{
	public DeleteAllRefCurrencyToCurrencyUsedByCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<TRequest>: CommandBase<TRequest, Currency>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToCurrencyUsedByCountryCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCurrencyToCurrencyUsedByCountryCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		RelationshipAction action)
		: base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency, Nox.Types.CurrencyCode3>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Country? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = CreateNoxTypeForKey<Country, Nox.Types.CountryCode2>("Id", request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToCurrencyUsedByCountry(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCurrencyUsedByCountry(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				await DbContext.Entry(entity).Collection(x => x.CurrencyUsedByCountry).LoadAsync();
				entity.DeleteAllRefToCurrencyUsedByCountry();
				break;
		}

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}