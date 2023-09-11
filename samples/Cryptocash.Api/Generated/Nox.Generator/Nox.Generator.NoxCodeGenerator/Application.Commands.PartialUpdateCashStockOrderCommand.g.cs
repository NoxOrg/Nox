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
using CashStockOrder = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public record PartialUpdateCashStockOrderCommand(System.Int64 keyId, Dictionary<string, dynamic> UpdatedProperties, System.Guid? Etag) : IRequest <CashStockOrderKeyDto?>;

public class PartialUpdateCashStockOrderCommandHandler: CommandBase<PartialUpdateCashStockOrderCommand, CashStockOrder>, IRequestHandler<PartialUpdateCashStockOrderCommand, CashStockOrderKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CashStockOrder> EntityMapper { get; }

	public PartialUpdateCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CashStockOrder> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}

	public async Task<CashStockOrderKeyDto?> Handle(PartialUpdateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CashStockOrder,DatabaseNumber>("Id", request.keyId);

		var entity = await DbContext.CashStockOrders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityMapper.PartialMapToEntity(entity, GetEntityDefinition<CashStockOrder>(), request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CashStockOrderKeyDto(entity.Id.Value);
	}
}