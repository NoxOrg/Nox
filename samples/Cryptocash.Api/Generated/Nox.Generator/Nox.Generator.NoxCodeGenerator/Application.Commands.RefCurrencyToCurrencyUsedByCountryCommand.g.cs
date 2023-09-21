
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

public abstract record RefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCurrencyToCurrencyUsedByCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefCurrencyToCurrencyUsedByCountryCommandHandler: RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<CreateRefCurrencyToCurrencyUsedByCountryCommand>
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

public partial class DeleteRefCurrencyToCurrencyUsedByCountryCommandHandler: RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<DeleteRefCurrencyToCurrencyUsedByCountryCommand>
{
	public DeleteRefCurrencyToCurrencyUsedByCountryCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<TRequest>: CommandBase<TRequest, Currency>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToCurrencyUsedByCountryCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

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
		var relatedKeyId = CreateNoxTypeForKey<Country, Nox.Types.CountryCode2>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Countries.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToCurrencyUsedByCountry(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToCurrencyUsedByCountry(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}