﻿﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Domain;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Commands;
public partial record DeleteExchangeRatesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateKeyDto EntityKeyDto) : IRequest <bool>;

internal partial class DeleteExchangeRatesForCurrencyCommandHandler : DeleteExchangeRatesForCurrencyCommandHandlerBase
{
	public DeleteExchangeRatesForCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution)
		: base(repository, noxSolution)
	{
	}
}

internal partial class DeleteExchangeRatesForCurrencyCommandHandlerBase : CommandBase<DeleteExchangeRatesForCurrencyCommand, ExchangeRateEntity>, IRequestHandler <DeleteExchangeRatesForCurrencyCommand, bool>
{
	public IRepository Repository { get; }

	public DeleteExchangeRatesForCurrencyCommandHandlerBase(
        IRepository repository,
		NoxSolution noxSolution) : base(noxSolution)
	{
		Repository = repository;
	}

	public virtual async Task<bool> Handle(DeleteExchangeRatesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		
		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId));
		var parentEntity = await Repository.FindAndIncludeAsync<Cryptocash.Domain.Currency>(keys.ToArray(), p => p.ExchangeRates, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Currency",  "keyId");
		}
		var ownedId = Dto.ExchangeRateMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.ExchangeRates.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("ExchangeRate.ExchangeRates",  $"ownedId");
		}
		parentEntity.ExchangeRates.Remove(entity);
		
		await OnCompletedAsync(request, entity);
		Repository.Delete(entity);
		await Repository.SaveChangesAsync(cancellationToken);

		return true;
	}
}