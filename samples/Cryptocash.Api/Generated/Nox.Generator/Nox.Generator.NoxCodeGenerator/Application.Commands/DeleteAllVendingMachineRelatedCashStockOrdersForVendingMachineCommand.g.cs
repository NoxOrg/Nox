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
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Commands;

public partial record DeleteAllVendingMachineRelatedCashStockOrdersForVendingMachineCommand(VendingMachineKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllVendingMachineRelatedCashStockOrdersForVendingMachineCommandHandler : DeleteAllVendingMachineRelatedCashStockOrdersForVendingMachineCommandHandlerBase
{
	public DeleteAllVendingMachineRelatedCashStockOrdersForVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllVendingMachineRelatedCashStockOrdersForVendingMachineCommandHandlerBase : CommandBase<DeleteAllVendingMachineRelatedCashStockOrdersForVendingMachineCommand, CashStockOrderEntity>, IRequestHandler <DeleteAllVendingMachineRelatedCashStockOrdersForVendingMachineCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllVendingMachineRelatedCashStockOrdersForVendingMachineCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllVendingMachineRelatedCashStockOrdersForVendingMachineCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.VendingMachineMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.VendingMachines.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.CashStockOrders;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.CashStockOrders.Remove(relatedEntity);
				await OnCompletedAsync(request, relatedEntity);
			}
			
			await trx.CommitAsync();
			
			var result = await DbContext.SaveChangesAsync(cancellationToken);
			if (result < 1)
			{
				return false;
			}

			return true;
		}
		catch
		{
			await trx.RollbackAsync();
			return false;
		}
	}
}