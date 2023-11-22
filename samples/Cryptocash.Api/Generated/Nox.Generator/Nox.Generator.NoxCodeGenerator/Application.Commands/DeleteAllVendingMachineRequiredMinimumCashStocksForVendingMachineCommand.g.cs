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
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Commands;

public partial record DeleteAllVendingMachineRequiredMinimumCashStocksForVendingMachineCommand(VendingMachineKeyDto ParentKeyDto) : IRequest <bool>;


internal partial class DeleteAllVendingMachineRequiredMinimumCashStocksForVendingMachineCommandHandler : DeleteAllVendingMachineRequiredMinimumCashStocksForVendingMachineCommandHandlerBase
{
	public DeleteAllVendingMachineRequiredMinimumCashStocksForVendingMachineCommandHandler(
        AppDbContext dbContext,
		NoxSolution noxSolution)
		: base(dbContext, noxSolution)
	{
	}
}

internal partial class DeleteAllVendingMachineRequiredMinimumCashStocksForVendingMachineCommandHandlerBase : CommandBase<DeleteAllVendingMachineRequiredMinimumCashStocksForVendingMachineCommand, MinimumCashStockEntity>, IRequestHandler <DeleteAllVendingMachineRequiredMinimumCashStocksForVendingMachineCommand, bool>
{
	public AppDbContext DbContext { get; }

	public DeleteAllVendingMachineRequiredMinimumCashStocksForVendingMachineCommandHandlerBase(
        AppDbContext dbContext,
		NoxSolution noxSolution) : base(noxSolution)
	{
		DbContext = dbContext;
	}

	public virtual async Task<bool> Handle(DeleteAllVendingMachineRequiredMinimumCashStocksForVendingMachineCommand request, CancellationToken cancellationToken)
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
			var related = parentEntity.MinimumCashStocks;
			if (related == null)
			{
				return false;
			}
			
			foreach(var relatedEntity in related)
			{
				DbContext.MinimumCashStocks.Remove(relatedEntity);
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