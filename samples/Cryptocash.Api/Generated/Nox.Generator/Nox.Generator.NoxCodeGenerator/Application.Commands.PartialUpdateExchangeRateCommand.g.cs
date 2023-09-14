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
public record PartialUpdateExchangeRateCommand(CurrencyKeyDto ParentKeyDto, ExchangeRateKeyDto EntityKeyDto, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <ExchangeRateKeyDto?>;

public partial class PartialUpdateExchangeRateCommandHandler: CommandBase<PartialUpdateExchangeRateCommand, ExchangeRate>, IRequestHandler <PartialUpdateExchangeRateCommand, ExchangeRateKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<ExchangeRate> EntityMapper { get; }

	public PartialUpdateExchangeRateCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<ExchangeRate> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<ExchangeRateKeyDto?> Handle(PartialUpdateExchangeRateCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<Currency,CurrencyCode3>("Id", request.ParentKeyDto.keyId);

		var parentEntity = await DbContext.Currencies.FindAsync(keyId);
		if (parentEntity == null)
		{
			return null;
		}
		var ownedId = CreateNoxTypeForKey<ExchangeRate,AutoNumber>("Id", request.EntityKeyDto.keyId);
		var entity = parentEntity.ExchangeRates.SingleOrDefault(x => x.Id == ownedId);	
		if (entity == null)
		{
			return null;
		}

		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<ExchangeRate>(), request.UpdatedProperties);
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