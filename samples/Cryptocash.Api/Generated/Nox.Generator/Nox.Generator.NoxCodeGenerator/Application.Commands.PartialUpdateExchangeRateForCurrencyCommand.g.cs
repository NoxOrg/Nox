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

namespace Cryptocash.Application.Commands;
public record PartialUpdateExchangeRateForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <ExchangeRateKeyDto?>;
public partial class PartialUpdateExchangeRateForCurrencyCommandHandler: PartialUpdateExchangeRateForCurrencyCommandHandlerBase
{
	public PartialUpdateExchangeRateForCurrencyCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<ExchangeRate, ExchangeRateCreateDto, ExchangeRateUpdateDto> entityFactory) : base(dbContext, noxSolution, serviceProvider, entityFactory)
	{
	}
}
public abstract class PartialUpdateExchangeRateForCurrencyCommandHandlerBase: CommandBase<PartialUpdateExchangeRateForCurrencyCommand, ExchangeRate>, IRequestHandler <PartialUpdateExchangeRateForCurrencyCommand, ExchangeRateKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<ExchangeRate, ExchangeRateCreateDto, ExchangeRateUpdateDto> EntityFactory { get; }

	public PartialUpdateExchangeRateForCurrencyCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<ExchangeRate, ExchangeRateCreateDto, ExchangeRateUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ExchangeRateKeyDto?> Handle(PartialUpdateExchangeRateForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,Nox.Types.CurrencyCode3>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<ExchangeRate,Nox.Types.AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.CurrencyExchangedFromRates.SingleOrDefault(x => x.Id == ownedId);	
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
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