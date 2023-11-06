
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
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Commands;

public abstract record RefCountryToCountryUsedByCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public partial record CreateRef CountryToCountryUsedByCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToCountryUsedByCurrencyCommandHandler
	: RefCountryToCountryUsedByCurrencyCommandHandlerBase<CreateRefCountryToCountryUsedByCurrencyCommand>
{
	public CreateRefCountryToCountryUsedByCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCountryUsedByCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCountryToCountryUsedByCurrencyCommandHandler
	: RefCountryToCountryUsedByCurrencyCommandHandlerBase<DeleteRefCountryToCountryUsedByCurrencyCommand>
{
	public DeleteRefCountryToCountryUsedByCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToCountryUsedByCurrencyCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCountryUsedByCurrencyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCountryToCountryUsedByCurrencyCommandHandler
	: RefCountryToCountryUsedByCurrencyCommandHandlerBase<DeleteAllRefCountryToCountryUsedByCurrencyCommand>
{
	public DeleteAllRefCountryToCountryUsedByCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCountryToCountryUsedByCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCountryUsedByCurrencyCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToCountryUsedByCurrencyCommandHandlerBase(
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
		var keyId = Cryptocash.Domain.CountryMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}

		Cryptocash.Domain.Currency? relatedEntity = null!;
		if(request.RelatedEntityKeyDto is not null)
		{
			var relatedKeyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.RelatedEntityKeyDto.keyId);
			relatedEntity = await DbContext.Currencies.FindAsync(relatedKeyId);
			if (relatedEntity == null)
			{
				return false;
			}
		}

		switch (Action)
		{
			case RelationshipAction.Create:
				entity.CreateRefToCountryUsedByCurrency(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCountryUsedByCurrency(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCountryUsedByCurrency();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}