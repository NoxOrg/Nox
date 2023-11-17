﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Commands;
public partial record DeleteExchangeRateForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteExchangeRateForCurrencyCommandHandler : DeleteExchangeRateForCurrencyCommandHandlerBase
{
	public DeleteExchangeRateForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteExchangeRateForCurrencyCommandHandlerBase : CommandBase<DeleteExchangeRateForCurrencyCommand, ExchangeRateEntity>, IRequestHandler <DeleteExchangeRateForCurrencyCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteExchangeRateForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteExchangeRateForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return false;
		}
		var ownedId = Cryptocash.Domain.ExchangeRateMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CurrencyExchangedFromRates.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return false;
		}
		parentEntity.CurrencyExchangedFromRates.Remove(entity);
		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Deleted;

		var result = await DbContext.SaveChangesAsync(cancellationToken);
		if (result < 1)
		{
			return false;
		}

		return true;
	}
}