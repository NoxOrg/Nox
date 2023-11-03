
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

public abstract record RefCountryToCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto? RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCountryToCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefCountryToCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class CreateRefCountryToCurrencyCommandHandler
	: RefCountryToCurrencyCommandHandlerBase<CreateRefCountryToCurrencyCommand>
{
	public CreateRefCountryToCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefCountryToCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

internal partial class DeleteRefCountryToCurrencyCommandHandler
	: RefCountryToCurrencyCommandHandlerBase<DeleteRefCountryToCurrencyCommand>
{
	public DeleteRefCountryToCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.Delete)
	{ }
}

public record DeleteAllRefCountryToCurrencyCommand(CountryKeyDto EntityKeyDto)
	: RefCountryToCurrencyCommand(EntityKeyDto, null);

internal partial class DeleteAllRefCountryToCurrencyCommandHandler
	: RefCountryToCurrencyCommandHandlerBase<DeleteAllRefCountryToCurrencyCommand>
{
	public DeleteAllRefCountryToCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution
		)
		: base(dbContext, noxSolution, RelationshipAction.DeleteAll)
	{ }
}

internal abstract class RefCountryToCurrencyCommandHandlerBase<TRequest> : CommandBase<TRequest, CountryEntity>,
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCurrencyCommand
{
	public AppDbContext DbContext { get; }

	public RelationshipAction Action { get; }

	public enum RelationshipAction { Create, Delete, DeleteAll };

	public RefCountryToCurrencyCommandHandlerBase(
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
				entity.CreateRefToCurrency(relatedEntity);
				break;
			case RelationshipAction.Delete:
				entity.DeleteRefToCurrency(relatedEntity);
				break;
			case RelationshipAction.DeleteAll:
				entity.DeleteAllRefToCurrency();
				break;
		}

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}