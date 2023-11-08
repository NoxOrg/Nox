
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

public abstract record RefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCurrencyToCurrencyUsedByCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCurrencyToCurrencyUsedByCountryCommandHandler
	: RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<CreateRefCurrencyToCurrencyUsedByCountryCommand>
{
	public CreateRefCurrencyToCurrencyUsedByCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto, CountryKeyDto RelatedEntityKeyDto)
	: RefCurrencyToCurrencyUsedByCountryCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCurrencyToCurrencyUsedByCountryCommandHandler
	: RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<DeleteRefCurrencyToCurrencyUsedByCountryCommand>
{
	public DeleteRefCurrencyToCurrencyUsedByCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCurrencyToCurrencyUsedByCountryCommand(CurrencyKeyDto EntityKeyDto)
	: RefCurrencyToCurrencyUsedByCountryCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCurrencyToCurrencyUsedByCountryCommandHandler
	: RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<DeleteAllRefCurrencyToCurrencyUsedByCountryCommand>
{
	public DeleteAllRefCurrencyToCurrencyUsedByCountryCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCurrencyToCurrencyUsedByCountryCommandHandlerBase<TRequest> : CommandBase<TRequest, CurrencyEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCurrencyToCurrencyUsedByCountryCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCurrencyToCurrencyUsedByCountryCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		RelationshipAction action)
		: base(noxSolution)
	{
		DbContext = dbContext;
		Action = action;
	}

	public virtual async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Currencies.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Country? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CountryMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
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

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}