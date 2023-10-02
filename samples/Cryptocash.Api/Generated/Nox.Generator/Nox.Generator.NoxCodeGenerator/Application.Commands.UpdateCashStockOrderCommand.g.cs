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

internal partial class UpdateCashStockOrderCommandHandler: UpdateCashStockOrderCommandHandlerBase
{
	public UpdateCashStockOrderCommandHandler(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory): base(dbContext, noxSolution, entityFactory)
	{
	}
}

internal abstract class UpdateCashStockOrderCommandHandlerBase: CommandBase<UpdateCashStockOrderCommand, CashStockOrder>, IRequestHandler<UpdateCashStockOrderCommand, CashStockOrderKeyDto?>
{
	public CryptocashDbContext DbContext { get; }
	private readonly IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> _entityFactory;

	public UpdateCashStockOrderCommandHandlerBase(
		CryptocashDbContext dbContext,
		NoxSolution noxSolution,
		IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto> entityFactory): base(noxSolution)
	{
		DbContext = dbContext;
		_entityFactory = entityFactory;
	}

	public virtual async Task<CashStockOrderKeyDto?> Handle(UpdateCashStockOrderCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		OnExecuting(request);
		var keyId = Cryptocash.Domain.CashStockOrderMetadata.CreateId(request.keyId);

		var entity = await DbContext.CashStockOrders.FindAsync(keyId);
		if (entity == null)
		{
			return null;
		}

		_entityFactory.UpdateEntity(entity, request.EntityDto);
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