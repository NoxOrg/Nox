﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Solution;
using Nox.Types;
using Nox.Application.Factories;
using Nox.Exceptions;
using Nox.Domain;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;
using Dto = Cryptocash.Application.Dto;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Commands;
public partial record PartialUpdateExchangeRatesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, Nox.Types.CultureCode CultureCode, System.Guid? Etag) : IRequest <ExchangeRateKeyDto>;
internal partial class PartialUpdateExchangeRatesForCurrencyCommandHandler: PartialUpdateExchangeRatesForCurrencyCommandHandlerBase
{
	public PartialUpdateExchangeRatesForCurrencyCommandHandler(
        IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(repository, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateExchangeRatesForCurrencyCommandHandlerBase: CommandBase<PartialUpdateExchangeRatesForCurrencyCommand, ExchangeRateEntity>, IRequestHandler <PartialUpdateExchangeRatesForCurrencyCommand, ExchangeRateKeyDto>
{
	protected readonly IRepository Repository;
	protected readonly IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> EntityFactory;
	
	protected PartialUpdateExchangeRatesForCurrencyCommandHandlerBase(
		IRepository repository,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory)
		: base(noxSolution)
	{
		Repository = repository;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ExchangeRateKeyDto> Handle(PartialUpdateExchangeRatesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);

		var keys = new List<object?>(1);
		keys.Add(Dto.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId));

		var parentEntity = await Repository.FindAndIncludeAsync<Currency>(keys.ToArray(),e => e.ExchangeRates, cancellationToken);
		if (parentEntity == null)
		{
			throw new EntityNotFoundException("Currency",  "keyId");
		}
		var ownedId = Dto.ExchangeRateMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.ExchangeRates.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			throw new EntityNotFoundException("Currency.ExchangeRates", $"ownedId");
		}

		await EntityFactory.PartialUpdateEntityAsync(entity, request.UpdatedProperties, request.CultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;
		Repository.Update(entity);
		await OnCompletedAsync(request, entity);
		await Repository.SaveChangesAsync();		

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}