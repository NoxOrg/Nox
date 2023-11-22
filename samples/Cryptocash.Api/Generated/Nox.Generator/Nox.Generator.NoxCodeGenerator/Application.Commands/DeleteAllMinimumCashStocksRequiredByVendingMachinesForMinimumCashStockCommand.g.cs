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
using VendingMachineEntity = Cryptocash.Domain.VendingMachine;

namespace Cryptocash.Application.Commands;

public partial record DeleteAllMinimumCashStocksRequiredByVendingMachinesForMinimumCashStockCommand(MinimumCashStockKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllMinimumCashStocksRequiredByVendingMachinesForMinimumCashStockCommandHandler : DeleteAllMinimumCashStocksRequiredByVendingMachinesForMinimumCashStockCommandHandlerBase
{
	public DeleteAllMinimumCashStocksRequiredByVendingMachinesForMinimumCashStockCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllMinimumCashStocksRequiredByVendingMachinesForMinimumCashStockCommandHandlerBase : CommandBase<DeleteAllMinimumCashStocksRequiredByVendingMachinesForMinimumCashStockCommand, VendingMachineEntity>, IRequestHandler <DeleteAllMinimumCashStocksRequiredByVendingMachinesForMinimumCashStockCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllMinimumCashStocksRequiredByVendingMachinesForMinimumCashStockCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllMinimumCashStocksRequiredByVendingMachinesForMinimumCashStockCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await OnExecutingAsync(request);
		var keyId = Cryptocash.Domain.MinimumCashStockMetadata.CreateId(request.ParentKeyDto.keyId);
		
		using var trx = DbContext.Database.BeginTransaction();
		
		try
		{
			var parentEntity = await DbContext.MinimumCashStocks.FindAsync(keyId);
			if (parentEntity == null)
			{
				return false;
			}
			var related = parentEntity.VendingMachines;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.VendingMachines.Remove(relatedEntity);
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