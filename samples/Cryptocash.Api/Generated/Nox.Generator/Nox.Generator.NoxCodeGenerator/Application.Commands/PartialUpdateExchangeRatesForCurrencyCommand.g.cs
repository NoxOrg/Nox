﻿
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
public partial record PartialUpdateExchangeRatesForCurrencyCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <ExchangeRateKeyDto?>;
internal partial class PartialUpdateExchangeRatesForCurrencyCommandHandler: PartialUpdateExchangeRatesForCurrencyCommandHandlerBase
{
	public PartialUpdateExchangeRatesForCurrencyCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory) : base(dbContext, noxSolution, entityFactory)
	{
	}
}
internal abstract class PartialUpdateExchangeRatesForCurrencyCommandHandlerBase: CommandBase<PartialUpdateExchangeRatesForCurrencyCommand, ExchangeRateEntity>, IRequestHandler <PartialUpdateExchangeRatesForCurrencyCommand, ExchangeRateKeyDto?>
{
	public AppDbContext DbContext { get; }
	public IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> EntityFactory { get; }

	public PartialUpdateExchangeRatesForCurrencyCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto> entityFactory) : base(noxSolution)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<ExchangeRateKeyDto?> Handle(PartialUpdateExchangeRatesForCurrencyCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.CurrencyMetadata.CreateId(request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		await DbContext.Entry(parentEntity).Collection(p => p.ExchangeRates).LoadAsync(cancellationToken);
		var ownedId = Cryptocash.Domain.ExchangeRateMetadata.CreateId(request.EntityKeyDto.keyId);
		var entity = parentEntity.ExchangeRates.SingleOrDefault(x => x.Id == ownedId);
		if (entity == null)
		{
			return null;
		}

		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties, DefaultCultureCode);
		parentEntity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		await OnCompletedAsync(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}