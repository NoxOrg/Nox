﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Factories;
using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Commands;
public record UpdateExchangeRateForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateKeyDto EntityKeyDto, ExchangeRateUpdateDto EntityDto, System.Guid? Etag) : IRequest <ExchangeRateKeyDto?>;

internal partial class UpdateExchangeRateForCurrencyCommandHandler : UpdateExchangeRateForCurrencyCommandHandlerBase
{
	public UpdateExchangeRateForCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateCreateDto, ExchangeRateUpdateDto> entityFactory)
		: base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal partial class UpdateExchangeRateForCurrencyCommandHandlerBase : CommandBase<UpdateExchangeRateForCurrencyCommand, ExchangeRateEntity>, IRequestHandler <UpdateExchangeRateForCurrencyCommand, ExchangeRateKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<ExchangeRateEntity, ExchangeRateCreateDto, ExchangeRateUpdateDto> _entityFactory;

	public UpdateExchangeRateForCurrencyCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateCreateDto, ExchangeRateUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<ExchangeRateKeyDto?> Handle(UpdateExchangeRateForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);
		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = Cryptocash.Domain.ExchangeRateMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.CurrencyExchangedFromRates.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		OnCompleted(request, entity);

		DbContext.Entry(parentEntity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}