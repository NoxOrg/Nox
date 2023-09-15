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
using CashStockOrder = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public record UpdateCashStockOrderCommand(System.Int64 keyId, CashStockOrderUpdateDto EntityDto, System.Guid? Etag) : IRequest<CashStockOrderKeyDto?>;

public class UpdateCashStockOrderCommandHandler: CommandBase<UpdateCashStockOrderCommand, CashStockOrder>, IRequestHandler<UpdateCashStockOrderCommand, CashStockOrderKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityMapper<CashStockOrder> EntityMapper { get; }

	public UpdateCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityMapper<CashStockOrder> entityMapper): base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityMapper = entityMapper;
	}
	
	public async Task<CashStockOrderKeyDto?> Handle(UpdateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CashStockOrder,Nox.Types.AutoNumber>("Id", request.keyId);
	
		var entity = await DbContext.CashStockOrders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		EntityMapper.MapToEntity(entity, GetEntityDefinition<CashStockOrder>(), request.EntityDto);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		if (result < 1)
		{
			return null;
		}

		return new CashStockOrderKeyDto(entity.Id.Value);
	}
}