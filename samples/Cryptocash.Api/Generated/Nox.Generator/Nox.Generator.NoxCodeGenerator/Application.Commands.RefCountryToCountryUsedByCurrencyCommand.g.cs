﻿
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

public abstract record RefCountryToCountryUsedByCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto) : IRequest <bool>;

public record CreateRefCountryToCountryUsedByCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class CreateRefCountryToCountryUsedByCurrencyCommandHandler: RefCountryToCountryUsedByCurrencyCommandHandlerBase<CreateRefCountryToCountryUsedByCurrencyCommand>
{
	public CreateRefCountryToCountryUsedByCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Create)
	{ }
}

public record DeleteRefCountryToCountryUsedByCurrencyCommand(CountryKeyDto EntityKeyDto, CurrencyKeyDto RelatedEntityKeyDto)
	: RefCountryToCountryUsedByCurrencyCommand(EntityKeyDto, RelatedEntityKeyDto);

public partial class DeleteRefCountryToCountryUsedByCurrencyCommandHandler: RefCountryToCountryUsedByCurrencyCommandHandlerBase<DeleteRefCountryToCountryUsedByCurrencyCommand>
{
	public DeleteRefCountryToCountryUsedByCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider
		)
		: base(dbContext, noxSolution, serviceProvider, RelationshipAction.Delete)
	{ }
}

public abstract class RefCountryToCountryUsedByCurrencyCommandHandlerBase<TRequest>: CommandBase<TRequest, Country>, 
	IRequestHandler <TRequest, bool> where TRequest : RefCountryToCountryUsedByCurrencyCommand
{
	public CryptocashDbContext DbContext { get; }

	public RelationshipAction Action { get; }

    public enum RelationshipAction { Create, Delete };

	public RefCountryToCountryUsedByCurrencyCommandHandlerBase(
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
		var keyId = CreateNoxTypeForKey<Country, Nox.Types.CountryCode2>("Id", request.EntityKeyDto.keyId);
		var entity = await DbContext.Countries.FindAsync(keyId);
		if (entity == null)
		{
			return false;
		}
		var relatedKeyId = CreateNoxTypeForKey<Currency, Nox.Types.CurrencyCode3>("Id", request.RelatedEntityKeyDto.keyId);
		var relatedEntity = await DbContext.Currencies.FindAsync(relatedKeyId);
		if (relatedEntity == null)
		{
			return false;
		}
		
		switch (Action)
        {
            case RelationshipAction.Create:
                entity.CreateRefToCountryUsedByCurrency(relatedEntity);
                break;
            case RelationshipAction.Delete:
                entity.DeleteRefToCountryUsedByCurrency(relatedEntity);
                break;
        }

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return true;
	}
}