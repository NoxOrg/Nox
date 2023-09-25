﻿﻿// Generated

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

internal class PartialUpdateCashStockOrderCommandHandler: PartialUpdateCashStockOrderCommandHandlerBase
{
	public PartialUpdateCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory) : base(dbContext,noxSolution, serviceProvider, entityFactory)
	{
	}
}
internal class PartialUpdateCashStockOrderCommandHandlerBase: CommandBase<PartialUpdateCashStockOrderCommand, CashStockOrder>, IRequestHandler<PartialUpdateCashStockOrderCommand, CashStockOrderKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	public IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> EntityFactory { get; }

	public PartialUpdateCashStockOrderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IServiceProvider serviceProvider,
		IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory) : base(noxSolution, serviceProvider)
	{
		DbContext = dbContext;
		EntityFactory = entityFactory;
	}

	public virtual async Task<CashStockOrderKeyDto?> Handle(PartialUpdateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = CreateNoxTypeForKey<CashStockOrder,Nox.Types.AutoNumber>("Id", request.keyId);

		var entity = await DbContext.CashStockOrders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}
		EntityFactory.PartialUpdateEntity(entity, request.UpdatedProperties);
		entity.Etag = request.Etag.HasValue ? request.Etag.Value : System.Guid.Empty;

		OnCompleted(request, entity);

		DbContext.Entry(entity).State = EntityState.Modified;
		var result = await DbContext.SaveChangesAsync();
		return new CashStockOrderKeyDto(entity.Id.Value);
	}
}