﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using Nox.Application.Commands;
using Nox.Factories;
using Nox.Solution;
using Nox.Types;

using CryptocashApi.Infrastructure.Persistence;
using CryptocashApi.Domain;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Application.Commands;

public record PartialUpdateMinimumCashStockCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties) : IRequest <MinimumCashStockKeyDto?>;

public class PartialUpdateMinimumCashStockCommandHandler: CommandBase<PartialUpdateMinimumCashStockCommand, MinimumCashStock>, IRequestHandler<PartialUpdateMinimumCashStockCommand, MinimumCashStockKeyDto?>
{
	public CryptocashApiDbContext DbContext { get; }
	public IEntityMapper<MinimumCashStock> EntityMapper { get; }

	public PartialUpdateMinimumCashStockCommandHandler(
		CryptocashApiDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<MinimumCashStock> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<MinimumCashStockKeyDto?> Handle(PartialUpdateMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<MinimumCashStock,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.MinimumCashStocks.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<MinimumCashStock>(), request.UpdatedProperties);

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new MinimumCashStockKeyDto(entity.Id.Value);
	}
}