﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using Cryptocash.Infrastructure.Persistence;
using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.Commands;

public record PartialUpdateExchangeRateCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <ExchangeRateKeyDto?>;

public class PartialUpdateExchangeRateCommandHandler: CommandBase<PartialUpdateExchangeRateCommand, ExchangeRate>, IRequestHandler<PartialUpdateExchangeRateCommand, ExchangeRateKeyDto?>
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
		var keyId = CreateNoxTypeForKey<ExchangeRate,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.ExchangeRates.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<ExchangeRate>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new ExchangeRateKeyDto(entity.Id.Value);
	}
}